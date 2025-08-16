
namespace Domain.Exceptions;

public abstract class NotFoundException : Exception
{
    // Default message for parameterless constructor
    private const string DefaultMessage = "The requested resource was not found.";

    public NotFoundException()
        : base(DefaultMessage)
    {
    }

    public NotFoundException(string message)
        : base(message)
    {
    }

    public NotFoundException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}
