using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmallBusinessForYouth.Models
{
    public class ShoppingcartModel
    {
        private List<Product> products;
        public ShoppingcartModel()
        {
            DBModel1 dbmodel = new DBModel1();
            this.products = dbmodel.Products.ToList();
        }
        public List<Product> findAll()
        {
            return this.products;
        }
        public Product find(int ID)
        {
            return this.products.Single(p => p.PId == ID);

        }
    }
}