using System;
using NQuandl.Client.Api;
using NQuandl.Client.CompositionRoot;
using NQuandl.ServiceQueue.Api;
using NQuandl.ServiceQueue.RateLimiter;
using SimpleInjector;
using SimpleInjector.Extensions;

namespace NQuandl.ServiceQueue.CompositionRoot
{
    public static class CompositionRoot
    {
        public static void ComposeRoot(this Container container)
        {
            container.Register<IServiceProvider>(() => container, Lifestyle.Singleton);
            container.Register<IRateGate>(() => new RateGate(1, TimeSpan.FromMilliseconds(300)), Lifestyle.Singleton);
            string url = @"https://quandl.com/api";
#if DEBUG
            url = @"http://localhost:49832/api";
#endif
            container.NQuandlRegisterRegisterAll(url);
            container.RegisterDecorator(typeof(IQuandlRestClient), typeof(QuandlRestClientDecorator));
            container.Verify();
        }
    }

    public static class Bootstrapper
    {
        private static readonly Container _container;
        static Bootstrapper()
        {
            _container = new Container();
            _container.ComposeRoot();
            _container.Verify();
        }

        public static IProcessQueries GetQueries()
        {
            return _container.GetInstance<IProcessQueries>();
        }
    }
}