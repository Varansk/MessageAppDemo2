using MessageAppDemo2.Backend.DataBase.DatabaseObjectPools.RepositoryPools;
using MessageAppDemo2.Backend.Message.MessageDatas.Interfaces;
using MessageAppDemo2.Backend.Users.UserData.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Media.Imaging;

namespace MessageAppDemo2.Backend.Chatting.ChatData.Interfaces
{

    public abstract class ChatBase : ICloneable
    {
        public Guid ChatID { get; init; }
        public IReadOnlyList<MessageBase> Messages
        {
            get
            {
                var messagesrepo = DatabaseMessageRepositoryPools.GetDatabaseMessageRepositoryPool("DTBR").Get();

                var list = messagesrepo.GetWhere((I) => { return I.DependentChatGuid == ChatID; });

                DatabaseMessageRepositoryPools.GetDatabaseMessageRepositoryPool("DTBR").Return(messagesrepo);

                return list;
            }
        }

        public IReadOnlyList<User> ChatUsers
        {
            get
            {
                var Userrepo = DatabaseUserRepositoryPools.GetDatabaseUserRepositoryPool("DTBR").Get();

                List<User> users = new List<User>();


                foreach (var item in UserIDs)
                {
                    users.Add(Userrepo.GetByID(item));
                }
                 
                DatabaseUserRepositoryPools.GetDatabaseUserRepositoryPool("DTBR").Return(Userrepo);

                return users;
            }
        }
        public List<Guid> UserIDs { get; set; }

        public abstract BitmapImage ChatPicture { get; set; }
        public abstract string ChatName { get; set; }
        public string ChatDetails { get; set; }
        private ChatBase()
        {
            UserIDs = new List<Guid>();
        }
        public ChatBase(Guid ChatID) : this()
        {
            this.ChatID = ChatID;
        }

        public abstract object Clone();

        public static explicit operator ChatType(ChatBase chat)
        {
            switch (chat)
            {
                case NormalChat:
                    return ChatType.NormalChat;
                case GroupChat:
                    return ChatType.GroupChat;
                default:
                    throw new ArgumentException("Type Not Found");
            }
        }

    }

    public enum ChatType
    {
        NormalChat, GroupChat
    }
}
