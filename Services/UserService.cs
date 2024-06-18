using CodingChallenge.Interfaces;
using CodingChallenge.Models;
using CodingChallenge.Models.DTOs;
using CodingChallenge.Exceptions;

namespace CodingChallenge.Services
{
    public class UserService : IUserUserService
    {
        private readonly IRepository<int, User> _usersRepository;

        public UserService(IRepository<int, User> usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public async Task<User> AddUser(User user)
        {
            var allUsers = await _usersRepository.GetAll();
            var foundedUser = allUsers?.FirstOrDefault(user => user.UserName == user.UserName);
            if (foundedUser != null)
            {
                throw new UserNameAlreadyExistsException($"UserName {user.UserName} already exists");
            }
            return await _usersRepository.Add(user);
        }

        public async Task<LoginSucessDTO> LoginUser(LoginUserDTO loginUserDTO)
        {
            var allUsers = await _usersRepository.GetAll();
            var foundedUser = allUsers.FirstOrDefault(user => user.UserName == loginUserDTO.UserName);
            if (foundedUser == null)
            {
                throw new UserNameNotFoundException($"UserName {loginUserDTO.UserName} not found");
            }
            if (foundedUser.Password != loginUserDTO.Password)
            {
                throw new PasswordMismatchException("Incorrect Password Entered");
            }
            LoginSucessDTO login = new LoginSucessDTO();
            login.UserID = foundedUser.UserID;
            login.UserName = loginUserDTO.UserName;
            login.isAdmin = foundedUser.isAdmin;
            return login;
        }
    }
}
