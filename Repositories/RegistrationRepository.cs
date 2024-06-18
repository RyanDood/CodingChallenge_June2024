using CodingChallenge.Context;
using CodingChallenge.Interfaces;
using CodingChallenge.Models;
using Microsoft.EntityFrameworkCore;

namespace CodingChallenge.Repositories
{
    public class RegistrationRepository : IRepository<int, Registration>
    {
        private readonly CodingChallengeContext _codingChallengeContext;
        private readonly ILogger<RegistrationRepository> _loggerUserRepository;

        public RegistrationRepository(CodingChallengeContext codingChallengeContext, ILogger<RegistrationRepository> loggerUserRepository)
        {
            _codingChallengeContext = codingChallengeContext;
            _loggerUserRepository = loggerUserRepository;
        }

        public async Task<Registration> Add(Registration item)
        {
            _codingChallengeContext.Registrations.Add(item);
            await _codingChallengeContext.SaveChangesAsync();
            _loggerUserRepository.LogInformation($"Added New Registration : {item.RegistrationID}");
            return item;
        }

        public async Task<Registration?> Delete(int key)
        {
            var foundedUser = await Get(key);
            if (foundedUser == null)
            {
                _loggerUserRepository.LogInformation($"Registration Not Found");
                return null;
            }
            else
            {
                _codingChallengeContext.Registrations.Remove(foundedUser);
                await _codingChallengeContext.SaveChangesAsync();
                _loggerUserRepository.LogInformation($"Registration Deleted : {foundedUser.RegistrationID}");
                return foundedUser;
            }
        }

        public async Task<Registration?> Get(int key)
        {
            var foundedUser = await _codingChallengeContext.Registrations.FirstOrDefaultAsync(user => user.RegistrationID == key);
            if (foundedUser == null)
            {
                _loggerUserRepository.LogInformation($"Registration Not Found");
                return null;
            }
            else
            {
                _loggerUserRepository.LogInformation($"Founded Registration : {foundedUser.RegistrationID}");
                return foundedUser;
            }
        }

        public async Task<List<Registration>?> GetAll()
        {
            var allUsers = await _codingChallengeContext.Registrations.ToListAsync();
            if (allUsers.Count == 0)
            {
                _loggerUserRepository.LogInformation("No Registration Returned");
                return null;
            }
            else
            {
                _loggerUserRepository.LogInformation("All Registration Returned");
                return allUsers;
            }
        }

        public async Task<Registration> Update(Registration item)
        {
            _codingChallengeContext.Entry<Registration>(item).State = EntityState.Modified;
            await _codingChallengeContext.SaveChangesAsync();
            _loggerUserRepository.LogInformation($"Updated Registration : {item.RegistrationID}");
            return item;
        }
    }
}
