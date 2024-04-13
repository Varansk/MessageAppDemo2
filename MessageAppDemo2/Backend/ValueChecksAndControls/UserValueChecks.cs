using MessageAppDemo2.Backend.DataBase.DatabaseObjectPools.RepositoryPools;
using MessageAppDemo2.Backend.DataBase.Repositorys;
using MessageAppDemo2.Backend.SystemData.ExtensionClasses;
using MessageAppDemo2.Backend.Users.UserData;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace MessageAppDemo2.Backend.ValueChecksAndControls
{

    public static class UserValueChecks
    {
        public static bool CheckUser(User User, Func<User, bool> ControlMethods)
        {
            if (User == null)
            {
                return false;
            }
            Delegate[] DG = ControlMethods.GetInvocationList();

            foreach (Delegate item in DG)
            {
                if (!(bool)item.DynamicInvoke(User))
                {
                    return false;
                }
            }
            return true;

        }

        #region Methods Accessible By User

        public static bool IsThisNumberExists(User User)
        {
            return IsThisNumberExists(User.PhoneNumber);
        }

        public static bool IsThisNumberExists(string PhoneNumber)
        {
            DatabaseRepository<User, Guid> databaseRepository = DatabaseUserRepositoryPools.GetDatabaseUserRepositoryPool("DTBR").Get();

            User User = null;

            if (CheckPhoneNumber(PhoneNumber))
            {
                User = databaseRepository.GetSingle(I => I.PhoneNumber == PhoneNumber);
            }


            return User != null ? true : false;

        }


        public static User FindUser(User User)
        {
            if (User is not null)
            {
                return FindUser(User.PhoneNumber, User.Password);
            }
            return null;
        }
        public static User FindUser(string PhoneNumber, string Password)
        {
            DatabaseRepository<User, Guid> databaseRepository = DatabaseUserRepositoryPools.GetDatabaseUserRepositoryPool("DTBR").Get();

            if (CheckPhoneNumber(PhoneNumber) && CheckPassword(Password))
            {
                User User = databaseRepository.GetSingle(I =>
                {
                    return I.PhoneNumber == ValueFormatter.FormatPhoneNumber(PhoneNumber) && Password.Trim() == I.Password;
                });

                DatabaseUserRepositoryPools.GetDatabaseUserRepositoryPool("DTBR").Return(databaseRepository);
                return User;
            }
            else
            {
                DatabaseUserRepositoryPools.GetDatabaseUserRepositoryPool("DTBR").Return(databaseRepository);
                return null;
            }

        }


        public static bool CheckName(string Name)
        {
            if (CheckString(Name, "", 2, 25, WhiteSpaceOptions.ReduceMultipleSpacesToOneAndTrim, StringControlTypes.IsLetter))
            {
                return true;
            }
            return false;
        }
        public static bool CheckName(User User)
        {
            return CheckName(User.Name);
        }

        public static bool CheckLastName(string LastName)
        {
            if (CheckString(LastName, "", 2, 20, WhiteSpaceOptions.Trim, StringControlTypes.IsLetter))
            {
                return true;
            }
            return false;
        }
        public static bool CheckLastName(User User)
        {
            return CheckLastName(User.LastName);
        }

        public static bool CheckPhoneNumber(string PhoneNumber)
        {
            if (!string.IsNullOrWhiteSpace(PhoneNumber))
            {
                PhoneNumber = PhoneNumber.Trim()
                    .Replace(" ", "")
                    .Replace("-", "")
                    .Replace("(", "")
                    .Replace(")", "");
                return Regex.Match(PhoneNumber, @"^\s*[-. (]*(\d{3})[-. )]*(\d{3})[-. ]*(\d{4})\s*$").Success;
            }
            return false;

        }
        public static bool CheckPhoneNumber(User User)
        {
            return CheckPhoneNumber(User.PhoneNumber);
        }
        public static bool CheckEmail(string Email)
        {
            var EEA = new EmailAddressAttribute();

            return EEA.IsValid(Email.Trim());
        }
        public static bool CheckEmail(User User)
        {
            return CheckEmail(User.Email);
        }
        /// <summary>
        /// Has minimum 8 characters in length
        /// At least one uppercase English letter. 
        /// At least one lowercase English letter.
        /// At least one digit.
        /// At least one special character.
        /// </summary>
        /// <param name="Password"></param>
        /// <returns></returns>
        public static bool CheckPassword(string Password)
        {
            if (string.IsNullOrWhiteSpace(Password))
            {
                return false;
            }
            Regex rgx = new(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$");

            return rgx.IsMatch(Password.Trim());
        }
        public static bool CheckPassword(User User)
        {
            return CheckPassword(User.Password);
        }
        public static bool CheckUserSignature(string UserSignature)
        {
            if (string.IsNullOrWhiteSpace(UserSignature))
            {
                return false;
            }
            return UserSignature.Length.IsBetween(3, 25, IntExtension.IncludeOptions.Including, IntExtension.IncludeOptions.Including);
        }
        public static bool CheckUserSignature(User User)
        {
            return CheckUserSignature(User.UserSignature);
        }
        public static bool CheckSavedUserName(string UserName)
        {
            if (string.IsNullOrWhiteSpace(UserName))
            {
                return false;
            }
            return UserName.Length.IsBetween(1, 40, IntExtension.IncludeOptions.Including, IntExtension.IncludeOptions.Including);
        }
        #endregion

        #region MethodsNotAccessibleByTheUser

        private static bool CheckString(string Value, string Contains, int LengthBiggerThan, int LengthSmallerThan, WhiteSpaceOptions WSO, StringControlTypes SCT)
        {
            if (string.IsNullOrWhiteSpace(Value) || Value.Trim().Length < LengthBiggerThan || Value.Trim().Length > LengthSmallerThan
                || !Value.RemoveExtraWhiteSpaces(WSO).IsSuitableForGivenType(SCT))
            {
                return false;
            }
            return true;
        }
        #endregion


    }
}

