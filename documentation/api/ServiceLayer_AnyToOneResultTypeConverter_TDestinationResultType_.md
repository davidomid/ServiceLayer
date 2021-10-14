### [ServiceLayer](ServiceLayer.md 'ServiceLayer')
## AnyToOneResultTypeConverter&lt;TDestinationResultType&gt; Class
Inherit this abstract class to create your own result type converter which converts any source result type enum value to any destination result type enum.  
```csharp
public abstract class AnyToOneResultTypeConverter<TDestinationResultType> : ServiceLayer.ResultTypeConverter
    where TDestinationResultType : struct, System.Enum
```
#### Type parameters
<a name='ServiceLayer_AnyToOneResultTypeConverter_TDestinationResultType__TDestinationResultType'></a>
`TDestinationResultType`  
  

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ServiceLayer.ResultTypeConverter](https://docs.microsoft.com/en-us/dotnet/api/ServiceLayer.ResultTypeConverter 'ServiceLayer.ResultTypeConverter') &#129106; AnyToOneResultTypeConverter&lt;TDestinationResultType&gt;  

| Constructors | |
| :--- | :--- |
| [AnyToOneResultTypeConverter()](ServiceLayer_AnyToOneResultTypeConverter_TDestinationResultType__AnyToOneResultTypeConverter().md 'ServiceLayer.AnyToOneResultTypeConverter&lt;TDestinationResultType&gt;.AnyToOneResultTypeConverter()') | Initializes a new instance of the [AnyToOneResultTypeConverter&lt;TDestinationResultType&gt;](ServiceLayer_AnyToOneResultTypeConverter_TDestinationResultType_.md 'ServiceLayer.AnyToOneResultTypeConverter&lt;TDestinationResultType&gt;') class<br/> |

| Methods | |
| :--- | :--- |
| [Convert(Enum)](ServiceLayer_AnyToOneResultTypeConverter_TDestinationResultType__Convert(System_Enum).md 'ServiceLayer.AnyToOneResultTypeConverter&lt;TDestinationResultType&gt;.Convert(System.Enum)') | This needs to be implemented so that any source result type enum value can be converted to the given [TDestinationResultType](ServiceLayer_AnyToOneResultTypeConverter_TDestinationResultType_.md#ServiceLayer_AnyToOneResultTypeConverter_TDestinationResultType__TDestinationResultType 'ServiceLayer.AnyToOneResultTypeConverter&lt;TDestinationResultType&gt;.TDestinationResultType') destination result type enum.<br/><br/> |
