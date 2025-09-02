using N5API.Domain.Abstractions.Repository;
using N5API.Domain.Abstractions.Service;
using N5API.Domain.DTO;

namespace N5API.Infraestructure.Data.Query
{
    public class GetPermissionTypeHandler : IQueryHandler<GetPermissionTypeQuery, PermissionTypeDTO>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetPermissionTypeHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public PermissionTypeDTO Handle(GetPermissionTypeQuery query)
        {
            var _permissionType = _unitOfWork.PermissionTypeRepository.GetPermissionType(query.PermissionTypeId);
            return new PermissionTypeDTO()
            {
                Id = _permissionType.Id,
                Description = _permissionType.Description
            };
        }
    }
}
