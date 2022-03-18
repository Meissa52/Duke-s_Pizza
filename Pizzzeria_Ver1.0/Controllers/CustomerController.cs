using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using Pizzzeria_Ver1._0.Models;

namespace Pizzzeria_Ver1._0.Controllers
{
    public class CustomerController : Controller
    {
        DBModel.db dblayer = new DBModel.db();
        // GET: Customer
        public ActionResult Signup_Customer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Signup_Customer(FormCollection fc)
        {
            Customer cust = new Customer();
            cust.Username = fc["Username"];
            cust.Password = fc["Password"];
            cust.Fullname = fc["Fullname"];
            cust.Phone = fc["Phone"];
            dblayer.Add_Customer(cust);
            int CustomerID = dblayer.Get_CustomerID();
            Session["CustomerID"] = CustomerID;
            return RedirectToAction("Home_Customer", "Customer", new { @CustID = CustomerID });
        }


        public ActionResult Login_Customer()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login_Customer(FormCollection fc)
        {
            string Username = fc["Username"];
            string Password = fc["Password"];
            int CustomerID = dblayer.Login_Customer(Username, Password);
            Session["CustomerID"] = CustomerID;
            return RedirectToAction("Add_Order", "Customer", new { @CustID = CustomerID });
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Login_Customer", "Customer");
        }

        public ActionResult Home_Customer()
        {
            int customerID = Convert.ToInt32(Session["CustomerID"]);
            DataSet ds = dblayer.Show_CustomerOrder(customerID);
            ViewBag.emp = ds.Tables[0];

            return View();
        }


        /* -------------------------------------------------------*/
        /* -------------------Add Section-------------------------*/
        /* -------------------------------------------------------*/
        public ActionResult Add_Order()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Add_Order(OrderInfo orderinfo)
        {
            int orderID;
            dblayer.Add_Order(orderinfo);
            orderID = dblayer.Get_OrderID();
            Session["OrderID"] = orderID;
            //return RedirectToAction("Add_Pizza", "Customer");
            return RedirectToAction("Add_Pizza", "Customer");
        }

        public ActionResult Add_Pizza()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add_Pizza(Pizza pizza, string submit)
        {
            pizza.OrderID = Convert.ToInt32(Session["OrderID"]);
            dblayer.Add_Pizza(pizza);
            int PizzaID = dblayer.Get_PizzaID();
            double Price;

            //Calculate the Pizza Price
            Price = CalcPizzaPrice(pizza);
            //Update the pizza price to database
            dblayer.Update_PizzaPrice(PizzaID, Price);
            switch (submit)
            {
                case "Add":
                    return RedirectToAction("Add_Pizza", "Customer", new { CustID = Session["CustomerID"], OrderID = Session["OrderID"] });
                case "Save":
                    return RedirectToAction("Order_Confirmation", "Customer", new { CustID = Session["CustomerID"], OrderID = Session["OrderID"] });
            }

            return View();
            
        }

        

        public ActionResult Order_Confirmation()
        {
            int orderID = Convert.ToInt32(Request.QueryString.Get("OrderID"));
            DataSet dl = dblayer.Show_PizzaInfo(orderID);
            ViewBag.emp1 = dl.Tables[0];

            DataSet ds = dblayer.Show_OrderInfo(orderID);
            ViewBag.emp2 = dl.Tables[0];

            return View();
        }

        public ActionResult Order_Save()
        {
            OrderItem orderItem = new OrderItem();

            int customerID = Convert.ToInt32(Session["CustomerID"]);
            int orderID = Convert.ToInt32(Session["OrderID"]);
            bool is_delivered = true;

            orderItem.CustomerID = customerID;
            orderItem.OrderID = orderID;
            orderItem.Is_delivered = is_delivered;

            dblayer.Add_OrderItem(orderItem);       //Insert orderItem data to Sql server

            return View();
        }

        public ActionResult Show_PizzaInfo()
        {
            int orderID = Convert.ToInt32(Request.QueryString.Get("OrderID"));
            DataSet dl = dblayer.Show_PizzaInfo(orderID);
            ViewBag.emp1 = dl.Tables[0];
            return View();
        }


        public double CalcPizzaPrice (Pizza pizza)
        {
            double Price = 0.0;
            if (pizza.Size == "Large")
            {
                Price = 13.45;
            }else if (pizza.Size == "Medium")
            {
                Price = 10.45;
            }else if (pizza.Size == "Small")
            {
                Price = 7.45;
            }else
            {
                Price = 10.00;
            }

            return Price;
        }

        /* -------------------------------------------------------*/
        /* -------------------Edit Section-------------------------*/
        /* -------------------------------------------------------*/
        public ActionResult EditOrderInfo()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult EditOrderInto(OrderInfo orderInfo)
        {
            int orderID = Convert.ToInt32(Request.QueryString.Get("OrderID"));
            dblayer.Update_OrderInfo(orderInfo, orderID);

            return RedirectToAction("Home_Customer", "Customer");
        }

        public ActionResult EditPizzaInfo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EditPizzaInfo(Pizza pizza)
        {
            int pizzaID = Convert.ToInt32(Request.QueryString.Get("PizzaID"));
            double Price = CalcPizzaPrice(pizza);
            pizza.Price = Price;
            dblayer.Update_PizzaInfo(pizza,pizzaID);

            return RedirectToAction("Home_Customer", "Customer");
        }

        /* -------------------------------------------------------*/
        /* -------------------Delete Section-----------------------*/
        /* -------------------------------------------------------*/
        public ActionResult DeleteOrderInfo(int orderID)
        {
            int customerID = Convert.ToInt32(Session["CustomerID"]);
            dblayer.Delete_EntirePizzaInfo(orderID);
            dblayer.Delete_OrderInfo(orderID);
            dblayer.Delete_OrderItem(customerID,orderID);

            return RedirectToAction("Home_Customer", "Customer");
        }

        public ActionResult DeleteOnePizzaInfo(int pizzaID)
        {
            dblayer.Delete_OnePizzaInfo(pizzaID);

            return RedirectToAction("Home_Customer", "Customer");
        }
    }
}