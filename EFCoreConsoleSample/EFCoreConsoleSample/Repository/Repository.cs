using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreConsoleSample.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private EfCoreDbContext _context;
      
        public Repository(IServiceProvider serviceProvider)
        {
            _context = (EfCoreDbContext)serviceProvider.GetService(typeof(EfCoreDbContext));
        }
        public async Task<IQueryable<TEntity>> GetList()
        {
            var Entities = _context.Set<TEntity>();
            return await Task.FromResult(Entities);
        }
    }
}
