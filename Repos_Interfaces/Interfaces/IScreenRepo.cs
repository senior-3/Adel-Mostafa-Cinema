using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cinema_Booking_System.Models;

namespace Cinema_Booking_System.Repos_Interfaces.Interfaces
{
    public interface IScreenRepo : IGenericRepo<Screen>
    {
        Task<IList<Screen>> GetScreens();
        Task<bool> DeleteScreen(int id);
        Task<Screen> GetScreenById(int id);
        Task<bool> CheckScreenNum(int num);
        Task<Screen> GetScreenByScreenNum(int num);
    }
}