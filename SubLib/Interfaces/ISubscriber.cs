using System;
using System.Collections.Generic;
using System.Text;

namespace SubLib.Interfaces
{
    public interface ISubscriber
    {
        long Id { get; set; }
        DateTime SubscriptionStartDate { get; set; }
        DateTime SubscriptionExpirationDate { get; set; }
    }
}
