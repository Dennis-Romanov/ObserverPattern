using Microsoft.Extensions.Logging;
using ObserverPattern.ViewModels;

namespace ObserverPattern.Services.Notifiers
{
    public class EmailObserver : IOrderObserver
    {
        private readonly ILogger<EmailObserver> _logger;

        public EmailObserver(ILogger<EmailObserver> logger)
        {
            _logger = logger;
        }

        public void Update(OrderViewModel order)
        {
            _logger.LogInformation("Order No '{0}' status is updated to '{1}'. An email sent to customer.",
                order.OrderNumber, order.OrderStatus.ToString());
        }
    }
}