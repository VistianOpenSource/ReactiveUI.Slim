using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ReactiveUI.Slim
{
    public class PocoChangeNotifierSelector : IPropertyChangeNotifierSelector
    {
        public static readonly IPropertyChangeNotifier NullChangeNotifier = new PocoChangeNotifier();
        public IPropertyChangeNotifier Create(object value, Expression property)
        {
            return NullChangeNotifier;
        }
    }
}
