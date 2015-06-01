//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using System.Reflection;
//using Rebus;
//using Rebus.Bus;
//using Rebus.Configuration;
//using SimpleInjector;
//using SimpleInjector.Extensions;

//namespace NQuandl.ServiceQueue.CompositionRoot.Rebus
//{
//    //https://github.com/rebus-org/Rebus/issues/260
//    public class SimpleInjectorAdapter : IContainerAdapter
//    {
//        public SimpleInjectorAdapter(Container container)
//        {
//            if (container == null)
//                throw new ArgumentNullException("container");
//            Container = container;
//        }

//        public Container Container { get; }

//        public IEnumerable<IHandleMessages> GetHandlerInstancesFor<T>()
//        {
//            var scope = Container.BeginLifetimeScope();
//            try
//            {
//                var handlers = Container.GetAllInstances<IHandleMessages<T>>().ToArray();
//                foreach (var handler in handlers)
//                {
//                    yield return handler;
//                }
//            }
//            finally
//            {
//                scope.Dispose();
//            }
//        }

//        public void Release(IEnumerable handlerInstances)
//        {
//            //foreach (var disposable in handlerInstances.OfType<IDisposable>())
//            //{
//            //    disposable.Dispose();
//            //}
//        }

//        public void SaveBusInstances(IBus bus)
//        {
//            Container.Register(() => bus, Lifestyle.Singleton);

           
//            Container.Register<IMessageContext>(() =>
//            {
//                if (MessageContext.HasCurrent && !Container.IsVerifying)
//                {
//                    return MessageContext.GetCurrent();
//                }
//                return new NQuandlMessageContext();
//            }, Lifestyle.Transient);
//        }

//        class NQuandlMessageContext : IMessageContext
//        {
//            public void Dispose()
//            {
//                throw new NotImplementedException();
//            }

//            public void Abort()
//            {
//                throw new NotImplementedException();
//            }

//            public void SkipHandler(Type type)
//            {
//                throw new NotImplementedException();
//            }

//            public void DoNotSkipHandler(Type type)
//            {
//                throw new NotImplementedException();
//            }

//            public string ReturnAddress { get; }
//            public string RebusTransportMessageId { get; }
//            public IDictionary<string, object> Items { get; }
//            public IReadOnlyCollection<Type> HandlersToSkip { get; }
//            public object CurrentMessage { get; }
//            public IDictionary<string, object> Headers { get; }
//            public event Action Disposed;
//        }
//    }

 
//}