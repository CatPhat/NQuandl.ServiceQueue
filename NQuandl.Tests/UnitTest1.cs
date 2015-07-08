using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NQuandl.ServiceQueue.CompositionRoot;
using NQuandl.ServiceQueue.CompositionRoot.Rebus;
using NQuandl.ServiceQueue.Messages;
using Rebus;

namespace NQuandl.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //var rebusFactory = new RebusFactory(new SimpleDependencyInjector());
            //var bus = rebusFactory.GetBus();
            //var message = new QuandlQueryRequest
            //{
            //  //  PathSegment = "test"
            //};
           
            //bus.Defer(TimeSpan.FromMilliseconds(1), message);
        }
    }
}
