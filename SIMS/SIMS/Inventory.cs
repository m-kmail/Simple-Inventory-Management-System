﻿using System;
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

        private bool IsEqual(Product p1,ref Product p2) => p1.Name == p2.Name && p1.Price == p2.Price;
    }
}
