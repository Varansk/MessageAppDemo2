using MessageAppDemo2.Backend.DataBase.DatabaseObjectPools.RepositoryPools;
using MessageAppDemo2.Backend.DataBase.Repositorys;
using MessageAppDemo2.Backend.Users.UserData;
using MessageAppDemo2.Backend.Users.UserData.Interfaces;
using MessageAppDemo2.Backend.ValueChecksAndControls;
using System;
using System.Windows;

namespace MessageAppDemo2.Backend.Login_SignUp
{
    public class PersonAuth : BaseAuth
    {
        public PersonAuth(Person Instance) : base(Instance)
        {

        }
        public PersonAuth()
        {

        }

        public override bool Login()
        {
            bool result = base.Login();
            if (result)
            {
                LoggedUserPool.AddLoggedUser(UserValueChecks.FindUser(Instance));
                return true;
            }
            return false;
        }

        public override bool SignUp()
        {
            DatabaseRepository<User, Guid> databaseRepository = DatabaseUserRepositoryPools.GetDatabaseUserRepositoryPool("DTBR").Get();

            bool result = base.SignUp();

            if (result)
            {
                databaseRepository.Add(Instance);
            }

            DatabaseUserRepositoryPools.GetDatabaseUserRepositoryPool("DTBR").Return(databaseRepository);

            return result;
        }
    }
}
