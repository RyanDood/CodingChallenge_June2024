using CodingChallenge.Exceptions;
using CodingChallenge.Interfaces;
using CodingChallenge.Models;
using CodingChallenge.Models.DTOs;
using Microsoft.Extensions.Logging;

namespace CodingChallenge.Services
{
    public class RegistrationService : IRegistrationAdminService
    {
        private readonly IRepository<int, Registration> _registrationsRepository;
        private readonly IRepository<int, Event> _eventRepository;

        public RegistrationService(IRepository<int, Registration> registrationsRepository, IRepository<int, Event> eventRepository)
        {
            _registrationsRepository = registrationsRepository;
            _eventRepository = eventRepository;
        }

        public async Task<Registration> EventRegister(Registration registration)
        {
            var allEvents = await _registrationsRepository.GetAll();
            var userEvents = allEvents?.Where(existingEvent => existingEvent.UserID == registration.UserID && existingEvent.EventID == registration.EventID).ToList();
            if (userEvents.Count != 0)
            {
                throw new UserAlreadyRegiseredException($"You have already Registerd for this Event");
            }
            var allEvents1 = await _registrationsRepository.GetAll();
            var userEvents1 = allEvents1?.Where(existingEvent => existingEvent.EventID == registration.EventID).ToList();
            var found = await _eventRepository.Get(registration.EventID);
            if (userEvents1.Count >= found.MaxAttendees)
            {
                throw new MaxExceedsException($"Event is fully booked");
            }
            return await _registrationsRepository.Add(registration);
        }

        public async Task<List<Registration>> GetAllEventsFromUsers(int userID)
        {
            var allEvents = await _registrationsRepository.GetAll();
            var userEvents = allEvents?.Where(existingEvent => existingEvent.UserID == userID).ToList();
            if(userEvents.Count == 0)
            {
                throw new UserNameNotFoundException($"UserID {userID} not found");
            }
            return userEvents;
        }

        public async Task<List<Registration>> GetAllUsersFromEvent(int eventID)
        {
            var allEvents = await _registrationsRepository.GetAll();
            var userEvents = allEvents?.Where(existingEvent => existingEvent.EventID == eventID).ToList();
            if (userEvents.Count == 0)
            {
                throw new EventNotFoundException($"EventID {eventID} not found");
            }
            return userEvents;
        }
    }
}
