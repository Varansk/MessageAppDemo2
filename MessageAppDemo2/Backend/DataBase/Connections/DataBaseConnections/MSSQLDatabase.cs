using MessageAppDemo2.Backend.DataBase.Connections.DataBaseConnections.Interfaces;
using Microsoft.Data.SqlClient;

namespace MessageAppDemo2.Backend.DataBase.Connections.DataBaseConnections
{
    public class MSSQLDatabase : IBasicDatabase
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader reader;
        //

        public SqlConnection GetConnection
        {
            get { return con; }
        }
        public SqlCommand GetCommand
        {
            get { return cmd; }
        }
        public SqlDataReader GetReader
        {
            get { return reader; }
            set { reader = value; }
        }
        private readonly string ConnectionString;
        public MSSQLDatabase(string Connection)
        {
            ConnectionString = Connection;
            InitializeConnector();
        }
        public void DeactivateConnections()
        {
            con.Dispose();
            cmd.Dispose();
            reader.Dispose();
        }

        public void InitializeConnector()
        {
            con = new SqlConnection(ConnectionString);
            cmd = con.CreateCommand();
            reader = cmd.ExecuteReader();
        }

        public void OpenConnection()
        {
            con.Open();
        }
        public void CloseConnection()
        {
            con.Close();
        }

    }
}
