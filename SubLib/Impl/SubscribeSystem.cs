using SubLib.Interfaces;
using SubLib.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;

namespace SubLib.Impl
{
    public class SubscribeSystem : ISubscribeSystem
    {
        private IDatabase _database;
        public SubscribeSystem(IDatabase database)
        {
            _database = database;
        }

        public SubsribeSystemStatus GetSubscribersCount(out long subscribersCount)
        {
            var status = _database.RowCount(out subscribersCount);

            return (status == DatabaseStatus.OK)
                ? SubsribeSystemStatus.OK
                : SubsribeSystemStatus.Fail;
        }

        public SubsribeSystemStatus Subscribe(ISubscriber subscriber)
        {
            var isExists = false;
            if(_database.IsExists(subscriber, out isExists) == DatabaseStatus.Fail)
            {
                return SubsribeSystemStatus.Fail;
            }

            if(isExists)
            {
                return SubsribeSystemStatus.AlreadySubscribed;
            }

            var status = _database.Insert(subscriber);

            return (status == DatabaseStatus.OK)
                ? SubsribeSystemStatus.OK
                : SubsribeSystemStatus.Fail;
        }

        public SubsribeSystemStatus Unsubscribe(ISubscriber subscriber)
        {
            var status = _database.Delete(subscriber);

            return (status == DatabaseStatus.OK)
                ? SubsribeSystemStatus.OK
                : SubsribeSystemStatus.Fail;
        }
    }
}
