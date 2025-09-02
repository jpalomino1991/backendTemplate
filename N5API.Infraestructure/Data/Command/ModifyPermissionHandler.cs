using N5API.Domain.Abstractions.Repository;
using N5API.Domain.Abstractions.Service;
using N5API.Domain.DTO;
using N5API.Domain.Entities;

namespace N5API.Infraestructure.Data.Command
{
    public class ModifyPermissionHandler : ICommandHandler<PermissionModifyDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        public ModifyPermissionHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void Handle(PermissionModifyDTO command)
        {
            var _permission = new Permission()
            {
                Id = command.Id,
                ForeName = command.ForeName,
                SurName = command.SurName,
                PermissionId = command.PermissionId,
                Date = command.Date
            };
            _unitOfWork.PermissionRepository.UpdatePermission(_permission);
        }
    }
}
