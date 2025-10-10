using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cinema_Booking_System.Models;

namespace Cinema_Booking_System.Repos_Interfaces.Interfaces
{
    public interface ICustomerProfileRepo : IGenericRepo<CustomerProfile>
    {
        Task UpdatePro(CustomerProfile pro);    
    }
}