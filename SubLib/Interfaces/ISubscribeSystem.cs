using SubLib.Model;
using System;

namespace SubLib.Interfaces
{
    public interface ISubscribeSystem
    {
        long GetSubscribersCount();
        SubsribeStatus Subscribe(ISubscriber subscriber);
        SubsribeStatus Unsubscribe(ISubscriber subscriber);
    }
}
