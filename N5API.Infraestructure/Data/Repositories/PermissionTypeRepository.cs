using Microsoft.EntityFrameworkCore;
using N5API.Domain.Abstractions.Repository;
using N5API.Domain.Entities;
using N5API.Infraestructure.DataPersistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N5API.Infraestructure.Data.Repositories
{
    public class PermissionTypeRepository : BaseRepository<PermissionType>, IPermissionTypeRepository
    {
        public PermissionTypeRepository(PermissionContext context) : base(context)
        {
        }
        public PermissionType GetPermissionType(int Id)
        {
            return _context.Set<PermissionType>().Find(Id);
        }
        public IEnumerable<PermissionType> GetAllPermissionTypes()
        {
            return _context.Set<PermissionType>().ToList();
        }
        public void UpdatePermissionType(PermissionType permissionType)
        {
            if (permissionType != null)
                _context.Set<PermissionType>().Update(permissionType);
        }
        public void AddPermissionType(PermissionType permissionType)
        {
            if (permissionType != null)
                _context.Set<PermissionType>().Add(permissionType);
        }
        public void RemovePermissionType(PermissionType permissionType)
        {
            if (permissionType != null)
                _context.Remove(permissionType);
        }
    }
}
