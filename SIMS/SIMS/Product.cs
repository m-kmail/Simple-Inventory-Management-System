using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS
{
    public class Product
    {
        private string? _Name;
        private double _Price;
        private int _Quantity;

        public Product() : this(String.Empty, -1, -1) { }

        public Product(string name, double price, int quantity)
        {
            _Name = name;
            _Price = price;
            _Quantity = quantity;   
        }

        public Product(Product other)
        {
            _Name=other.Name;
            _Price = other.Price;
            _Quantity = other.Quantity;
        }

        public string Name
        {
            get => String.IsNullOrWhiteSpace(_Name) ? String.Empty : _Name;

            set
            {
                if(String.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException("Empty String");

                _Name = value;
            }
        }
        public double Price 
        {
            get => _Price;

            set
            {
                if(value < 0)
                    throw new ArgumentOutOfRangeException("Price < 0");

                _Price = value;
            }
        }
        public int Quantity 
        {
            get => _Quantity;

            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("Quantity < 1");

                _Quantity = value;
            }
        }

    }
}
