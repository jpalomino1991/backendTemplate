using N5API.Domain.Entities;

namespace N5API.Domain.Abstractions.Repository
{
    public interface IPermissionTypeRepository
    {
        public PermissionType GetPermissionType(int Id);
        public IEnumerable<PermissionType> GetAllPermissionTypes();
        public void UpdatePermissionType(PermissionType permission);
        public void AddPermissionType(PermissionType permission);
        public void RemovePermissionType(PermissionType permission);
    }
}
