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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace YazilimCalismasiWPF8
{
    /// <summary>
    /// BU özel denetimi bir XAML dosyasında kullanmak için 1a ya da 1b ve daha sonra 2 adımlarını izleyin.
    ///
    /// Adım 1a) Geçerli dosyada bulunan bir XAML dosyasında bu özel denetimi kullanmak.
    /// Bu XmlNamespace özniteliğini kullanılacağı yerde biçimlendirme dosyasının 
    /// kök öğesine ekle:
    ///
    ///     xmlns:MyNamespace="clr-namespace:YazilimCalismasiWPF8"
    ///
    ///
    /// Adım 1b) Başka bir dosyada bulunan bir XAML dosyasında bu özel denetimi kullanmak.
    /// Bu XmlNamespace özniteliğini kullanılacağı yerde biçimlendirme dosyasının 
    /// kök öğesine ekle:
    ///
    ///     xmlns:MyNamespace="clr-namespace:YazilimCalismasiWPF8;assembly=YazilimCalismasiWPF8"
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
    ///     <MyNamespace:TextboxExtended/>
    ///
    /// </summary>
    public class TextboxExtended : TextBox
    {

        public CornerRadius TextboxCornerRadius
        {
            get { return (CornerRadius)GetValue(TextboxCornerRadiusProperty); }
            set { SetValue(TextboxCornerRadiusProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TextboxCornerRadius.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextboxCornerRadiusProperty =
            DependencyProperty.Register("TextboxCornerRadius", typeof(CornerRadius), typeof(TextboxExtended), new PropertyMetadata(new CornerRadius(0)));

        public Brush HeaderColor
        {
            get { return (Brush)GetValue(HeaderColorProperty); }
            set { SetValue(HeaderColorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for HeaderColor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HeaderColorProperty =
            DependencyProperty.Register("HeaderColor", typeof(Brush), typeof(TextboxExtended), new PropertyMetadata(Brushes.LightGray));

        public HeaderPozition HeaderPozition
        {
            get { return (HeaderPozition)GetValue(HeaderPozitionProperty); }
            set { SetValue(HeaderPozitionProperty, value); }
        }

        // Using a DependencyProperty as the backing store for HeaderPozition.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HeaderPozitionProperty =
            DependencyProperty.Register("HeaderPozition", typeof(HeaderPozition), typeof(TextboxExtended), new PropertyMetadata(HeaderPozition.Inside));


        public FontWeight HeaderFontWeight
        {
            get { return (FontWeight)GetValue(HeaderFontWeightProperty); }
            set { SetValue(HeaderFontWeightProperty, value); }
        }

        // Using a DependencyProperty as the backing store for HeaderFontWeight.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HeaderFontWeightProperty =
            DependencyProperty.Register("HeaderFontWeight", typeof(FontWeight), typeof(TextboxExtended), new PropertyMetadata(FontWeights.Normal));

        public double HeaderFontSize
        {
            get { return (double)GetValue(HeaderFontSizeProperty); }
            set { SetValue(HeaderFontSizeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for HeaderFontSize.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HeaderFontSizeProperty =
            DependencyProperty.Register("HeaderFontSize", typeof(double), typeof(TextboxExtended), new PropertyMetadata((double)20));

        public FontStyle HeaderFontStyle
        {
            get { return (FontStyle)GetValue(HeaderFontStyleProperty); }
            set { SetValue(HeaderFontStyleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for HeaderFontStyle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HeaderFontStyleProperty =
            DependencyProperty.Register("HeaderFontStyle", typeof(FontStyle), typeof(TextboxExtended), new PropertyMetadata(FontStyles.Normal));

        public string Header
        {
            get { return (string)GetValue(HeaderProperty); }
            set { SetValue(HeaderProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Header.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HeaderProperty =
            DependencyProperty.Register("Header", typeof(string), typeof(TextboxExtended), new PropertyMetadata(string.Empty));


        static TextboxExtended()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TextboxExtended), new FrameworkPropertyMetadata(typeof(TextboxExtended)));
            TextBox.FontSizeProperty.OverrideMetadata(typeof(TextboxExtended),new FrameworkPropertyMetadata((double)14));
        }
    }  
    public enum HeaderPozition
    {
        Top, Left, Inside
    }
}
