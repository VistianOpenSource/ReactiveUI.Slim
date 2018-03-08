using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactiveUI.Slim
{
    public class InprPreChangeNotifier : IPropertyChangeNotifier
    {
        private readonly INotifyPropertyChanging _propertyChanging;
        private readonly string _memberName;

        public InprPreChangeNotifier(INotifyPropertyChanging propertyChanging, string memberName)
        {
            _propertyChanging = propertyChanging;
            _memberName = memberName;
            propertyChanging.PropertyChanging += PropertyChangingOnPropertyChanging;
        }

        private void PropertyChangingOnPropertyChanging(object sender, PropertyChangingEventArgs propertyChangingEventArgs)
        {
            if (propertyChangingEventArgs.PropertyName == _memberName)
            {
                Changed.Invoke(this, new PropertyValueChangedEventArgs(_memberName));
            }
        }

        public void Dispose()
        {
            _propertyChanging.PropertyChanging -= PropertyChangingOnPropertyChanging;
        }

        public EventHandler<PropertyValueChangedEventArgs> Changed { get; set; }
    }
}
