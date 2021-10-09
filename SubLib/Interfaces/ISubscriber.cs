using System;
using System.Collections.Generic;
using System.Text;

namespace SubLib.Interfaces
{
    public interface ISubscriber
    {
        long TelegramId { get; set; }
        string TelegramUsername { get; set; }
        DateTime SubscriptionStartDate { get; set; }
        DateTime SubscriptionExpirationDate { get; set; }
    }
}
