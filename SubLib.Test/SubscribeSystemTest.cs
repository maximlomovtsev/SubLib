using SubLib.Impl;
using SubLib.Interfaces;
using System;
using System.Collections.Generic;
using Xunit;

namespace SubLib.Test
{
    public class SubscribeSystemTest
    {
        [Theory]
        [InlineData(3, "SubscribeSystemTestDatabase.sqlite")]
        public void GetSubscribersCount(int subscribeCount, string databaseName)
        {
            var database = new Database(databaseName);
            var subsribeSystem = new SubscribeSystem(database);

            List<ISubscriber> subscribers = new List<ISubscriber>();
            for(var i = 0; i < subscribeCount; ++i)
            {
                subscribers.Add(new Subscriber());
            }

            foreach(var subscriber in subscribers)
            {
                subsribeSystem.Subscribe(subscriber);
            }

            var subscribersCount = subsribeSystem.GetSubscribersCount();
            Assert.Equal(subscribersCount, subscribeCount);

            foreach (var subscriber in subscribers)
            {
                subsribeSystem.Unsubscribe(subscriber);
            }

            subscribersCount = subsribeSystem.GetSubscribersCount();
            Assert.Equal(subscribersCount, 0);
        }
    }
}