using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Rebus;
using Rebus.Configuration;
using SimpleInjector;

namespace NQuandl.ServiceQueue.CompositionRoot.Rebus
{
    public class SimpleInjectorAdapter : IContainerAdapter
    {
        public SimpleInjectorAdapter(Container container)
        {
            if (container == null)
                throw new ArgumentNullException("container");
            Container = container;
        }

        public Container Container { get; }

        public IEnumerable<IHandleMessages> GetHandlerInstancesFor<T>()
        {
            IEnumerable<IHandleMessages> handlers =
                Container.GetAllInstances(typeof (IHandleMessages<T>)).Cast<IHandleMessages<T>>();
            IEnumerable<IHandleMessages> asyncHandlers =
                Container.GetAllInstances(typeof (IHandleMessagesAsync<T>)).Cast<IHandleMessagesAsync<T>>();

            return handlers.Union(asyncHandlers).ToArray();
        }

        public void Release(IEnumerable handlerInstances)
        {
            foreach (var disposable in handlerInstances.OfType<IDisposable>())
            {
                disposable.Dispose();
            }
        }

        public void SaveBusInstances(IBus bus)
        {
            Container.Register(() => bus, Lifestyle.Singleton);

            Container.Register<IMessageContext>(() => MessageContext.GetCurrent(), Lifestyle.Transient);
        }
    }
}