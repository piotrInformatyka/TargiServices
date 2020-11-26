using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Targi.Core.Repositories;
using Targi.Infrastructure.Data;

namespace Targi.Infrastructure.Repositories
{
    public class GenericRepository : IGenericRepository
    {
        private readonly DataContext _contex;
        public GenericRepository(DataContext contex)
        {
            _contex = contex;
        }
        public void Add<T>(T entity) where T : class
        {
            _contex.Add(entity);
        }
        public void Delete<T>(T entity) where T : class
        {
            _contex.Remove(entity);
        }
        public async Task<bool> SaveAll()
        {
            return await _contex.SaveChangesAsync() > 0;
        }
    }
}
