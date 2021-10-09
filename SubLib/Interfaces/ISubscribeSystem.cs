using SubLib.Model;
using System;

namespace SubLib.Interfaces
{
    public interface ISubscribeSystem
    {
        SubsribeStatus GetSubscribersCount(out long subscribersCount);
        SubsribeStatus Subscribe(ISubscriber subscriber);
        SubsribeStatus Unsubscribe(ISubscriber subscriber);
    }
}
