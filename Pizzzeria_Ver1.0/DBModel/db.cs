using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Pizzzeria_Ver1._0.Models;

namespace Pizzzeria_Ver1._0.DBModel
{
    public class db
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);

        public void Add_Customer(Customer cust)
        {
            SqlCommand com = new SqlCommand("Add_Customer", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Username", cust.Username);
            com.Parameters.AddWithValue("@Password", cust.Password);
            com.Parameters.AddWithValue("@Fullname", cust.Fullname);
            com.Parameters.AddWithValue("@Phone", cust.Phone);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();

        }

        public int Login_Customer(string username, string password)
        {
            SqlCommand com = new SqlCommand("Login_Customer", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Username", username);
            com.Parameters.AddWithValue("@Password", password);
            con.Open();
            int modified = Convert.ToInt32(com.ExecuteScalar());
            con.Close();

            return modified;
        }

        public int Login_Employee(string username, string password)
        {
            SqlCommand com = new SqlCommand("Login_Employee", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Username", username);
            com.Parameters.AddWithValue("@Password", password);
            con.Open();
            int modified = Convert.ToInt32(com.ExecuteScalar());
            con.Close();

            return modified;
        }

        public void Add_Pizza(Pizza pizza)
        {
            SqlCommand cmd = new SqlCommand("AddPizza", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@OrderID", pizza.OrderID);
            cmd.Parameters.AddWithValue("@Size", pizza.Size);
            cmd.Parameters.AddWithValue("@Cheese", pizza.Cheese);
            cmd.Parameters.AddWithValue("@Blackolives", pizza.Blackolives);
            cmd.Parameters.AddWithValue("@Bacon", pizza.Bacon);
            cmd.Parameters.AddWithValue("@Greenpeppers", pizza.Greenpeppers);
            cmd.Parameters.AddWithValue("@Pinapple", pizza.Pinapple);
            cmd.Parameters.AddWithValue("@Mushroom", pizza.Mushroom);
            cmd.Parameters.AddWithValue("@Spinach", pizza.Spinach);
            cmd.Parameters.AddWithValue("@Onions", pizza.Onions);
            cmd.Parameters.AddWithValue("@Shrimp", pizza.Shrimp);
            cmd.Parameters.AddWithValue("@Sausages", pizza.Sausages);
            cmd.Parameters.AddWithValue("@Chicken", pizza.Chicken);
            cmd.Parameters.AddWithValue("@Price",pizza.Price);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

        }

        public void Add_Order(OrderInfo order)
        {
            SqlCommand cmd = new SqlCommand("AddOrderInfo", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@OrderMethod", order.OrderMethod);
            cmd.Parameters.AddWithValue("@Date", order.Date);
            cmd.Parameters.AddWithValue("@Time", order.Time);
            cmd.Parameters.AddWithValue("@Street", order.Street.Trim());
            cmd.Parameters.AddWithValue("@City", order.City.Trim());
            cmd.Parameters.AddWithValue("@State", order.State);
            cmd.Parameters.AddWithValue("@Zip", order.Zip);
            con.Open();
            cmd.ExecuteNonQuery();
            //int modified = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
        }

        public void Add_OrderItem(OrderItem orderitem)
        {
            SqlCommand cmd = new SqlCommand("AddOrderItem", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CustomerID", orderitem.CustomerID);
            cmd.Parameters.AddWithValue("@OrderID", orderitem.OrderID);
            cmd.Parameters.AddWithValue("@Is_delivered", orderitem.Is_delivered);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public DataSet Show_OrderInfo(int orderID)
        {
            SqlCommand com = new SqlCommand("Order_Confirmation1", con);
            com.Parameters.AddWithValue("@OrderID", orderID);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public DataSet Show_PizzaInfo(int orderID)
        {
            SqlCommand com = new SqlCommand("Order_Confirmation2", con);
            com.Parameters.AddWithValue("@OrderID", orderID);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public DataSet Show_CustomerOrder(int customerID)
        {
            SqlCommand com = new SqlCommand("Order_History_ForCustomer", con);
            com.Parameters.AddWithValue("@CustomerID", customerID);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public DataSet Show_EveryCustomerOrder()
        {
            SqlCommand com = new SqlCommand("Order_History_ForEmployee", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public DataSet Show_CustomerOrder_ByOrderID(int orderID)
        {
            SqlCommand com = new SqlCommand("Order_History_ForCustomer_ByOrderID", con);
            com.Parameters.AddWithValue("@OrderID", orderID);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public int Get_CustomerID()
        {
            int orderID = 0;
            SqlCommand cmd = new SqlCommand("select max(CustomerID) from Customer", con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                orderID = reader.GetInt32(0);
            }
            con.Close();

            return orderID;
        }

        public int Get_OrderID()
        {
            int orderID=0;
            SqlCommand cmd = new SqlCommand("GetOrderID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.ExecuteNonQuery();

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                orderID = reader.GetInt32(0);
            }
            con.Close();

            return orderID;
        }

        public int Get_PizzaID()
        {
            int pizzaID = 0;
            SqlCommand cmd = new SqlCommand("GetPizzaID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.ExecuteNonQuery();

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                pizzaID = reader.GetInt32(0);
            }
            con.Close();

            return pizzaID;
        }

        public void Update_PizzaPrice(int pizzaID, double price)
        {
            SqlCommand cmd = new SqlCommand("Update_PizzaPrice", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PizzaID", pizzaID);
            cmd.Parameters.AddWithValue("@Price", price);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void Update_PizzaInfo(Pizza pizza, int pizzaID)
        {
            SqlCommand cmd = new SqlCommand("UpdatePizzaInfo", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PizzaID", pizzaID);
            cmd.Parameters.AddWithValue("@Size", pizza.Size);
            cmd.Parameters.AddWithValue("@Cheese", pizza.Cheese);
            cmd.Parameters.AddWithValue("@Blackolives", pizza.Blackolives);
            cmd.Parameters.AddWithValue("@Bacon", pizza.Bacon);
            cmd.Parameters.AddWithValue("@Greenpeppers", pizza.Greenpeppers);
            cmd.Parameters.AddWithValue("@Pinapple", pizza.Pinapple);
            cmd.Parameters.AddWithValue("@Mushroom", pizza.Mushroom);
            cmd.Parameters.AddWithValue("@Spinach", pizza.Spinach);
            cmd.Parameters.AddWithValue("@Onions", pizza.Onions);
            cmd.Parameters.AddWithValue("@Shrimp", pizza.Shrimp);
            cmd.Parameters.AddWithValue("@Sausages", pizza.Sausages);
            cmd.Parameters.AddWithValue("@Chicken", pizza.Chicken);
            cmd.Parameters.AddWithValue("@Price", pizza.Price);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void Update_OrderInfo(OrderInfo order, int orderID)
        {
            SqlCommand cmd = new SqlCommand("UpdateOrderInfo", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@OrderID",orderID);
            cmd.Parameters.AddWithValue("@OrderMethod", order.OrderMethod);
            cmd.Parameters.AddWithValue("@Date", order.Date);
            cmd.Parameters.AddWithValue("@Time", order.Time);
            cmd.Parameters.AddWithValue("@Street", order.Street.Trim());
            cmd.Parameters.AddWithValue("@City", order.City.Trim());
            cmd.Parameters.AddWithValue("@State", order.State);
            cmd.Parameters.AddWithValue("@Zip", order.Zip);
            con.Open();
            cmd.ExecuteNonQuery();
            //int modified = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
        }

        public void Delete_EntirePizzaInfo(int orderID)
        {
            SqlCommand cmd = new SqlCommand("DeleteEntirePizzaInfo", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@OrderID", orderID);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void Delete_OnePizzaInfo(int pizzaID)
        {
            SqlCommand cmd = new SqlCommand("DeleteOnePizzaInfo", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PizzaID", pizzaID);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void Delete_OrderInfo(int orderID)
        {
            SqlCommand cmd = new SqlCommand("DeleteOrderInfo", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@OrderID", orderID);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void Delete_OrderItem(int customerID, int orderID)
        {
            SqlCommand cmd = new SqlCommand("DeleteOrderItem", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CustomerID", customerID);
            cmd.Parameters.AddWithValue("@OrderID", orderID);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void OrderFinish(int orderID)
        {
            SqlCommand cmd = new SqlCommand("OrderFinish", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@OrderID", orderID);
            cmd.Parameters.AddWithValue("@Is_delivered", false);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }



    }
}