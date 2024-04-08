using MessageAppDemo2.Backend.SystemData.IFactory;
using MessageAppDemo2.Backend.Users.UserData;
using MessageAppDemo2.FrontEnd.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MessageAppDemo2.FrontEnd.FrontEnd_BackendActions.FrontendLoginRedirecter
{
    public class LoginFactory : FactoryBase<UserControl, UserType>
    {
        protected override Dictionary<UserType, Type> EnumTypeKeyValuePairs
        {
            get
            {
                return new Dictionary<UserType, Type>()
                {
                    {UserType.Person,typeof(PersonScreen) },
                };
            }
        }
    }
}
