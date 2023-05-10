namespace BusinessLogicLayer.Anemic.Exceptions;

public class SessionException : Exception
{
    private SessionException(string message) { }

    public static SessionException SessionNotActive(Guid id)
    {
        return new SessionException($"Session not active : {id}");
    }
}