namespace BusinessLogicLayer.Anemic.Exceptions;

public class SearchException<T> : Exception
{
    private SearchException(string message) { }

    public static SearchException<T> NotFound()
    {
        return new SearchException<T>($"Not found: {typeof(T)}");
    }
}