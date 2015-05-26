//using System;

//namespace NQuandl.ServiceQueue.CompositionRoot.Rebus
//{
//    public class AmbientUserContext : IDisposable
//    {
//        [ThreadStatic]
//        private static UserContext _current;

//        public static UserContext Current
//        {
//            get { return _current; }
//        }

//        public AmbientUserContext(UserContext context)
//        {
//            _current = context;
//        }

//        public void Dispose()
//        {
//            _current = null;
//        }

//    }
//}