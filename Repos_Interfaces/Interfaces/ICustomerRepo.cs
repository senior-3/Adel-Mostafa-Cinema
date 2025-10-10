using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cinema_Booking_System.Models;

namespace Cinema_Booking_System.Repos_Interfaces.Interfaces
{
    public interface ICustomerRepo : IGenericRepo<Customer>
    {
        Task<IList<Customer>> GetAllCustomers();
        Task<Customer> GetCusById(int id);
        Task UpdateCus(Customer Cus, CustomerProfile profile);
        Task<bool> DeleteCus(int id);
        Task CreateCus(Customer cus, CustomerProfile pro);
        Task<bool> ValidateEA(Customer cus);
        bool NotNullVAlidation(Customer cus);
        Task<Customer> GetCustomerByEmail(string email);
    }
}