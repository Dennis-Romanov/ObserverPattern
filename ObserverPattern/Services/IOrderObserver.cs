using ObserverPattern.ViewModels;

namespace ObserverPattern.Services
{
    public interface IOrderObserver
    {
        void Update(OrderViewModel order);
    }
}