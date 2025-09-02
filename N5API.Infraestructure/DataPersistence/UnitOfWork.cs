using Microsoft.EntityFrameworkCore;
using N5API.Domain.Abstractions.Repository;
using N5API.Infraestructure.Data.Repositories;

namespace N5API.Infraestructure.DataPersistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private PermissionContext _context;

        public UnitOfWork()
        {
        }

        public UnitOfWork(DbContextOptions<PermissionContext> options)
        {
            _context = new PermissionContext(options);
            PermissionRepository = new PermissionRepository(_context);
            PermissionTypeRepository = new PermissionTypeRepository(_context);
        }
        public IPermissionRepository PermissionRepository { get; private set; }
        public IPermissionTypeRepository PermissionTypeRepository { get; private set; }
        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
