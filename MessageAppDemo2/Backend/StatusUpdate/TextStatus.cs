using MessageAppDemo.Backend.StatusUpdate.Interfaces;

namespace MessageAppDemo.Backend.StatusUpdate
{
    public class TextStatus : StatusTypeProp
    {
        public override object Clone()
        {
            TextStatus ClonedInstance = this.MemberwiseClone() as TextStatus;

            return ClonedInstance;
        }
    }
}
