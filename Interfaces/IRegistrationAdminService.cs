using CodingChallenge.Models;

namespace CodingChallenge.Interfaces
{
    public interface IRegistrationAdminService : IRegistrationUserService
    {
        public Task<List<Registration>> GetAllUsersFromEvent(int eventID);
    }
}
