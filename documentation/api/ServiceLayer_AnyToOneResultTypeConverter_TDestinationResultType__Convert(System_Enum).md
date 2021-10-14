### [ServiceLayer](ServiceLayer.md 'ServiceLayer').[AnyToOneResultTypeConverter&lt;TDestinationResultType&gt;](ServiceLayer_AnyToOneResultTypeConverter_TDestinationResultType_.md 'ServiceLayer.AnyToOneResultTypeConverter&lt;TDestinationResultType&gt;')
## AnyToOneResultTypeConverter&lt;TDestinationResultType&gt;.Convert(Enum) Method
This needs to be implemented so that any source result type enum value can be converted to the given [TDestinationResultType](ServiceLayer_AnyToOneResultTypeConverter_TDestinationResultType_.md#ServiceLayer_AnyToOneResultTypeConverter_TDestinationResultType__TDestinationResultType 'ServiceLayer.AnyToOneResultTypeConverter&lt;TDestinationResultType&gt;.TDestinationResultType') destination result type enum.
```csharp
public abstract System.Nullable<TDestinationResultType> Convert(System.Enum sourceResultType);
```
#### Parameters
<a name='ServiceLayer_AnyToOneResultTypeConverter_TDestinationResultType__Convert(System_Enum)_sourceResultType'></a>
`sourceResultType` [System.Enum](https://docs.microsoft.com/en-us/dotnet/api/System.Enum 'System.Enum')  
The source result type enum value.
  
#### Returns
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[TDestinationResultType](ServiceLayer_AnyToOneResultTypeConverter_TDestinationResultType_.md#ServiceLayer_AnyToOneResultTypeConverter_TDestinationResultType__TDestinationResultType 'ServiceLayer.AnyToOneResultTypeConverter&lt;TDestinationResultType&gt;.TDestinationResultType')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')  
A resulting [TDestinationResultType](ServiceLayer_AnyToOneResultTypeConverter_TDestinationResultType_.md#ServiceLayer_AnyToOneResultTypeConverter_TDestinationResultType__TDestinationResultType 'ServiceLayer.AnyToOneResultTypeConverter&lt;TDestinationResultType&gt;.TDestinationResultType') value after converting from the given [sourceResultType](ServiceLayer_AnyToOneResultTypeConverter_TDestinationResultType__Convert(System_Enum).md#ServiceLayer_AnyToOneResultTypeConverter_TDestinationResultType__Convert(System_Enum)_sourceResultType 'ServiceLayer.AnyToOneResultTypeConverter&lt;TDestinationResultType&gt;.Convert(System.Enum).sourceResultType').  
`null` can be returned when no conversion to [TDestinationResultType](ServiceLayer_AnyToOneResultTypeConverter_TDestinationResultType_.md#ServiceLayer_AnyToOneResultTypeConverter_TDestinationResultType__TDestinationResultType 'ServiceLayer.AnyToOneResultTypeConverter&lt;TDestinationResultType&gt;.TDestinationResultType') is possible.  
### Remarks
If no direct conversion from [sourceResultType](ServiceLayer_AnyToOneResultTypeConverter_TDestinationResultType__Convert(System_Enum).md#ServiceLayer_AnyToOneResultTypeConverter_TDestinationResultType__Convert(System_Enum)_sourceResultType 'ServiceLayer.AnyToOneResultTypeConverter&lt;TDestinationResultType&gt;.Convert(System.Enum).sourceResultType') to [TDestinationResultType](ServiceLayer_AnyToOneResultTypeConverter_TDestinationResultType_.md#ServiceLayer_AnyToOneResultTypeConverter_TDestinationResultType__TDestinationResultType 'ServiceLayer.AnyToOneResultTypeConverter&lt;TDestinationResultType&gt;.TDestinationResultType') is possible, you can return `null`.  
ServiceLayer will then automatically fall back to the next valid converter.  
If you want to prevent ServiceLayer from falling back to the next converter, you can throw any [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception').  
