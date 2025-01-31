using MessageAppDemo2.Backend.Message.MessageDatas.Interfaces;
using MessageAppDemo2.Backend.SystemData.IFactory;
using MessageAppDemo2.Backend.SystemData.UploadedFile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MessageAppDemo2.Backend.Message.MessageDatas
{
    public class MessageFactory : IFactory<MessageBase, MessageType>
    {

        /// <summary>
        /// Creates Message According to Parameters
        /// </summary>
        /// <param name="type">Wanted MessageType</param>
        /// <param name="parameters">Give a Instance of MessageParameters Class</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public MessageBase CreateInstanceWithParameter(MessageType type, params object[] parameters)
        {


            MessageParameters mp = parameters[0] as MessageParameters;

            if (mp is null)
            {
                return null;
            }
            MessageBase instance;
            switch (type)
            {
                case MessageType.TextMessage:
                    instance = new TextMessage() { Text = mp.Text, ChatRoute = mp.ChatRoute, DependentChatGuid = mp.DependentChatGuid, Files = mp.Files, MessageID = mp.DependentChatMessageCount + 1, IsEdited = false, QuotedMessage = mp.QuotedMessage, MessageSenderID = mp.MessageSenderGuid, MessageSentDate = mp.MessageSentDate };
                    break;
                case MessageType.VoiceMessage:
                    instance = new VoiceMessage() { ChatRoute = mp.ChatRoute, DependentChatGuid = mp.DependentChatGuid, MessageID = mp.DependentChatMessageCount + 1, IsEdited = false, QuotedMessage = mp.QuotedMessage, MessageSenderID = mp.MessageSenderGuid, MessageSentDate = mp.MessageSentDate, VoiceFiles = mp.Files };
                    break;
                case MessageType.VideoMessage:
                    instance = new VideoMessage() { Text = mp.Text, ChatRoute = mp.ChatRoute, DependentChatGuid = mp.DependentChatGuid, MessageID = mp.DependentChatMessageCount + 1, IsEdited = false, QuotedMessage = mp.QuotedMessage, MessageSenderID = mp.MessageSenderGuid, MessageSentDate = mp.MessageSentDate, VideoFiles = mp.Files, };
                    break;
                case MessageType.PictureMessage:
                    instance = new PictureMessage() { Text = mp.Text, ChatRoute = mp.ChatRoute, DependentChatGuid = mp.DependentChatGuid, MessageID = mp.DependentChatMessageCount + 1, IsEdited = false, QuotedMessage = mp.QuotedMessage, MessageSenderID = mp.MessageSenderGuid, MessageSentDate = mp.MessageSentDate, PictureFiles = mp.Files };
                    break;
                default:
                    throw new ArgumentException("Not Avaible Message");

            }

            return instance;

        }

        public T CreateInstanceWithParameter<T>(MessageType type, params object[] parameters) where T : MessageBase
        {
            MessageParameters mp = parameters[0] as MessageParameters;

            if (mp is null)
            {
                return null;
            }
            MessageBase instance;
            switch (type)
            {
                case MessageType.TextMessage:
                    instance = new TextMessage() { Text = mp.Text, ChatRoute = mp.ChatRoute, DependentChatGuid = mp.DependentChatGuid, Files = mp.Files, MessageID = mp.DependentChatMessageCount + 1, IsEdited = false, QuotedMessage = mp.QuotedMessage, MessageSenderID = mp.MessageSenderGuid, MessageSentDate = mp.MessageSentDate };
                    break;
                case MessageType.VoiceMessage:
                    instance = new VoiceMessage() { ChatRoute = mp.ChatRoute, DependentChatGuid = mp.DependentChatGuid, MessageID = mp.DependentChatMessageCount + 1, IsEdited = false, QuotedMessage = mp.QuotedMessage, MessageSenderID = mp.MessageSenderGuid, MessageSentDate = mp.MessageSentDate, VoiceFiles = mp.Files };
                    break;
                case MessageType.VideoMessage:
                    instance = new VideoMessage() { Text = mp.Text, ChatRoute = mp.ChatRoute, DependentChatGuid = mp.DependentChatGuid, MessageID = mp.DependentChatMessageCount + 1, IsEdited = false, QuotedMessage = mp.QuotedMessage, MessageSenderID = mp.MessageSenderGuid, MessageSentDate = mp.MessageSentDate, VideoFiles = mp.Files, };
                    break;
                case MessageType.PictureMessage:
                    instance = new PictureMessage() { Text = mp.Text, ChatRoute = mp.ChatRoute, DependentChatGuid = mp.DependentChatGuid, MessageID = mp.DependentChatMessageCount + 1, IsEdited = false, QuotedMessage = mp.QuotedMessage, MessageSenderID = mp.MessageSenderGuid, MessageSentDate = mp.MessageSentDate, PictureFiles = mp.Files };
                    break;
                default:
                    throw new ArgumentException("Not Avaible Message");

            }

            return instance as T;
        }

        /// <summary>
        /// Dont use it.
        /// </summary>
        /// <exception cref="NotSupportedException"></exception>
        MessageBase IFactory<MessageBase, MessageType>.CreateInstance(MessageType type)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Dont use it.
        /// </summary>
        /// <exception cref="NotSupportedException"></exception>
        T IFactory<MessageBase, MessageType>.CreateInstance<T>(MessageType type)
        {
            throw new NotSupportedException();
        }
    }


    public record class MessageParameters()
    {
        public DateTime MessageSentDate { get; init; } = default;
        public Guid MessageSenderGuid { get; init; } = default;
        public MessageBase QuotedMessage { get; init; } = default;
        public int DependentChatMessageCount { get; init; } = default;
        public string ChatRoute { get; init; } = default;
        public Guid DependentChatGuid { get; init; } = default;
        public List<UploadedFile> Files { get; init; } = default;
        public string Text { get; init; } = string.Empty;
    }
}
