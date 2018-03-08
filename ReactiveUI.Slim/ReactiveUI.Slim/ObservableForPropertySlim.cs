using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactiveUI.Slim
{
    public static class ReactiveNotifyPropertyChangedMixins
    {
        /// <summary>
        /// Create an observable for a property of a class.
        /// </summary>
        /// <typeparam name="TSender"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="this"></param>
        /// <param name="property"></param>
        /// <param name="beforeChange"></param>
        /// <param name="skipInitial"></param>
        /// <returns></returns>
        public static IObservable<TValue> ObservableForPropertySlim<TSender, TValue>(
            this TSender @this,
            Expression<Func<TSender, TValue>> property,
            bool beforeChange = false,
            bool skipInitial = true
        )
        {
            if (@this == null)
            {
                throw new ArgumentNullException(nameof(@this));
            }

            if (property == null)
            {
                throw new ArgumentNullException(nameof(property));
            }

            // construct the appropriate change notifier factory 
            var propertyChangeNotifierFactory = new PropertyChangeNotifierFactory(beforeChange ? PropertyChangeSelectors.Pre : PropertyChangeSelectors.Post);
            // now need to create an observable...

            return Observable.Create<TValue>((observer) =>
            {
                // create the member details chain

                var expressionChain = ExpressionChainExtractor.Default.Decode(property.Body);

                IClassPropertyPair parent = new RootPropertyPair(@this);

                var classPropertyChain = new List<IClassPropertyPair>();

                foreach (var expression in expressionChain)
                {
                    var pair = new ClassPropertyPair(expression, parent, propertyChangeNotifierFactory);

                    parent = pair;

                    classPropertyChain.Add(pair);
                }

                // now then, parent contains the final item, so we need to 
                // monitor the Value and push that along...
                // create an observable from just the final event handler...
                var eventObservable = Observable.FromEventPattern<ValueChangedEventArgs>(
                        (e) => parent.ValueChanged += e,
                        (e) => parent.ValueChanged -= e)
                    .Select(e => (TValue)e.EventArgs.Value);

                // if shouldn't skip the initial value and we DO have a value 
                if (!skipInitial && parent.Value != null)
                {
                    eventObservable = eventObservable.StartWith((TValue)parent.Value);
                }

                eventObservable = eventObservable.DistinctUntilChanged();

                return new CompositeDisposable(classPropertyChain) { eventObservable.Subscribe(observer) };
            });
        }
    }
}
