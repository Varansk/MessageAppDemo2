using MessageAppDemo2.Backend.Chatting.ChatData;
using MessageAppDemo2.Backend.Chatting.ChatData.Interfaces;
using MessageAppDemo2.Backend.Message.MessageDatas.Interfaces;
using MessageAppDemo2.Backend.SystemData.ChangeController.Interfaces;
using MessageAppDemo2.Backend.SystemData.ExtensionClasses.CollectionExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageAppDemo2.Backend.SystemData.ChangeController.SubControllers
{
    public class GroupChatController : ChatController
    {

        public override Func<ChatBase, ChatBase, bool> UpdateController
        {
            get
            {
                Func<ChatBase, ChatBase, bool> ControllerHandler = (Chat1, Chat2) =>
                {
                    UserController uc = new UserController();

                    bool A = Chat1.ChatID == Chat2.ChatID;
                    bool b = Chat1.UserIDs.All((I) => { return Chat2.UserIDs.Contains(I); }) && Chat1.UserIDs.Count == Chat2.UserIDs.Count;
                    bool c = true;//(Chat1.Messages as List<MessageBase>).ContainsSameElements((Chat2.Messages as List<MessageBase>), new MessageController());
                    bool d = Chat1.ChatDetails == Chat2.ChatDetails;
                    bool e = ((GroupChat)Chat1).BlockedUsers.ContainsSameElements(((GroupChat)Chat2).BlockedUsers, uc);

                    return A && !(b && c && d && e);
                };
                return ControllerHandler;
            }
        }

    }
}
