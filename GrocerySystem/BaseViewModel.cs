using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Assignemnt_2_GrocerySystem
{
    class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propName)
        {

            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }

        }
    }
}