using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using Pizzzeria_Ver1._0.Models;

namespace Pizzzeria_Ver1._0.Controllers
{
    public class EmployeeController : Controller
    {
        DBModel.db dblayer = new DBModel.db();
        public ActionResult Login_Employee()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login_Employee(FormCollection fc)
        {
            string Username = fc["Username"];
            string Password = fc["Password"];
            dblayer.Login_Employee(Username, Password);
            TempData["msg"] = "Login Success!!";
            int EmployeeID = dblayer.Login_Employee(Username, Password);
            Session["EmployeeID"] = EmployeeID;
            return RedirectToAction("Home_Employee", "Employee");
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Login_Employee", "Employee");
        }

        // GET: Employee
        public ActionResult Home_Employee()
        {
            DataSet ds = dblayer.Show_EveryCustomerOrder();
            ViewBag.emp = ds.Tables[0];

            return View();
        }

        public ActionResult Order_Finish()
        {
            int orderID = Convert.ToInt32(Request.QueryString.Get("OrderID"));
            dblayer.OrderFinish(orderID);

            return View();
        }
    }
}