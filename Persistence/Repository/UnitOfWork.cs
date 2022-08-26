using Application.Interfaces;
using Domain.Entities;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repository
{
    public class UnitOfWork : IUnitofWork
    {
        private readonly AppDbContext _appDbContext;
        public UnitOfWork(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        private IRepo<TodoTask> _TodoRepo;

        public IRepo<TodoTask> TodoRepo
        {
            get
            {
                if (_TodoRepo == null)
                    _TodoRepo = new Repo<TodoTask>(_appDbContext);
                return _TodoRepo;
            }
        }

        public int Save()
        {
            return _appDbContext.SaveChanges();
        }
    }
}
