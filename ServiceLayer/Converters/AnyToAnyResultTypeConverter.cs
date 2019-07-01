using System;

namespace ServiceLayer
{
    public abstract class AnyToAnyResultTypeConverter : ResultTypeConverter
    {
        protected AnyToAnyResultTypeConverter() : base(null, null)
        {
        }

        internal override Enum PerformInternalConversion(Enum sourceResultType, Type destinationEnumType)
        {
            return this.Convert(sourceResultType, destinationEnumType);
        }

        public abstract Enum Convert(Enum sourceResultType, Type destinationEnumType);
    }
}
