using MessageAppDemo2.Backend.PersonalData;
using System;

namespace MessageAppDemo2.Backend.Users.UserData
{

    public class Person : User
    {
        public Person(Guid ID) : base(ID)
        {
            this.UserType = UserType.Person;
        }
        public Person() : base(Guid.NewGuid())
        {
            this.UserType = UserType.Person;
        }

        public override object Clone()
        {
            Person ClonedInstance = MemberwiseClone() as Person;
            ClonedInstance.PersonalChatList = PersonalChatList.Clone() as PersonalChatList;
            ClonedInstance.PersonalUserLists = PersonalUserLists.Clone() as PersonalUserLists;
            ClonedInstance.PersonalSettings = PersonalSettings.Clone() as PersonalSettings;

            return ClonedInstance;
        }
    }

}
