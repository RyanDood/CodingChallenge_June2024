namespace CodingChallenge.Exceptions
{
    public class EventAlreadyExistsException : Exception
    {
        public EventAlreadyExistsException(string? message) : base(message)
        {
        }
    }
}
