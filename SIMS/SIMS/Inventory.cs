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

        public bool AddProduct(String name , int quantity , int price)
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

        private bool IsValid(ref Product product) => 
            !String.IsNullOrEmpty(product.Name) && product.Quantity > 0 && product.Price >= 0;

        private int Find(ref Product product)
        {
            int indx = -1, cur = 0;

            foreach (var item in products)
            {
                if(IsEqual(item,ref product))
                {
                    indx = cur;
                    break;
                }
                cur++;
            }

            return indx;
        }

        private int Find(string name)
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

        private bool IsEqual(Product p1,ref Product p2) => p1.Name == p2.Name;
    }
}
