### [ServiceLayer](ServiceLayer.md 'ServiceLayer')
## OneToAnyResultTypeConverter&lt;TSourceResultType&gt; Class
Inherit this abstract class to create your own result type converter which converts between a specific [TSourceResultType](ServiceLayer_OneToAnyResultTypeConverter_TSourceResultType_.md#ServiceLayer_OneToAnyResultTypeConverter_TSourceResultType__TSourceResultType 'ServiceLayer.OneToAnyResultTypeConverter&lt;TSourceResultType&gt;.TSourceResultType') source type and any destination type.  
```csharp
public abstract class OneToAnyResultTypeConverter<TSourceResultType> : ServiceLayer.ResultTypeConverter
    where TSourceResultType : System.Enum
```
#### Type parameters
<a name='ServiceLayer_OneToAnyResultTypeConverter_TSourceResultType__TSourceResultType'></a>
`TSourceResultType`  
The source result type enum which any given destination result types will be converted from.
  

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ServiceLayer.ResultTypeConverter](https://docs.microsoft.com/en-us/dotnet/api/ServiceLayer.ResultTypeConverter 'ServiceLayer.ResultTypeConverter') &#129106; OneToAnyResultTypeConverter&lt;TSourceResultType&gt;  

| Constructors | |
| :--- | :--- |
| [OneToAnyResultTypeConverter()](ServiceLayer_OneToAnyResultTypeConverter_TSourceResultType__OneToAnyResultTypeConverter().md 'ServiceLayer.OneToAnyResultTypeConverter&lt;TSourceResultType&gt;.OneToAnyResultTypeConverter()') | Initializes a new instance of the [OneToAnyResultTypeConverter&lt;TSourceResultType&gt;](ServiceLayer_OneToAnyResultTypeConverter_TSourceResultType_.md 'ServiceLayer.OneToAnyResultTypeConverter&lt;TSourceResultType&gt;') class<br/> |

| Methods | |
| :--- | :--- |
| [Convert&lt;TDestinationResultType&gt;(TSourceResultType)](ServiceLayer_OneToAnyResultTypeConverter_TSourceResultType__Convert_TDestinationResultType_(TSourceResultType).md 'ServiceLayer.OneToAnyResultTypeConverter&lt;TSourceResultType&gt;.Convert&lt;TDestinationResultType&gt;(TSourceResultType)') | This needs to be implemented so that the given [TSourceResultType](ServiceLayer_OneToAnyResultTypeConverter_TSourceResultType_.md#ServiceLayer_OneToAnyResultTypeConverter_TSourceResultType__TSourceResultType 'ServiceLayer.OneToAnyResultTypeConverter&lt;TSourceResultType&gt;.TSourceResultType') source result type enum value can be converted to a given [TDestinationResultType](ServiceLayer_OneToAnyResultTypeConverter_TSourceResultType__Convert_TDestinationResultType_(TSourceResultType).md#ServiceLayer_OneToAnyResultTypeConverter_TSourceResultType__Convert_TDestinationResultType_(TSourceResultType)_TDestinationResultType 'ServiceLayer.OneToAnyResultTypeConverter&lt;TSourceResultType&gt;.Convert&lt;TDestinationResultType&gt;(TSourceResultType).TDestinationResultType') destination result type enum.<br/><br/> |
