using System;
namespace ServiceLayer
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
    public class ResultTypeAttribute : Attribute
    {
        public ResultTypeAttribute(object resultType)
        {
            ResultType = (Enum)resultType;
        }

        public Enum ResultType { get; }

        public bool IsDefault { get; set; }
    }
}
