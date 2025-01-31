using MessageAppDemo2.Backend.ValueChecksAndControls;
using MessageAppDemo2.FrontEnd.FrontEnd_BackendActions.ViewModels.App;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Documents;

namespace MessageAppDemo2.Backend.SystemData.UploadedFile
{
    public class UploadedFile : ICloneable
    {
        public UploadedFile(string filePath)
        {
            _FilePath = filePath;

            if (!IsFileExists())
            {
                throw new ArgumentException("File does not exist.");
            }


            _FileName = Path.GetFileName(filePath);
            _FileType = FileFormatChecks.GetFileType(filePath);
            _FileExtension = Path.GetExtension(filePath);
        }

        private readonly string _FilePath;
        private readonly string _FileName;
        private readonly FileTypes _FileType;
        private readonly string _FileExtension;

        public string FileExtension { get { return _FileExtension; } }
        public string FilePath { get { return _FilePath; } }
        public string FileName { get { return _FileName; } }
        public FileTypes FileType { get { return _FileType; } }

        public byte[] GetRawFile()
        {
                    
            if (!IsFileExists())
            {
                return null;
            }

            List<byte> data = new List<byte>();

            using (FileStream fs = new FileStream(_FilePath, FileMode.Open, FileAccess.Read))
            {
                byte[] buffer = new byte[81920];
                int bytesread = 0;

                while ((bytesread = (fs.Read(buffer, 0, buffer.Length))) > 0)
                {
                    for (int i = 0; i < bytesread; i++)
                    {
                        data.Add(buffer[i]);
                    }
                }
            }

            return data.ToArray();

        }

        public bool IsFileExists()
        {
            if (File.Exists(_FilePath))
            {
                return true;
            }

            return false;
        }

        public object Clone()
        {
            UploadedFile CopiedInstance = MemberwiseClone() as UploadedFile;
            //FileType lar hakkında işlem yapılacak
            return CopiedInstance;

        }
    }
    public enum FileTypes
    {
        File, Video, Image, Voice, GIF
    }
}
