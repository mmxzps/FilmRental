using FilmRental.Data.Repos.IRepos;
using FilmRental.Models;
using FilmRental.Models.DTOs;
using FilmRental.Services.IServices;
using Microsoft.AspNetCore.Http.HttpResults;

namespace FilmRental.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<UserDTO>> GetAllUsersAsync()
        {
            var usersList = await _userRepository.GetAllUsersAsync();
            //den mappar om datan som är User till vår UserDTO
            return usersList.Select(x => new UserDTO
            {
                UserId = x.Id,
                Name = x.Name,
                Email = x.Email,
            }).ToList();
        }

        public async Task<UserDTO> GetUserByIdAsync(int userId)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);
            if (user == null)
            {
                return null;
            }
            return new UserDTO
            {
                UserId = userId,
                Name = user.Name,
                Email = user.Email,
            };
        }
        public async Task<int> AddUserAsync(UserDTO user)
        {
            var allUsers = await _userRepository.GetAllUsersAsync();
            var existingUser = allUsers.SingleOrDefault(x=>x.Email == user.Email);
            
            if (existingUser != null)
            {
                return existingUser.Id;
            }
            else
            {
                var newUser = new User
                {
                    Name = user.Name,
                    Email = user.Email,
                };

                return await _userRepository.AddUserAsync(newUser);
            }
        }

        public async Task UpdateUserAsync(UserDTO user)
        {
            var existingUser = await _userRepository.GetUserByIdAsync(user.UserId);
            existingUser.Name = user.Name;
            existingUser.Email = user.Email;

            await _userRepository.UpdateUserAsync(existingUser);
        }
        public async Task DeleteUserAsync(int userId)
        {
            await _userRepository.DeleteUserAsync(userId);
        }
    }
}
