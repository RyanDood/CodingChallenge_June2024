namespace CodingChallenge.Exceptions
{
    public class UserNameNotFoundException : Exception
    {
        public UserNameNotFoundException(string? message) : base(message)
        {
        }
    }
}
