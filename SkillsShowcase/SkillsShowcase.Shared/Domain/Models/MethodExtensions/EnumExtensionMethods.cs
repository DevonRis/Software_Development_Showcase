using System;
using System.ComponentModel;
using System.Reflection;

namespace SkillsShowcase.Shared.Domain.Models.MethodExtensions
{
    public static class EnumExtensionMethods
    {
        public static string GetEnumDescription(this Enum enumValue)
        {
            FieldInfo fieldInfo = enumValue.GetType().GetField(enumValue.ToString());

            DescriptionAttribute[] attributes = (DescriptionAttribute[])fieldInfo
            .GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
                return attributes[0].Description;
            else
                return enumValue.ToString();
        }
    }
}
