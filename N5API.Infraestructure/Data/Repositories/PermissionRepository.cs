using N5API.Domain.Abstractions.Repository;
using N5API.Domain.Entities;
using N5API.Infraestructure.DataPersistence;

namespace N5API.Infraestructure.Data.Repositories
{
    public class PermissionRepository : BaseRepository<Permission> , IPermissionRepository
    {
        public PermissionRepository(PermissionContext context) : base(context)
        {
        }
        public Permission GetPermission(int Id)
        {
            return _context.Set<Permission>().Find(Id);
        }
        public IEnumerable<Permission> GetAllPermissions()
        {
            return _context.Set<Permission>().ToList();
        }
        public void UpdatePermission(Permission permission)
        {
            if (permission != null)
                _context.Set<Permission>().Update(permission);
        }
        public void AddPermission(Permission permission)
        {
            if (permission != null)
                _context.Set<Permission>().Add(permission);
        }
        public void RemovePermission(Permission permission)
        {
            if (permission != null)
                _context.Remove(permission);
        }
    }
}
