using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apprenticeship.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        T GetById(object id);
        void Insert(T obj);
        void Update(T obj);
        void Save();
    }
}
