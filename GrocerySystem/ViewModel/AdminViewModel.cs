using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using Assignemnt_2_GrocerySystem.Command;
using Assignemnt_2_GrocerySystem.Models;
using System.Windows;

namespace Assignemnt_2_GrocerySystem.ViewModel
{
    class AdminViewModel:BaseViewModel
    {
       
        public int ProductID { get; set; }
        public int ProductID2 { get; set; }
        public string ProductName { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        ObservableCollection<Admin> AdminList { get; set; }
        AdminServices adminServices;
        public DelegateCommand AddProduct { get; set; }
        public DelegateCommand DeleteProduct { get; set; }
        public DelegateCommand Logout { get; set; }
        public HomeViewModel MainViewModel { get;  set; }

        public AdminViewModel()
        {
            adminServices = new AdminServices();
            AddProduct = new DelegateCommand(add, canAdd);
            DeleteProduct = new DelegateCommand(delete, canDelete);
            Logout = new DelegateCommand(logout, canLogout);
        }
        public void logout(object o)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
        }
        public bool canLogout(object o)
        {
            return true;
        }
        public bool canDelete(object o)
        {
            if (string.IsNullOrEmpty(ProductID2.ToString()) || ProductID2==0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public void delete(object o)
        {
            if (!(string.IsNullOrEmpty(ProductID2.ToString())))
            {
                Admin admin = new Admin();
                admin.ProductID = this.ProductID2;
                adminServices.deleteFromDataBase(admin);
            }
        }
        public void add(object o)
        {

            int flag = 1;
            AdminList = adminServices.readDataBase();
            for (int i = 0; i < AdminList.Count; i++)
            {
                //  MessageBox.Show("far to flag");
                if (AdminList[i].ProductID == this.ProductID)
                {
                    
                    flag = 0;
                    break;
                }
            }
            if (flag == 1)
            {
                Admin admin = new Admin();
                admin.ProductID = this.ProductID;
                admin.ProductName = this.ProductName;
                admin.Quantity = this.Quantity;
                admin.Price = this.Price;
                adminServices.addInDataBase(admin);
                
            }
            else
            {
                MessageBox.Show("This Product ID is not Available===");
            }

        }
        public bool canAdd(object o)
        {
            if(string.IsNullOrEmpty(ProductID.ToString()) || string.IsNullOrEmpty(ProductName) || string.IsNullOrEmpty(Price.ToString()) || string.IsNullOrEmpty(Quantity.ToString()))
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
