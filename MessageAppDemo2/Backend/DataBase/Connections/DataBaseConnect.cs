using MessageAppDemo2.Backend.DataBase.Connections.DataBaseConnections.Interfaces;

namespace MessageAppDemo2.Backend.DataBase.Connections
{
    public class DataBaseConnect
    {
        private IBasicDatabase _basicDatabase;
        public void InitializeConnector()
        {
            _basicDatabase.InitializeConnector();
        }
        public void DeactivateConnections()
        {
            _basicDatabase.DeactivateConnections();
        }
        public void OpenConnection()
        {
            _basicDatabase.OpenConnection();
        }
        public void CloseConnection()
        {
            _basicDatabase.CloseConnection();
        }
        public DataBaseConnect()
        {

        }
        public DataBaseConnect(IBasicDatabase _Database)
        {
            SetDatabase(_Database);
        }
        public void SetDatabase(IBasicDatabase _Database)
        {
            _basicDatabase = _Database;
        }

    }
}
