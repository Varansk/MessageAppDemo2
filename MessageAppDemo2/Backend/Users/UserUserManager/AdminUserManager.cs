using MessageAppDemo2.Backend.Chatting.ChatData.Interfaces;
using MessageAppDemo2.Backend.Chatting.ChatUserActions;
using MessageAppDemo2.Backend.Chatting.ChatUserActions.Interfaces;
using MessageAppDemo2.Backend.DataBase.DatabaseObjectPools.RepositoryPools;
using MessageAppDemo2.Backend.DataBase.Repositorys;
using MessageAppDemo2.Backend.ReportSystem;
using MessageAppDemo2.Backend.ReportSystem.Interfaces;
using MessageAppDemo2.Backend.SystemData.BasicCRUDSupport;
using MessageAppDemo2.Backend.SystemData.ChangeController;
using MessageAppDemo2.Backend.SystemData.ExtensionClasses.CollectionExtensions;
using MessageAppDemo2.Backend.Users.UserData;
using MessageAppDemo2.Backend.Users.UserData.Interfaces;
using MessageAppDemo2.Backend.Users.UserManagers;
using MessageAppDemo2.Backend.Users.UserManagers.Managers;
using MessageAppDemo2.Backend.Users.UserManagers.Managers.Factory;
using MessageAppDemo2.Backend.Users.UserManagers.Managers.Interfaces;
using MessageAppDemo2.Backend.Users.UserUserManager.Interfaces;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MessageAppDemo2.Backend.Users.UserUserManager
{
    public class AdminUserManager : IAdminUserManager<Admin>
    {
        private UserController userController = new UserController();
        public bool AddFriend(Admin User1, User User2)
        {
            DatabaseRepository<User, Guid> userRepository = DatabaseUserRepositoryPools.GetDatabaseUserRepositoryPool("DTBR").Get();

            if (User1 is null || User2 is null)
            {
                return false;
            }

            if ((User1.PersonalUserLists.BlockedByUsers.Contains(User2, userController) && User2.PersonalUserLists.BlockedPersons.Contains(User1, userController)) || (User1.PersonalUserLists.BlockedPersons.Contains(User2, userController) && User2.PersonalUserLists.BlockedByUsers.Contains(User1, userController)))
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

        public bool BanUser(Admin Banner, User Banned, BanInformation Information)
        {
            if (Banner is null || Banned is null)
            {
                return false;
            }

            if (Banned is IAdmin || Banned is BlockedPerson)
            {
                return false;
            }

            UserManager userManager = new();
            UserManagerFactory userManagerFactory = new();

            dynamic obj = userManagerFactory.CreateInstance((UserType)Banned);

            DatabaseRepository<User, Guid> databaseUserRepository = DatabaseUserRepositoryPools.GetDatabaseUserRepositoryPool("DTBR").Get();

            Type type = obj.GetType();

            MethodInfo o = typeof(UserManager).GetMethod("Remove").MakeGenericMethod(type.GetInterface("IUserManager`2", true).GenericTypeArguments[0], type.GetInterface("IUserManager`2").GenericTypeArguments[1]);

            o.Invoke(userManager, new object[] { obj, Banned.UserGUİD });

            // userManager.Remove(obj, Banned.UserGUİD);

            BlockedPerson blocked = new BlockedPerson(Banned, Information);
            databaseUserRepository.Add(blocked);

            DatabaseUserRepositoryPools.GetDatabaseUserRepositoryPool("DTBR").Return(databaseUserRepository);

            return true;
        }


        public bool BlockUser(Admin Blocker, User Blocked)
        {
            DatabaseRepository<User, Guid> userRepository = DatabaseUserRepositoryPools.GetDatabaseUserRepositoryPool("DTBR").Get();

            if (Blocker is null || Blocked is null)
            {
                return false;
            }

            if (Blocker.PersonalUserLists.BlockedPersons.Contains(Blocked, userController) && Blocked.PersonalUserLists.BlockedByUsers.Contains(Blocker, userController))
            {
                return false;
            }

            if (Blocker.PersonalUserLists.ListOfSavedUsers.Contains(Blocked, userController) || Blocked.PersonalUserLists.ListOfSavedUsers.Contains(Blocker, userController))
            {
                RemoveFriend(Blocker, Blocked);
            }

            Blocker.PersonalUserLists.BlockedPersons.Add(Blocked);
            Blocked.PersonalUserLists.BlockedByUsers.Add(Blocker);

            if (!(userRepository.GetByID(Blocker.UserGUİD).PersonalUserLists.BlockedPersons.Contains(Blocked, userController)))
            {
                userRepository.UpdateWithPatch(Blocker.UserGUİD, (I) => { I.PersonalUserLists.BlockedPersons.Add(Blocked); });
            }

            if (!(userRepository.GetByID(Blocked.UserGUİD).PersonalUserLists.BlockedByUsers.Contains(Blocker, userController)))
            {
                userRepository.UpdateWithPatch(Blocked.UserGUİD, (I) => { I.PersonalUserLists.BlockedByUsers.Add(Blocker); });
            }

            DatabaseUserRepositoryPools.GetDatabaseUserRepositoryPool("DTBR").Return(userRepository);

            return true;
        }

        public bool RemoveFriend(Admin User1, User User2)
        {
            DatabaseRepository<User, Guid> userRepository = DatabaseUserRepositoryPools.GetDatabaseUserRepositoryPool("DTBR").Get();

            if (User1 is null || User2 is null)
            {
                return false;
            }

            if (!User1.PersonalUserLists.ListOfSavedUsers.Contains(User2, userController) || !User2.PersonalUserLists.ListOfSavedUsers.Contains(User1, userController))
            {
                return false;
            }

            User1.PersonalUserLists.ListOfSavedUsers.Remove(User2, userController);
            User2.PersonalUserLists.ListOfSavedUsers.Remove(User1, userController);

            if (userRepository.GetByID(User1.UserGUİD).PersonalUserLists.ListOfSavedUsers.Contains(User2, userController))
            {
                userRepository.UpdateWithPatch(User1.UserGUİD, (I) => { I.PersonalUserLists.ListOfSavedUsers.Remove(User2, userController); });
            }

            if (userRepository.GetByID(User2.UserGUİD).PersonalUserLists.ListOfSavedUsers.Contains(User1, userController))
            {
                userRepository.UpdateWithPatch(User2.UserGUİD, (I) => { I.PersonalUserLists.ListOfSavedUsers.Remove(User1, userController); });
            }

            DatabaseUserRepositoryPools.GetDatabaseUserRepositoryPool("DTBR").Return(userRepository);

            return true;
        }

        public bool Report(UserReport ReportDetails)
        {
            DatabaseRepository<ReportBase, Guid> ReportRepository = DatabaseReportRepositoryPools.GetDatabaseReportRepositoryPool("DTBR").Get();

            ReportRepository.Add(ReportDetails);

            DatabaseReportRepositoryPools.GetDatabaseReportRepositoryPool("DTBR").Return(ReportRepository);

            return true;
        }

        public bool UnBanUser(Admin Banner, BlockedPerson Banned)
        {
            UserController userController = new();
            DatabaseRepository<User, Guid> databaseRepository = DatabaseUserRepositoryPools.GetDatabaseUserRepositoryPool("DTBR").Get();

            if (Banner is null || Banned is null)
            {
                return false;
            }

            if (databaseRepository.GetByID(Banned.UserGUİD) is not null && databaseRepository.GetByID(Banner.UserGUİD) is not null)
            {
                databaseRepository.Remove(Banned, userController);
                databaseRepository.Add(Banned.BannedUserAccount);
            }

            DatabaseUserRepositoryPools.GetDatabaseUserRepositoryPool("DTBR").Return(databaseRepository);

            return true;
        }

        public bool UnBlockUser(Admin Blocker, User Blocked)
        {
            DatabaseRepository<User, Guid> userRepository = DatabaseUserRepositoryPools.GetDatabaseUserRepositoryPool("DTBR").Get();

            if (Blocker is null || Blocked is null)
            {
                return false;
            }

            if (!Blocker.PersonalUserLists.BlockedPersons.Contains(Blocked, userController) && !Blocked.PersonalUserLists.BlockedByUsers.Contains(Blocker, userController))
            {
                return false;
            }

            Blocker.PersonalUserLists.BlockedPersons.Remove(Blocked, userController);
            Blocked.PersonalUserLists.BlockedByUsers.Remove(Blocker, userController);

            if (userRepository.GetByID(Blocker.UserGUİD).PersonalUserLists.BlockedPersons.Contains(Blocked, userController))
            {
                userRepository.UpdateWithPatch(Blocker.UserGUİD, (I) => { I.PersonalUserLists.BlockedPersons.Remove(Blocked, userController); });
            }

            if (userRepository.GetByID(Blocked.UserGUİD).PersonalUserLists.BlockedByUsers.Contains(Blocker, userController))
            {
                userRepository.UpdateWithPatch(Blocked.UserGUİD, (I) => { I.PersonalUserLists.BlockedByUsers.Remove(Blocker, userController); });
            }

            DatabaseUserRepositoryPools.GetDatabaseUserRepositoryPool("DTBR").Return(userRepository);

            return true;
        }
    }
}
