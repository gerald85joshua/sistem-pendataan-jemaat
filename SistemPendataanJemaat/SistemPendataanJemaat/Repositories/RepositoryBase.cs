using Microsoft.EntityFrameworkCore;
using SistemPendataanJemaat.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SistemPendataanJemaat.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected RepositoryContext RepositoryContext { get; set; }
        public RepositoryBase(RepositoryContext repositoryContext)
        {
            RepositoryContext = repositoryContext;
        }

        public async Task<IEnumerable<T>> FindAll() => await RepositoryContext.Set<T>().ToListAsync();

        public async Task<IEnumerable<T>> FindByCondition(Expression<Func<T, bool>> expression) => await RepositoryContext.Set<T>().Where(expression).ToListAsync();

        public async Task Create(T entity) {
            await RepositoryContext.Set<T>().AddAsync(entity);
            await RepositoryContext.SaveChangesAsync();
        }

        public async Task Update(T entity) { 
            RepositoryContext.Set<T>().Update(entity);
            await RepositoryContext.SaveChangesAsync();

        }

        public async Task Delete(T entity) { 
            RepositoryContext.Set<T>().Remove(entity);
            await RepositoryContext.SaveChangesAsync();
        }
    }
}
