using N5API.Domain.Abstractions.Repository;
using N5API.Domain.Abstractions.Service;
using N5API.Domain.DTO;
using N5API.Domain.Entities;

namespace N5API.Infraestructure.Data.Command
{
    public class CreatePermissionTypeHandler : ICommandHandler<PermissionTypeDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreatePermissionTypeHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void Handle(PermissionTypeDTO command)
        {
            var _permissiontype = new PermissionType()
            {
                Id = command.Id,
                Description = command.Description
                
            };
            _unitOfWork.PermissionTypeRepository.AddPermissionType(_permissiontype);
        }
    }
}
