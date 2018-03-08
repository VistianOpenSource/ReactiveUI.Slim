using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ReactiveUI.Slim
{
    public class PropertyChangeNotifierFactory : IPropertyChangeNotifierSelector
    {
        private readonly IList<IPropertyChangeNotifierSelector> _selectors;

        public PropertyChangeNotifierFactory(IList<IPropertyChangeNotifierSelector> selectors)
        {
            _selectors = selectors;
        }

        public IPropertyChangeNotifier Create(object value, Expression property)
        {
            foreach (var selector in _selectors)
            {
                var notifier = selector.Create(value, property);

                if (notifier != null)
                {
                    return notifier;
                }
            }

            return null;
        }


    }
}
