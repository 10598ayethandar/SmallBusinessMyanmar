using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SmallBusinessForYouth.Models;

namespace SmallBusinessForYouth.Controllers
{
    public class ShoppingcartController : Controller
    {
        // GET: Shoppingcart
        public ActionResult Index()
        {
            return View();
        }

      
        public ActionResult Buy(int id)
        {
            ShoppingcartModel productModel = new ShoppingcartModel();
            if(Session["cart"] == null)
            {
                List<Order_Detail> cart = new List<Order_Detail>();
                cart.Add(new Order_Detail { Product = productModel.find(id), Qty = 1 });
                Session["cart"] = cart;
                Session["count"] = 1;
            }
            else
            {
                List<Order_Detail> cart = (List<Order_Detail>)Session["cart"];
                int index = isExist(id);
                if (index != -1)
                {
                    cart[index].Qty++;
                }
                else
                {
                    cart.Add(new Order_Detail { Product = productModel.find(id), Qty = 1 });
                }
                Session["cart"] = cart;
                Session["count"] = GetCount(cart);
            }
            return RedirectToAction("ProductList", "Products");
        }

        public int GetCount(List<Order_Detail> cart)
        {
            int count = 0;
            foreach (Order_Detail item in cart)
            {
                count = count + item.Qty;
            }
            return count;
        }
        public ActionResult Remove(int id)
        {
            if(Session["cart"] !=null)
            {
                List<Order_Detail> cart = (List<Order_Detail>)Session["cart"];
                var str = cart.Find(order => order.Product.PId == id);
                cart.Remove(str);
                Session["cart"] = cart;
                Session["count"] = GetCount(cart);
            }
            else
            {
                Session["count"] = 0;
                Session["cart"] = null;
            }
            
            return RedirectToAction("ProductList", "Products");
        }
            private int isExist(int id)
        {
            List<Order_Detail> cart = (List<Order_Detail>)Session["cart"];
            for(int i = 0; i < cart.Count; i++)
            {
                if (cart[i].Product.PId == id)
                    return i;
            }
            return -1;
        }
    }
}