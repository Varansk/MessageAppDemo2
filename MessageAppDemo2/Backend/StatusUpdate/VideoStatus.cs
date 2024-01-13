using MessageAppDemo.Backend.StatusUpdate.Interfaces;

namespace MessageAppDemo.Backend.StatusUpdate
{
    public class VideoStatus : StatusTypeProp
    {
        public override object Clone()
        {
            VideoStatus ClonedInstance = this.MemberwiseClone() as VideoStatus;
             
            return ClonedInstance;
        }
    }
}
