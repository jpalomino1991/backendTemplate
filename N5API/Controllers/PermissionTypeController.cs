using Microsoft.AspNetCore.Mvc;
using N5API.Domain.Abstractions.Repository;
using N5API.Domain.Entities;

namespace N5API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PermissionTypeController : Controller
    {
        private readonly ILogger<PermissionTypeController> _logger;
        private readonly IPermissionTypeRepository _permissionTypeRepository;
        private readonly IPermissionRepository _permissionRepository;

        public PermissionTypeController(ILogger<PermissionTypeController> logger,
            IPermissionTypeRepository permissionTypeRepository, IPermissionRepository permissionRepository)
        {
            _logger = logger;
            _permissionTypeRepository = permissionTypeRepository;
            _permissionRepository = permissionRepository;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var permissionType = _permissionTypeRepository.GetPermissionType(id);

            if (permissionType == null)
            {
                return NotFound();
            }

            return Ok(permissionType);
        }

        [HttpPost]
        public IActionResult Create(PermissionType permissionType)
        {
            _permissionTypeRepository.AddPermissionType(permissionType);

            return CreatedAtAction(nameof(GetById), new { id = permissionType.Id }, permissionType);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, PermissionType permissionType)
        {
            var existingPermissionType = _permissionTypeRepository.GetPermissionType(id);

            if (existingPermissionType == null)
            {
                return NotFound();
            }
            // existingPermissionType.Name = permissionType.Name;
            // // Update any other properties as needed
            _permissionTypeRepository.UpdatePermissionType(existingPermissionType);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var permissionType = _permissionTypeRepository.GetPermissionType(id);

            if (permissionType == null)
            {
                return NotFound();
            }

            _permissionTypeRepository.RemovePermissionType(permissionType);

            return NoContent();
        }

    }
}
