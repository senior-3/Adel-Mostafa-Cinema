using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cinema_Booking_System.Data;
using Cinema_Booking_System.Repos_Interfaces.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Cinema_Booking_System.Repos_Interfaces.Repos
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        protected readonly AppDb _db;
        public GenericRepo(AppDb db)
        {
            _db = db;
        }
        public async Task<T> Create(T entity)
        {
            await _db.Set<T>().AddAsync(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task Delete(T entity)
        {
            _db.Set<T>().Remove(entity);
            await _db.SaveChangesAsync();
        }

        public async Task<IList<T>> GetAll()
        {
            return await _db.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _db.Set<T>().FindAsync(id);
        }

        public async Task Update(T entity)
        {
            _db.Set<T>().Update(entity);
            await _db.SaveChangesAsync();
        }
    }
}