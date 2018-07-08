using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Web;

namespace System
{
    public static class EnumExtensions
    {
        public static string ToDisplayString(this Enum value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            string description = value.ToString();
            EnumDescriptionAttribute[] attributes = (EnumDescriptionAttribute[])value.GetType().GetCustomAttributes(typeof(EnumDescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
            {
                Type resourceType = attributes[0].ResourceType;

                if (resourceType != null)
                {
                    var property = resourceType.GetProperty(description);
                    if (property != null)
                    {
                        var propertyValue = property.GetValue(null);

                        if (propertyValue != null)
                        {
                            description = propertyValue.ToString();
                        }
                    }
                }
            }
            return description;
        }
    }
}