using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using ObserverPattern.Enums;
using ObserverPattern.Services;
using ObserverPattern.Services.Notifiers;
using ObserverPattern.ViewModels;

namespace ObserverPattern.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ILoggerFactory _loggerFactory;

        private readonly IOrderService _orderService;

        public HomeController(
            ILoggerFactory loggerFactory,
            IOrderService orderService)
        {
            _loggerFactory = loggerFactory;
            _logger = loggerFactory.CreateLogger<HomeController>();
            
            _orderService = orderService;
        }

        public IActionResult Index()
        {
            var order = new OrderViewModel
            {
                OrderNumber = "11283A454B",
                OrderDate = DateTime.Now,
                TotalAmount = 105.99m,
                OrderStatus = OrderStatuses.PendingPayment
            };

            return View(order);
        }

        [HttpPost]
        public IActionResult Index(OrderViewModel order)
        {
            _logger.LogInformation("Attaching Observers...");

            var smsObserverLogger = _loggerFactory.CreateLogger<SmsObserver>();
            var emailObserverLogger = _loggerFactory.CreateLogger<EmailObserver>();

            var smsObserver = new SmsObserver(smsObserverLogger);
            var emailObserver = new EmailObserver(emailObserverLogger);

            _orderService.Attach(smsObserver);
            _orderService.Attach(emailObserver);

            _logger.LogInformation("Updating Order Status...");

            _orderService.UpdateOrder(order);

            return View(order);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
