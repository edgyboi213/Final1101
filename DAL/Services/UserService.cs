using DAL.Data;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Services
{
    public class UserService
    {
        private readonly ShopContext _context = new();

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task GetUserByIdAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                Console.WriteLine($"{user.UserId} {user.Name} {user.Surname} {user.Role}");
            }
            else
            {
                Console.WriteLine("Пользователь не найден!");
            }
        }

        public async Task AddUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUserAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUser(User user)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }
    }
}
