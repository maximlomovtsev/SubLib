using SubLib.Interfaces;
using SubLib.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SubLib.Impl
{
    public class SubscribeSystem : ISubscribeSystem
    {
        public long GetSubscribersCount()
        {
            throw new NotImplementedException();
        }

        public SubsribeStatus Subscribe(ISubscriber subscriber)
        {
            throw new NotImplementedException();
        }

        public SubsribeStatus Unsubscribe(ISubscriber subscriber)
        {
            throw new NotImplementedException();
        }
    }
}
