using MessageAppDemo2.Backend.Chatting.ChatData.Interfaces;
using MessageAppDemo2.Backend.DataBase.Connections.DataBaseConnections;
using MessageAppDemo2.Backend.DataBase.Repositorys.Interfaces;
using MessageAppDemo2.Backend.DataBase.Repositorys.Interfaces.RepositoryBase;
using MessageAppDemo2.Backend.Message.MessageDatas.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Data;

namespace MessageAppDemo2.Backend.DataBase.Repositorys.AllRepositorys.MessageRepository
{
    public class MSSQLMessageRepository : Repository<MessageBase, int>, IRunStoredProcedure<SqlCommand, SqlDataReader>, IChatSelector
    {
        private MSSQLDatabase MSSQLDatabase;
        private Guid _dependentChat;
        private string route;

        public MSSQLMessageRepository(MSSQLDatabase Database, ChatBase DependentChat)
        {
            MSSQLDatabase = Database;
            this._dependentChat = DependentChat.ChatID;
            UpdateVirtualList();
        }
        public MSSQLMessageRepository(MSSQLDatabase Database, Guid DependentChatID)
        {
            MSSQLDatabase = Database;
            this._dependentChat = DependentChatID;
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

        public override MessageBase GetByID(int ID)
        {
            return _Items.Find(I => I.MessageID == ID && (I.DependentChatGuid == _dependentChat) && (I.ChatRoute == route));
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

        public void SetDependentChat(ChatBase Chat)
        {
            _dependentChat = Chat.ChatID;
        }

        public void SetDependentChat(Guid ChatID)
        {
            this._dependentChat = ChatID;
        }

        public void SetRoute(string Route)
        {
            this.route = Route;
        }
    }
}
