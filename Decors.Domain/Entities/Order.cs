using Decors.Domain.Enums;
using System;
using System.Collections.Generic;

namespace Decors.Domain.Entities
{
    public class Order: EntityBase
    {


        public string Email { get; set; }
        public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.Now;
        public Address ShipToAddress { get; set; }
        public DeliveryMethod DeliveryMethod { get; set; }
        public IReadOnlyList<OrderItem> OrderItems { get; set; }
        public decimal Subtotal { get; set; }
        public OrderStatus OrderStatus { get; set; } = OrderStatus.Pending;
        public string PaymentIntentId { get; set; }

        public decimal GetTotal() { return Subtotal + DeliveryMethod.Price; }
    }

    public class ProductItemOrdered
    {
        public int ProductItemId { get; set; }
        public string ProductName { get; set; }
        public string PictureUrl { get; set; }

    }

    public class OrderAddress
    {
        public string FirstName{ get; set; }
        public string LastName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }

    }
}
