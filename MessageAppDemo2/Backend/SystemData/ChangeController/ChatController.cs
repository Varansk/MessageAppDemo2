using MessageAppDemo2.Backend.Chatting.ChatData.Interfaces;
using MessageAppDemo2.Backend.SystemData.ChangeController.Interfaces;
using MessageAppDemo2.Backend.SystemData.ExtensionClasses.CollectionExtensions;
using System;

namespace MessageAppDemo2.Backend.SystemData.ChangeController
{
    public class ChatController : BaseController<ChatBase>
    {
        public override Func<ChatBase, ChatBase, bool> AddRemoveController
        {
            get
            {
                Func<ChatBase, ChatBase, bool> ControllerHandler = (Chat1, Chat2) =>
                {
                    return Chat1.ChatID == Chat2.ChatID;
                };

                return ControllerHandler;
            }
        }

        public override Func<ChatBase, ChatBase, bool> UpdateController
        {
            get
            {
                Func<ChatBase, ChatBase, bool> ControllerHandler = (Chat1, Chat2) =>
                {
                    bool A = Chat1.ChatID == Chat2.ChatID;
                    bool b = Chat1.ChatUsers.ContainsSameElements(Chat2.ChatUsers, new UserController());
                    bool c = Chat1.Messages.ContainsSameElements(Chat2.Messages, new MessageController());
                    bool d = Chat1.ChatDetails == Chat2.ChatDetails;

                    return A && !(b && c && d);
                };
                return ControllerHandler;
            }
        }
    }
}
