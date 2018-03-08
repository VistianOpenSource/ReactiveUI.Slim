using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactiveUI.Slim.Console
{
    public class ModelA : ReactiveObject
    {
        private ModelB _b;

        public ModelB B
        {
            get { return _b; }
            set
            {
                this.RaiseAndSetIfChanged(ref _b, value);
            }
        }
    }

    public class ModelB : ReactiveObject
    {
        private string _value;
        private ModelC _c;

        public string Value
        {
            get { return _value; }
            set
            {
                this.RaiseAndSetIfChanged(ref _value, value);
            }
        }

        public ModelC C
        {
            get { return _c; }
            set { this.RaiseAndSetIfChanged(ref _c, value); }
        }
    }


    public class ModelC : ReactiveObject
    {
        private string _value;

        public string Value
        {
            get { return _value; }
            set
            {
                this.RaiseAndSetIfChanged(ref _value, value);
            }
        }

    }

}
