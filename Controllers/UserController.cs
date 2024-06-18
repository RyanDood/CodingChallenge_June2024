using CodingChallenge.Exceptions;
using CodingChallenge.Interfaces;
using CodingChallenge.Models;
using CodingChallenge.Models.DTOs;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodingChallenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CodingChallengePolicy")]
    public class UserController : ControllerBase
    {
        private readonly IUserUserService _userService;

        public UserController(IUserUserService userService)
        {
            _userService = userService;
        }

        [Route("Login")]
        [HttpPost]
        public async Task<ActionResult<LoginSucessDTO>> Login(LoginUserDTO loginUserDTO)
        {
            try
            {
                return await _userService.LoginUser(loginUserDTO);
            }
            catch (UserNameNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (PasswordMismatchException e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("Register")]
        [HttpPost]
        public async Task<ActionResult<User>> Register(User user)
        {
            try
            {
                return await _userService.AddUser(user);
            }
            catch (UserNameAlreadyExistsException e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
