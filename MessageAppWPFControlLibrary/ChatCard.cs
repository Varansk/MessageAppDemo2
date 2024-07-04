using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MessageAppWPFCustomControlLibrary
{
    /// <summary>
    /// BU özel denetimi bir XAML dosyasında kullanmak için 1a ya da 1b ve daha sonra 2 adımlarını izleyin.
    ///
    /// Adım 1a) Geçerli dosyada bulunan bir XAML dosyasında bu özel denetimi kullanmak.
    /// Bu XmlNamespace özniteliğini kullanılacağı yerde biçimlendirme dosyasının 
    /// kök öğesine ekle:
    ///
    ///     xmlns:MyNamespace="clr-namespace:MessageAppWPFCustomControlLibrary"
    ///
    ///
    /// Adım 1b) Başka bir dosyada bulunan bir XAML dosyasında bu özel denetimi kullanmak.
    /// Bu XmlNamespace özniteliğini kullanılacağı yerde biçimlendirme dosyasının 
    /// kök öğesine ekle:
    ///
    ///     xmlns:MyNamespace="clr-namespace:MessageAppWPFCustomControlLibrary;assembly=MessageAppWPFCustomControlLibrary"
    ///
    /// Derleme hatalarından kaçınmak adına XAML dosyasının yaşadığı projeden bu projeye
    /// bir proje başvurusu eklemeye ve Yeniden Yapılandırmaya ihtiyacınız olacak:
    ///
    ///     Çözüm Gezginindeki hedef dosyaya sağ tıklayın ve
    ///     "Başvuru Ekle"->"Projeler"->[Bu projeyi seçmek için göz atın]
    ///
    ///
    /// Adım 2)
    /// Devam edin ve XAML dosyasında denetimi kullanın.
    ///
    ///     <MyNamespace:ChatCard/>
    ///
    /// </summary>
    public class ChatCard : Control
    {

        public ImageSource MainImage
        {
            get { return (ImageSource)GetValue(MainImageProperty); }
            set { SetValue(MainImageProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MainImage.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MainImageProperty =
            DependencyProperty.Register("MainImage", typeof(ImageSource), typeof(ChatCard), new PropertyMetadata(null));



        public BitmapImage LastMessageLogo
        {
            get { return (BitmapImage)GetValue(LastMessageLogoProperty); }
            set { SetValue(LastMessageLogoProperty, value); }
        }   

        // Using a DependencyProperty as the backing store for LastMessageLogo.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LastMessageLogoProperty =
            DependencyProperty.Register("LastMessageLogo", typeof(BitmapImage), typeof(ChatCard), new PropertyMetadata(new BitmapImage()));


        public string LastMessage
        {
            get { return (string)GetValue(LastMessageProperty); }
            set { SetValue(LastMessageProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LastMessage.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LastMessageProperty =
            DependencyProperty.Register("LastMessage", typeof(string), typeof(ChatCard), new PropertyMetadata("There is no message here!"));

        public object Chat
        {
            get { return (object)GetValue(ChatProperty); }
            set { SetValue(ChatProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Chat.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ChatProperty =
            DependencyProperty.Register("Chat", typeof(object), typeof(ChatCard), new PropertyMetadata(new object()));



        public double CornerRadius
        {
            get { return (double)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CornerRadius.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register("CornerRadius", typeof(double), typeof(ChatCard), new PropertyMetadata(0D));



        public string ChatName
        {
            get { return (string)GetValue(ChatNameProperty); }
            set { SetValue(ChatNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ChatName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ChatNameProperty =
            DependencyProperty.Register("ChatName", typeof(string), typeof(ChatCard), new PropertyMetadata(""));


        static ChatCard()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ChatCard), new FrameworkPropertyMetadata(typeof(ChatCard)));
            BackgroundProperty.OverrideMetadata(typeof(ChatCard), new FrameworkPropertyMetadata(Brushes.LightGray));
        }
    }
}
