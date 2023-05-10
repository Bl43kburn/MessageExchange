namespace BusinessLogicLayer.Anemic.Exceptions;

public class AssignmentException : Exception
{
    private AssignmentException(string message) { }

    public static AssignmentException DuplicateAssignment()
    {
        return new AssignmentException("Duplicate assignment");
    }

}