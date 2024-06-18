using CodingChallenge.Models;

namespace CodingChallenge.Interfaces
{
    public interface IRegistrationUserService
    {
        public Task<List<Registration>> GetAllEventsFromUsers(int userID);
        public Task<Registration> EventRegister(Registration registration);
    }
}
