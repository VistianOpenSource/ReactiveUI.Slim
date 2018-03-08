using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactiveUI.Slim
{
    public class InprPostChangeNotifier : IPropertyChangeNotifier
    {
        private readonly INotifyPropertyChanged _propertyChanged;
        private readonly string _memberName;

        public InprPostChangeNotifier(INotifyPropertyChanged propertyChanged, string memberName)
        {
            _propertyChanged = propertyChanged;
            _memberName = memberName;
            propertyChanged.PropertyChanged += PropertyChangedOnPropertyChanged;
        }

        private void PropertyChangedOnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            if (propertyChangedEventArgs.PropertyName == _memberName)
            {
                Changed.Invoke(this, new PropertyValueChangedEventArgs(_memberName));
            }
        }

        public void Dispose()
        {
            _propertyChanged.PropertyChanged -= PropertyChangedOnPropertyChanged;
        }

        public EventHandler<PropertyValueChangedEventArgs> Changed { get; set; }
    }
}
