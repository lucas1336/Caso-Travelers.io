namespace si730pc2u202110085.Domain.Exceptions;

public class PlanValidationException : Exception
{
    public PlanValidationException(string message) : base(message)
    {
    }
}