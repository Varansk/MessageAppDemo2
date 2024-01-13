using MessageAppDemo.Backend.PersonalData;
using System;

namespace MessageAppDemo.Backend.Users.UserData
{

    public class BlockedPerson : User
    {
        public BlockedPerson(Guid ID) : base(ID)
        {

        }
        public BlockedPerson() : base(Guid.NewGuid())
        {
            
        }
        public override object Clone()
        {
            BlockedPerson ClonedInstance = this.MemberwiseClone() as BlockedPerson;
            ClonedInstance.PersonalChatList = PersonalChatList.Clone() as PersonalChatList;
            ClonedInstance.PersonalUserLists = PersonalUserLists.Clone() as PersonalUserLists;
            ClonedInstance.PersonalSettings = PersonalSettings.Clone() as PersonalSettings;

            return ClonedInstance;
        }
    }
}
