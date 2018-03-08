using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactiveUI.Slim
{
    public class PropertyValueChangedEventArgs : System.EventArgs
    {
        public readonly string Name;

        public PropertyValueChangedEventArgs(string name)
        {
            Name = name;
        }
    }
}
