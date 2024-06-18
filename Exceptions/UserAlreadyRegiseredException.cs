namespace CodingChallenge.Exceptions
{
    public class UserAlreadyRegiseredException : Exception
    {
        public UserAlreadyRegiseredException(string? message) : base(message)
        {
        }
    }
}
