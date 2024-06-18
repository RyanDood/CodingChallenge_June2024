using CodingChallenge.Models;
using CodingChallenge.Models.DTOs;

namespace CodingChallenge.Interfaces
{
    public interface IUserUserService
    {
        public Task<LoginSucessDTO> LoginUser(LoginUserDTO loginUserDTO);
        public Task<User> AddUser(User enteredUser);
    }
}
