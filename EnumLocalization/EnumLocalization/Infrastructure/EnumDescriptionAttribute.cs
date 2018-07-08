using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace System
{
    public class EnumDescriptionAttribute : Attribute
    {
        public Type ResourceType { get; set; }

        public EnumDescriptionAttribute(Type resourceType)
        {
            ResourceType = resourceType;
        }
    }
}