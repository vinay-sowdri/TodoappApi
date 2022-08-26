using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repository
{
    public class Repo<T> : IRepo<T> where T : class
    {
        private readonly AppDbContext _appDbContext;

     
        public Repo(AppDbContext appdbContext) 
        {
            _appDbContext = appdbContext;
        }

        
        public void Add<T>(T model) where T : class
        {
            _appDbContext.Set<T>().Add(model);
            
        }

        public void Delete<T>(Expression<Func<T, bool>> filter = null) where T : class
        {
            IQueryable<T> query = _appDbContext.Set<T>();
            var datatobeDelete = query.AsNoTracking().FirstOrDefault(filter);
            _appDbContext.Remove(datatobeDelete);

        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = _appDbContext.Set<T>();
            return query.ToList();
        }

    }
}
