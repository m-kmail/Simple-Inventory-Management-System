using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS
{
    public class Inventory
    {
        private List<Product> products;
        public Inventory() 
        {
            products = new List<Product>();
        }

        public bool AddProduct(Product product) 
        {
            if (!IsValid(ref product))
                return false;

            if (Find(ref product) >= 0) 
                return false;

            Product NewProduct = new(product);
            products.Add(NewProduct);
            return true;
        }

        public bool AddProduct(String name , int quantity , double price)
        {
            Product NewProduct = new(name,price,quantity);

            if (!IsValid(ref NewProduct))
                return false;

            if (Find(ref NewProduct) >= 0)
                return false;

            products.Add(NewProduct);
            return true;
        }

        public bool RemoveProduct(Product product) 
        {
            int idx = Find(ref product);

            if (idx == -1)
                return false;

            products.RemoveAt(idx);
            return true;
        }

        public bool RemoveProduct(String name)
        {
            int idx = Find(name);

            if (idx == -1)
                return false;

            products.RemoveAt(idx);
            return true;
        }

        public void ViewAllProducts()
        {
            foreach (var product in products)
                Console.WriteLine(product.DisplayInfo());
        }

        public void EditProduct(string name, int quantity, double price, int idx)
        {
            products[idx].Name= String.IsNullOrWhiteSpace(name) ? products[idx].Name : name;
            products[idx].Quantity= quantity>0 ? quantity : products[idx].Quantity;
            products[idx].Price= price >=0 ? price : products[idx].Price;
        }

        public string SearchForProduct(string name) 
        {
            int idx = Find(name);
            return idx >=0 ? products[idx].DisplayInfo() : "The Product Does Not Exist";
        } 
        
        private bool IsValid(ref Product product) => 
            !String.IsNullOrEmpty(product.Name) && product.Quantity > 0 && product.Price >= 0;

        private int Find(ref Product product)
        {
            int indx = -1, cur = 0;

            foreach (var item in products)
            {
                if(item.IsEqual(ref product))
                {
                    indx = cur;
                    break;
                }
                cur++;
            }

            return indx;
        }

        public int Find(string name)
        {
            int indx = -1, cur = 0;

            foreach (var item in products)
            {
                if (item.Name == name)
                {
                    indx = cur;
                    break;
                }
                cur++;
            }

            return indx;
        }
    }
}
