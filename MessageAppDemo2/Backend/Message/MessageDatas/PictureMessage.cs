using MessageAppDemo2.Backend.Chatting.ChatData.Interfaces;
using MessageAppDemo2.Backend.Message.MessageDatas.Interfaces;
using MessageAppDemo2.Backend.SystemData.UploadedFile;
using MessageAppDemo2.Backend.Users.UserData.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MessageAppDemo2.Backend.Message.MessageDatas
{
    public class PictureMessage : MessageBase, IHaveQuotedMessage, IHaveTextMessage
    {
        private MessageBase _QuotedMessage;
        private string _Text;



        private List<UploadedFile> _PictureFiles;



        public List<UploadedFile> PictureFiles
        {
            get
            {
                return _PictureFiles;
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

                if (value.Select((I) => { return I.FileType; }).All((I) => { return I == FileTypes.Image; }))
                {
                    _PictureFiles = value;
                }
                else
                {
                    throw new ArgumentException("Wrong File Format For Message Type");
                }
            }
        }


        public MessageBase QuotedMessage { get { return _QuotedMessage; } set { _QuotedMessage = value; } }
        public string Text { get { return _Text; } set { _Text = value; } }

        

        public PictureMessage()
        {
            _QuotedMessage = null;
            _Text = string.Empty;
            _PictureFiles = new List<UploadedFile>();
        }
        public override object Clone()
        {
            PictureMessage ClonedInstance = MemberwiseClone() as PictureMessage;
            ClonedInstance.MessageSender = MessageSender.Clone() as User;
            ClonedInstance.WhichChatMessageSent = WhichChatMessageSent.Clone() as ChatBase;

            return ClonedInstance;
        }
    }
}
