using MessageAppDemo2.Backend.Chatting.ChatData.Interfaces;
using MessageAppDemo2.Backend.DataBase.Connections.DataBaseConnections.Interfaces;
using MessageAppDemo2.Backend.Message.MessageDatas.Interfaces;
using MessageAppDemo2.Backend.ReportSystem.Interfaces;
using MessageAppDemo2.Backend.SystemData.ExtensionClasses;
using MessageAppDemo2.Backend.Users.UserData;
using MessageAppDemo2.FrontEnd.Resources.Icons;
using System;
using System.Collections.Generic;

namespace MessageAppDemo2.Backend.DataBase.Connections.DataBaseConnections
{
    public class VirtualDatabase : IBasicDatabase
    {
        private List<User> Users;
        private List<ChatBase> Chats;
        private List<MessageBase> Messages; 
        private List<ReportBase> Reports;


        private object UsersLockConnection;
        private object ChatsLockConnection;
        private object MessagesLockConnection;
        private object ReportsLockConnection;

        public VirtualDatabase()
        {
            InitializeConnector();
        }
        public List<User> UserList
        {
            get { return Users; }

        }
        public List<ChatBase> ChatList
        {
            get { return Chats; }
        }

        public List<MessageBase> MessageList
        {
            get { return Messages; }
        }

        public List<ReportBase> ReportsList
        {
            get { return Reports; }
        }

        public void InitializeConnector()
        {
            Chats = new List<ChatBase>();
            Users = new List<User>();
            Messages = new List<MessageBase>();
            Reports = new List<ReportBase>();

            CloseConnection();
        }

        public void DeactivateConnections()
        {
            Chats = null;
            Users = null;
            Messages = null;
            Reports = null;

            UsersLockConnection = null;
            ChatsLockConnection = null;
            MessagesLockConnection = null;
            ReportsLockConnection = null;
        }

        public void OpenConnection()
        {
            Users = (List<User>)UsersLockConnection;
            Chats = (List<ChatBase>)ChatsLockConnection;
            Messages = (List<MessageBase>)MessagesLockConnection;
            Reports = (List<ReportBase>)ReportsLockConnection;
        }

        public void CloseConnection()
        {
            UsersLockConnection = Users;
            ChatsLockConnection = Chats;
            MessagesLockConnection = Messages;
            ReportsLockConnection = Reports;

            Users = null;
            Chats = null;
            Messages = null;
            Reports = null;
        }


       
    }
}
