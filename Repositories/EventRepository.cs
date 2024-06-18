using CodingChallenge.Context;
using CodingChallenge.Interfaces;
using CodingChallenge.Models;
using Microsoft.EntityFrameworkCore;

namespace CodingChallenge.Repositories
{
    public class EventRepository : IRepository<int, Event>
    {
        private readonly CodingChallengeContext _codingChallengeContext;
        private readonly ILogger<EventRepository> _loggerUserRepository;

        public EventRepository(CodingChallengeContext codingChallengeContext, ILogger<EventRepository> loggerUserRepository)
        {
            _codingChallengeContext = codingChallengeContext;
            _loggerUserRepository = loggerUserRepository;
        }

        public async Task<Event> Add(Event item)
        {
            _codingChallengeContext.Events.Add(item);
            await _codingChallengeContext.SaveChangesAsync();
            _loggerUserRepository.LogInformation($"Added New Event : {item.Title}");
            return item;
        }

        public async Task<Event?> Delete(int key)
        {
            var foundedUser = await Get(key);
            if (foundedUser == null)
            {
                _loggerUserRepository.LogInformation($"Event Not Found");
                return null;
            }
            else
            {
                _codingChallengeContext.Events.Remove(foundedUser);
                await _codingChallengeContext.SaveChangesAsync();
                _loggerUserRepository.LogInformation($"Event Deleted : {foundedUser.Title}");
                return foundedUser;
            }
        }

        public async Task<Event?> Get(int key)
        {
            var foundedUser = await _codingChallengeContext.Events.FirstOrDefaultAsync(user => user.EventID == key);
            if (foundedUser == null)
            {
                _loggerUserRepository.LogInformation($"Event Not Found");
                return null;
            }
            else
            {
                _loggerUserRepository.LogInformation($"Founded Event : {foundedUser.Title}");
                return foundedUser;
            }
        }

        public async Task<List<Event>?> GetAll()
        {
            var allUsers = await _codingChallengeContext.Events.ToListAsync();
            if (allUsers.Count == 0)
            {
                _loggerUserRepository.LogInformation("No Event Returned");
                return null;
            }
            else
            {
                _loggerUserRepository.LogInformation("All Event Returned");
                return allUsers;
            }
        }

        public async Task<Event> Update(Event item)
        {
            _codingChallengeContext.Entry<Event>(item).State = EntityState.Modified;
            await _codingChallengeContext.SaveChangesAsync();
            _loggerUserRepository.LogInformation($"Updated Event : {item.Title}");
            return item;
        }
    }
}
