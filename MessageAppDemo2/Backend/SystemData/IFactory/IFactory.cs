using MessageAppDemo2.Backend.Users.UserData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageAppDemo2.Backend.SystemData.IFactory
{
    public interface IFactory<BaseType, in TypesEnum> where TypesEnum : Enum where BaseType : class
    {
        BaseType CreateInstance(TypesEnum type);
        BaseType CreateInstanceWithParameter(TypesEnum type, params object[] parameters);

        T CreateInstance<T>(TypesEnum type) where T : BaseType;
        T CreateInstanceWithParameter<T>(TypesEnum type, params object[] parameters) where T : BaseType;
    }

    public abstract class FactoryBase<BaseType, TypesEnum> : IFactory<BaseType, TypesEnum> where TypesEnum : Enum where BaseType : class
    {
        protected abstract Dictionary<TypesEnum, Type> EnumTypeKeyValuePairs { get; }
        public virtual BaseType CreateInstance(TypesEnum type)
        {
            foreach (KeyValuePair<TypesEnum, Type> pair in EnumTypeKeyValuePairs)
            {
                if (pair.Key.ToString() == type.ToString())
                {
                    return (BaseType)Activator.CreateInstance(pair.Value);
                }
            }
            throw new ArgumentException("Value not found.");
        }

        public virtual T CreateInstance<T>(TypesEnum type) where T : BaseType
        {
            foreach (KeyValuePair<TypesEnum, Type> pair in EnumTypeKeyValuePairs)
            {
                if (pair.Key.ToString() == type.ToString())
                {
                    return (T)Activator.CreateInstance(pair.Value);
                }
            }
            throw new ArgumentException("Value not found.");
        }

        public virtual BaseType CreateInstanceWithParameter(TypesEnum type, params object[] parameters)
        {
            foreach (KeyValuePair<TypesEnum, Type> pair in EnumTypeKeyValuePairs)
            {
                if (pair.Key.ToString() == type.ToString())
                {
                    return (BaseType)Activator.CreateInstance(pair.Value, args: parameters);
                }
            }
            throw new ArgumentException("Value not found.");
        }

        public virtual T CreateInstanceWithParameter<T>(TypesEnum type, params object[] parameters) where T : BaseType
        {
            foreach (KeyValuePair<TypesEnum, Type> pair in EnumTypeKeyValuePairs)
            {
                if (pair.Key.ToString() == type.ToString())
                {
                    return (T)Activator.CreateInstance(pair.Value, args: parameters);
                }
            }
            throw new ArgumentException("Value not found.");
        }
    }
}
