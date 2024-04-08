using MessageAppDemo2.Backend.Message.MessageDatas.Interfaces;
using MessageAppDemo2.Backend.SystemData.ChangeController.Interfaces;
using System;

namespace MessageAppDemo2.Backend.SystemData.ChangeController
{
    public class MessageController : BaseController<MessageBase>
    {
        public override Func<MessageBase, MessageBase, bool> AddRemoveController
        {
            get
            {
                Func<MessageBase, MessageBase, bool> ControllerHandler = (Message1, Message2) =>
                {

                    return Message1.MessageID == Message2.MessageID && Message1.WhichChatMessageSent.ChatID == Message2.WhichChatMessageSent.ChatID;
                };
                return ControllerHandler;
            }
        }

        public override Func<MessageBase, MessageBase, bool> UpdateController
        {
            get
            {
                Func<MessageBase, MessageBase, bool> ControllerHandler = (Message1, Message2) =>
                {
                    bool A = Message1.MessageID == Message2.MessageID && Message1.WhichChatMessageSent.ChatID == Message2.WhichChatMessageSent.ChatID;
                    bool b = Message1.IsEdited == Message2.IsEdited;
                    bool c = Message1.MessageSentDate == Message2.MessageSentDate;

                    return A && !(b && c);
                };
                return ControllerHandler;
            }
        }
    }
}
