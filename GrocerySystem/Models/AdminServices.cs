using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using Microsoft.Data.SqlClient;

namespace Assignemnt_2_GrocerySystem.Models
{
    class AdminServices
    {
        ObservableCollection<Admin> adminList = new ObservableCollection<Admin>();
        //// Table Name  //  AvailableItems
        public ObservableCollection<Admin> readDataBase()
        {

            Admin a = new Admin();
            // inserting a connection string to make connection
            string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AdminCustomerDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            //using sqlcommand class to create connection with data base
            SqlConnection con = new SqlConnection(connString);
            try
            {
                con.Open();   // it's open the data base

                // creating query
                string selectAllQuery = "select * from AvailableItems";

                // to run the queries use sqlCommand class 
                SqlCommand cmd = new SqlCommand(selectAllQuery, con);

                // to read data from database use SqlDataReader class
                SqlDataReader dr = cmd.ExecuteReader();   // dr have the reference of the database that we have created

                // dr.
                while (dr.Read())
                {
                    a.ProductID = System.Convert.ToInt32(dr[0]);
                    a.ProductName = dr[1].ToString();
                    a.Price = System.Convert.ToInt32(dr[2]);
                    a.Quantity = System.Convert.ToInt32(dr[3]);
                    adminList.Add(a);
                }
            }
            catch
            {
                MessageBox.Show("DataBase not Accessable");
            }
            
            con.Close();
            return adminList;
        }
        public void addInDataBase(Admin a)
        {
            // inserting a connection string to make connection
            string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AdminCustomerDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            //using sqlcommand class to create connection with data base
            SqlConnection con = new SqlConnection(connString);
            try
            {
                con.Open();   // it's open the data base

                // creating query
                string insertRow = $"insert into AvailableItems values('{a.ProductID}','{a.ProductName}','{a.Price}','{a.Quantity}')";

                // to run the queries use sqlCommand class 
                SqlCommand cmd = new SqlCommand(insertRow, con);
                try
                {
                    int countRows = cmd.ExecuteNonQuery();
                }
                catch
                {
                   // MessageBox.Show("This Product Id is not available");
                }
                

            }
            catch
            {
                MessageBox.Show("Not Accessable");
            }
            con.Close();

        }
        public void deleteFromDataBase(Admin a)
        {
            // inserting a connection string to make connection
            string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AdminCustomerDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            //using sqlcommand class to create connection with data base
            SqlConnection con = new SqlConnection(connString);
            try
            {
                con.Open();   // it's open the data base

                // creating query
                string deleteRow = $"delete from AvailableItems where ProductID = '{a.ProductID}'";

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
                MessageBox.Show("There is some Data BAse problem");
            }

           
            con.Close();
        }
    }
}
