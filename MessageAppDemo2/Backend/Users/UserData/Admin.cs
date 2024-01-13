using MessageAppDemo.Backend.PersonalData;
using System;

namespace MessageAppDemo.Backend.Users.UserData
{

    public class Admin : User
    {
        public Admin(Guid ID) : base(ID)
        {

        }
        public Admin() : base(Guid.NewGuid())
        {
            
        }

        public override object Clone()
        {
            Admin ClonedInstance = this.MemberwiseClone() as Admin;
            ClonedInstance.PersonalChatList = PersonalChatList.Clone() as PersonalChatList;
            ClonedInstance.PersonalUserLists = PersonalUserLists.Clone() as PersonalUserLists;
            ClonedInstance.PersonalSettings = PersonalSettings.Clone() as PersonalSettings;

            return ClonedInstance;
        }
    }
}
