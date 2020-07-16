using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Pedidos.Entities.Enums;

namespace Pedidos.Entities
{
    class Order
    {
        public DateTime Moment { get; private set; }
        public OrderStatus order { get; set; }
        public Client client { get; set; }
        public List<OrdemItem> Items { get; set; } = new List<OrdemItem>();

        public Order() { }
        public Order(DateTime moment, OrderStatus order, Client client)
        {
            Moment = moment;
            this.order = order;
            this.client = client;
        }

        public void AddItem(OrdemItem item)
        {
            Items.Add(item);
        }

        public void RemoveItem(OrdemItem item)
        {
            Items.Remove(item);
        }

        public double Total()
        {
            double sum = 0;

            foreach (OrdemItem item in Items)
            {
                sum += item.SubTotal();
            }

            return sum;
        }

        public override string ToString()
        {
            StringBuilder os = new StringBuilder();
            os.AppendLine($"Order moment: {Moment}");
            os.AppendLine($"Order status: {order}");
            os.AppendLine($"Client: {client}");
            os.AppendLine("Order items");
            foreach (OrdemItem item in Items)
            {
                os.AppendLine($"{item}");

            }

            os.AppendLine($"Total price: ${Total().ToString("F2", CultureInfo.InvariantCulture)}");

            return os.ToString();

           
        }

    }
}
