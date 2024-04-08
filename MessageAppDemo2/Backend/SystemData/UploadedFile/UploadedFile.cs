using System;

namespace MessageAppDemo2.Backend.SystemData.UploadedFile
{
    public class UploadedFile<FileType> : ICloneable
    {
        public byte[] RawFile { get; set; }
        public FileType File { get; set; }
        public string FileName { get; set; }

        public object Clone()
        {
            UploadedFile<FileType> CopiedInstance = MemberwiseClone() as UploadedFile<FileType>;
            //FileType lar hakkında işlem yapılacak
            return CopiedInstance;

        }
    }
}
