using MessageAppDemo2.Backend.Chatting.ChatData.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace MessageAppDemo2.FrontEnd.FrontEnd_BackendActions.ViewModels.App.ConvertersAndMarkupExt
{
    public record class ChatCardInstance
    {
        public ImageSource MainImage { get; set; }
        public ImageSource LastMessageLogo { get; set; }
        public string LastMessageSenderName { get; set; }
        public string LastMessage { get; set; }
        public ChatBase Chat { get; set; }
        public int NonReadMessageCount { get; set; }
        public string ChatName { get; set; }

        public ChatCardInstance()
        {
            this.MainImage = null;
            LastMessageLogo = null;
            LastMessageSenderName = "";
            LastMessage = "";
            Chat = null;
            NonReadMessageCount = 0;
            ChatName = "";
        }

    }
}
