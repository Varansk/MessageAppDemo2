using MessageAppDemo.Backend.PersonalData;
using System;

namespace MessageAppDemo.Backend.Users.UserData
{

    public class BusinessPerson : User
    {
        public BusinessPerson(Guid ID) : base(ID)
        {

        }
        public BusinessPerson() : base(Guid.NewGuid())
        {
            
        }

        public override object Clone()
        {
            BusinessPerson ClonedInstance = this.MemberwiseClone() as BusinessPerson;
            ClonedInstance.PersonalChatList = PersonalChatList.Clone() as PersonalChatList;
            ClonedInstance.PersonalUserLists = PersonalUserLists.Clone() as PersonalUserLists;
            ClonedInstance.PersonalSettings = PersonalSettings.Clone() as PersonalSettings;

            return ClonedInstance;
        }
    }
}
