using MessageAppDemo2.Backend.Chatting.ChatData.Interfaces;
using MessageAppDemo2.Backend.Message.MessageDatas.Interfaces;
using MessageAppDemo2.Backend.SystemData.ChangeController.Interfaces;
using MessageAppDemo2.Backend.SystemData.ExtensionClasses.CollectionExtensions;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Documents;

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

                    bool b = Chat1.UserIDs.All((I) => Chat2.UserIDs.Contains(I)) && Chat1.UserIDs.Count == Chat2.UserIDs.Count;
                    bool c = true;//(Chat1.Messages as List<MessageBase>).ContainsSameElements(Chat2.Messages as List<MessageBase>, new MessageController());
                    bool d = Chat1.ChatDetails == Chat2.ChatDetails;

                    return A && !(b && c && d);
                };
                return ControllerHandler;
            }
        }
    }
}
