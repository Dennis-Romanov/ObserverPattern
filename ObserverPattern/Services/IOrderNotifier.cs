using ObserverPattern.ViewModels;

namespace ObserverPattern.Services
{
    public interface IOrderNotifier
    {
        // Attach an order observer to the subject.
        void Attach(IOrderObserver observer);

        // Detach an order observer from the subject.
        void Detach(IOrderObserver observer);

        // Notify all order observers about an event.
        void Notify(OrderViewModel order);
    }
}