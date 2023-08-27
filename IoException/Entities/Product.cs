using System.Globalization;
using IoException.Entities.MyExceptions;

namespace IoException.Entities
{
    sealed class Product
    {
        public string Name { get;  set; }
        public double Price { get;  set; }
        public int Quantity { get;  set; }

        public Product(string name, double price, int quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
        }

        public double TotalValue()
        {
            return Quantity * Price;
        }

        public void AddItem(int quantity)
        {            
            Quantity += quantity;
        }
        public void RemoveItem(int quantity)
        {
            if(Quantity < quantity)
            {
                throw new ProductExceptions("The quantity to be removed is greater than the quantity  in stock");
            }
            Quantity -= quantity;
        }

        public override string ToString()
        {
            return
                $"Name: {Name}, Price: $ {Price.ToString("F2", CultureInfo.InvariantCulture)}, Quantity: {Quantity} \nStock Value: {TotalValue().ToString("F2", CultureInfo.InvariantCulture)}";
        }

    }
}
