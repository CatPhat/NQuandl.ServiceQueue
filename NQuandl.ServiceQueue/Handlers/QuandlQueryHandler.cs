using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NQuandl.ServiceQueue.Messages;
using Rebus;

namespace NQuandl.ServiceQueue.Handlers
{
    public class QuandlQueryHandler : IHandleMessages<QuandlQuery>
    {
        public void Handle(QuandlQuery message)
        {
            
        }
    }
}
