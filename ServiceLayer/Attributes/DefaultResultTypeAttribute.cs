using System;
namespace ServiceLayer
{
    /// <summary>
    /// <para>The default result type attribute class.</para>
    /// <para>This attribute is used for annotating the default value of an enum to use when it's treated as a result type.</para>
    /// </summary>
    /// <seealso cref="Attribute"/>
    [AttributeUsage(AttributeTargets.Field)]
    public class DefaultResultTypeAttribute : Attribute
    {
    }
}
