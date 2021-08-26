using System;
using ObserverPattern.Enums;

namespace ObserverPattern.ViewModels
{
    public class OrderViewModel
    {
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }

        public OrderStatuses OrderStatus { get; set; }
    }
}