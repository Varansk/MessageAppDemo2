using System.Collections.Generic;

namespace MessageAppDemo.Backend.Message.MessageDatas.Interfaces
{
    public interface IFileUploadableMessage<FileType>
    {
        List<FileType> Files { get; set; }
    }
}
    