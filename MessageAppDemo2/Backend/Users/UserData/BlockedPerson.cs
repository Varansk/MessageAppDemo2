using MessageAppDemo2.Backend.PersonalData;
using MessageAppDemo2.Backend.StatusUpdate.Interfaces;
using MessageAppDemo2.Backend.SystemData.Enums;
using Microsoft.Identity.Client;
using System;
using System.Windows.Media.Imaging;

namespace MessageAppDemo2.Backend.Users.UserData
{

    public class BlockedPerson : User
    {
        public BlockedPerson(Guid ID) : base(ID)
        {
            this.UserType = UserType.BlockedPerson;
        }
        public BlockedPerson() : this(Guid.NewGuid())
        {

        }
        public BlockedPerson(User BlockedPersonsAccount, BanInformation Information) : this(BlockedPersonsAccount.UserGUİD)
        {
            this.BannedUserAccount = BlockedPersonsAccount;
            this.BanInformation = Information;

        }
        public override object Clone()
        {
            BlockedPerson ClonedInstance = MemberwiseClone() as BlockedPerson;
            ClonedInstance.PersonalChatList = PersonalChatList.Clone() as PersonalChatList;
            ClonedInstance.PersonalUserLists = PersonalUserLists.Clone() as PersonalUserLists;
            ClonedInstance.PersonalSettings = PersonalSettings.Clone() as PersonalSettings;

            return ClonedInstance;
        }

        public sealed override Guid UserGUİD { get => BannedUserAccount.UserGUİD; init => base.UserGUİD = value; }
        public sealed override string Name { get => BannedUserAccount.Name; set => BannedUserAccount.Name = value; }
        public sealed override string LastName { get => BannedUserAccount.LastName; set => BannedUserAccount.LastName = value; }
        public sealed override string PhoneNumber { get => BannedUserAccount.PhoneNumber; set => BannedUserAccount.PhoneNumber = value; }
        public sealed override string Email { get => BannedUserAccount.Email; set => BannedUserAccount.Email = value; }
        public sealed override string Password { get => BannedUserAccount.Password; set => BannedUserAccount.Password = value; }
        public sealed override string UserSignature { get => BannedUserAccount.UserSignature; set => BannedUserAccount.UserSignature = value; }
        public sealed override BitmapImage ProfilePicture { get => BannedUserAccount.ProfilePicture; set => BannedUserAccount.ProfilePicture = value; }
        public sealed override DateTime BirthDay { get => BannedUserAccount.BirthDay; set => BannedUserAccount.BirthDay = value; }
        public sealed override DateTime FirstRegisteredDay { get => BannedUserAccount.FirstRegisteredDay; set => BannedUserAccount.FirstRegisteredDay = value; }
        public sealed override PersonalChatList PersonalChatList { get => BannedUserAccount.PersonalChatList; set => BannedUserAccount.PersonalChatList = value; }
        public sealed override PersonalUserLists PersonalUserLists { get => BannedUserAccount.PersonalUserLists; set => BannedUserAccount.PersonalUserLists = value; }
        public sealed override PersonalSettings PersonalSettings { get => BannedUserAccount.PersonalSettings; set => BannedUserAccount.PersonalSettings = value; }
        public sealed override StatusTypeProp StatusUpdate { get => BannedUserAccount.StatusUpdate; set => BannedUserAccount.StatusUpdate = value; }


        public BanInformation BanInformation { get; set; }
        public User BannedUserAccount { get; set; }
    }


    public record struct BanInformation(string BanDetail, int BanHour, Level BanLevel, User WhoBanned)
    {

    }
}
