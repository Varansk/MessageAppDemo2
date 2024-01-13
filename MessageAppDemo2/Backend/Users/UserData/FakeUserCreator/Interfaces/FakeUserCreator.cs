using MessageAppDemo.Backend.SystemData.ExtensionClasses;
using MessageAppDemo.Backend.SystemData.FakeDataCreator;
using System;

namespace MessageAppDemo.Backend.Users.UserData.FakeUserCreator.Interfaces
{
    public abstract class FakeUserCreator : IFaker<User>
    {
        protected User _User;

        public FakeUserCreator(User User)
        {
            _User = User;
        }

        public virtual User CreateFakeData()
        {
           
            _User.BirthDay = Faker.DateTimeFaker.DateTimeBetweenYears(70, -18);
            _User.FirstRegisteredDay = Faker.DateTimeFaker.DateTimeBetweenYears(DateTime.Now.Year - _User.BirthDay.Year, 0);
            _User.Name = Faker.NameFaker.FirstName();
            _User.LastName = Faker.NameFaker.LastName();
            _User.PhoneNumber = Faker.PhoneFaker.InternationalPhone();
            _User.UserSignature = Faker.TextFaker.Sentences(3);
            _User.Email = Faker.InternetFaker.Email();
            _User.Password = Faker.StringFaker.AlphaNumeric(15);
            _User.ProfilePicture = MessageAppDemo.FrontEnd.Resources.Icons.IconResources.NoImageIcon.ToImage();
            _User.PersonalSettings.BackGroundPicture = MessageAppDemo.FrontEnd.Resources.Icons.IconResources.NoImageIcon.ToImage();


            return _User;
        }
    }
}
