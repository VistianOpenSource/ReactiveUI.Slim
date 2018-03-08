using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ReactiveUI.Slim
{
    public interface IPropertyChangeNotifierSelector
    {
        IPropertyChangeNotifier Create(object value, Expression property);
    }
}
