using MessageAppDemo2.Backend.Users.UserData;
using System;

namespace MessageAppDemo2.Backend.StatusUpdate.Interfaces
{
    public abstract class StatusTypeProp : ICloneable
    {
        public int StatusID { get; set; }
        public WhoCanSeeStatus StatusAccess { get; set; }
        public User WhoShares { get; set; }
        public DateTime SharedDate { get; set; }
        public DateTime EndOfSharingDate { get; set; }

        public StatusTypeProp()
        {
            StatusID = -1;
        }
        public abstract object Clone();

    }
    public enum WhoCanSeeStatus
    {
        SavedPersons, All
    }
}
