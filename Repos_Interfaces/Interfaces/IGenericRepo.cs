using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema_Booking_System.Repos_Interfaces.Interfaces
{
    public interface IGenericRepo<T> where T : class
    {
        Task<IList<T>> GetAll();
        Task<T> GetById(int id);
        Task Delete(T entity);
        Task Update(T entity);
        Task<T> Create(T entity);        
    }
}