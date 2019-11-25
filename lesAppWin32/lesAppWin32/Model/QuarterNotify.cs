using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace lesAppWin32.Model
{
    class QuarterNotify : INotifyPropertyChanged
    {
        //https://docs.microsoft.com/ru-ru/dotnet/framework/winforms/how-to-implement-the-inotifypropertychanged-interface
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
