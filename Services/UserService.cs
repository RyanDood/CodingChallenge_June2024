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

        public async Task<User> AddUser(User enteredUser)
        {
            var allUsers = await _usersRepository.GetAll();
            var foundedUser = allUsers?.FirstOrDefault(user => user.UserName == enteredUser.UserName);
            if (foundedUser != null)
            {
                throw new UserNameAlreadyExistsException($"UserName {enteredUser.UserName} already exists");
            }
            return await _usersRepository.Add(enteredUser);
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
