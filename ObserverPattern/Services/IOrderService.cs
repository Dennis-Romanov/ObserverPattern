using ObserverPattern.ViewModels;

namespace ObserverPattern.Services
{
    public interface IOrderService : IOrderNotifier
    {
        void UpdateOrder(OrderViewModel order);
    }
}