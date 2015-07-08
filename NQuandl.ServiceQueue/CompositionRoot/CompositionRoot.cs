using System;
using NQuandl.Client.Api;
using SimpleInjector;

namespace NQuandl.ServiceQueue.CompositionRoot
{
    public static class CompositionRoot
    {
        public static void ComposeRoot(this Container container)
        {
            container.Register<IServiceProvider>(() => container, Lifestyle.Singleton);
            container.Register<IProcessQueries>(Client.CompositionRoot.Bootstapper.GetQueryProcessor, Lifestyle.Transient);
        }
    }
}