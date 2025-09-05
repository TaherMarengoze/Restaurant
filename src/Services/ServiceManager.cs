
using Domain.Contracts;
using Services.Abstraction;

namespace Services;

public sealed class ServiceManager(IUnitOfWork unitOfWork) : IServiceManager
{
    private readonly Lazy<IMenuItemService> menuItemService = new(() => new MenuItemService(unitOfWork));

    public IMenuItemService MenuItemService => menuItemService.Value;
}
