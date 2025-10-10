using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cinema_Booking_System.Data;
using Cinema_Booking_System.Models;
using Cinema_Booking_System.Repos_Interfaces.Interfaces;

namespace Cinema_Booking_System.Repos_Interfaces.Repos
{
    public class CustomerProfileRepo : GenericRepo<CustomerProfile>, ICustomerProfileRepo
    {
        public CustomerProfileRepo(AppDb _db) : base(_db)
        {
            
        }
        public async Task UpdatePro(CustomerProfile pro)
        {
            _db.customerProfile.Update(pro);
            await _db.SaveChangesAsync();
        }
    }
}