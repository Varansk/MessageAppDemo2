using MessageAppDemo2.Backend.DataBase.DatabaseObjectPools.RepositoryPools;
using MessageAppDemo2.Backend.DataBase.Repositorys;
using MessageAppDemo2.Backend.Users.UserData;
using MessageAppDemo2.Backend.Users.UserData.Interfaces;
using System;

namespace MessageAppDemo2.Backend.Login_SignUp.UserLoginClass
{
    public class BusinessPersonAuth : BaseAuth
    {
        public BusinessPersonAuth(BusinessPerson Instance) : base(Instance)
        {
        }
        public BusinessPersonAuth()
        {

        }
        public override bool Login()
        {
            bool result = base.Login();
            if (result)
            {
                LoggedUserPool.AddLoggedUser(this.Instance);
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

