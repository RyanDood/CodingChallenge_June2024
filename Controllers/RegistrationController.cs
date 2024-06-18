using CodingChallenge.Exceptions;
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
        [Route("GetAllEvents")]
        [HttpGet]
        public async Task<ActionResult<List<Event>>> GetAllEvents()
        {
            try
            {
                return await _eventService.GetAllEvents();
            }
            catch (EventNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        [Route("GetAllEvents")]
        [HttpGet]
        public async Task<ActionResult<List<Event>>> GetAllEvents()
        {
            try
            {
                return await _eventService.GetAllEvents();
            }
            catch (EventNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
