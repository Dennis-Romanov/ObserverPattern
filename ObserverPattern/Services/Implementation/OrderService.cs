using System.Collections.Generic;
using ObserverPattern.ViewModels;

namespace ObserverPattern.Services.Implementation
{
    public class OrderService : IOrderService
    {
        private List<IOrderObserver> _observers;

        public OrderService()
        {
            _observers = new List<IOrderObserver>();
        }

        public void UpdateOrder(OrderViewModel order)
        {
            // Update the order and then notify all subscribers
            Notify(order);
        }

        public void Attach(IOrderObserver observer)
        {
            if (_observers.Contains(observer))
            {
                return;
            }

            _observers.Add(observer);
        }

        public void Detach(IOrderObserver observer)
        {
            if (!_observers.Contains(observer))
            {
                return;
            }

            _observers.Remove(observer);
        }

        public void Notify(OrderViewModel order)
        {
            foreach (var observer in _observers)
            {
                observer.Update(order);
            }
        }
    }
}