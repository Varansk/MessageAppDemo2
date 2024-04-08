using MessageAppDemo2.Backend.PersonalData;
using MessageAppDemo2.Backend.StatusUpdate.Interfaces;
using System;
using System.Windows.Media.Imaging;

namespace MessageAppDemo2.Backend.Users.UserData
{
    public abstract class User : ICloneable
    {
        public Guid UserGUİD { get; init; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserSignature { get; set; }
        public BitmapImage ProfilePicture { get; set; }
        public DateTime BirthDay { get; set; }
        public DateTime FirstRegisteredDay { get; set; }
        public PersonalChatList PersonalChatList { get; set; }
        public PersonalUserLists PersonalUserLists { get; set; }
        public PersonalSettings PersonalSettings { get; set; }
        public StatusTypeProp StatusUpdate { get; set; }
        public UserType UserType { get; set; }


        public User(Guid ID)
        {   
            UserGUİD = ID;
            InitializeUser();
        }
        public User()
        {
            UserGUİD = Guid.NewGuid();
            InitializeUser();
        }
        protected virtual void InitializeUser()
        {
            PersonalChatList = new PersonalChatList();
            PersonalUserLists = new PersonalUserLists();
            PersonalSettings = new PersonalSettings();
        }

        public abstract object Clone();
    }
    public enum UserType
    {
        Person, BlockedPerson, BusinessPerson, Admin, HighLevelAdmin
    }
}
