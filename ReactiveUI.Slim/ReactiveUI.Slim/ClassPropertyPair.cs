using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactiveUI.Slim
{
    /// <summary>
    /// Represents a single member of a class.
    /// </summary>
    public class ClassPropertyPair : IClassPropertyPair
    {
        /// <summary>
        /// The details of the member that this class monitors.
        /// </summary>
        private readonly MemberDetails _memberDetails;

        /// <summary>
        /// The selector used to construct property change notifiers.
        /// </summary>
        private readonly IPropertyChangeNotifierSelector _changeSelector;

        /// <summary>
        /// The parent <see cref="IClassPropertyPair"/> instance.
        /// </summary>
        public IClassPropertyPair Parent { get; private set; }

        /// <summary>
        /// The current property change notifier
        /// </summary>
        private IPropertyChangeNotifier _propertyChangeNotifier;

        /// <summary>
        /// Create an instance for a specified member, parent.
        /// </summary>
        /// <param name="memberDetails"></param>
        /// <param name="parent"></param>
        /// <param name="changeSelector"></param>
        public ClassPropertyPair(MemberDetails memberDetails, IClassPropertyPair parent, IPropertyChangeNotifierSelector changeSelector)
        {
            if (parent == null)
            {
                throw new ArgumentNullException(nameof(parent));
            }

            if (changeSelector == null)
            {
                throw new ArgumentNullException(nameof(changeSelector));
            }

            _memberDetails = memberDetails;

            _changeSelector = changeSelector;

            SetParent(parent);
        }

        /// <summary>
        /// Record the parent <see cref="IClassPropertyPair"/> and read an initial value.
        /// </summary>
        /// <param name="parent"></param>
        private void SetParent(IClassPropertyPair parent)
        {
            // need to consider fact that we need to 'bin off' any of our current monitors
            Parent = parent;

            // setup a value change listener for when its value changes
            Parent.ValueChanged += Parent_ValueChanged;

            // if there current is a value for the parent...
            if (parent.Value != null)
            {
                SetupMonitorAndReadCurrent();
            }
            else
            {
                SetValue(null);
            }
        }

        /// <summary>
        /// Setup a change notifier for the property and then get the current value.
        /// </summary>
        private void SetupMonitorAndReadCurrent()
        {
            // setup change notifier
            SetupChangeNotifier();

            // 
            // need to evaluate the expression with 
            var newValue = GetCurrentValue();

            SetValue(newValue);
        }

        /// <summary>
        /// Set the current value to a new specified value. If anyone is listening, pass it on.
        /// </summary>
        /// <param name="newValue"></param>
        protected void SetValue(object newValue)
        {
            if (Value == newValue) return;

            Value = newValue;

            //only pass on a new value if not null
            if (newValue != null)
            {
                OnValueChanged(new ValueChangedEventArgs(newValue));
            }
        }

        /// <summary>
        /// The value has changed, tell any event listeners.
        /// </summary>
        /// <param name="args"></param>
        protected void OnValueChanged(ValueChangedEventArgs args)
        {
            ValueChanged?.Invoke(this, args);
        }

        /// <summary>
        /// The underlying value of the parent has changed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Parent_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            SetupMonitorAndReadCurrent();
        }

        /// <summary>
        /// Setup a change notifier and dispose of any current one.
        /// </summary>
        private void SetupChangeNotifier()
        {
            _propertyChangeNotifier?.Dispose();

            _propertyChangeNotifier = CreatePropertyChangeNotifier();

            if (_propertyChangeNotifier != null)
            {
                _propertyChangeNotifier.Changed += PropertyValueChanged;
            }
        }

        /// <summary>
        /// Get the current value of this member.
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// If the current Parent.Value is null then we just pass back a null value.</remarks>
        private object GetCurrentValue()
        {
            return Parent.Value == null ? null : _memberDetails.GetValue(Parent.Value);
        }

        /// <summary>
        /// The members value has changed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="valueChangedEventArgs"></param>
        private void PropertyValueChanged(object sender, PropertyValueChangedEventArgs valueChangedEventArgs)
        {
            // evaluate the current value
            var newValue = GetCurrentValue();

            // and pass it on...
            SetValue(newValue);
        }

        /// <summary>
        /// Create a <see cref="IPropertyChangeNotifier"/> using the previously specified selector.
        /// </summary>
        /// <returns></returns>
        private IPropertyChangeNotifier CreatePropertyChangeNotifier()
        {
            return Parent.Value != null ? _changeSelector.Create(Parent.Value, _memberDetails.Expression) : null;
        }

        /// <summary>
        /// The current value
        /// </summary>
        public object Value { get; internal set; }

        /// <summary>
        /// Event for when the value changes.
        /// </summary>
        public event EventHandler<ValueChangedEventArgs> ValueChanged;


        /// <summary>
        /// Tidy up by disposing the property change notifier and removing any event listeners.
        /// </summary>
        public void Dispose()
        {
            _propertyChangeNotifier?.Dispose();

            Parent.ValueChanged -= Parent_ValueChanged;
        }
    }
}
