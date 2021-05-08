using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Assignemnt_2_GrocerySystem.Models
{
    class Customer : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        private string userName;
        public string UserName
        {
            get { return userName; }
            set { userName = value; OnPropertyChanged("UserName"); }
        }
        private string password;
        public string Password
        {
            get { return password; }
            set { password = value; OnPropertyChanged("Password"); }
        }
        private int productID;
        public int ProductID
        {
            get { return productID; }
            set { productID = value; OnPropertyChanged("ProductID"); }
        }
        private int quantity;
        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; OnPropertyChanged("Quantity"); }
        }
    }
}