namespace CodingChallenge.Exceptions
{
    public class UserNameAlreadyExistsException : Exception
    {
        public UserNameAlreadyExistsException(string? message) : base(message)
        {
        }
    }
}
