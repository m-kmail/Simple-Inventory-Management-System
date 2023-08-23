using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS
{
    public static class InputManager
    {

        public static Tuple<string,int,double> GetFullInfo()
        {
            string name = GetName();
            int quantity = GetQuantity();
            double price= GetPrice();

            return Tuple.Create(name, quantity, price);
        }
        public static string GetName()
        {
            string? name = "";

            while(String.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Enter a Valid Name ==> Not Empty");
                name = Console.ReadLine();
            }

            return name;
        }

        public static int GetQuantity()
        {
            int quantity = 0;

            while (quantity <= 0) 
            {
                Console.WriteLine("Enter a Valid quantity ==> at least 1");
                quantity = Convert.ToInt32(Console.ReadLine());
            }

            return quantity;
        }

        public static double GetPrice()
        {
            double price = -1f;

            while (price < 0)
            {
                Console.WriteLine("Enter a Valid Price");
                price = Convert.ToDouble(Console.ReadLine());
            }

            return price;
        }
    }
}
