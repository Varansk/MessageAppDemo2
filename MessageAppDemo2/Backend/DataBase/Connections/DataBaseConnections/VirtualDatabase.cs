using MessageAppDemo2.Backend.Chatting.ChatData.Interfaces;
using MessageAppDemo2.Backend.DataBase.Connections.DataBaseConnections.Interfaces;
using MessageAppDemo2.Backend.Message.MessageDatas.Interfaces;
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


        private object UsersLockConnection;
        private object ChatsLockConnection;
        private object MessagesLockConnection;

        public VirtualDatabase()
        {
            InitializeConnector();
        }
        public List<User> UserList
        {
            get { return Users; }
            set { Users = value; }
        }
        public List<ChatBase> ChatList
        {
            get { return Chats; }
            set { Chats = value; }
        }

        public List<MessageBase> MessageList
        {
            get { return Messages; }
            set { Messages = value; }
        }
        public void InitializeConnector()
        {
            Chats = new List<ChatBase>();
            Users = new List<User>();
            Messages = new List<MessageBase>();

            CloseConnection();
        }

        public void DeactivateConnections()
        {
            Chats = null;
            Users = null;
            Messages = null;
            UsersLockConnection = null;
            ChatsLockConnection = null;
            MessagesLockConnection = null;
        }

        public void OpenConnection()
        {
            Users = (List<User>)UsersLockConnection;
            Chats = (List<ChatBase>)ChatsLockConnection;
            Messages = (List<MessageBase>)MessagesLockConnection;
        }

        public void CloseConnection()
        {
            UsersLockConnection = Users;
            ChatsLockConnection = Chats;
            MessagesLockConnection = Messages;

            Users = null;
            Chats = null;
            Messages = null;
        }


       
    }
}
