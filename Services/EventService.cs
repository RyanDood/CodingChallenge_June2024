using CodingChallenge.Exceptions;
using CodingChallenge.Interfaces;
using CodingChallenge.Models;
using CodingChallenge.Repositories;

namespace CodingChallenge.Services
{
    public class EventService : IEventAdminService
    {
        private readonly IRepository<int, Event> _eventsRepository;

        public EventService(IRepository<int, Event> eventsRepository)
        {
            _eventsRepository = eventsRepository;
        }

        public async Task<Event> AddEvent(Event newEvent)
        {
            var allUsers = await _eventsRepository.GetAll();
            var foundedUser = allUsers.FirstOrDefault(user => user.Title == newEvent.Title);
            if (foundedUser != null)
            {
                throw new EventAlreadyExistsException($"Event {newEvent.Title} already exists");
            }
            return await _eventsRepository.Add(newEvent);
        }

        public async Task<Event> DeleteEvent(int id)
        {
            var deletedMember = await _eventsRepository.Delete(id);
            if (deletedMember == null)
            {
                throw new EventNotFoundException($"Event ID {id} not found");
            }
            return await _eventsRepository.Delete(deletedMember.EventID);
        }

        public async Task<List<Event>> GetAllEvents()
        {
            var allMembers = await _eventsRepository.GetAll();
            if (allMembers == null)
            {
                throw new EventNotFoundException("No Available Events Data");
            }
            return allMembers;
        }

        public async Task<Event> GetEvent(int id)
        {
            var foundedMember = await _eventsRepository.Get(id);
            if (foundedMember == null)
            {
                throw new EventNotFoundException($"Event ID {id} not found");
            }
            return foundedMember;
        }

        public async Task<Event> UpdateEvent(Event existingEvent)
        {
            var foundedMember = await GetEvent(existingEvent.EventID);
            foundedMember = existingEvent;
            return await _eventsRepository.Update(foundedMember);
        }
    }
}
