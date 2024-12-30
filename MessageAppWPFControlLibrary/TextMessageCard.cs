using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace MessageAppWPFCustomControlLibrary
{
    public class TextMessageCard : Control
    {


        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(TextMessageCard), new PropertyMetadata("null"));


        public string SenderName
        {
            get { return (string)GetValue(SenderNameProperty); }
            set { SetValue(SenderNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SenderName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SenderNameProperty =
            DependencyProperty.Register("SenderName", typeof(string), typeof(TextMessageCard), new PropertyMetadata("null"));



        public ImageSource ProfileImage
        {   
            get { return (ImageSource)GetValue(ProfileImageProperty); }
            set { SetValue(ProfileImageProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ProfileImage.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ProfileImageProperty =
            DependencyProperty.Register("ProfileImage", typeof(ImageSource), typeof(TextMessageCard), new PropertyMetadata(null));



        public DateTime MessageSendDate
        {
            get { return (DateTime)GetValue(MessageSendDateProperty); } 
            set { SetValue(MessageSendDateProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MessageSendDate.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MessageSendDateProperty =
            DependencyProperty.Register("MessageSendDate", typeof(DateTime), typeof(TextMessageCard), new PropertyMetadata(DateTime.MinValue));






        public ICommand[] ExpanderButtonCommandsTtoD
        {
            get { return (ICommand[])GetValue(ExpanderButtonCommandsTtoDProperty); }
            set { SetValue(ExpanderButtonCommandsTtoDProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ExpanderButtonCommandsTtoD.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ExpanderButtonCommandsTtoDProperty =
            DependencyProperty.Register("ExpanderButtonCommandsTtoD", typeof(ICommand[]), typeof(TextMessageCard), new PropertyMetadata(null));





        public object[] ExpanderButtonCommandParametersTtoD
        {
            get { return (object[])GetValue(ExpanderButtonCommandParametersTtoDProperty); }
            set { SetValue(ExpanderButtonCommandParametersTtoDProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ExpanderButtonCommandParametersTtoD.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ExpanderButtonCommandParametersTtoDProperty =
            DependencyProperty.Register("ExpanderButtonCommandParametersTtoD", typeof(object[]), typeof(TextMessageCard), new PropertyMetadata(null));





        #region MessageIdentifiers
        public Guid UserID
        {
            get { return (Guid)GetValue(UserIDProperty); }
            set { SetValue(UserIDProperty, value); }
        }

        // Using a DependencyProperty as the backing store for UserID.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UserIDProperty =
            DependencyProperty.Register("UserID", typeof(Guid), typeof(TextMessageCard), new PropertyMetadata(Guid.Empty));


        public int MessageID
        {
            get { return (int)GetValue(MessageIDProperty); }
            set { SetValue(MessageIDProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MessageID.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MessageIDProperty =
            DependencyProperty.Register("MessageID", typeof(int), typeof(TextMessageCard), new PropertyMetadata(0));


        public Guid ChatID
        {
            get { return (Guid)GetValue(ChatIDProperty); }
            set { SetValue(ChatIDProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ChatID.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ChatIDProperty =
            DependencyProperty.Register("ChatID", typeof(Guid), typeof(TextMessageCard), new PropertyMetadata(Guid.Empty));


        public string MessageRoute
        {
            get { return (string)GetValue(MessageRouteProperty); }
            set { SetValue(MessageRouteProperty, value); }  
        }

        // Using a DependencyProperty as the backing store for MessageRoute.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MessageRouteProperty =
            DependencyProperty.Register("MessageRoute", typeof(string), typeof(TextMessageCard), new PropertyMetadata(""));
        #endregion
        


        static TextMessageCard()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TextMessageCard), new FrameworkPropertyMetadata(typeof(TextMessageCard)));
        
        }
    }
}
