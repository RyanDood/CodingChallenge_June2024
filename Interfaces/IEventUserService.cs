using CodingChallenge.Models;

namespace CodingChallenge.Interfaces
{
    public interface IEventUserService
    {
        public Task<List<Event>> GetAllEvents();
    }
}
