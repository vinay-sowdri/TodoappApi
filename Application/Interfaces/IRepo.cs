using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IRepo<T> where T : class
    {
        void Delete<T>(Expression<Func<T,bool>> filter = null) where T : class;

        IEnumerable<T> GetAll();

        void Add<T>(T model) where T : class;

    }
}
