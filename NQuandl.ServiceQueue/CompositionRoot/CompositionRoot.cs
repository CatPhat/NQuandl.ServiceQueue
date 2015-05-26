using System;
using NQuandl.ServiceQueue.CompositionRoot.Rebus;
using SimpleInjector;

namespace NQuandl.ServiceQueue.CompositionRoot
{
    public static class CompositionRoot
    {
        public static void ComposeRoot(this Container container)
        {
            container.Register<IServiceProvider>(() => container, Lifestyle.Singleton);
            container.RegisterRebus();
        }
    }
}