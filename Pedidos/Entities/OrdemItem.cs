using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace Pedidos.Entities
{
    class OrdemItem
    {
        public int Quantity { get; set; }
        public double Price { get; set; }
        public Product product { get; set; }

        public OrdemItem() { }

        public OrdemItem(int quantity, double price, Product product)
        {
            Quantity = quantity;
            Price = price;
            this.product = product;
        }

        public double SubTotal()
        {
            return Quantity * Price;
        }

        public override string ToString()
        {
            return $"{product.Name}, ${Price.ToString("F2", CultureInfo.InvariantCulture)}, Quantity: {Quantity}, Subtotal: $ {SubTotal().ToString("F2", CultureInfo.InvariantCulture)}";
        }



    }
}
