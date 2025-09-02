using Microsoft.AspNetCore.Mvc;
using N5API.Domain.Abstractions.Repository;
using N5API.Domain.Abstractions.Service;
using N5API.Domain.DTO;
using N5API.Domain.Entities;
using N5API.Infraestructure.Data.Command;
using Nest;
using Newtonsoft.Json;

namespace N5API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PermissionController : ControllerBase
    {
        private readonly ILogger<PermissionController> _logger;
        private readonly IPermissionRepository _permissionRepository;
        private readonly IElasticClient _elasticClient;
        private readonly IProducerService _kafkaProducer;
        private readonly IQueryHandler<GetPermissionQuery, PermissionDTO> _queryPermissionHandler;
        private readonly ICommandHandler<PermissionCreateDTO> _createPermissionCommandHandler;
        private readonly ICommandHandler<PermissionModifyDTO> _modifyPermissionCommandHandler;


        public PermissionController(ILogger<PermissionController> logger, IQueryHandler<GetPermissionQuery, PermissionDTO> queryHandler, 
            ICommandHandler<PermissionCreateDTO> createPermissionCommandHandler, ICommandHandler<PermissionModifyDTO> modifyPermissionCommandHandler,
            IElasticClient elasticClient, IProducerService kafkaProducer)
        {
            _logger = logger;
            _createPermissionCommandHandler = createPermissionCommandHandler;
            _modifyPermissionCommandHandler = modifyPermissionCommandHandler;
            _queryPermissionHandler = queryHandler;
            _elasticClient = elasticClient;
            _kafkaProducer = kafkaProducer;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var query = new GetPermissionQuery { PermissionId = id };

            try
            {
                var permission = _queryPermissionHandler.Handle(query);
                if (permission == null)
                {
                    return NotFound();
                }
                else
                {
                    var kafkaEvent = new KafkaEvent()
                    {
                        Id = Guid.NewGuid(),
                        Operation = "get",
                        Message = JsonConvert.SerializeObject(permission),
                    };

                    _kafkaProducer.ProduceMessage(kafkaEvent);
                    _elasticClient.IndexDocument(permission);
                }

                _logger.LogInformation($"La consulta ha devuelto el siguiente registro {permission} ");
                return Ok(permission);
            }
            catch (Exception ex)
            {
                //_logger.LogWarning("Log de advertencia");
                _logger.LogError($"Se ecnontro el siguiente error {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Request(PermissionDTO permission)
        {

            var kafkaEvent = new KafkaEvent
            {
                Id = Guid.NewGuid(),
                Operation = "modify",
                Message = JsonConvert.SerializeObject(permission),
            };

            try
            {
                _createPermissionCommandHandler.Handle(new PermissionCreateDTO(permission));

                _kafkaProducer.ProduceMessage(kafkaEvent);
                _elasticClient.IndexDocument(permission);

                _logger.LogInformation($"La consulta ha devuelto el siguiente registro {permission} ");
                return CreatedAtAction(nameof(Get), new { id = permission.Id }, permission);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Se ha creado el siguiente error {ex.Message}");
                return BadRequest(ex.Message);
            }



        }

        [HttpPut]
        public IActionResult Modify(PermissionDTO permission)
        {
            var query = new GetPermissionQuery { PermissionId = permission.Id };

            try
            {
                var existingPermission = _queryPermissionHandler.Handle(query);

                if (existingPermission == null)
                {
                    return NotFound();
                }

                _modifyPermissionCommandHandler.Handle(new PermissionModifyDTO(permission));

                _logger.LogInformation($"Se ha modificado el siguiente registro {permission} ");
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Se ecnontro el siguiente error {ex.Message}");
                return BadRequest(ex.Message);
            }
        }
    }
}
