using SubLib.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SubLib.Interfaces
{
    public interface IDatabase
    {
        DatabaseStatus IsExists(ISubscriber subscriber, out bool isExists);
        DatabaseStatus Insert(ISubscriber subscriber);
        DatabaseStatus Delete(ISubscriber subscriber);
        DatabaseStatus RowCount(out long rowCount);

    }
}
