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

            if(_database.Open() == DatabaseStatus.Fail)
            {
                throw new Exception("Failed open database");
            }
        }

        ~SubscribeSystem()
        {
            _database.Close();
        }

        public long GetSubscribersCount()
        {
            throw new NotImplementedException();
        }

        public SubsribeStatus Subscribe(ISubscriber subscriber)
        {
            throw new NotImplementedException();
        }

        public SubsribeStatus Unsubscribe(ISubscriber subscriber)
        {
            throw new NotImplementedException();
        }
    }
}
