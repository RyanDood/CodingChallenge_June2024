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
    public class EventController : ControllerBase
    {
        private readonly IEventAdminService _eventService;

        public EventController(IEventAdminService eventService)
        {
            _eventService = eventService;
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

        [Route("GetEvent")]
        [HttpGet]
        public async Task<ActionResult<Event>> GetEvent(int eventID)
        {
            try
            {
                return await _eventService.GetEvent(eventID);
            }
            catch (EventNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }


        [Route("AddEvent")]
        [HttpPost]
        public async Task<ActionResult<Event>> AddEvent(Event newEvent)
        {
            try
            {
                return await _eventService.AddEvent(newEvent);
            }
            catch (EventAlreadyExistsException e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("UpdateEvent")]
        [HttpPut]
        public async Task<ActionResult<Event>> UpdateEvent(Event updateEvent)
        {
            try
            {
                return await _eventService.UpdateEvent(updateEvent);
            }
            catch (EventNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        [Route("DeleteEvent")]
        [HttpDelete]
        public async Task<ActionResult<Event>> DeleteEvent(int eventID)
        {
            try
            {
                return await _eventService.DeleteEvent(eventID);
            }
            catch (EventNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
