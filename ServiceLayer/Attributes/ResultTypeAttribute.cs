using System;
namespace ServiceLayer.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class ResultTypeAttribute : Attribute
    {
        public ResultTypeAttribute(Enum resultType)
        {
            ResultType = resultType;
        }

        public Enum ResultType { get; }

        public bool IsDefault { get; set; }
    }
}
