using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactiveUI.Slim
{
    /// <summary>
    /// A value has changed for a member of the expression chain.
    /// </summary>
    public class ValueChangedEventArgs : System.EventArgs
    {
        public readonly object Value;

        public ValueChangedEventArgs(object value)
        {
            Value = value;
        }
    }
}
