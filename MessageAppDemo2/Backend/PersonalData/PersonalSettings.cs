using System;
using System.Windows.Media.Imaging;

namespace MessageAppDemo2.Backend.PersonalData
{

    public class PersonalSettings : ICloneable
    {
        public BitmapImage BackGroundPicture { get; set; }
        public ViewingSettings UserViewingSettings { get; set; }

        public PersonalSettings()
        {

        }
        public object Clone()
        {
            PersonalSettings ClonedInstance = MemberwiseClone() as PersonalSettings;
            ClonedInstance.BackGroundPicture = BackGroundPicture.Clone() as BitmapImage;

            return ClonedInstance;
        }
    }
    public enum ViewingSettings
    {
        Default, ClosedView, BusinessMan
    }
}
