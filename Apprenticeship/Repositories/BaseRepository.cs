using Apprenticeship.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apprenticeship.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private ApplicationDbContext _context = null;
        private DbSet<T> table = null;
        //public BaseRepository()
        //{
        //    this._context = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>());
        //    table = _context.Set<T>();
        //}
        public BaseRepository(ApplicationDbContext context)
        {
            this._context = context;
            table = _context.Set<T>();
        }
        public T GetById(object id)
        {
            return table.Find(id);
        }
        public void Insert(T obj)
        {
            table.Add(obj);
            Save();
        }
        public void Update(T obj)
        {
            table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
            Save();
        }
        public void Save()
        {
            _context.SaveChanges();
        }
        
    }
}
