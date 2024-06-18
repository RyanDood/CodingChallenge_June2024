using CodingChallenge.Models;

namespace CodingChallenge.Interfaces
{
    public interface IEventAdminService : IEventUserService
    {
        public Task<Event> AddEvent(Event newEvent);
        public Task<Event> DeleteEvent(int id);
        public Task<Event> GetEvent(int id);
        public Task<Event> UpdateEvent(Event existingEvent);
    }
}
