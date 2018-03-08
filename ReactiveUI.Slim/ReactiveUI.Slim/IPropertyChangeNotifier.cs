using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactiveUI.Slim
{
    /// <summary>
    /// Specification for implementations that can notify when a properties value changes.
    /// </summary>
    public interface IPropertyChangeNotifier : IDisposable
    {
        // event handler for the changes...
        EventHandler<PropertyValueChangedEventArgs> Changed { get; set; }
    }
}
