using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cinema_Booking_System.Data;
using Cinema_Booking_System.Models;
using Cinema_Booking_System.Repos_Interfaces.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Cinema_Booking_System.Repos_Interfaces.Repos
{
    public class ScreenRepo : GenericRepo<Screen>, IScreenRepo
    {
        public ScreenRepo(AppDb _db) : base(_db)
        {
            
        }

        public async Task<bool> CheckScreenNum(int num)
        {
            var scr = await _db.screen.FirstOrDefaultAsync(x => x.ScreenNumber == num);

            if (scr == null) return true;

            return false;
        }

        public async Task<bool> DeleteScreen(int id)
        {
            var scr = await _db.screen.Include(x => x.bookings).FirstOrDefaultAsync(x => x.Id == id);

            if (scr == null || scr.bookings.Any()) return false;

            await Delete(scr);

            return true;
        }

        public async Task<Screen> GetScreenById(int id)
        {
            var res = await _db.screen.Include(x => x.movie).FirstOrDefaultAsync(x => x.Id == id);

            return res;
        }

        public async Task<Screen> GetScreenByScreenNum(int num)
        {
            var res = await _db.screen.FirstOrDefaultAsync(x => x.ScreenNumber == num);

            return res;
        }

        public async Task<IList<Screen>> GetScreens()
        {
            var res = await _db.screen.Include(x => x.movie).Include(x => x.bookings).ToListAsync();

            return res;
        }

        
    }
}