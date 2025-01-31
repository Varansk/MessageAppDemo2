using MessageAppDemo2.Backend.Chatting.ChatData.Interfaces;
using MessageAppDemo2.Backend.Message.MessageDatas.Interfaces;
using MessageAppDemo2.Backend.SystemData.UploadedFile;
using MessageAppDemo2.Backend.Users.UserData.Interfaces;
using System.Collections.Generic;
using System;
using System.Linq;

namespace MessageAppDemo2.Backend.Message.MessageDatas
{
    public class VoiceMessage : MessageBase, IHaveQuotedMessage
    {
        private MessageBase _QuotedMessage;

        public MessageBase QuotedMessage { get { return _QuotedMessage; } set { _QuotedMessage = value; } }

        private List<UploadedFile> _VoiceFiles;



        public List<UploadedFile> VoiceFiles
        {
            get
            {
                return _VoiceFiles;
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

                if (value.Select((I) => { return I.FileType; }).All((I) => { return I == FileTypes.Voice; }))
                {
                    _VoiceFiles = value;
                }
                else
                {
                    throw new ArgumentException("Wrong File Format For Message Type");
                }
            }
        }

        public VoiceMessage()
        {
            _QuotedMessage = null;
        }
        public override object Clone()
        {
            VoiceMessage ClonedInstance = MemberwiseClone() as VoiceMessage;
            ClonedInstance.MessageSender = MessageSender.Clone() as User;
            ClonedInstance.WhichChatMessageSent = WhichChatMessageSent.Clone() as ChatBase;

            return ClonedInstance;
        }
    }
}
