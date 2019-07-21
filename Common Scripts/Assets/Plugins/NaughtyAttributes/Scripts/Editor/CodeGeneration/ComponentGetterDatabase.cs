using System;
using System.Collections.Generic;

namespace NaughtyAttributes.Editor
{
    public class ComponentGetterDatabase
    {
        private static Dictionary<Type, ComponentGetter> gettersByAttributeType;

        static ComponentGetterDatabase()
        {
            gettersByAttributeType = new Dictionary<Type, ComponentGetter>
            {
                [typeof(GetComponentAttribute)] = new ComponentGetter()
            };
        }

        public static ComponentGetter GetComponentGetterForAttribute(Type attributeType)
        {
            if (gettersByAttributeType.TryGetValue(attributeType, out ComponentGetter getter))
            {
                return getter;
            }
            else
            {
                return null;
            }
        }
    }
}
