using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using Microsoft.Data.SqlClient;
using System.Windows;

namespace Assignemnt_2_GrocerySystem.Models
{
    class CustomerServices
    {
        ObservableCollection<Customer> cusList = new ObservableCollection<Customer>();
        public ObservableCollection<Customer> readDataBase(Customer cus)
        {
            Customer c = new Customer();
            string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AdminCustomerDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            SqlConnection con = new SqlConnection(connString);

            try
            {
                con.Open();   // it's open the data base

                // creating query
                string selectAllQuery = "select * from Customer";     //Table Name     ' Customer'

                // to run the queries use sqlCommand class 
                SqlCommand cmd = new SqlCommand(selectAllQuery, con);

                // to read data from database use SqlDataReader class
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    c.Password = dr[0].ToString();
                    c.UserName = dr[1].ToString();
                    cusList.Add(c);
                }
            }
            catch
            {
                MessageBox.Show("There is some Data Base problem");
            }
            con.Close();

            return cusList;

        }
        public void addData(Customer c)
        {
            // inserting a connection string to make connection
            string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AdminCustomerDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            //using sqlcommand class to create connection with data base
            SqlConnection con = new SqlConnection(connString);

            try
            {
                con.Open();   // it's open the data base

                // creating query
                string insertRow = $"insert into Customer values('{c.Password}','{c.UserName}')";

                // to run the queries use sqlCommand class 
                SqlCommand cmd = new SqlCommand(insertRow, con);
                try
                {
                    int countRows = cmd.ExecuteNonQuery();
                }
                catch
                {
                    MessageBox.Show("Not Reachable Or sign up denied");
                    Environment.Exit(0);
                }
            }
            catch
            {
                MessageBox.Show("There is some Data Base problem");
            }
            con.Close();
        }
        public void finishSale(Customer c)
        {
            // inserting a connection string to make connection
            string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AdminCustomerDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            //using sqlcommand class to create connection with data base
            SqlConnection con = new SqlConnection(connString);
            try
            {
                con.Open();   // it's open the data base

                // creating query
                string deleteRow = $"delete from AvailableItems where ProductID = '{c.ProductID}'";

                // to run the queries use sqlCommand class 
                SqlCommand cmd = new SqlCommand(deleteRow, con);
                try
                {
                    int countRows = cmd.ExecuteNonQuery();
                }
                catch
                {
                    MessageBox.Show("Product Id is Invalid");
                }
            }
            catch
            {
                MessageBox.Show("There is some Data Base problem");
            }


            con.Close();
        }
        public void print(Customer c)
        {
            
            string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AdminCustomerDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            SqlConnection con = new SqlConnection(connString);

            try
            {
                con.Open();   // it's open the data base

                // creating query
                string selectAllQuery = "select * from Cart";     //Table Name     ' Cart'

                // to run the queries use sqlCommand class 
                SqlCommand cmd = new SqlCommand(selectAllQuery, con);

                // to read data from database use SqlDataReader class
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    if (c.ProductID == System.Convert.ToInt32(dr[0]))
                    {
                        MessageBox.Show($"Product ID: {System.Convert.ToInt32(dr[0])} \n Quantity:{System.Convert.ToInt32(dr[1])}");
                    }

                }
            }
            catch
            {
                MessageBox.Show("DataBAse not Accesable");
            }
           
            con.Close();
        }
        public void addToCart(Customer c)
        {
            // inserting a connection string to make connection
            string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AdminCustomerDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            //using sqlcommand class to create connection with data base
            SqlConnection con = new SqlConnection(connString);

            try
            {
                con.Open();   // it's open the data base

                // creating query
                string insertRow = $"insert into Cart values('{c.ProductID}','{c.Quantity}')";

                // to run the queries use sqlCommand class 
                SqlCommand cmd = new SqlCommand(insertRow, con);
                try
                {
                    int countRows = cmd.ExecuteNonQuery();
                }
                catch
                {
                    MessageBox.Show("Not Reachable Or sign up denied");
                    Environment.Exit(0);
                }
            }
            catch
            {
                MessageBox.Show("DataBase Not Accesable");
            }
           
            con.Close();
        }
    }
}
