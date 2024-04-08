using MessageAppDemo2.Backend.StatusUpdate.Interfaces;

namespace MessageAppDemo2.Backend.StatusUpdate
{
    public class VideoStatus : StatusTypeProp
    {
        public override object Clone()
        {
            VideoStatus ClonedInstance = MemberwiseClone() as VideoStatus;

            return ClonedInstance;
        }
    }
}
