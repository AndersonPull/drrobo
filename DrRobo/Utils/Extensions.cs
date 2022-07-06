using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;

namespace DrRobo.Utils
{
    public static class Extensions
    {
        public static string Value(this Enum @enum)
        {
            var attr =
                @enum.GetType().GetMember(@enum.ToString()).FirstOrDefault()?.
                    GetCustomAttributes(false).OfType<EnumMemberAttribute>().
                    FirstOrDefault();
            return attr == null ? @enum.ToString() : attr.Value;
        }

        public static string Description(this Enum @enum)
        {
            var attr =
             @enum.GetType().GetMember(@enum.ToString()).FirstOrDefault()?.
                 GetCustomAttributes(false).OfType<DescriptionAttribute>().
                 FirstOrDefault();
            return attr == null ? @enum.ToString() : attr.Description;
        }
    }
}
