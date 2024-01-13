using MessageAppDemo.Backend.Users.UserData;
using System;
using System.Collections.Generic;

namespace MessageAppDemo.Backend.PersonalData
{

    public class PersonalUserLists : ICloneable
    {
        public List<User> ListOfSavedUsers { get; set; }
        public Dictionary<Guid, string> SavedUserNames { get; set; }
        public List<User> BlockedPersons { get; set; }
        public PersonalUserLists()
        {
            ListOfSavedUsers = new List<User>();
            BlockedPersons = new List<User>();
            SavedUserNames = new Dictionary<Guid, string>();
        }

        public object Clone()
        {
            PersonalUserLists ClonedInstance = this.MemberwiseClone() as PersonalUserLists;

            return ClonedInstance;
        }
    }
}
    