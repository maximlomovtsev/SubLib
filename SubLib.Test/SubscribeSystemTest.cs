using SubLib.Impl;
using SubLib.Interfaces;
using SubLib.Model;
using System;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace SubLib.Test
{
    public class SubscribeSystemTest
    {
        [Theory]
        [InlineData("SubscribeUnsubscribeTestDatabase.sqlite")]
        public void SubscribeUnsubscribe(string databaseName)
        {
            var database = new Database(databaseName);
            var subsribeSystem = new SubscribeSystem(database);

            List<ISubscriber> subscribers = new List<ISubscriber>();

            // First subscriber
            var firstSubscriber = new Subscriber();
            firstSubscriber.TelegramId = 1;
            firstSubscriber.TelegramUsername = "First User";
            firstSubscriber.SubscriptionStartDate = new DateTime(1);
            firstSubscriber.SubscriptionExpirationDate = new DateTime(2);
            subscribers.Add(firstSubscriber);

            // Second subscriber
            var secondSubscriber = new Subscriber();
            secondSubscriber.TelegramId = 2;
            secondSubscriber.TelegramUsername = "Second User";
            secondSubscriber.SubscriptionStartDate = new DateTime(1);
            secondSubscriber.SubscriptionExpirationDate = new DateTime(2);
            subscribers.Add(secondSubscriber);

            // Third subscriber
            var thirdSubscriber = new Subscriber();
            thirdSubscriber.TelegramId = 3;
            thirdSubscriber.TelegramUsername = "Third User";
            thirdSubscriber.SubscriptionStartDate = new DateTime(1);
            thirdSubscriber.SubscriptionExpirationDate = new DateTime(2);
            subscribers.Add(thirdSubscriber);

            // Third subscriber (duplicate)
            var thirdSubscriberDuplicate = new Subscriber();
            thirdSubscriberDuplicate.TelegramId = 3;
            thirdSubscriberDuplicate.TelegramUsername = "Third User";
            thirdSubscriberDuplicate.SubscriptionStartDate = new DateTime(1);
            thirdSubscriberDuplicate.SubscriptionExpirationDate = new DateTime(2);
            subscribers.Add(thirdSubscriberDuplicate);

            foreach (var subscriber in subscribers)
            {
                subsribeSystem.Subscribe(subscriber);
            }

            long subscribersCount = 0;
            Assert.Equal(SubsribeSystemStatus.OK, subsribeSystem.GetSubscribersCount(out subscribersCount));
            Assert.True(subscribers.Count > subscribersCount);

            var subscribersInDatabase = new List<ISubscriber>();
            Assert.Equal(SubsribeSystemStatus.OK, subsribeSystem.GetSubscribers(subscribersCount, out subscribersInDatabase));
            Assert.Equal(subscribersCount, subscribersInDatabase.Count);

            foreach (var subscriber in subscribers)
            {
                Assert.Equal(SubsribeSystemStatus.OK, subsribeSystem.Unsubscribe(subscriber));
            }

            Assert.Equal(SubsribeSystemStatus.OK, subsribeSystem.GetSubscribersCount(out subscribersCount));
            Assert.Equal(0, subscribersCount);
        }
    }
}
