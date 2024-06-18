using CodingChallenge.Exceptions;
using CodingChallenge.Interfaces;
using CodingChallenge.Models;
using CodingChallenge.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodingChallenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CodingChallengePolicy")]
    public class RegistrationController : ControllerBase
    {
        private readonly IRegistrationAdminService _registrationService;

        public RegistrationController(IRegistrationAdminService registrationService)
        {
            _registrationService = registrationService;
        }

        [Route("GetAllEventsFromUsers")]
        [HttpGet]
        public async Task<ActionResult<List<Registration>>> GetAllEventsFromUsers(int userID)
        {
            try
            {
                return await _registrationService.GetAllEventsFromUsers(userID);
            }
            catch (UserNameNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        [Route("GetAllUsersFromEvent")]
        [HttpGet]
        public async Task<ActionResult<List<Registration>>> GetAllUsersFromEvent(int eventID)
        {
            try
            {
                return await _registrationService.GetAllUsersFromEvent(eventID);
            }
            catch (EventNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        [Route("EventRegister")]
        [HttpPost]
        public async Task<ActionResult<Registration>> EventRegister(Registration registration)
        {
            try
            {
                return await _registrationService.EventRegister(registration);
            }
            catch (UserAlreadyRegiseredException e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
