using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Showcase.WPF.DragDrop.ViewModels
{

    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetProperty<T>(ref T property, T Value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(property, Value))
            {
                return false;
            }
            property = Value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}