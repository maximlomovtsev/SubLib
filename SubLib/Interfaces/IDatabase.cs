using SubLib.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SubLib.Interfaces
{
    public interface IDatabase
    {
        DatabaseStatus Open();
        DatabaseStatus Close();
    }
}
