using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS
{
    public static class Menu
    {
        public static void DisplayMainMenu()
        {
            Console.WriteLine("--------------------");
            Console.WriteLine("1. Add a product");
            Console.WriteLine("2. View all products");
            Console.WriteLine("3. Edit a product");
            Console.WriteLine("4. Delete a product");
            Console.WriteLine("5. Search for a product");
            Console.WriteLine("6. Exit");
            Console.WriteLine("\t\tEnter your choice:");
            Console.WriteLine("_____________________");
        }

        public static void DisplayEditMenu()
        {
            Console.WriteLine("0. Go Back!!");
            Console.WriteLine("1. Edit Product name");
            Console.WriteLine("2. Edit Product price");
            Console.WriteLine("3. Edit Product quantity");
        }
    }
}
