using MessageAppDemo2.Backend.SystemData.UploadedFile;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace MessageAppDemo2.Backend.ValueChecksAndControls
{
    public static class FileFormatChecks
    {
        public static FileTypes GetFileType(string filePath)
        {
            if (IsImage(filePath))
            {
                return FileTypes.Image;
            }
            else if (IsGIF(filePath))
            {
                return FileTypes.GIF;
            }
            else if (IsVideo(filePath))
            {
                return FileTypes.Video;
            }
            else if (IsAudio(filePath))
            {
                return FileTypes.Voice;
            }
            else
            {
                return FileTypes.File;
            }
        }

        public static bool IsImage(string filePath)
        {
            try
            {
                BitmapImage bs = new(new Uri(filePath));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool IsVideo(string filePath)
        {

            string FileExt = Path.GetExtension(filePath);
            string[] VideoFormats = new string[]
            { ".mp4", ".m4v" ,".mov", ".asf",".avi",".wmv",".m2ts" ,".mkv",".ogv"};

            if (VideoFormats.Contains(FileExt.ToLower()))
            {
                return true;
            }

            return false;


        }
        public static bool IsGIF(string filePath)
        {
            string FileExt = Path.GetExtension(filePath);


            if (FileExt.ToLower() == ".gif")
            {
                return true;
            }

            return false;

        }

        public static bool IsAudio(string filePath)
        {
            string FileExt = Path.GetExtension(filePath);
            string[] VideoFormats = new string[]
            {".mp3",".flac",".aac",".adt",".adts",".m4a",".wav",".wma",".ac3",".amr",".mka",".oga", ".ogg",".opus" };

            if (VideoFormats.Contains(FileExt.ToLower()))
            {
                return true;
            }

            return false;

        }




    }
}
