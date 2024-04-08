using System.Windows.Media.Imaging;

namespace MessageAppDemo2.Backend.SystemData.ExtensionClasses
{
    public static class ByteExtension
    {
        public static BitmapImage ToImage(this byte[] array)
        {
            using (var ms = new System.IO.MemoryStream(array))
            {
                var image = new BitmapImage();
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.StreamSource = ms;
                image.EndInit();
                return image;
            }
        }
    }
}
