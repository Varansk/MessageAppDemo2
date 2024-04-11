using MessageAppDemo2.Backend.DataBase.DatabaseObjectPools.RepositoryPools;
using MessageAppDemo2.Backend.DataBase.Repositorys;
using MessageAppDemo2.Backend.ReportSystem;
using MessageAppDemo2.Backend.SystemData.ChangeController;
using MessageAppDemo2.Backend.SystemData.ExtensionClasses.CollectionExtensions;
using MessageAppDemo2.Backend.Users.UserData;
using MessageAppDemo2.Backend.Users.UserUserManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageAppDemo2.Backend.Users.UserUserManager
{
    public class HighLevelAdminUserManager : IHighLevelAdminUserManager
    {
        private UserController userController = new UserController();
        public bool AddFriend(Admin User1, User User2)
        {
            DatabaseRepository<User, Guid> userRepository = DatabaseUserRepositoryPools.GetDatabaseUserRepositoryPool("DTBR").Get();
            if (User1 is null || User2 is null)
            {
                return false;
            }
            if ((User1.PersonalUserLists.BlockedByUsers.Contains(User2, userController) && User1.PersonalUserLists.BlockedPersons.Contains(User2, userController)) || (User2.PersonalUserLists.BlockedPersons.Contains(User1, userController) && User2.PersonalUserLists.BlockedByUsers.Contains(User1, userController)))
            {
                return false;
            }
            if (User1.PersonalUserLists.ListOfSavedUsers.Contains(User2, userController) || User2.PersonalUserLists.ListOfSavedUsers.Contains(User1, userController))
            {
                return false;
            }
            User1.PersonalUserLists.ListOfSavedUsers.Add(User2);
            User2.PersonalUserLists.ListOfSavedUsers.Add(User1);
            if (!(userRepository.GetByID(User1.UserGUİD).PersonalUserLists.ListOfSavedUsers.Contains(User2, userController)))
            {
                userRepository.UpdateWithPatch(User1.UserGUİD, (I) => { I.PersonalUserLists.ListOfSavedUsers.Add(User2); });
            }

            if (!(userRepository.GetByID(User2.UserGUİD).PersonalUserLists.ListOfSavedUsers.Contains(User1, userController)))
            {
                userRepository.UpdateWithPatch(User2.UserGUİD, (I) => { I.PersonalUserLists.ListOfSavedUsers.Add(User1); });
            }

            DatabaseUserRepositoryPools.GetDatabaseUserRepositoryPool("DTBR").Return(userRepository);

            return true;
        }

        public bool BanAdmin(HighLevelAdmin User1, Admin User2)
        {
            throw new NotImplementedException();
        }

        public bool BanUser(Admin Banner, User Banned, BanInformation Information)
        {
            throw new NotImplementedException();
        }

        public bool BlockUser(Admin Blocker, User Blocked)
        {
            throw new NotImplementedException();
        }

        public bool RemoveFriend(Admin User1, User User2)
        {
            throw new NotImplementedException();
        }

        public bool Report(UserReportDetails ReportDetails)
        {
            throw new NotImplementedException();
        }

        public bool UnBanUser(Admin Banner, User Banned)
        {
            throw new NotImplementedException();
        }

        public bool UnBlockUser(Admin Blocker, User Blocked)
        {
            throw new NotImplementedException();
        }
    }
}
