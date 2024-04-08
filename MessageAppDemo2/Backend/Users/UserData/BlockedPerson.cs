using MessageAppDemo2.Backend.PersonalData;
using System;

namespace MessageAppDemo2.Backend.Users.UserData
{

    public class BlockedPerson : User
    {
        public BlockedPerson(Guid ID) : base(ID)
        {
            this.UserType = UserType.BlockedPerson;
        }
        public BlockedPerson() : base(Guid.NewGuid())
        {
            this.UserType = UserType.BlockedPerson;
        }
        public override object Clone()
        {
            BlockedPerson ClonedInstance = MemberwiseClone() as BlockedPerson;
            ClonedInstance.PersonalChatList = PersonalChatList.Clone() as PersonalChatList;
            ClonedInstance.PersonalUserLists = PersonalUserLists.Clone() as PersonalUserLists;
            ClonedInstance.PersonalSettings = PersonalSettings.Clone() as PersonalSettings;

            return ClonedInstance;
        }

        public BanInformation BanInformation { get; set; }  
        public User BannedUserAccount { get; set; }
    }
    [Flags] 
    public enum BanLevel
    {
        VeryLow = 1, Low, Medium, High, VeryHigh
    }

    public record struct BanInformation(string BanDetail, int BanHour, BanLevel BanLevel)
    {

    }
}
