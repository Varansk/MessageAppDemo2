using MessageAppDemo2.Backend.Chatting.ChatData.Interfaces;
using MessageAppDemo2.Backend.Message.MessageDatas.Interfaces;
using MessageAppDemo2.Backend.SystemData.UploadedFile;
using MessageAppDemo2.Backend.Users.UserData.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Documents;

namespace MessageAppDemo2.Backend.Message.MessageDatas
{
    public class VideoMessage : MessageBase, IHaveQuotedMessage, IHaveTextMessage
    {
        private MessageBase _QuotedMessage;
        private string _Text;
        private List<UploadedFile> _VideoFiles;



        public List<UploadedFile> VideoFiles
        {
            get
            {
                return _VideoFiles;
            }

            set
            {
                if (value is null)
                {
                    throw new ArgumentException("Null Message");
                }
                else if (value.Count == 0)
                {
                    throw new ArgumentException("Empty Message");
                }

                if (value.Select((I) => { return I.FileType; }).All((I) => { return (I == FileTypes.Video || I == FileTypes.GIF); }))
                {
                    _VideoFiles = value;
                }
                else
                {
                    throw new ArgumentException("Wrong File Format For Message Type");
                }
            }
        }


        public MessageBase QuotedMessage { get { return _QuotedMessage; } set { _QuotedMessage = value; } }
        public string Text { get { return _Text; } set { _Text = value; } }
        public VideoMessage()
        {
            _QuotedMessage = null;
            _VideoFiles = new List<UploadedFile>();
            _Text = string.Empty;
        }
        public override object Clone()
        {
            VideoMessage ClonedInstance = MemberwiseClone() as VideoMessage;
            ClonedInstance.MessageSender = MessageSender.Clone() as User;
            ClonedInstance.WhichChatMessageSent = WhichChatMessageSent.Clone() as ChatBase;

            return ClonedInstance;
        }
    }
}
