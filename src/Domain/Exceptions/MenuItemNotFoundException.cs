
namespace Domain.Exceptions;

public class MenuItemNotFoundException : NotFoundException
{
    public MenuItemNotFoundException()
    {
    }

    public MenuItemNotFoundException(Guid id)
        : base($"Menu item with ID '{id}' was not found.")
    {
    }

    public MenuItemNotFoundException(Guid id, Exception innerException)
        : base($"Menu item with ID '{id}' was not found.", innerException)
    {
    }
}
