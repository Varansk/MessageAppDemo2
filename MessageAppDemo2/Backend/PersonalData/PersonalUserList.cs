using MessageAppDemo2.Backend.Users.UserData.Interfaces;
using System;
using System.Collections.Generic;

namespace MessageAppDemo2.Backend.PersonalData
{

    public class PersonalUserLists : ICloneable
    {
        public List<User> ListOfSavedUsers { get; set; }
        public Dictionary<Guid, string> SavedUserNames { get; set; }
        public List<User> BlockedPersons { get; set; }
        public List<User> BlockedByUsers { get; set; }
        public PersonalUserLists()
        {
            ListOfSavedUsers = new List<User>();
            BlockedPersons = new List<User>();
            SavedUserNames = new Dictionary<Guid, string>();
            BlockedByUsers = new List<User>();
        }

        public object Clone()
        {
            PersonalUserLists ClonedInstance = MemberwiseClone() as PersonalUserLists;

            return ClonedInstance;
        }
    }
}
