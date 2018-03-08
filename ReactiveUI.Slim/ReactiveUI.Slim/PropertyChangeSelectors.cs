using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactiveUI.Slim
{
    public static class PropertyChangeSelectors
    {
        public static readonly List<IPropertyChangeNotifierSelector> Pre = new List<IPropertyChangeNotifierSelector>()
        {
            new InprPreChangeNotifierSelector(),
            new PocoChangeNotifierSelector()
        };

        public static readonly List<IPropertyChangeNotifierSelector> Post = new List<IPropertyChangeNotifierSelector>()
        {
            new InprPostChangeNotifierSelector(),
            new PocoChangeNotifierSelector()
        };

    }
}
