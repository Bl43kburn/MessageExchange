namespace BusinessLogicLayer.Anemic.Exceptions;

public class CreationException : Exception
{
    private CreationException(string message) { }
    
    public static CreationException DuplicateAccount()
    {
        return new CreationException("Duplicate account creation");
    }
}