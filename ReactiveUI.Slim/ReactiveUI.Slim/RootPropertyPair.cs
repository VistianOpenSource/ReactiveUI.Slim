using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactiveUI.Slim
{
    /// <summary>
    /// Simple <see cref="IClassPropertyPair"/> used to represent the root value of an expression chain.
    /// </summary>
    public class RootPropertyPair : IClassPropertyPair
    {
        private object _value;
        public IClassPropertyPair Parent { get; }

        /// <summary>
        /// Get or set the root value.
        /// </summary>
        public object Value
        {
            get { return _value; }
            set
            {
                if (_value == value) return;

                _value = value;
                OnValueChanged(new ValueChangedEventArgs(_value));
            }
        }

        /// <summary>
        /// Raise an event for any listeners for the change of value.
        /// </summary>
        /// <param name="valueChangedEventArgs"></param>
        private void OnValueChanged(ValueChangedEventArgs valueChangedEventArgs)
        {
            ValueChanged?.Invoke(this, valueChangedEventArgs);
        }

        public event EventHandler<ValueChangedEventArgs> ValueChanged;


        /// <summary>
        /// Create a root instance with a specified initial value.
        /// </summary>
        /// <param name="value"></param>
        public RootPropertyPair(object value)
        {
            if (value == null)
            {
                throw new ArgumentException(nameof(value));
            }
            Value = value;
        }

        public void Dispose()
        {
        }
    }
}
