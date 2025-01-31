using System;
using System.Linq;

// How to retrieve Data Annotations from code ?
// https://stackoverflow.com/questions/7027613/how-to-retrieve-data-annotations-from-code-programmatically
// var name = player.GetAttributeFrom<DisplayAttribute>("PlayerDescription").Name;
// var maxLength = player.GetAttributeFrom<MaxLengthAttribute>("PlayerName").Length;

namespace EasyLOB.Data
{
    /// <summary>
    /// Attribute Extensions.
    /// </summary>
    public static class AttributeExtensions
    {
        public static T GetAttributeFrom<T>(this object instance, string propertyName) where T : Attribute
        {
            var attrType = typeof(T);
            var property = instance.GetType().GetProperty(propertyName);

            return (T)property.GetCustomAttributes(attrType, false).First();
        }
    }
}
