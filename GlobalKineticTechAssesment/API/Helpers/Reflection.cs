﻿using System;
using System.Reflection;

namespace API.Helpers
{
    /// <summary>
    /// Helper class to get property values through reflection used if derived class has more members than baseclass
    /// </summary>
    public static class Reflection
    {
        public static Object GetPropValue(this Object obj, String name)
        {
            foreach (String part in name.Split('.'))
            {
                if (obj == null) { return null; }

                Type type = obj.GetType();
                PropertyInfo info = type.GetProperty(part);
                if (info == null) { return null; }

                obj = info.GetValue(obj, null);
            }
            return obj;
        }

        public static T GetPropValue<T>(this Object obj, String name)
        {
            Object retval = GetPropValue(obj, name);
            if (retval == null) { return default(T); }
            
            return (T)retval;
        }
    }
}
