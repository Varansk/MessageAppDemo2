using MessageAppDemo2.Backend.PersonalData;
using MessageAppDemo2.Backend.StatusUpdate.Interfaces;
using System;
using System.Runtime.CompilerServices;
using System.Windows.Media.Imaging;

namespace MessageAppDemo2.Backend.Users.UserData.Interfaces
{
    public abstract class User : ICloneable
    {
        public virtual Guid UserGUİD { get; init; }
        public virtual string Name { get; set; }
        public virtual string LastName { get; set; }
        public virtual string PhoneNumber { get; set; }
        public virtual string Email { get; set; }
        public virtual string Password { get; set; }
        public virtual string UserSignature { get; set; }
        public virtual BitmapImage ProfilePicture { get; set; }
        public virtual DateTime BirthDay { get; set; }
        public virtual DateTime FirstRegisteredDay { get; set; }
        public virtual PersonalChatList PersonalChatList { get; set; }
        public virtual PersonalUserLists PersonalUserLists { get; set; }
        public virtual PersonalSettings PersonalSettings { get; set; }
        public virtual StatusTypeProp StatusUpdate { get; set; }
        public virtual UserType UserType { get; set; }

        protected User(Guid ID, bool InitiliazeBaseUser)
        {
            UserGUİD = ID;
            if (InitiliazeBaseUser)
            {
                InitializeUser();
            }
        }

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

        public static explicit operator UserType(User user)
        {
            switch (user)
            {
                case Person:
                    return UserType.Person;
                case Admin:
                    return UserType.Admin;
                case HighLevelAdmin:
                    return UserType.HighLevelAdmin;
                case BlockedPerson:
                    return UserType.BlockedPerson;
                case BusinessPerson:
                    return UserType.BusinessPerson;
                default:
                    throw new ArgumentException("User Type Not Found.");
            }
        }
    }
    public enum UserType
    {
        Person, BlockedPerson, BusinessPerson, Admin, HighLevelAdmin
    }
}
