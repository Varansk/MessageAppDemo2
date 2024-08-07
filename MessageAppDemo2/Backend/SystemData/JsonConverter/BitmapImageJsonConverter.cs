using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using MessageAppDemo2.Backend.SystemData.ExtensionClasses;
using System.Buffers.Text;
using System.Diagnostics;
namespace MessageAppDemo2.Backend.SystemData.JsonConverter
{
    public class BitmapImageJsonConverter : Newtonsoft.Json.JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            if (objectType == typeof(BitmapImage))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            var base64 = (string)reader.Value;
            byte[] array = Convert.FromBase64String(base64);

            BitmapImage bitmapImage = new BitmapImage();

            bitmapImage = array.ToBitmapImage();

            return bitmapImage;
        }

        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            BitmapImage bitmapImage = value as BitmapImage;

            byte[] bytes = bitmapImage.ToByteArray();

            string stringmessage = Convert.ToBase64String(bytes);

            writer.WriteValue(stringmessage);
        }

    }
}
