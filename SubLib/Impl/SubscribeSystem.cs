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

        public SubsribeStatus GetSubscribersCount(out long subscribersCount)
        {
            var status = _database.RowCount(out subscribersCount);

            return (status == DatabaseStatus.OK)
                ? SubsribeStatus.OK
                : SubsribeStatus.Fail;
        }

        public SubsribeStatus Subscribe(ISubscriber subscriber)
        {
            var status = _database.Insert(subscriber);

            return (status == DatabaseStatus.OK)
                ? SubsribeStatus.OK
                : SubsribeStatus.Fail;
        }

        public SubsribeStatus Unsubscribe(ISubscriber subscriber)
        {
            var status = _database.Delete(subscriber);

            return (status == DatabaseStatus.OK)
                ? SubsribeStatus.OK
                : SubsribeStatus.Fail;
        }
    }
}
