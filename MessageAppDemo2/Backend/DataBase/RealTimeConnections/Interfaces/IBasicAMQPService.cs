using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessageAppDemo2.Backend.DataBase.RealTimeConnections;


namespace MessageAppDemo2.Backend.DataBase.RealTimeConneciton.Interfaces
{
    public interface IBasicAMQPService
    {
        bool OpenConnection();
        bool CloseConnection();       
    }

        


}
