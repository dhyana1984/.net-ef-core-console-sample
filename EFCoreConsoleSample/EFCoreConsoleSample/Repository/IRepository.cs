using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreConsoleSample.Repository
{
   public interface IRepository<TEntity>
    {
        Task<IQueryable<TEntity>> GetList();
    }
}
