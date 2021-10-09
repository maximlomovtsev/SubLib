using SubLib.Model;
using System;

namespace SubLib.Interfaces
{
    public interface ISubscribeSystem
    {
        SubsribeSystemStatus GetSubscribersCount(out long subscribersCount);
        SubsribeSystemStatus Subscribe(ISubscriber subscriber);
        SubsribeSystemStatus Unsubscribe(ISubscriber subscriber);
    }
}
