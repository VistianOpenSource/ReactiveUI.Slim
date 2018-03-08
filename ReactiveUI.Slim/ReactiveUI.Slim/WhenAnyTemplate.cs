using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;


namespace ReactiveUI.Slim
{
    public static class WhenAnySlimMixin
    {
        /// <summary>
        /// WhenAnyValue allows you to observe whenever the value of a
        /// property on an object has changed, providing an initial value when
        /// the Observable is set up, unlike ObservableForProperty(). Use this
        /// method in constructors to set up bindings between properties that also
        /// need an initial setup.
        /// </summary>
        public static IObservable<TRet> WhenAnyValueSlim<TSender, TRet>(this TSender This,
                            Expression<Func<TSender, TRet>> property1)
        {
            return This.WhenAnySlim(property1, (TRet c1) => c1);
        }

                
        
                                
        
        /// <summary>
        /// WhenAnyValue allows you to observe whenever the value of one or more
        /// properties on an object have changed, providing an initial value when
        /// the Observable is set up, unlike ObservableForProperty(). Use this
        /// method in constructors to set up bindings between properties that also
        /// need an initial setup.
        /// </summary>
        public static IObservable<TRet> WhenAnyValueSlim<TSender, TRet, T1>(this TSender This,
                            Expression<Func<TSender, T1>> property1,
                            Func<T1, TRet> selector)
        {
            return This.WhenAnySlim(property1,
                                (c1) =>
                                    selector(c1));
        }

        /// <summary>
        /// WhenAny allows you to observe whenever one or more properties on an
        /// object have changed, providing an initial value when the Observable
        /// is set up, unlike ObservableForProperty(). Use this method in
        /// constructors to set up bindings between properties that also need an
        /// initial setup.
        /// </summary>
        public static IObservable<TRet> WhenAnySlim<TSender, TRet, T1>(this TSender This,
                            Expression<Func<TSender, T1>> property1,
                            Func<T1, TRet> selector)
        {
                            return This.ObservableForPropertySlim(property1, false, false).Select(selector);
                    }


            
        
                                
                /// <summary>
        /// WhenAnyValue allows you to observe whenever the value of one or more
        /// properties on an object have changed, providing an initial value when
        /// the Observable is set up, unlike ObservableForProperty(). Use this
        /// method in constructors to set up bindings between properties that also
        /// need an initial setup.ssss
		
        /// </summary>
        public static IObservable<Tuple<T1,T2>> WhenAnyValueSlim<TSender, T1,T2>(this TSender This,
                            Expression<Func<TSender, T1>> property1,
                            Expression<Func<TSender, T2>> property2
            )
        {
            return This.WhenAnySlim(property1, property2,
                                (c1, c2) =>
                                    Tuple.Create(c1, c2));
        }
        
        /// <summary>
        /// WhenAnyValue allows you to observe whenever the value of one or more
        /// properties on an object have changed, providing an initial value when
        /// the Observable is set up, unlike ObservableForProperty(). Use this
        /// method in constructors to set up bindings between properties that also
        /// need an initial setup.
        /// </summary>
        public static IObservable<TRet> WhenAnyValueSlim<TSender, TRet, T1,T2>(this TSender This,
                            Expression<Func<TSender, T1>> property1,
                            Expression<Func<TSender, T2>> property2,
                            Func<T1,T2, TRet> selector)
        {
            return This.WhenAnySlim(property1, property2,
                                (c1, c2) =>
                                    selector(c1, c2));
        }

        /// <summary>
        /// WhenAny allows you to observe whenever one or more properties on an
        /// object have changed, providing an initial value when the Observable
        /// is set up, unlike ObservableForProperty(). Use this method in
        /// constructors to set up bindings between properties that also need an
        /// initial setup.
        /// </summary>
        public static IObservable<TRet> WhenAnySlim<TSender, TRet, T1,T2>(this TSender This,
                            Expression<Func<TSender, T1>> property1,
                            Expression<Func<TSender, T2>> property2,
                            Func<T1, T2, TRet> selector)
        {
                        return Observable.CombineLatest(
                                    This.ObservableForPropertySlim(property1, false, false),
                                    This.ObservableForPropertySlim(property2, false, false),
                                selector
            );
                    }


            
        
                                
                /// <summary>
        /// WhenAnyValue allows you to observe whenever the value of one or more
        /// properties on an object have changed, providing an initial value when
        /// the Observable is set up, unlike ObservableForProperty(). Use this
        /// method in constructors to set up bindings between properties that also
        /// need an initial setup.ssss
		
        /// </summary>
        public static IObservable<Tuple<T1,T2,T3>> WhenAnyValueSlim<TSender, T1,T2,T3>(this TSender This,
                            Expression<Func<TSender, T1>> property1,
                            Expression<Func<TSender, T2>> property2,
                            Expression<Func<TSender, T3>> property3
            )
        {
            return This.WhenAnySlim(property1, property2, property3,
                                (c1, c2, c3) =>
                                    Tuple.Create(c1, c2, c3));
        }
        
        /// <summary>
        /// WhenAnyValue allows you to observe whenever the value of one or more
        /// properties on an object have changed, providing an initial value when
        /// the Observable is set up, unlike ObservableForProperty(). Use this
        /// method in constructors to set up bindings between properties that also
        /// need an initial setup.
        /// </summary>
        public static IObservable<TRet> WhenAnyValueSlim<TSender, TRet, T1,T2,T3>(this TSender This,
                            Expression<Func<TSender, T1>> property1,
                            Expression<Func<TSender, T2>> property2,
                            Expression<Func<TSender, T3>> property3,
                            Func<T1,T2,T3, TRet> selector)
        {
            return This.WhenAnySlim(property1, property2, property3,
                                (c1, c2, c3) =>
                                    selector(c1, c2, c3));
        }

        /// <summary>
        /// WhenAny allows you to observe whenever one or more properties on an
        /// object have changed, providing an initial value when the Observable
        /// is set up, unlike ObservableForProperty(). Use this method in
        /// constructors to set up bindings between properties that also need an
        /// initial setup.
        /// </summary>
        public static IObservable<TRet> WhenAnySlim<TSender, TRet, T1,T2,T3>(this TSender This,
                            Expression<Func<TSender, T1>> property1,
                            Expression<Func<TSender, T2>> property2,
                            Expression<Func<TSender, T3>> property3,
                            Func<T1, T2, T3, TRet> selector)
        {
                        return Observable.CombineLatest(
                                    This.ObservableForPropertySlim(property1, false, false),
                                    This.ObservableForPropertySlim(property2, false, false),
                                    This.ObservableForPropertySlim(property3, false, false),
                                selector
            );
                    }


            
        
                                
                /// <summary>
        /// WhenAnyValue allows you to observe whenever the value of one or more
        /// properties on an object have changed, providing an initial value when
        /// the Observable is set up, unlike ObservableForProperty(). Use this
        /// method in constructors to set up bindings between properties that also
        /// need an initial setup.ssss
		
        /// </summary>
        public static IObservable<Tuple<T1,T2,T3,T4>> WhenAnyValueSlim<TSender, T1,T2,T3,T4>(this TSender This,
                            Expression<Func<TSender, T1>> property1,
                            Expression<Func<TSender, T2>> property2,
                            Expression<Func<TSender, T3>> property3,
                            Expression<Func<TSender, T4>> property4
            )
        {
            return This.WhenAnySlim(property1, property2, property3, property4,
                                (c1, c2, c3, c4) =>
                                    Tuple.Create(c1, c2, c3, c4));
        }
        
        /// <summary>
        /// WhenAnyValue allows you to observe whenever the value of one or more
        /// properties on an object have changed, providing an initial value when
        /// the Observable is set up, unlike ObservableForProperty(). Use this
        /// method in constructors to set up bindings between properties that also
        /// need an initial setup.
        /// </summary>
        public static IObservable<TRet> WhenAnyValueSlim<TSender, TRet, T1,T2,T3,T4>(this TSender This,
                            Expression<Func<TSender, T1>> property1,
                            Expression<Func<TSender, T2>> property2,
                            Expression<Func<TSender, T3>> property3,
                            Expression<Func<TSender, T4>> property4,
                            Func<T1,T2,T3,T4, TRet> selector)
        {
            return This.WhenAnySlim(property1, property2, property3, property4,
                                (c1, c2, c3, c4) =>
                                    selector(c1, c2, c3, c4));
        }

        /// <summary>
        /// WhenAny allows you to observe whenever one or more properties on an
        /// object have changed, providing an initial value when the Observable
        /// is set up, unlike ObservableForProperty(). Use this method in
        /// constructors to set up bindings between properties that also need an
        /// initial setup.
        /// </summary>
        public static IObservable<TRet> WhenAnySlim<TSender, TRet, T1,T2,T3,T4>(this TSender This,
                            Expression<Func<TSender, T1>> property1,
                            Expression<Func<TSender, T2>> property2,
                            Expression<Func<TSender, T3>> property3,
                            Expression<Func<TSender, T4>> property4,
                            Func<T1, T2, T3, T4, TRet> selector)
        {
                        return Observable.CombineLatest(
                                    This.ObservableForPropertySlim(property1, false, false),
                                    This.ObservableForPropertySlim(property2, false, false),
                                    This.ObservableForPropertySlim(property3, false, false),
                                    This.ObservableForPropertySlim(property4, false, false),
                                selector
            );
                    }


            
        
                                
                /// <summary>
        /// WhenAnyValue allows you to observe whenever the value of one or more
        /// properties on an object have changed, providing an initial value when
        /// the Observable is set up, unlike ObservableForProperty(). Use this
        /// method in constructors to set up bindings between properties that also
        /// need an initial setup.ssss
		
        /// </summary>
        public static IObservable<Tuple<T1,T2,T3,T4,T5>> WhenAnyValueSlim<TSender, T1,T2,T3,T4,T5>(this TSender This,
                            Expression<Func<TSender, T1>> property1,
                            Expression<Func<TSender, T2>> property2,
                            Expression<Func<TSender, T3>> property3,
                            Expression<Func<TSender, T4>> property4,
                            Expression<Func<TSender, T5>> property5
            )
        {
            return This.WhenAnySlim(property1, property2, property3, property4, property5,
                                (c1, c2, c3, c4, c5) =>
                                    Tuple.Create(c1, c2, c3, c4, c5));
        }
        
        /// <summary>
        /// WhenAnyValue allows you to observe whenever the value of one or more
        /// properties on an object have changed, providing an initial value when
        /// the Observable is set up, unlike ObservableForProperty(). Use this
        /// method in constructors to set up bindings between properties that also
        /// need an initial setup.
        /// </summary>
        public static IObservable<TRet> WhenAnyValueSlim<TSender, TRet, T1,T2,T3,T4,T5>(this TSender This,
                            Expression<Func<TSender, T1>> property1,
                            Expression<Func<TSender, T2>> property2,
                            Expression<Func<TSender, T3>> property3,
                            Expression<Func<TSender, T4>> property4,
                            Expression<Func<TSender, T5>> property5,
                            Func<T1,T2,T3,T4,T5, TRet> selector)
        {
            return This.WhenAnySlim(property1, property2, property3, property4, property5,
                                (c1, c2, c3, c4, c5) =>
                                    selector(c1, c2, c3, c4, c5));
        }

        /// <summary>
        /// WhenAny allows you to observe whenever one or more properties on an
        /// object have changed, providing an initial value when the Observable
        /// is set up, unlike ObservableForProperty(). Use this method in
        /// constructors to set up bindings between properties that also need an
        /// initial setup.
        /// </summary>
        public static IObservable<TRet> WhenAnySlim<TSender, TRet, T1,T2,T3,T4,T5>(this TSender This,
                            Expression<Func<TSender, T1>> property1,
                            Expression<Func<TSender, T2>> property2,
                            Expression<Func<TSender, T3>> property3,
                            Expression<Func<TSender, T4>> property4,
                            Expression<Func<TSender, T5>> property5,
                            Func<T1, T2, T3, T4, T5, TRet> selector)
        {
                        return Observable.CombineLatest(
                                    This.ObservableForPropertySlim(property1, false, false),
                                    This.ObservableForPropertySlim(property2, false, false),
                                    This.ObservableForPropertySlim(property3, false, false),
                                    This.ObservableForPropertySlim(property4, false, false),
                                    This.ObservableForPropertySlim(property5, false, false),
                                selector
            );
                    }


            
        
                                
                /// <summary>
        /// WhenAnyValue allows you to observe whenever the value of one or more
        /// properties on an object have changed, providing an initial value when
        /// the Observable is set up, unlike ObservableForProperty(). Use this
        /// method in constructors to set up bindings between properties that also
        /// need an initial setup.ssss
		
        /// </summary>
        public static IObservable<Tuple<T1,T2,T3,T4,T5,T6>> WhenAnyValueSlim<TSender, T1,T2,T3,T4,T5,T6>(this TSender This,
                            Expression<Func<TSender, T1>> property1,
                            Expression<Func<TSender, T2>> property2,
                            Expression<Func<TSender, T3>> property3,
                            Expression<Func<TSender, T4>> property4,
                            Expression<Func<TSender, T5>> property5,
                            Expression<Func<TSender, T6>> property6
            )
        {
            return This.WhenAnySlim(property1, property2, property3, property4, property5, property6,
                                (c1, c2, c3, c4, c5, c6) =>
                                    Tuple.Create(c1, c2, c3, c4, c5, c6));
        }
        
        /// <summary>
        /// WhenAnyValue allows you to observe whenever the value of one or more
        /// properties on an object have changed, providing an initial value when
        /// the Observable is set up, unlike ObservableForProperty(). Use this
        /// method in constructors to set up bindings between properties that also
        /// need an initial setup.
        /// </summary>
        public static IObservable<TRet> WhenAnyValueSlim<TSender, TRet, T1,T2,T3,T4,T5,T6>(this TSender This,
                            Expression<Func<TSender, T1>> property1,
                            Expression<Func<TSender, T2>> property2,
                            Expression<Func<TSender, T3>> property3,
                            Expression<Func<TSender, T4>> property4,
                            Expression<Func<TSender, T5>> property5,
                            Expression<Func<TSender, T6>> property6,
                            Func<T1,T2,T3,T4,T5,T6, TRet> selector)
        {
            return This.WhenAnySlim(property1, property2, property3, property4, property5, property6,
                                (c1, c2, c3, c4, c5, c6) =>
                                    selector(c1, c2, c3, c4, c5, c6));
        }

        /// <summary>
        /// WhenAny allows you to observe whenever one or more properties on an
        /// object have changed, providing an initial value when the Observable
        /// is set up, unlike ObservableForProperty(). Use this method in
        /// constructors to set up bindings between properties that also need an
        /// initial setup.
        /// </summary>
        public static IObservable<TRet> WhenAnySlim<TSender, TRet, T1,T2,T3,T4,T5,T6>(this TSender This,
                            Expression<Func<TSender, T1>> property1,
                            Expression<Func<TSender, T2>> property2,
                            Expression<Func<TSender, T3>> property3,
                            Expression<Func<TSender, T4>> property4,
                            Expression<Func<TSender, T5>> property5,
                            Expression<Func<TSender, T6>> property6,
                            Func<T1, T2, T3, T4, T5, T6, TRet> selector)
        {
                        return Observable.CombineLatest(
                                    This.ObservableForPropertySlim(property1, false, false),
                                    This.ObservableForPropertySlim(property2, false, false),
                                    This.ObservableForPropertySlim(property3, false, false),
                                    This.ObservableForPropertySlim(property4, false, false),
                                    This.ObservableForPropertySlim(property5, false, false),
                                    This.ObservableForPropertySlim(property6, false, false),
                                selector
            );
                    }


            
        
                                
                /// <summary>
        /// WhenAnyValue allows you to observe whenever the value of one or more
        /// properties on an object have changed, providing an initial value when
        /// the Observable is set up, unlike ObservableForProperty(). Use this
        /// method in constructors to set up bindings between properties that also
        /// need an initial setup.ssss
		
        /// </summary>
        public static IObservable<Tuple<T1,T2,T3,T4,T5,T6,T7>> WhenAnyValueSlim<TSender, T1,T2,T3,T4,T5,T6,T7>(this TSender This,
                            Expression<Func<TSender, T1>> property1,
                            Expression<Func<TSender, T2>> property2,
                            Expression<Func<TSender, T3>> property3,
                            Expression<Func<TSender, T4>> property4,
                            Expression<Func<TSender, T5>> property5,
                            Expression<Func<TSender, T6>> property6,
                            Expression<Func<TSender, T7>> property7
            )
        {
            return This.WhenAnySlim(property1, property2, property3, property4, property5, property6, property7,
                                (c1, c2, c3, c4, c5, c6, c7) =>
                                    Tuple.Create(c1, c2, c3, c4, c5, c6, c7));
        }
        
        /// <summary>
        /// WhenAnyValue allows you to observe whenever the value of one or more
        /// properties on an object have changed, providing an initial value when
        /// the Observable is set up, unlike ObservableForProperty(). Use this
        /// method in constructors to set up bindings between properties that also
        /// need an initial setup.
        /// </summary>
        public static IObservable<TRet> WhenAnyValueSlim<TSender, TRet, T1,T2,T3,T4,T5,T6,T7>(this TSender This,
                            Expression<Func<TSender, T1>> property1,
                            Expression<Func<TSender, T2>> property2,
                            Expression<Func<TSender, T3>> property3,
                            Expression<Func<TSender, T4>> property4,
                            Expression<Func<TSender, T5>> property5,
                            Expression<Func<TSender, T6>> property6,
                            Expression<Func<TSender, T7>> property7,
                            Func<T1,T2,T3,T4,T5,T6,T7, TRet> selector)
        {
            return This.WhenAnySlim(property1, property2, property3, property4, property5, property6, property7,
                                (c1, c2, c3, c4, c5, c6, c7) =>
                                    selector(c1, c2, c3, c4, c5, c6, c7));
        }

        /// <summary>
        /// WhenAny allows you to observe whenever one or more properties on an
        /// object have changed, providing an initial value when the Observable
        /// is set up, unlike ObservableForProperty(). Use this method in
        /// constructors to set up bindings between properties that also need an
        /// initial setup.
        /// </summary>
        public static IObservable<TRet> WhenAnySlim<TSender, TRet, T1,T2,T3,T4,T5,T6,T7>(this TSender This,
                            Expression<Func<TSender, T1>> property1,
                            Expression<Func<TSender, T2>> property2,
                            Expression<Func<TSender, T3>> property3,
                            Expression<Func<TSender, T4>> property4,
                            Expression<Func<TSender, T5>> property5,
                            Expression<Func<TSender, T6>> property6,
                            Expression<Func<TSender, T7>> property7,
                            Func<T1, T2, T3, T4, T5, T6, T7, TRet> selector)
        {
                        return Observable.CombineLatest(
                                    This.ObservableForPropertySlim(property1, false, false),
                                    This.ObservableForPropertySlim(property2, false, false),
                                    This.ObservableForPropertySlim(property3, false, false),
                                    This.ObservableForPropertySlim(property4, false, false),
                                    This.ObservableForPropertySlim(property5, false, false),
                                    This.ObservableForPropertySlim(property6, false, false),
                                    This.ObservableForPropertySlim(property7, false, false),
                                selector
            );
                    }


            
        
                                
        
        /// <summary>
        /// WhenAnyValue allows you to observe whenever the value of one or more
        /// properties on an object have changed, providing an initial value when
        /// the Observable is set up, unlike ObservableForProperty(). Use this
        /// method in constructors to set up bindings between properties that also
        /// need an initial setup.
        /// </summary>
        public static IObservable<TRet> WhenAnyValueSlim<TSender, TRet, T1,T2,T3,T4,T5,T6,T7,T8>(this TSender This,
                            Expression<Func<TSender, T1>> property1,
                            Expression<Func<TSender, T2>> property2,
                            Expression<Func<TSender, T3>> property3,
                            Expression<Func<TSender, T4>> property4,
                            Expression<Func<TSender, T5>> property5,
                            Expression<Func<TSender, T6>> property6,
                            Expression<Func<TSender, T7>> property7,
                            Expression<Func<TSender, T8>> property8,
                            Func<T1,T2,T3,T4,T5,T6,T7,T8, TRet> selector)
        {
            return This.WhenAnySlim(property1, property2, property3, property4, property5, property6, property7, property8,
                                (c1, c2, c3, c4, c5, c6, c7, c8) =>
                                    selector(c1, c2, c3, c4, c5, c6, c7, c8));
        }

        /// <summary>
        /// WhenAny allows you to observe whenever one or more properties on an
        /// object have changed, providing an initial value when the Observable
        /// is set up, unlike ObservableForProperty(). Use this method in
        /// constructors to set up bindings between properties that also need an
        /// initial setup.
        /// </summary>
        public static IObservable<TRet> WhenAnySlim<TSender, TRet, T1,T2,T3,T4,T5,T6,T7,T8>(this TSender This,
                            Expression<Func<TSender, T1>> property1,
                            Expression<Func<TSender, T2>> property2,
                            Expression<Func<TSender, T3>> property3,
                            Expression<Func<TSender, T4>> property4,
                            Expression<Func<TSender, T5>> property5,
                            Expression<Func<TSender, T6>> property6,
                            Expression<Func<TSender, T7>> property7,
                            Expression<Func<TSender, T8>> property8,
                            Func<T1, T2, T3, T4, T5, T6, T7, T8, TRet> selector)
        {
                        return Observable.CombineLatest(
                                    This.ObservableForPropertySlim(property1, false, false),
                                    This.ObservableForPropertySlim(property2, false, false),
                                    This.ObservableForPropertySlim(property3, false, false),
                                    This.ObservableForPropertySlim(property4, false, false),
                                    This.ObservableForPropertySlim(property5, false, false),
                                    This.ObservableForPropertySlim(property6, false, false),
                                    This.ObservableForPropertySlim(property7, false, false),
                                    This.ObservableForPropertySlim(property8, false, false),
                                selector
            );
                    }


            
        
                                
        
        /// <summary>
        /// WhenAnyValue allows you to observe whenever the value of one or more
        /// properties on an object have changed, providing an initial value when
        /// the Observable is set up, unlike ObservableForProperty(). Use this
        /// method in constructors to set up bindings between properties that also
        /// need an initial setup.
        /// </summary>
        public static IObservable<TRet> WhenAnyValueSlim<TSender, TRet, T1,T2,T3,T4,T5,T6,T7,T8,T9>(this TSender This,
                            Expression<Func<TSender, T1>> property1,
                            Expression<Func<TSender, T2>> property2,
                            Expression<Func<TSender, T3>> property3,
                            Expression<Func<TSender, T4>> property4,
                            Expression<Func<TSender, T5>> property5,
                            Expression<Func<TSender, T6>> property6,
                            Expression<Func<TSender, T7>> property7,
                            Expression<Func<TSender, T8>> property8,
                            Expression<Func<TSender, T9>> property9,
                            Func<T1,T2,T3,T4,T5,T6,T7,T8,T9, TRet> selector)
        {
            return This.WhenAnySlim(property1, property2, property3, property4, property5, property6, property7, property8, property9,
                                (c1, c2, c3, c4, c5, c6, c7, c8, c9) =>
                                    selector(c1, c2, c3, c4, c5, c6, c7, c8, c9));
        }

        /// <summary>
        /// WhenAny allows you to observe whenever one or more properties on an
        /// object have changed, providing an initial value when the Observable
        /// is set up, unlike ObservableForProperty(). Use this method in
        /// constructors to set up bindings between properties that also need an
        /// initial setup.
        /// </summary>
        public static IObservable<TRet> WhenAnySlim<TSender, TRet, T1,T2,T3,T4,T5,T6,T7,T8,T9>(this TSender This,
                            Expression<Func<TSender, T1>> property1,
                            Expression<Func<TSender, T2>> property2,
                            Expression<Func<TSender, T3>> property3,
                            Expression<Func<TSender, T4>> property4,
                            Expression<Func<TSender, T5>> property5,
                            Expression<Func<TSender, T6>> property6,
                            Expression<Func<TSender, T7>> property7,
                            Expression<Func<TSender, T8>> property8,
                            Expression<Func<TSender, T9>> property9,
                            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TRet> selector)
        {
                        return Observable.CombineLatest(
                                    This.ObservableForPropertySlim(property1, false, false),
                                    This.ObservableForPropertySlim(property2, false, false),
                                    This.ObservableForPropertySlim(property3, false, false),
                                    This.ObservableForPropertySlim(property4, false, false),
                                    This.ObservableForPropertySlim(property5, false, false),
                                    This.ObservableForPropertySlim(property6, false, false),
                                    This.ObservableForPropertySlim(property7, false, false),
                                    This.ObservableForPropertySlim(property8, false, false),
                                    This.ObservableForPropertySlim(property9, false, false),
                                selector
            );
                    }


            
        
                                
        
        /// <summary>
        /// WhenAnyValue allows you to observe whenever the value of one or more
        /// properties on an object have changed, providing an initial value when
        /// the Observable is set up, unlike ObservableForProperty(). Use this
        /// method in constructors to set up bindings between properties that also
        /// need an initial setup.
        /// </summary>
        public static IObservable<TRet> WhenAnyValueSlim<TSender, TRet, T1,T2,T3,T4,T5,T6,T7,T8,T9,T10>(this TSender This,
                            Expression<Func<TSender, T1>> property1,
                            Expression<Func<TSender, T2>> property2,
                            Expression<Func<TSender, T3>> property3,
                            Expression<Func<TSender, T4>> property4,
                            Expression<Func<TSender, T5>> property5,
                            Expression<Func<TSender, T6>> property6,
                            Expression<Func<TSender, T7>> property7,
                            Expression<Func<TSender, T8>> property8,
                            Expression<Func<TSender, T9>> property9,
                            Expression<Func<TSender, T10>> property10,
                            Func<T1,T2,T3,T4,T5,T6,T7,T8,T9,T10, TRet> selector)
        {
            return This.WhenAnySlim(property1, property2, property3, property4, property5, property6, property7, property8, property9, property10,
                                (c1, c2, c3, c4, c5, c6, c7, c8, c9, c10) =>
                                    selector(c1, c2, c3, c4, c5, c6, c7, c8, c9, c10));
        }

        /// <summary>
        /// WhenAny allows you to observe whenever one or more properties on an
        /// object have changed, providing an initial value when the Observable
        /// is set up, unlike ObservableForProperty(). Use this method in
        /// constructors to set up bindings between properties that also need an
        /// initial setup.
        /// </summary>
        public static IObservable<TRet> WhenAnySlim<TSender, TRet, T1,T2,T3,T4,T5,T6,T7,T8,T9,T10>(this TSender This,
                            Expression<Func<TSender, T1>> property1,
                            Expression<Func<TSender, T2>> property2,
                            Expression<Func<TSender, T3>> property3,
                            Expression<Func<TSender, T4>> property4,
                            Expression<Func<TSender, T5>> property5,
                            Expression<Func<TSender, T6>> property6,
                            Expression<Func<TSender, T7>> property7,
                            Expression<Func<TSender, T8>> property8,
                            Expression<Func<TSender, T9>> property9,
                            Expression<Func<TSender, T10>> property10,
                            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TRet> selector)
        {
                        return Observable.CombineLatest(
                                    This.ObservableForPropertySlim(property1, false, false),
                                    This.ObservableForPropertySlim(property2, false, false),
                                    This.ObservableForPropertySlim(property3, false, false),
                                    This.ObservableForPropertySlim(property4, false, false),
                                    This.ObservableForPropertySlim(property5, false, false),
                                    This.ObservableForPropertySlim(property6, false, false),
                                    This.ObservableForPropertySlim(property7, false, false),
                                    This.ObservableForPropertySlim(property8, false, false),
                                    This.ObservableForPropertySlim(property9, false, false),
                                    This.ObservableForPropertySlim(property10, false, false),
                                selector
            );
                    }


            
        
                                
        
        /// <summary>
        /// WhenAnyValue allows you to observe whenever the value of one or more
        /// properties on an object have changed, providing an initial value when
        /// the Observable is set up, unlike ObservableForProperty(). Use this
        /// method in constructors to set up bindings between properties that also
        /// need an initial setup.
        /// </summary>
        public static IObservable<TRet> WhenAnyValueSlim<TSender, TRet, T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11>(this TSender This,
                            Expression<Func<TSender, T1>> property1,
                            Expression<Func<TSender, T2>> property2,
                            Expression<Func<TSender, T3>> property3,
                            Expression<Func<TSender, T4>> property4,
                            Expression<Func<TSender, T5>> property5,
                            Expression<Func<TSender, T6>> property6,
                            Expression<Func<TSender, T7>> property7,
                            Expression<Func<TSender, T8>> property8,
                            Expression<Func<TSender, T9>> property9,
                            Expression<Func<TSender, T10>> property10,
                            Expression<Func<TSender, T11>> property11,
                            Func<T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11, TRet> selector)
        {
            return This.WhenAnySlim(property1, property2, property3, property4, property5, property6, property7, property8, property9, property10, property11,
                                (c1, c2, c3, c4, c5, c6, c7, c8, c9, c10, c11) =>
                                    selector(c1, c2, c3, c4, c5, c6, c7, c8, c9, c10, c11));
        }

        /// <summary>
        /// WhenAny allows you to observe whenever one or more properties on an
        /// object have changed, providing an initial value when the Observable
        /// is set up, unlike ObservableForProperty(). Use this method in
        /// constructors to set up bindings between properties that also need an
        /// initial setup.
        /// </summary>
        public static IObservable<TRet> WhenAnySlim<TSender, TRet, T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11>(this TSender This,
                            Expression<Func<TSender, T1>> property1,
                            Expression<Func<TSender, T2>> property2,
                            Expression<Func<TSender, T3>> property3,
                            Expression<Func<TSender, T4>> property4,
                            Expression<Func<TSender, T5>> property5,
                            Expression<Func<TSender, T6>> property6,
                            Expression<Func<TSender, T7>> property7,
                            Expression<Func<TSender, T8>> property8,
                            Expression<Func<TSender, T9>> property9,
                            Expression<Func<TSender, T10>> property10,
                            Expression<Func<TSender, T11>> property11,
                            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TRet> selector)
        {
                        return Observable.CombineLatest(
                                    This.ObservableForPropertySlim(property1, false, false),
                                    This.ObservableForPropertySlim(property2, false, false),
                                    This.ObservableForPropertySlim(property3, false, false),
                                    This.ObservableForPropertySlim(property4, false, false),
                                    This.ObservableForPropertySlim(property5, false, false),
                                    This.ObservableForPropertySlim(property6, false, false),
                                    This.ObservableForPropertySlim(property7, false, false),
                                    This.ObservableForPropertySlim(property8, false, false),
                                    This.ObservableForPropertySlim(property9, false, false),
                                    This.ObservableForPropertySlim(property10, false, false),
                                    This.ObservableForPropertySlim(property11, false, false),
                                selector
            );
                    }


            
        
                                
        
        /// <summary>
        /// WhenAnyValue allows you to observe whenever the value of one or more
        /// properties on an object have changed, providing an initial value when
        /// the Observable is set up, unlike ObservableForProperty(). Use this
        /// method in constructors to set up bindings between properties that also
        /// need an initial setup.
        /// </summary>
        public static IObservable<TRet> WhenAnyValueSlim<TSender, TRet, T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12>(this TSender This,
                            Expression<Func<TSender, T1>> property1,
                            Expression<Func<TSender, T2>> property2,
                            Expression<Func<TSender, T3>> property3,
                            Expression<Func<TSender, T4>> property4,
                            Expression<Func<TSender, T5>> property5,
                            Expression<Func<TSender, T6>> property6,
                            Expression<Func<TSender, T7>> property7,
                            Expression<Func<TSender, T8>> property8,
                            Expression<Func<TSender, T9>> property9,
                            Expression<Func<TSender, T10>> property10,
                            Expression<Func<TSender, T11>> property11,
                            Expression<Func<TSender, T12>> property12,
                            Func<T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12, TRet> selector)
        {
            return This.WhenAnySlim(property1, property2, property3, property4, property5, property6, property7, property8, property9, property10, property11, property12,
                                (c1, c2, c3, c4, c5, c6, c7, c8, c9, c10, c11, c12) =>
                                    selector(c1, c2, c3, c4, c5, c6, c7, c8, c9, c10, c11, c12));
        }

        /// <summary>
        /// WhenAny allows you to observe whenever one or more properties on an
        /// object have changed, providing an initial value when the Observable
        /// is set up, unlike ObservableForProperty(). Use this method in
        /// constructors to set up bindings between properties that also need an
        /// initial setup.
        /// </summary>
        public static IObservable<TRet> WhenAnySlim<TSender, TRet, T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12>(this TSender This,
                            Expression<Func<TSender, T1>> property1,
                            Expression<Func<TSender, T2>> property2,
                            Expression<Func<TSender, T3>> property3,
                            Expression<Func<TSender, T4>> property4,
                            Expression<Func<TSender, T5>> property5,
                            Expression<Func<TSender, T6>> property6,
                            Expression<Func<TSender, T7>> property7,
                            Expression<Func<TSender, T8>> property8,
                            Expression<Func<TSender, T9>> property9,
                            Expression<Func<TSender, T10>> property10,
                            Expression<Func<TSender, T11>> property11,
                            Expression<Func<TSender, T12>> property12,
                            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TRet> selector)
        {
                        return Observable.CombineLatest(
                                    This.ObservableForPropertySlim(property1, false, false),
                                    This.ObservableForPropertySlim(property2, false, false),
                                    This.ObservableForPropertySlim(property3, false, false),
                                    This.ObservableForPropertySlim(property4, false, false),
                                    This.ObservableForPropertySlim(property5, false, false),
                                    This.ObservableForPropertySlim(property6, false, false),
                                    This.ObservableForPropertySlim(property7, false, false),
                                    This.ObservableForPropertySlim(property8, false, false),
                                    This.ObservableForPropertySlim(property9, false, false),
                                    This.ObservableForPropertySlim(property10, false, false),
                                    This.ObservableForPropertySlim(property11, false, false),
                                    This.ObservableForPropertySlim(property12, false, false),
                                selector
            );
                    }


        }

    public static class WhenAnyObservableSlimMixin
    {
        public static IObservable<TRet> WhenAnyObservableSlim<TSender, TRet>(this TSender This, Expression<Func<TSender, IObservable<TRet>>> obs1)
        {
            return This.WhenAnySlim(obs1, x => x.EmptyIfNull()).Switch();
        }

        public static IObservable<TRet> WhenAnyObservableSlim<TSender, TRet>(this TSender This, Expression<Func<TSender, IObservable<TRet>>> obs1, Expression<Func<TSender, IObservable<TRet>>> obs2)
        {
            return This.WhenAnySlim(obs1, obs2, (o1, o2) => new[] {o1.EmptyIfNull(), o2.EmptyIfNull()})
                .Select(x => x.Merge()).Switch();
        }
        public static IObservable<TRet> WhenAnyObservableSlim<TSender, TRet>(this TSender This, Expression<Func<TSender, IObservable<TRet>>> obs1, Expression<Func<TSender, IObservable<TRet>>> obs2, Expression<Func<TSender, IObservable<TRet>>> obs3)
        {
            return This.WhenAnySlim(obs1, obs2, obs3, (o1, o2, o3) => new[] {o1.EmptyIfNull(), o2.EmptyIfNull(), o3.EmptyIfNull()})
                .Select(x => x.Merge()).Switch();
        }
        public static IObservable<TRet> WhenAnyObservableSlim<TSender, TRet>(this TSender This, Expression<Func<TSender, IObservable<TRet>>> obs1, Expression<Func<TSender, IObservable<TRet>>> obs2, Expression<Func<TSender, IObservable<TRet>>> obs3, Expression<Func<TSender, IObservable<TRet>>> obs4)
        {
            return This.WhenAnySlim(obs1, obs2, obs3, obs4, (o1, o2, o3, o4) => new[] {o1.EmptyIfNull(), o2.EmptyIfNull(), o3.EmptyIfNull(), o4.EmptyIfNull()})
                .Select(x => x.Merge()).Switch();
        }
        public static IObservable<TRet> WhenAnyObservableSlim<TSender, TRet>(this TSender This, Expression<Func<TSender, IObservable<TRet>>> obs1, Expression<Func<TSender, IObservable<TRet>>> obs2, Expression<Func<TSender, IObservable<TRet>>> obs3, Expression<Func<TSender, IObservable<TRet>>> obs4, Expression<Func<TSender, IObservable<TRet>>> obs5)
        {
            return This.WhenAnySlim(obs1, obs2, obs3, obs4, obs5, (o1, o2, o3, o4, o5) => new[] {o1.EmptyIfNull(), o2.EmptyIfNull(), o3.EmptyIfNull(), o4.EmptyIfNull(), o5.EmptyIfNull()})
                .Select(x => x.Merge()).Switch();
        }
        public static IObservable<TRet> WhenAnyObservableSlim<TSender, TRet>(this TSender This, Expression<Func<TSender, IObservable<TRet>>> obs1, Expression<Func<TSender, IObservable<TRet>>> obs2, Expression<Func<TSender, IObservable<TRet>>> obs3, Expression<Func<TSender, IObservable<TRet>>> obs4, Expression<Func<TSender, IObservable<TRet>>> obs5, Expression<Func<TSender, IObservable<TRet>>> obs6)
        {
            return This.WhenAnySlim(obs1, obs2, obs3, obs4, obs5, obs6, (o1, o2, o3, o4, o5, o6) => new[] {o1.EmptyIfNull(), o2.EmptyIfNull(), o3.EmptyIfNull(), o4.EmptyIfNull(), o5.EmptyIfNull(), o6.EmptyIfNull()})
                .Select(x => x.Merge()).Switch();
        }
        public static IObservable<TRet> WhenAnyObservableSlim<TSender, TRet>(this TSender This, Expression<Func<TSender, IObservable<TRet>>> obs1, Expression<Func<TSender, IObservable<TRet>>> obs2, Expression<Func<TSender, IObservable<TRet>>> obs3, Expression<Func<TSender, IObservable<TRet>>> obs4, Expression<Func<TSender, IObservable<TRet>>> obs5, Expression<Func<TSender, IObservable<TRet>>> obs6, Expression<Func<TSender, IObservable<TRet>>> obs7)
        {
            return This.WhenAnySlim(obs1, obs2, obs3, obs4, obs5, obs6, obs7, (o1, o2, o3, o4, o5, o6, o7) => new[] {o1.EmptyIfNull(), o2.EmptyIfNull(), o3.EmptyIfNull(), o4.EmptyIfNull(), o5.EmptyIfNull(), o6.EmptyIfNull(), o7.EmptyIfNull()})
                .Select(x => x.Merge()).Switch();
        }
        public static IObservable<TRet> WhenAnyObservableSlim<TSender, TRet>(this TSender This, Expression<Func<TSender, IObservable<TRet>>> obs1, Expression<Func<TSender, IObservable<TRet>>> obs2, Expression<Func<TSender, IObservable<TRet>>> obs3, Expression<Func<TSender, IObservable<TRet>>> obs4, Expression<Func<TSender, IObservable<TRet>>> obs5, Expression<Func<TSender, IObservable<TRet>>> obs6, Expression<Func<TSender, IObservable<TRet>>> obs7, Expression<Func<TSender, IObservable<TRet>>> obs8)
        {
            return This.WhenAnySlim(obs1, obs2, obs3, obs4, obs5, obs6, obs7, obs8, (o1, o2, o3, o4, o5, o6, o7, o8) => new[] {o1.EmptyIfNull(), o2.EmptyIfNull(), o3.EmptyIfNull(), o4.EmptyIfNull(), o5.EmptyIfNull(), o6.EmptyIfNull(), o7.EmptyIfNull(), o8.EmptyIfNull()})
                .Select(x => x.Merge()).Switch();
        }
        public static IObservable<TRet> WhenAnyObservableSlim<TSender, TRet>(this TSender This, Expression<Func<TSender, IObservable<TRet>>> obs1, Expression<Func<TSender, IObservable<TRet>>> obs2, Expression<Func<TSender, IObservable<TRet>>> obs3, Expression<Func<TSender, IObservable<TRet>>> obs4, Expression<Func<TSender, IObservable<TRet>>> obs5, Expression<Func<TSender, IObservable<TRet>>> obs6, Expression<Func<TSender, IObservable<TRet>>> obs7, Expression<Func<TSender, IObservable<TRet>>> obs8, Expression<Func<TSender, IObservable<TRet>>> obs9)
        {
            return This.WhenAnySlim(obs1, obs2, obs3, obs4, obs5, obs6, obs7, obs8, obs9, (o1, o2, o3, o4, o5, o6, o7, o8, o9) => new[] {o1.EmptyIfNull(), o2.EmptyIfNull(), o3.EmptyIfNull(), o4.EmptyIfNull(), o5.EmptyIfNull(), o6.EmptyIfNull(), o7.EmptyIfNull(), o8.EmptyIfNull(), o9.EmptyIfNull()})
                .Select(x => x.Merge()).Switch();
        }
        public static IObservable<TRet> WhenAnyObservableSlim<TSender, TRet>(this TSender This, Expression<Func<TSender, IObservable<TRet>>> obs1, Expression<Func<TSender, IObservable<TRet>>> obs2, Expression<Func<TSender, IObservable<TRet>>> obs3, Expression<Func<TSender, IObservable<TRet>>> obs4, Expression<Func<TSender, IObservable<TRet>>> obs5, Expression<Func<TSender, IObservable<TRet>>> obs6, Expression<Func<TSender, IObservable<TRet>>> obs7, Expression<Func<TSender, IObservable<TRet>>> obs8, Expression<Func<TSender, IObservable<TRet>>> obs9, Expression<Func<TSender, IObservable<TRet>>> obs10)
        {
            return This.WhenAnySlim(obs1, obs2, obs3, obs4, obs5, obs6, obs7, obs8, obs9, obs10, (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10) => new[] {o1.EmptyIfNull(), o2.EmptyIfNull(), o3.EmptyIfNull(), o4.EmptyIfNull(), o5.EmptyIfNull(), o6.EmptyIfNull(), o7.EmptyIfNull(), o8.EmptyIfNull(), o9.EmptyIfNull(), o10.EmptyIfNull()})
                .Select(x => x.Merge()).Switch();
        }
        public static IObservable<TRet> WhenAnyObservableSlim<TSender, TRet>(this TSender This, Expression<Func<TSender, IObservable<TRet>>> obs1, Expression<Func<TSender, IObservable<TRet>>> obs2, Expression<Func<TSender, IObservable<TRet>>> obs3, Expression<Func<TSender, IObservable<TRet>>> obs4, Expression<Func<TSender, IObservable<TRet>>> obs5, Expression<Func<TSender, IObservable<TRet>>> obs6, Expression<Func<TSender, IObservable<TRet>>> obs7, Expression<Func<TSender, IObservable<TRet>>> obs8, Expression<Func<TSender, IObservable<TRet>>> obs9, Expression<Func<TSender, IObservable<TRet>>> obs10, Expression<Func<TSender, IObservable<TRet>>> obs11)
        {
            return This.WhenAnySlim(obs1, obs2, obs3, obs4, obs5, obs6, obs7, obs8, obs9, obs10, obs11, (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11) => new[] {o1.EmptyIfNull(), o2.EmptyIfNull(), o3.EmptyIfNull(), o4.EmptyIfNull(), o5.EmptyIfNull(), o6.EmptyIfNull(), o7.EmptyIfNull(), o8.EmptyIfNull(), o9.EmptyIfNull(), o10.EmptyIfNull(), o11.EmptyIfNull()})
                .Select(x => x.Merge()).Switch();
        }
        public static IObservable<TRet> WhenAnyObservableSlim<TSender, TRet>(this TSender This, Expression<Func<TSender, IObservable<TRet>>> obs1, Expression<Func<TSender, IObservable<TRet>>> obs2, Expression<Func<TSender, IObservable<TRet>>> obs3, Expression<Func<TSender, IObservable<TRet>>> obs4, Expression<Func<TSender, IObservable<TRet>>> obs5, Expression<Func<TSender, IObservable<TRet>>> obs6, Expression<Func<TSender, IObservable<TRet>>> obs7, Expression<Func<TSender, IObservable<TRet>>> obs8, Expression<Func<TSender, IObservable<TRet>>> obs9, Expression<Func<TSender, IObservable<TRet>>> obs10, Expression<Func<TSender, IObservable<TRet>>> obs11, Expression<Func<TSender, IObservable<TRet>>> obs12)
        {
            return This.WhenAnySlim(obs1, obs2, obs3, obs4, obs5, obs6, obs7, obs8, obs9, obs10, obs11, obs12, (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12) => new[] {o1.EmptyIfNull(), o2.EmptyIfNull(), o3.EmptyIfNull(), o4.EmptyIfNull(), o5.EmptyIfNull(), o6.EmptyIfNull(), o7.EmptyIfNull(), o8.EmptyIfNull(), o9.EmptyIfNull(), o10.EmptyIfNull(), o11.EmptyIfNull(), o12.EmptyIfNull()})
                .Select(x => x.Merge()).Switch();
        }

        public static IObservable<TRet> WhenAnyObservableSlim<TSender, TRet, T1,T2>(this TSender This,
                            Expression<Func<TSender, IObservable<T1>>> obs1,
                            Expression<Func<TSender, IObservable<T2>>> obs2,
                            Func<T1, T2, TRet> selector)
        {
            return This.WhenAnySlim(obs1, obs2, (o1, o2) => Observable.CombineLatest(o1.EmptyIfNull(), o2.EmptyIfNull(), selector))
                .Switch();
        }
        public static IObservable<TRet> WhenAnyObservableSlim<TSender, TRet, T1,T2,T3>(this TSender This,
                            Expression<Func<TSender, IObservable<T1>>> obs1,
                            Expression<Func<TSender, IObservable<T2>>> obs2,
                            Expression<Func<TSender, IObservable<T3>>> obs3,
                            Func<T1, T2, T3, TRet> selector)
        {
            return This.WhenAnySlim(obs1, obs2, obs3, (o1, o2, o3) => Observable.CombineLatest(o1.EmptyIfNull(), o2.EmptyIfNull(), o3.EmptyIfNull(), selector))
                .Switch();
        }
        public static IObservable<TRet> WhenAnyObservableSlim<TSender, TRet, T1,T2,T3,T4>(this TSender This,
                            Expression<Func<TSender, IObservable<T1>>> obs1,
                            Expression<Func<TSender, IObservable<T2>>> obs2,
                            Expression<Func<TSender, IObservable<T3>>> obs3,
                            Expression<Func<TSender, IObservable<T4>>> obs4,
                            Func<T1, T2, T3, T4, TRet> selector)
        {
            return This.WhenAnySlim(obs1, obs2, obs3, obs4, (o1, o2, o3, o4) => Observable.CombineLatest(o1.EmptyIfNull(), o2.EmptyIfNull(), o3.EmptyIfNull(), o4.EmptyIfNull(), selector))
                .Switch();
        }
        public static IObservable<TRet> WhenAnyObservableSlim<TSender, TRet, T1,T2,T3,T4,T5>(this TSender This,
                            Expression<Func<TSender, IObservable<T1>>> obs1,
                            Expression<Func<TSender, IObservable<T2>>> obs2,
                            Expression<Func<TSender, IObservable<T3>>> obs3,
                            Expression<Func<TSender, IObservable<T4>>> obs4,
                            Expression<Func<TSender, IObservable<T5>>> obs5,
                            Func<T1, T2, T3, T4, T5, TRet> selector)
        {
            return This.WhenAnySlim(obs1, obs2, obs3, obs4, obs5, (o1, o2, o3, o4, o5) => Observable.CombineLatest(o1.EmptyIfNull(), o2.EmptyIfNull(), o3.EmptyIfNull(), o4.EmptyIfNull(), o5.EmptyIfNull(), selector))
                .Switch();
        }
        public static IObservable<TRet> WhenAnyObservableSlim<TSender, TRet, T1,T2,T3,T4,T5,T6>(this TSender This,
                            Expression<Func<TSender, IObservable<T1>>> obs1,
                            Expression<Func<TSender, IObservable<T2>>> obs2,
                            Expression<Func<TSender, IObservable<T3>>> obs3,
                            Expression<Func<TSender, IObservable<T4>>> obs4,
                            Expression<Func<TSender, IObservable<T5>>> obs5,
                            Expression<Func<TSender, IObservable<T6>>> obs6,
                            Func<T1, T2, T3, T4, T5, T6, TRet> selector)
        {
            return This.WhenAnySlim(obs1, obs2, obs3, obs4, obs5, obs6, (o1, o2, o3, o4, o5, o6) => Observable.CombineLatest(o1.EmptyIfNull(), o2.EmptyIfNull(), o3.EmptyIfNull(), o4.EmptyIfNull(), o5.EmptyIfNull(), o6.EmptyIfNull(), selector))
                .Switch();
        }
        public static IObservable<TRet> WhenAnyObservableSlim<TSender, TRet, T1,T2,T3,T4,T5,T6,T7>(this TSender This,
                            Expression<Func<TSender, IObservable<T1>>> obs1,
                            Expression<Func<TSender, IObservable<T2>>> obs2,
                            Expression<Func<TSender, IObservable<T3>>> obs3,
                            Expression<Func<TSender, IObservable<T4>>> obs4,
                            Expression<Func<TSender, IObservable<T5>>> obs5,
                            Expression<Func<TSender, IObservable<T6>>> obs6,
                            Expression<Func<TSender, IObservable<T7>>> obs7,
                            Func<T1, T2, T3, T4, T5, T6, T7, TRet> selector)
        {
            return This.WhenAnySlim(obs1, obs2, obs3, obs4, obs5, obs6, obs7, (o1, o2, o3, o4, o5, o6, o7) => Observable.CombineLatest(o1.EmptyIfNull(), o2.EmptyIfNull(), o3.EmptyIfNull(), o4.EmptyIfNull(), o5.EmptyIfNull(), o6.EmptyIfNull(), o7.EmptyIfNull(), selector))
                .Switch();
        }
        public static IObservable<TRet> WhenAnyObservableSlim<TSender, TRet, T1,T2,T3,T4,T5,T6,T7,T8>(this TSender This,
                            Expression<Func<TSender, IObservable<T1>>> obs1,
                            Expression<Func<TSender, IObservable<T2>>> obs2,
                            Expression<Func<TSender, IObservable<T3>>> obs3,
                            Expression<Func<TSender, IObservable<T4>>> obs4,
                            Expression<Func<TSender, IObservable<T5>>> obs5,
                            Expression<Func<TSender, IObservable<T6>>> obs6,
                            Expression<Func<TSender, IObservable<T7>>> obs7,
                            Expression<Func<TSender, IObservable<T8>>> obs8,
                            Func<T1, T2, T3, T4, T5, T6, T7, T8, TRet> selector)
        {
            return This.WhenAnySlim(obs1, obs2, obs3, obs4, obs5, obs6, obs7, obs8, (o1, o2, o3, o4, o5, o6, o7, o8) => Observable.CombineLatest(o1.EmptyIfNull(), o2.EmptyIfNull(), o3.EmptyIfNull(), o4.EmptyIfNull(), o5.EmptyIfNull(), o6.EmptyIfNull(), o7.EmptyIfNull(), o8.EmptyIfNull(), selector))
                .Switch();
        }
        public static IObservable<TRet> WhenAnyObservableSlim<TSender, TRet, T1,T2,T3,T4,T5,T6,T7,T8,T9>(this TSender This,
                            Expression<Func<TSender, IObservable<T1>>> obs1,
                            Expression<Func<TSender, IObservable<T2>>> obs2,
                            Expression<Func<TSender, IObservable<T3>>> obs3,
                            Expression<Func<TSender, IObservable<T4>>> obs4,
                            Expression<Func<TSender, IObservable<T5>>> obs5,
                            Expression<Func<TSender, IObservable<T6>>> obs6,
                            Expression<Func<TSender, IObservable<T7>>> obs7,
                            Expression<Func<TSender, IObservable<T8>>> obs8,
                            Expression<Func<TSender, IObservable<T9>>> obs9,
                            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TRet> selector)
        {
            return This.WhenAnySlim(obs1, obs2, obs3, obs4, obs5, obs6, obs7, obs8, obs9, (o1, o2, o3, o4, o5, o6, o7, o8, o9) => Observable.CombineLatest(o1.EmptyIfNull(), o2.EmptyIfNull(), o3.EmptyIfNull(), o4.EmptyIfNull(), o5.EmptyIfNull(), o6.EmptyIfNull(), o7.EmptyIfNull(), o8.EmptyIfNull(), o9.EmptyIfNull(), selector))
                .Switch();
        }
        public static IObservable<TRet> WhenAnyObservableSlim<TSender, TRet, T1,T2,T3,T4,T5,T6,T7,T8,T9,T10>(this TSender This,
                            Expression<Func<TSender, IObservable<T1>>> obs1,
                            Expression<Func<TSender, IObservable<T2>>> obs2,
                            Expression<Func<TSender, IObservable<T3>>> obs3,
                            Expression<Func<TSender, IObservable<T4>>> obs4,
                            Expression<Func<TSender, IObservable<T5>>> obs5,
                            Expression<Func<TSender, IObservable<T6>>> obs6,
                            Expression<Func<TSender, IObservable<T7>>> obs7,
                            Expression<Func<TSender, IObservable<T8>>> obs8,
                            Expression<Func<TSender, IObservable<T9>>> obs9,
                            Expression<Func<TSender, IObservable<T10>>> obs10,
                            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TRet> selector)
        {
            return This.WhenAnySlim(obs1, obs2, obs3, obs4, obs5, obs6, obs7, obs8, obs9, obs10, (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10) => Observable.CombineLatest(o1.EmptyIfNull(), o2.EmptyIfNull(), o3.EmptyIfNull(), o4.EmptyIfNull(), o5.EmptyIfNull(), o6.EmptyIfNull(), o7.EmptyIfNull(), o8.EmptyIfNull(), o9.EmptyIfNull(), o10.EmptyIfNull(), selector))
                .Switch();
        }
        public static IObservable<TRet> WhenAnyObservableSlim<TSender, TRet, T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11>(this TSender This,
                            Expression<Func<TSender, IObservable<T1>>> obs1,
                            Expression<Func<TSender, IObservable<T2>>> obs2,
                            Expression<Func<TSender, IObservable<T3>>> obs3,
                            Expression<Func<TSender, IObservable<T4>>> obs4,
                            Expression<Func<TSender, IObservable<T5>>> obs5,
                            Expression<Func<TSender, IObservable<T6>>> obs6,
                            Expression<Func<TSender, IObservable<T7>>> obs7,
                            Expression<Func<TSender, IObservable<T8>>> obs8,
                            Expression<Func<TSender, IObservable<T9>>> obs9,
                            Expression<Func<TSender, IObservable<T10>>> obs10,
                            Expression<Func<TSender, IObservable<T11>>> obs11,
                            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TRet> selector)
        {
            return This.WhenAnySlim(obs1, obs2, obs3, obs4, obs5, obs6, obs7, obs8, obs9, obs10, obs11, (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11) => Observable.CombineLatest(o1.EmptyIfNull(), o2.EmptyIfNull(), o3.EmptyIfNull(), o4.EmptyIfNull(), o5.EmptyIfNull(), o6.EmptyIfNull(), o7.EmptyIfNull(), o8.EmptyIfNull(), o9.EmptyIfNull(), o10.EmptyIfNull(), o11.EmptyIfNull(), selector))
                .Switch();
        }
        public static IObservable<TRet> WhenAnyObservableSlim<TSender, TRet, T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12>(this TSender This,
                            Expression<Func<TSender, IObservable<T1>>> obs1,
                            Expression<Func<TSender, IObservable<T2>>> obs2,
                            Expression<Func<TSender, IObservable<T3>>> obs3,
                            Expression<Func<TSender, IObservable<T4>>> obs4,
                            Expression<Func<TSender, IObservable<T5>>> obs5,
                            Expression<Func<TSender, IObservable<T6>>> obs6,
                            Expression<Func<TSender, IObservable<T7>>> obs7,
                            Expression<Func<TSender, IObservable<T8>>> obs8,
                            Expression<Func<TSender, IObservable<T9>>> obs9,
                            Expression<Func<TSender, IObservable<T10>>> obs10,
                            Expression<Func<TSender, IObservable<T11>>> obs11,
                            Expression<Func<TSender, IObservable<T12>>> obs12,
                            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TRet> selector)
        {
            return This.WhenAnySlim(obs1, obs2, obs3, obs4, obs5, obs6, obs7, obs8, obs9, obs10, obs11, obs12, (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12) => Observable.CombineLatest(o1.EmptyIfNull(), o2.EmptyIfNull(), o3.EmptyIfNull(), o4.EmptyIfNull(), o5.EmptyIfNull(), o6.EmptyIfNull(), o7.EmptyIfNull(), o8.EmptyIfNull(), o9.EmptyIfNull(), o10.EmptyIfNull(), o11.EmptyIfNull(), o12.EmptyIfNull(), selector))
                .Switch();
        }
}

    internal static class ObservableExtensions
    {
        public static IObservable<T> EmptyIfNull<T>(this IObservable<T> @this)
        {
            return @this ?? Observable.Empty<T>();
        }
    }
}