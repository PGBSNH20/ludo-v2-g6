using RestApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Repositories
{
    public class Repository : IRepository
    {
        protected readonly LudoContext _context;
        public Repository(LudoContext context) { _context = context; }
        public async Task<T> Add<T>(T entity) where T : class
        {
            await _context.Set<T>().AddAsync(entity);
            await Save();
            return entity;
        }
        public async Task Update<T>(T entity) where T : class
        {
            _context.Update(entity);
            await Save();
        }

        public async Task<bool> Save()
        {
            return await _context.SaveChangesAsync() > 0;
        }

    }
}
