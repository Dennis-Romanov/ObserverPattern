using Microsoft.Extensions.Logging;
using ObserverPattern.ViewModels;

namespace ObserverPattern.Services.Notifiers
{
    public class SmsObserver : IOrderObserver
    {
        private readonly ILogger<SmsObserver> _logger;

        public SmsObserver(ILogger<SmsObserver> logger)
        {
            _logger = logger;
        }

        public void Update(OrderViewModel order)
        {
            _logger.LogInformation("Order No '{0}' status is updated to '{1}'. SMS message sent to customer.",
                order.OrderNumber, order.OrderStatus.ToString());
        }
    }
}