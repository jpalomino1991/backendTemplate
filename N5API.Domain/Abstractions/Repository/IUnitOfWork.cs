using N5API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N5API.Domain.Abstractions.Repository
{
    public  interface IUnitOfWork : IDisposable
    {
        IPermissionRepository PermissionRepository { get; }
        IPermissionTypeRepository PermissionTypeRepository { get; }
        int Complete();
        void Dispose();
    }
}
