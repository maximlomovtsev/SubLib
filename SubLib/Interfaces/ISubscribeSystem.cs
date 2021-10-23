using SubLib.Model;
using System;
using System.Collections.Generic;

namespace SubLib.Interfaces
{
    public interface ISubscribeSystem
    {
        SubsribeSystemStatus GetSubscribersCount(out long subscribersCount);
        SubsribeSystemStatus GetSubscribers(long count, out List<ISubscriber> subscribers);
        SubsribeSystemStatus Subscribe(ISubscriber subscriber);
        SubsribeSystemStatus Unsubscribe(ISubscriber subscriber);
    }
}
