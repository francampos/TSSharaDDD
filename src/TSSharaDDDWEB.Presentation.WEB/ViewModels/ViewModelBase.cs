using System;
using System.ComponentModel;

namespace TSSharaDDDWEB.Presentation.WEB.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        
        public event PropertyChangedEventHandler PropertyChanged;
    }

}
