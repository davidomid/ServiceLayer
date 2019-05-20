using System;

namespace ServiceLayer.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public abstract class BaseAttribute : Attribute
    {
        public bool IsDefault { get; set; }
    }
}
