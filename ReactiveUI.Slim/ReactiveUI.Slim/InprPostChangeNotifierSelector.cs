using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ReactiveUI.Slim
{
    public class InprPostChangeNotifierSelector : IPropertyChangeNotifierSelector
    {
        public IPropertyChangeNotifier Create(object value, Expression property)
        {
            var propertyChanged = value as INotifyPropertyChanged;

            if (propertyChanged == null) return null;

            var memberName = (property as MemberExpression).Member.Name;

            return new InprPostChangeNotifier(propertyChanged, memberName);
        }
    }
}
