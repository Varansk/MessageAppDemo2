using MessageAppDemo2.Backend.DataBase.RealTimeConneciton.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageAppDemo2.Backend.DataBase.RealTimeConneciton
{
    public class RealTimeConnect
    {
        private IBasicAMQPService _basicAMQPService;
        public RealTimeConnect(IBasicAMQPService service)
        {
            this._basicAMQPService = service;
        }

        public bool OpenConnection()
        {
            return _basicAMQPService.OpenConnection();
        }
        public bool CloseConnection()
        {
            return _basicAMQPService.CloseConnection();
        }
    }
}
