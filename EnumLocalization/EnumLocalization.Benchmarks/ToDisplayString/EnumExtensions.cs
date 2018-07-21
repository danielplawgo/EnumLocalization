using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EnumLocalization.Models;
using EnumLocalization.Resources;

namespace EnumLocalization.Benchmarks.ToDisplayString
{
    public static class EnumExtensions
    {
        public static string ToDisplayStringResources(this OrderStatus value)
        {
            switch (value)
            {
                case OrderStatus.Created:
                    return OrderStatusResources.Created;
                case OrderStatus.Completed:
                    return OrderStatusResources.Completed;
                case OrderStatus.Canceled:
                    return OrderStatusResources.Canceled;
                default:
                    throw new ArgumentOutOfRangeException(nameof(value), value, null);
            }
        }

        public static string ToDisplayStringReflection(this Enum value)
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

        public static string ToDisplayStringCreatingResourceManager(this Enum value)
        {
            string description = value.ToString();

            EnumDescriptionAttribute[] attributes = (EnumDescriptionAttribute[])value.GetType().GetCustomAttributes(typeof(EnumDescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
            {
                Type resourceType = attributes[0].ResourceType;

                if (resourceType != null)
                {
                    var resourceManager = new ResourceManager(attributes[0].ResourceType.FullName,
                        attributes[0].ResourceType.Assembly);

                    return resourceManager.GetString(description, Thread.CurrentThread.CurrentUICulture);
                }
            }

            return description;
        }

        public static string ToDisplayStringUsingResourceManager(this Enum value)
        {
            string description = value.ToString();

            EnumDescriptionAttribute[] attributes = (EnumDescriptionAttribute[])value.GetType().GetCustomAttributes(typeof(EnumDescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
            {
                Type resourceType = attributes[0].ResourceType;

                if (resourceType != null)
                {
                    var resourceManagerProperty = resourceType.GetProperty("ResourceManager");

                    if (resourceManagerProperty != null)
                    {
                        var resourceManager = resourceManagerProperty.GetValue(null) as ResourceManager;

                        if (resourceManager != null)
                        {
                            return resourceManager.GetString(description, Thread.CurrentThread.CurrentUICulture);
                        }
                    }
                }
            }

            return description;
        }

        private static IDictionary<Type, ResourceManager> _resourceManagers = new ConcurrentDictionary<Type, ResourceManager>();

        public static string ToDisplayStringUsingResourceManagerAndCache(this Enum value, CultureInfo culture = null)
        {
            string description = value.ToString();

            ResourceManager resourceManager = null;

            if (_resourceManagers.TryGetValue(value.GetType(), out resourceManager) == false)
            {
                EnumDescriptionAttribute[] attributes = (EnumDescriptionAttribute[])value.GetType().GetCustomAttributes(typeof(EnumDescriptionAttribute), false);

                if (attributes.Any())
                {
                    Type resourceType = attributes[0].ResourceType;

                    if (resourceType != null)
                    {
                        var resourceManagerProperty = resourceType.GetProperty("ResourceManager");

                        if (resourceManagerProperty != null)
                        {
                            resourceManager = resourceManagerProperty.GetValue(null) as ResourceManager;

                            _resourceManagers.Add(value.GetType(), resourceManager);
                        }
                    }
                }
            }

            if (resourceManager != null)
            {
                return resourceManager.GetString(description, culture ?? Thread.CurrentThread.CurrentUICulture);
            }

            return description;
        }
    }
}
