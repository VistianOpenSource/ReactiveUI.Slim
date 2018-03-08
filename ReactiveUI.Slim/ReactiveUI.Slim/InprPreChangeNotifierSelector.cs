using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ReactiveUI.Slim
{
    public class InprPreChangeNotifierSelector : IPropertyChangeNotifierSelector
    {
        public IPropertyChangeNotifier Create(object value, Expression property)
        {
            var propertyChanging = value as INotifyPropertyChanging;

            if (propertyChanging == null) return null;

            var memberName = (property as MemberExpression).Member.Name;

            return new InprPreChangeNotifier(propertyChanging, memberName);
        }
    }
}
