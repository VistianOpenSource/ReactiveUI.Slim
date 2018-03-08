using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactiveUI.Slim
{
    /// <summary>
    /// Specification of representation of a member in an expression chain.
    /// </summary>
    public interface IClassPropertyPair : IDisposable
    {
        IClassPropertyPair Parent { get; }
        object Value { get; }

        // perhaps need to just insert an event on the value...
        event EventHandler<ValueChangedEventArgs> ValueChanged;
    }
}
