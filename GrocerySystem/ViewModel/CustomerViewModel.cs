using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;
using Assignemnt_2_GrocerySystem.Command;
using Assignemnt_2_GrocerySystem.Models;
using Assignemnt_2_GrocerySystem.Views;
using System.Collections.ObjectModel;
using System.Windows;

namespace Assignemnt_2_GrocerySystem.ViewModel
{
    class CustomerViewModel : BaseViewModel
    {
        ObservableCollection<Customer> cusList = new ObservableCollection<Customer>();
        public DelegateCommand Login { get; set; }
        public DelegateCommand SignUp { get; set; }
        public DelegateCommand Add { get; set; }
        public DelegateCommand Logout { get; set; }
        public DelegateCommand FinishSale { get; set; }
        public DelegateCommand Receipt { get; set; }
        public string UserName { get; set; }

        public string Password { get; set; }
        public string UserName1 { get; set; }
        public string Password1 { get; set; }
        public string PhoneNo { get; set; }
        CustomerServices cs;
        public CustomerViewModel()
        {
            cs = new CustomerServices();
           Login = new DelegateCommand(login, canLogin);
            SignUp = new DelegateCommand(signUp, canSignUp);
            Add = new DelegateCommand(add, canFinish);
            Logout = new DelegateCommand(logout, canLogout);
            FinishSale = new DelegateCommand(finish, canFinish);
            Receipt = new DelegateCommand(receipt, canFinish);
        }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public void finish(object o)
        {
            Customer c = new Customer();
            c.ProductID = this.ProductID;
            c.Quantity = this.Quantity;
            cs.finishSale(c);
           
        }
        
        public void receipt(object o)
        {
            Customer c = new Customer();
            c.ProductID = this.ProductID;
            c.Quantity = this.Quantity;
            cs.print(c);
        }
        public bool canFinish(object o)
        {
            if(string.IsNullOrEmpty(ProductID.ToString())|| string.IsNullOrEmpty(Quantity.ToString()))
            {
                return false;
            }
            else
            {
               return true;
            }
        }
        public void add(object o)
        {
            Customer c = new Customer();
            c.ProductID = this.ProductID;
            c.Quantity = this.Quantity;
            cs.addToCart(c);
        }
       
        public bool canLogout(object o)
        {
            return true;
        }
        public void logout(object o)
        {
            Environment.Exit(0);
        }
       
        public void signUp(object o)
        {
            Customer cus = new Customer();
            cus.UserName = this.UserName1;
            cus.Password = this.Password1;
            
                cs.addData(cus);
                CustomerCart cc = new CustomerCart();
                cc.ShowDialog();
           
        }
        public bool canSignUp(object o)
        {
            if (string.IsNullOrEmpty(UserName1) || string.IsNullOrEmpty(Password1) || string.IsNullOrEmpty(PhoneNo))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public void login(object o)
        {
            Customer cus = new Customer();
            cus.UserName = this.UserName;
            cus.Password = this.Password;
            cusList=cs.readDataBase(cus);
            bool result = false;
            for (int i = 0; i < cusList.Count; i++)
            {
                
                if (string.Equals(cusList[i].UserName,this.UserName) && string.Equals(cusList[i].Password, this.Password))
                {
                   
                    result=true;
                }
                else
                {
                     result=false;
                }
            }
           
            if (result)
            {
                CustomerCart cc = new CustomerCart();
                cc.ShowDialog();
            }
            else
            {
                MessageBox.Show("Login Denied");
            }
        }
        public bool canLogin(object o)
        {
            if(string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(Password))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
       
           
    }
}
