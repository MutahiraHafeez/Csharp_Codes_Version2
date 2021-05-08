using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace EAD_Assignment3_BlogApplication.Models
{
    public class UserRepository
    {
        public static List<Posts> post = new List<Posts>();
        public static List<Users> user = new List<Users>();
        public static void ReadData()
        {
            user.Clear();
            string conStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BlogDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection sqlconn = new SqlConnection(conStr);
            sqlconn.Open();
            string query = "select * from Users";
            SqlCommand cmd = new SqlCommand(query, sqlconn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                user.Add(new Users {Id=System.Convert.ToInt32(dr[0]), Name = dr[1].ToString(), Email = dr[2].ToString(), Password = dr[3].ToString() });
            }
            sqlconn.Close();
        }
        public static void ReadPost()
        {
            post.Clear();
            string conStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BlogDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection sqlconn = new SqlConnection(conStr);
            sqlconn.Open();
            string query = "select * from Posts";
            SqlCommand cmd = new SqlCommand(query, sqlconn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                post.Add(new Posts { Id = System.Convert.ToInt32(dr[0]), Name = dr[1].ToString(), Title = dr[2].ToString(), Post = dr[3].ToString()});
            }
            sqlconn.Close();
        }
        public static void AddUser(Users u)
        {
           
           
                string conStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BlogDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                SqlConnection sqlconn = new SqlConnection(conStr);
                sqlconn.Open();
                string query = $"insert into Users(Name, Email, Password,Image) values('{u.Name}','{u.Email}','{u.Password}','{u.ImageName}')";
                SqlCommand cmd = new SqlCommand(query, sqlconn);
                int insertedRows = cmd.ExecuteNonQuery();
                sqlconn.Close();
           
           
           
        }
        public static void AddPost(Posts u)
        {
            string conStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BlogDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection sqlconn = new SqlConnection(conStr);
            sqlconn.Open();
            string query = $"insert into Posts(Name, Title, Post) values('{u.Name}','{u.Title}','{u.Post}')";
            SqlCommand cmd = new SqlCommand(query, sqlconn);
            int insertedRows = cmd.ExecuteNonQuery();
            sqlconn.Close();
        }
        public static void UpdatePost(Posts u)
        {
            string conStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BlogDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection sqlconn = new SqlConnection(conStr);
            sqlconn.Open();
            string query = $"Update Posts set Title='{u.Title}',Post ='{u.Post}' where Name  = '{u.Name}'";
            SqlCommand cmd = new SqlCommand(query, sqlconn);
            int insertedRows = cmd.ExecuteNonQuery();
            sqlconn.Close();
        }
        public static void UpdateData(Users u,string Name)
        {
            string conStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BlogDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection sqlconn = new SqlConnection(conStr);
            sqlconn.Open();
            string query = $"Update  Users set Name ='{u.Name}',Email='{u.Email}',Password ='{u.Password}' where Name  = '{Name}'";
            SqlCommand cmd = new SqlCommand(query, sqlconn);
            int insertedRows = cmd.ExecuteNonQuery();
            sqlconn.Close();
        }
        public static void RemovePost(string Name)
        {
            string conStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BlogDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection sqlconn = new SqlConnection(conStr);
            sqlconn.Open();
            string query = $"Delete from Posts where Name  = '{Name}'";
            SqlCommand cmd = new SqlCommand(query, sqlconn);
            int insertedRows = cmd.ExecuteNonQuery();
            sqlconn.Close();
        }
        public static void DeletePost(int id)
        {
            string conStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BlogDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection sqlconn = new SqlConnection(conStr);
            sqlconn.Open();
            string query = $"Delete from Posts where Id  = '{id}'";
            SqlCommand cmd = new SqlCommand(query, sqlconn);
            int insertedRows = cmd.ExecuteNonQuery();
            sqlconn.Close();
        }
        public static void RemoveData( string Name)
        {
            string conStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BlogDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection sqlconn = new SqlConnection(conStr);
            sqlconn.Open();
            string query = $"Delete from Users where Name  = '{Name}'";
            SqlCommand cmd = new SqlCommand(query, sqlconn);
            int insertedRows = cmd.ExecuteNonQuery();
            sqlconn.Close();
            RemovePost(Name);
        }
        public static void ReadSomePost(string Name)
        {
            post.Clear();
            string conStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BlogDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection sqlconn = new SqlConnection(conStr);
            sqlconn.Open();
            string query = $"select * from Posts where Name ='{Name}'";
            SqlCommand cmd = new SqlCommand(query, sqlconn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                post.Add(new Posts { Name = dr[1].ToString(), Title = dr[2].ToString(), Post = dr[3].ToString() });
            }
            sqlconn.Close();
        }
    }
}
