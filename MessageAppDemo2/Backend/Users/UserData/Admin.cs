using MessageAppDemo2.Backend.PersonalData;
using System;

namespace MessageAppDemo2.Backend.Users.UserData
{

    public class Admin : User
    {
        public Admin(Guid ID) : base(ID)
        {
            this.UserType = UserType.Admin;
        }
        public Admin() : base(Guid.NewGuid())
        {
            this.UserType = UserType.Admin;
        }


        public override object Clone()
        {
            Admin ClonedInstance = MemberwiseClone() as Admin;
            ClonedInstance.PersonalChatList = PersonalChatList.Clone() as PersonalChatList;
            ClonedInstance.PersonalUserLists = PersonalUserLists.Clone() as PersonalUserLists;
            ClonedInstance.PersonalSettings = PersonalSettings.Clone() as PersonalSettings;

            return ClonedInstance;
        }
    }
}
