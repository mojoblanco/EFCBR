using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreBaseRepo.IRepository
{
    public interface IUnitofWork
    {
        void Commit();
        Task CommitAsync();
    }
}
