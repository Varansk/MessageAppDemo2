using MessageAppDemo.Backend.PersonalData;
using System;

namespace MessageAppDemo.Backend.Users.UserData
{

    public class HighLevelAdmin : User
    {
        public HighLevelAdmin(Guid ID) : base(ID)
        {

        }
        public HighLevelAdmin() : base(Guid.NewGuid()) 
        {
            
        }

        public override object Clone()
        {
            HighLevelAdmin ClonedInstance = this.MemberwiseClone() as HighLevelAdmin;
            ClonedInstance.PersonalChatList = PersonalChatList.Clone() as PersonalChatList;
            ClonedInstance.PersonalUserLists = PersonalUserLists.Clone() as PersonalUserLists;
            ClonedInstance.PersonalSettings = PersonalSettings.Clone() as PersonalSettings;

            return ClonedInstance;
        }
    }
}
