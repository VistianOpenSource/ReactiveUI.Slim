using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ReactiveUI.Slim.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Expression<Func<ModelA, string>> testE = (m) => m.B.C.Value;

            var mA = new ModelA() { B = new ModelB() { C = new ModelC() { Value = "hello" } } };
            var swap = new ModelB() { Value = "hello2", C = new ModelC() { Value = "hello2" } };

            mA.WhenAnyValueSlim(testE).Subscribe(v => System.Console.WriteLine($"Slim - Seen Value {v}"));
            mA.WhenAnyValue(testE).Subscribe(v => System.Console.WriteLine($"Full Fat - Seen Value {v}"));

            mA.B = swap;

            System.Console.WriteLine("Press return to exit");
            System.Console.ReadLine();

        }
    }
}
