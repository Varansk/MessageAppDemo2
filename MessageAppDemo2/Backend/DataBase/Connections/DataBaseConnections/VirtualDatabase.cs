using MessageAppDemo.Backend.Chatting.ChatData.Interfaces;
using MessageAppDemo.Backend.DataBase.Connections.DataBaseConnections.Interfaces;
using MessageAppDemo.Backend.Message.MessageDatas.Interfaces;
using MessageAppDemo.Backend.Users.UserData;
using System.Collections.Generic;

namespace MessageAppDemo.Backend.DataBase.Connections.DataBaseConnections
{
    public class VirtualDatabase : IBasicDatabase
    {
        private List<User> Users;
        private List<ChatBase> Chats;
        private List<MessageBase> Messages;


        private object UsersLockConnection;
        private object ChatsLockConnection;
        private object MessagesLockConnection;

        public VirtualDatabase()
        {
            InitializeConnector();
        }
        public List<User> UserList
        {
            get { return Users; }
            set { Users = value; }
        }
        public List<ChatBase> ChatList
        {
            get { return Chats; }
            set { Chats = value; }
        }

        public List<MessageBase> MessageList
        {
            get { return Messages; }
            set { Messages = value; }
        }
        public void InitializeConnector()
        {
            Chats = new List<ChatBase>();
            Users = new List<User>();
            Messages = new List<MessageBase>();

            CreateFakeUserData(Users, 50);

            CloseConnection();
        }

        public void DeactivateConnections()
        {
            Chats = null;
            Users = null;
            Messages = null;
            UsersLockConnection = null;
            ChatsLockConnection = null;
            MessagesLockConnection = null;
        }

        public void OpenConnection()
        {
            Users = (List<User>)UsersLockConnection;
            Chats = (List<ChatBase>)ChatsLockConnection;
            Messages = (List<MessageBase>)MessagesLockConnection;
        }

        public void CloseConnection()
        {
            UsersLockConnection = Users;
            ChatsLockConnection = Chats;
            MessagesLockConnection = Messages;

            Users = null;
            Chats = null;
            Messages = null;
        }
        #region FakeDataCreaters
        private void CreateFakeUserData(List<User> Users, int Count)
        {
            /*
            for (int i = 0; i < Count * 3 / 4; i++)
            {
                Person person = new Person(Guid.NewGuid());
                person.BirthDay = Faker.DateTimeFaker.DateTimeBetweenYears(70, -18);
                person.FirstRegisteredDay = Faker.DateTimeFaker.DateTimeBetweenYears(DateTime.Now.Year - person.BirthDay.Year, 0);
                person.Name = Faker.NameFaker.FirstName();
                person.LastName = Faker.NameFaker.LastName();
                person.PhoneNumber = Faker.PhoneFaker.InternationalPhone();
                person.UserSignature = Faker.TextFaker.Sentences(3);
                person.Email = Faker.InternetFaker.Email();
                person.Password = Faker.StringFaker.AlphaNumeric(15);
                person.ProfilePicture = BitmapImage.FromFile(@"C:\Users\ertur\Downloads\No-BitmapImage-Placeholder.svg.png");
                person.PersonalSettings.BackGroundPicture = BitmapImage.FromFile(@"C:\Users\ertur\Downloads\No-BitmapImage-Placeholder.svg.png");

                Users.Add(person);
            }
            for (int i = 0; i < Count * 1 / 16; i++)
            {
                Admin admin = new Admin(Guid.NewGuid());
                admin.BirthDay = Faker.DateTimeFaker.DateTimeBetweenYears(70, -18);
                admin.FirstRegisteredDay = Faker.DateTimeFaker.DateTimeBetweenYears(DateTime.Now.Year - admin.BirthDay.Year, 0);
                admin.Name = Faker.NameFaker.FirstName();
                admin.LastName = Faker.NameFaker.LastName();
                admin.PhoneNumber = Faker.PhoneFaker.InternationalPhone();
                admin.UserSignature = Faker.TextFaker.Sentences(3);
                admin.Email = Faker.InternetFaker.Email();
                admin.Password = Faker.StringFaker.AlphaNumeric(15);
                admin.ProfilePicture = BitmapImage.FromFile(@"C:\Users\ertur\Downloads\No-BitmapImage-Placeholder.svg.png");
                admin.PersonalSettings.BackGroundPicture = BitmapImage.FromFile(@"C:\Users\ertur\Downloads\No-BitmapImage-Placeholder.svg.png");

                Users.Add(admin);
            }
            for (int i = 0; i < Count * 1 / 16; i++)
            {
                HighLevelAdmin highLevelAdmin = new HighLevelAdmin(Guid.NewGuid());
                highLevelAdmin.BirthDay = Faker.DateTimeFaker.DateTimeBetweenYears(70, -18);
                highLevelAdmin.FirstRegisteredDay = Faker.DateTimeFaker.DateTimeBetweenYears(DateTime.Now.Year - highLevelAdmin.BirthDay.Year, 0);
                highLevelAdmin.Name = Faker.NameFaker.FirstName();
                highLevelAdmin.LastName = Faker.NameFaker.LastName();
                highLevelAdmin.PhoneNumber = Faker.PhoneFaker.InternationalPhone();
                highLevelAdmin.UserSignature = Faker.TextFaker.Sentences(3);
                highLevelAdmin.Email = Faker.InternetFaker.Email();
                highLevelAdmin.Password = Faker.StringFaker.AlphaNumeric(15);
                highLevelAdmin.ProfilePicture = BitmapImage.FromFile(@"C:\Users\ertur\Downloads\No-BitmapImage-Placeholder.svg.png");
                highLevelAdmin.PersonalSettings.BackGroundPicture = BitmapImage.FromFile(@"C:\Users\ertur\Downloads\No-BitmapImage-Placeholder.svg.png");

                Users.Add(highLevelAdmin);
            }
            for (int i = 0; i < Count * 1 / 16; i++)
            {
                BlockedPerson blockedPerson = new BlockedPerson(Guid.NewGuid());
                blockedPerson.BirthDay = Faker.DateTimeFaker.DateTimeBetweenYears(70, -18);
                blockedPerson.FirstRegisteredDay = Faker.DateTimeFaker.DateTimeBetweenYears(DateTime.Now.Year - blockedPerson.BirthDay.Year, 0);
                blockedPerson.Name = Faker.NameFaker.FirstName();
                blockedPerson.LastName = Faker.NameFaker.LastName();
                blockedPerson.PhoneNumber = Faker.PhoneFaker.InternationalPhone();
                blockedPerson.UserSignature = Faker.TextFaker.Sentences(3);
                blockedPerson.Email = Faker.InternetFaker.Email();
                blockedPerson.Password = Faker.StringFaker.AlphaNumeric(15);
                blockedPerson.ProfilePicture = BitmapImage.FromFile(@"C:\Users\ertur\Downloads\No-BitmapImage-Placeholder.svg.png");
                blockedPerson.PersonalSettings.BackGroundPicture = BitmapImage.FromFile(@"C:\Users\ertur\Downloads\No-BitmapImage-Placeholder.svg.png");

                Users.Add(blockedPerson);
            }
            for (int i = 0; i < Count * 1 / 16; i++)
            {
                BusinessPerson businessPerson = new BusinessPerson(Guid.NewGuid());
                businessPerson.BirthDay = Faker.DateTimeFaker.DateTimeBetweenYears(70, -18);
                businessPerson.FirstRegisteredDay = Faker.DateTimeFaker.DateTimeBetweenYears(DateTime.Now.Year - businessPerson.BirthDay.Year, 0);
                businessPerson.Name = Faker.NameFaker.FirstName();
                businessPerson.LastName = Faker.NameFaker.LastName();
                businessPerson.PhoneNumber = Faker.PhoneFaker.InternationalPhone();
                businessPerson.UserSignature = Faker.TextFaker.Sentences(3);
                businessPerson.Email = Faker.InternetFaker.Email();
                businessPerson.Password = Faker.StringFaker.AlphaNumeric(15);
                businessPerson.ProfilePicture = BitmapImage.FromFile(@"C:\Users\ertur\Downloads\No-BitmapImage-Placeholder.svg.png");
                businessPerson.PersonalSettings.BackGroundPicture = BitmapImage.FromFile(@"C:\Users\ertur\Downloads\No-BitmapImage-Placeholder.svg.png");

                Users.Add(businessPerson);
            }
            */

        }
        private void CreateFakeMessageData(List<MessageBase> Messages, int Count)
        {

        }
        private void CreateFakeChatData(List<ChatBase> Chats, int Count)
        {

        }
        #endregion
    }
}
