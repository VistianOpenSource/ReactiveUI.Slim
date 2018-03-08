using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactiveUI.Slim
{
    public class PocoChangeNotifier : IPropertyChangeNotifier
    {
        public void Dispose()
        {
        }

        public EventHandler<PropertyValueChangedEventArgs> Changed { get; set; }
    }
}
