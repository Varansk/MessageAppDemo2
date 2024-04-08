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
    ///     <MyNamespace:ButtonExtended/>
    ///
    /// </summary>
    public class ButtonExtended : Button
    {
        public Brush OnMouseClickBorderBrush
        {
            get { return (Brush)GetValue(OnMouseClickBorderBrushProperty); }
            set { SetValue(OnMouseClickBorderBrushProperty, value); }
        }

        // Using a DependencyProperty as the backing store for OnMouseClickBorderBrush.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OnMouseClickBorderBrushProperty =
            DependencyProperty.Register("OnMouseClickBorderBrush", typeof(Brush), typeof(ButtonExtended), new PropertyMetadata(Brushes.DarkBlue));

        public Brush OnMouseEnterBorderBrush
        {
            get { return (Brush)GetValue(OnMouseEnterBorderBrushProperty); }
            set { SetValue(OnMouseEnterBorderBrushProperty, value); }
        }

        // Using a DependencyProperty as the backing store for OnMouseEnterBorderBrush.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OnMouseEnterBorderBrushProperty =
            DependencyProperty.Register("OnMouseEnterBorderBrush", typeof(Brush), typeof(ButtonExtended), new PropertyMetadata(Brushes.Blue));

        public double ButtonCornerRadius
        {
            get { return (double)GetValue(ButtonCornerRadiusProperty); }
            set { SetValue(ButtonCornerRadiusProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ButtonCornerRadius.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ButtonCornerRadiusProperty =
            DependencyProperty.Register("ButtonCornerRadius", typeof(double), typeof(ButtonExtended), new PropertyMetadata(0D));


        static ButtonExtended()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ButtonExtended), new FrameworkPropertyMetadata(typeof(ButtonExtended)));
        }
    }
}
