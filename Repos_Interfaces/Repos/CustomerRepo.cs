using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cinema_Booking_System.Data;
using Cinema_Booking_System.Models;
using Cinema_Booking_System.Repos_Interfaces.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Cinema_Booking_System.Repos_Interfaces.Repos
{
    public class CustomerRepo : GenericRepo<Customer> , ICustomerRepo
    {
        private readonly ICustomerProfileRepo _cpr;
        public CustomerRepo(AppDb _db , ICustomerProfileRepo cpr) : base(_db)
        {
            _cpr = cpr;
        }

        public async Task CreateCus(Customer cus, CustomerProfile pro)
        {
            var isValid = await ValidateEA(cus);
            var x = await Create(cus);
            pro.CustomerId = x.Id;
            pro.customer = x;
            await _cpr.Create(pro);
        }

        public async Task<bool> DeleteCus(int id)
        {
            var cus = await _db.customer.Include(x => x.bookings).FirstOrDefaultAsync(x => x.Id == id);

            if (cus == null || cus.bookings.Any()) return false;

            await Delete(cus);

            return true;
        }

        public async Task<IList<Customer>> GetAllCustomers()
        {
            var cus = await _db.customer.Include(x => x.customerProfile).
            Include(x => x.bookings).
            ThenInclude(x => x.screen).
            ThenInclude(x => x.movie)
            .OrderBy(x => x.bookings.Max(x => x.BookingDate))
            .ToListAsync();
            return cus;
        }

        public async Task<Customer> GetCusById(int id)
        {
            return await _db.customer.Include(x => x.customerProfile).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateCus(Customer Cus, CustomerProfile pro)
        {
            await Update(Cus);
            var cusPro = await _db.customerProfile.FirstOrDefaultAsync(x => x.CustomerId == Cus.Id);

            if (cusPro != null)
            {
                cusPro.Address = pro.Address;
                cusPro.DateOfBirth = pro.DateOfBirth;
                await _db.SaveChangesAsync();
            }
        }

        public async Task<bool> ValidateEA(Customer cus)
        {

            var res = NotNullVAlidation(cus);

            var x = await _db.customer.FirstOrDefaultAsync(x => x.Email == cus.Email);

            if (x != null || !res) return false;

            return true;
        }
        
        public bool NotNullVAlidation(Customer cus)
        {
            foreach (var i in cus.GetType().GetProperties())
            {
                var value = i.GetValue(cus);
                if (value == null)
                    return false;
            }
            return true;
        }

        public async Task<Customer> GetCustomerByEmail(string email)
        {
            return await _db.customer.FirstOrDefaultAsync(x => x.Email == email);
        }
    }
}