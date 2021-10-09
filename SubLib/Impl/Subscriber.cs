using SubLib.Interfaces;
using System;

namespace SubLib.Impl
{
    public class Subscriber : ISubscriber
    {
        public DateTime SubscriptionStartDate { get; set; }
        public DateTime SubscriptionExpirationDate { get; set; }
        public long TelegramId { get; set; }
        public string TelegramUsername { get; set; }
    }
}
