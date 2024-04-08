using MessageAppDemo2.Backend.StatusUpdate.Interfaces;

namespace MessageAppDemo2.Backend.StatusUpdate
{
    public class TextStatus : StatusTypeProp
    {
        public override object Clone()
        {
            TextStatus ClonedInstance = MemberwiseClone() as TextStatus;

            return ClonedInstance;
        }
    }
}
