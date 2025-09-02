using N5API.Domain.Entities;

namespace N5API.Domain.Abstractions.Repository
{
    public interface IPermissionRepository
    {
        public Permission GetPermission(int Id);
        public IEnumerable<Permission> GetAllPermissions();
        public void UpdatePermission(Permission permission);
        public void AddPermission(Permission permission);
        public void RemovePermission(Permission permission);
    }
}
