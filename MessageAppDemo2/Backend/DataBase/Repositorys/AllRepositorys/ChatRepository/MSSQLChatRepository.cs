using MessageAppDemo2.Backend.Chatting.ChatData.Interfaces;
using MessageAppDemo2.Backend.DataBase.Connections.DataBaseConnections;
using MessageAppDemo2.Backend.DataBase.Repositorys.Interfaces;
using MessageAppDemo2.Backend.DataBase.Repositorys.Interfaces.RepositoryBase;
using Microsoft.Data.SqlClient;
using System;
using System.Data;

namespace MessageAppDemo2.Backend.DataBase.Repositorys.AllRepositorys.ChatRepository
{
    public class MSSQLChatRepository : Repository<ChatBase, Guid>, IRunStoredProcedure<SqlCommand, SqlDataReader>
    {
        private MSSQLDatabase MSSQLDatabase;
        public MSSQLChatRepository(MSSQLDatabase Database)
        {
            MSSQLDatabase = Database;
            UpdateVirtualList();
        }

        public void ExecuteStoredProcedure(SqlCommand cmd, string SPName, string[] ParameterNames, object[] Values)
        {
            StoredProcedureCommandBuilder(cmd, SPName, ParameterNames, Values).ExecuteNonQuery();
            cmd.CommandType = CommandType.Text;
        }
        public SqlDataReader ExecuteStoredProcedureAndRead(SqlCommand cmd, string SPName, string[] ParameterNames, object[] Values)
        {
            SqlDataReader reader = StoredProcedureCommandBuilder(cmd, SPName, ParameterNames, Values).ExecuteReader();
            cmd.CommandType = CommandType.Text;
            return reader;
        }

        private SqlCommand StoredProcedureCommandBuilder(SqlCommand cmd, string SPName, string[] ParameterNames, object[] Values)
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.CommandText = SPName.Trim();

            for (int i = 0; i < ParameterNames.Length; i++)
            {
                ParameterNames[i] = ParameterNames[i].Trim();
                if (!ParameterNames[i].StartsWith("@"))
                {
                    ParameterNames[i] = "@" + ParameterNames[i];
                }
                cmd.Parameters.AddWithValue(ParameterNames[i], Values[i]);
            }

            return cmd;

        }

        public override ChatBase GetByID(Guid ID)
        {
            return _Items.Find(I => I.ChatID == ID);
        }

        public override void SaveAllChanges()
        {
            MSSQLDatabase.OpenConnection();

            throw new NotImplementedException();

            MSSQLDatabase.CloseConnection();
        }

        public override void UpdateVirtualList()
        {
            MSSQLDatabase.OpenConnection();

            throw new NotImplementedException();

            MSSQLDatabase.CloseConnection();
        }
    }
}
