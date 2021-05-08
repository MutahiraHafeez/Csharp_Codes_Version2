using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;
using Assignemnt_2_GrocerySystem.Command;

namespace Assignemnt_2_GrocerySystem.ViewModel
{
    class MainViewModel:BaseViewModel
    {
        private BaseViewModel selectedViewModel;
        public BaseViewModel SelectedViewModel
        {
            get { return selectedViewModel; }
            set { selectedViewModel = value; OnPropertyChanged("SelectedViewModel"); }
        }
        public ICommand UpdateViewCommand { get; set; }
        public MainViewModel()
        {
            UpdateViewCommand = new DelegateCommand(ViewSelector, canExecute);
            SelectedViewModel = new HomeViewModel();
        }
        public void logout()
        {
            MessageBox.Show("hello home");
            SelectedViewModel = new HomeViewModel();
        }
        bool canExecute(object o)
        {
            return true;
        }
        void ViewSelector(object o)
        {

            if ((o as string).Equals("Admin"))
            {
                SelectedViewModel = new AdminViewModel();
            }
            else if ((o as string).Equals("Customer"))
            {
                SelectedViewModel = new CustomerViewModel();
            }
            else if ((o as string).Equals("Home"))
            {
                SelectedViewModel = new HomeViewModel();
            }
        }

    }
}
