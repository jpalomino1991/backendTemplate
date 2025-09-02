using N5API.Domain.Abstractions.Repository;
using N5API.Domain.Abstractions.Service;
using N5API.Domain.DTO;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace N5API.Infraestructure.Data.Query
{
    public class GetPermissionHandler : IQueryHandler<GetPermissionQuery, PermissionDTO>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetPermissionHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public PermissionDTO Handle(GetPermissionQuery query)
        {
            var _permission = _unitOfWork.PermissionRepository.GetPermission(query.PermissionId);
            return new PermissionDTO()
            {
                Id = _permission.Id,
                ForeName = _permission.ForeName,
                SurName = _permission.SurName,
                PermissionId = _permission.PermissionId,
                Date = _permission.Date
            };
        }
    }
}
