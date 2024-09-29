using FilmRental.Data.Repos.IRepos;
using FilmRental.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmRental.Data.Repos
{
    public class UserRepository : IUserRepository
    {
        private readonly FilmRentalContext _context;
        public UserRepository(FilmRentalContext context)
        {
            _context = context;
        }


        public async Task<int> AddUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user.Id;
        }

        public async Task DeleteUserAsync(int userId)
        {
            var deleteUser = await _context.Users.FindAsync(userId);
            if(deleteUser != null)
            {
                _context.Users.Remove(deleteUser);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            var userList = await _context.Users.ToListAsync();
            return userList;
        }

        public async Task<User> GetUserByIdAsync(int userId)
        {
            var getUser = await _context.Users.FindAsync(userId);
            return getUser;
        }

        public async Task UpdateUserAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }
    }
}
