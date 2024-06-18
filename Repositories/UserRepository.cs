using CodingChallenge.Context;
using CodingChallenge.Interfaces;
using CodingChallenge.Models;
using Microsoft.EntityFrameworkCore;

namespace CodingChallenge.Repositories
{
    public class UserRepository : IRepository<int, User>
    {
        private readonly CodingChallengeContext _codingChallengeContext;
        private readonly ILogger<UserRepository> _loggerUserRepository;

        public UserRepository(CodingChallengeContext codingChallengeContext, ILogger<UserRepository> loggerUserRepository)
        {
            _codingChallengeContext = codingChallengeContext;
            _loggerUserRepository = loggerUserRepository;
        }

        public async Task<User> Add(User item)
        {
            _codingChallengeContext.Users.Add(item);
            await _codingChallengeContext.SaveChangesAsync();
            _loggerUserRepository.LogInformation($"Added New User : {item.Name}");
            return item;
        }

        public async Task<User?> Delete(int key)
        {
            var foundedUser = await Get(key);
            if (foundedUser == null)
            {
                _loggerUserRepository.LogInformation($"User Not Found");
                return null;
            }
            else
            {
                _codingChallengeContext.Users.Remove(foundedUser);
                await _codingChallengeContext.SaveChangesAsync();
                _loggerUserRepository.LogInformation($"User Deleted : {foundedUser.Name}");
                return foundedUser;
            }
        }

        public async Task<User?> Get(int key)
        {
            var foundedUser = await _codingChallengeContext.Users.FirstOrDefaultAsync(user => user.UserID == key);
            if (foundedUser == null)
            {
                _loggerUserRepository.LogInformation($"User Not Found");
                return null;
            }
            else
            {
                _loggerUserRepository.LogInformation($"Founded User : {foundedUser.Name}");
                return foundedUser;
            }
        }

        public async Task<List<User>?> GetAll()
        {
            var allUsers = await _codingChallengeContext.Users.ToListAsync();
            if (allUsers.Count == 0)
            {
                _loggerUserRepository.LogInformation("No Users Returned");
                return null;
            }
            else
            {
                _loggerUserRepository.LogInformation("All Users Returned");
                return allUsers;
            }
        }

        public async Task<User> Update(User item)
        {
            _codingChallengeContext.Entry<User>(item).State = EntityState.Modified;
            await _codingChallengeContext.SaveChangesAsync();
            _loggerUserRepository.LogInformation($"Updated User : {item.Name}");
            return item;
        }
    }
}
