using MessageAppDemo.Backend.PersonalData;
using System;

namespace MessageAppDemo.Backend.Users.UserData
{

    public class Person : User
    {
        public Person(Guid ID) : base(ID)
        {

        }
        public Person() : base(Guid.NewGuid()) 
        {
            
        }

        public override object Clone()
        {
            Person ClonedInstance = this.MemberwiseClone() as Person;         
            ClonedInstance.PersonalChatList = PersonalChatList.Clone() as PersonalChatList;
            ClonedInstance.PersonalUserLists = PersonalUserLists.Clone() as PersonalUserLists;
            ClonedInstance.PersonalSettings = PersonalSettings.Clone() as PersonalSettings;

            return ClonedInstance;
        }
    }

}
