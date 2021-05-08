using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Assignemnt_2_GrocerySystem.Models
{
    class Admin : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        private int productID;
        public int ProductID
        {
            get { return productID; }
            set { productID = value; OnPropertyChanged("ProductID"); }
        }
        private string productName;
        public string ProductName
        {
            get { return productName; }
            set { productName = value; OnPropertyChanged("ProductID"); }
        }
        private int price;
        public int Price
        {
            get { return price; }
            set { price = value; OnPropertyChanged("ProductID"); }
        }
        private int quantity;
        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; OnPropertyChanged("ProductID"); }
        }
    }
}
