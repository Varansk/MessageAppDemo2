using MessageAppDemo2.Backend.PersonalData;
using System;

namespace MessageAppDemo2.Backend.Users.UserData
{

    public class BusinessPerson : User
    {
        public BusinessPerson(Guid ID) : base(ID)
        {
            this.UserType = UserType.BusinessPerson;
        }
        public BusinessPerson() : base(Guid.NewGuid())
        {
            this.UserType = UserType.BusinessPerson;
        }

        public override object Clone()
        {
            BusinessPerson ClonedInstance = MemberwiseClone() as BusinessPerson;
            ClonedInstance.PersonalChatList = PersonalChatList.Clone() as PersonalChatList;
            ClonedInstance.PersonalUserLists = PersonalUserLists.Clone() as PersonalUserLists;
            ClonedInstance.PersonalSettings = PersonalSettings.Clone() as PersonalSettings;

            return ClonedInstance;
        }
    }
}
