using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;
using Domain.SharedKernel;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataAccess
{
    public class EfRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly TimetrackerContext _timetrackerContext;

        public EfRepository(TimetrackerContext timetrackerContext)
        {
            _timetrackerContext = timetrackerContext;
        }

        public virtual List<T> List()
        {
            return _timetrackerContext.Set<T>().ToList();
        }

        public virtual async Task<List<T>> ListAsync()
        {
            return await _timetrackerContext.Set<T>().ToListAsync();
        }

        public T Add(T entity)
        {
            _timetrackerContext.Set<T>().Add(entity);
            _timetrackerContext.SaveChanges();
            return entity;
        }

        public async Task<T> AddAsync(T entity)
        {
            _timetrackerContext.Set<T>().Add(entity);
            await _timetrackerContext.SaveChangesAsync();
            return entity;
        }

        public virtual void Delete(T entity)
        {
            _timetrackerContext.Set<T>().Remove(entity);
            _timetrackerContext.SaveChanges();
        }

        public async void DeleteAsync(T entity)
        {
            _timetrackerContext.Set<T>().Remove(entity);
            await _timetrackerContext.SaveChangesAsync();
        }

        public T Update(T entity)
        {
            _timetrackerContext.Entry(entity).State = EntityState.Modified;
            _timetrackerContext.SaveChanges();
            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _timetrackerContext.Entry(entity).State = EntityState.Modified;
            await _timetrackerContext.SaveChangesAsync();
            return entity;
        }
    }
}
