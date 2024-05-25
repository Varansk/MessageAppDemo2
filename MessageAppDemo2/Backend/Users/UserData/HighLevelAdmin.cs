using MessageAppDemo2.Backend.PersonalData;
using MessageAppDemo2.Backend.Users.UserData.Interfaces;
using System;

namespace MessageAppDemo2.Backend.Users.UserData
{

    public class HighLevelAdmin : User , IAdmin
    {
        public HighLevelAdmin(Guid ID) : base(ID)
        {
            this.UserType = UserType.HighLevelAdmin;
        }
        public HighLevelAdmin() : base(Guid.NewGuid())
        {
            this.UserType = UserType.HighLevelAdmin;
        }

        public override object Clone()
        {
            HighLevelAdmin ClonedInstance = MemberwiseClone() as HighLevelAdmin;
            ClonedInstance.PersonalChatList = PersonalChatList.Clone() as PersonalChatList;
            ClonedInstance.PersonalUserLists = PersonalUserLists.Clone() as PersonalUserLists;
            ClonedInstance.PersonalSettings = PersonalSettings.Clone() as PersonalSettings;

            return ClonedInstance;
        }
    }
}
