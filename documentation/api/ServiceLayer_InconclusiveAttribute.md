#### [ServiceLayer](index.md 'index')
### [ServiceLayer](index.md#ServiceLayer 'ServiceLayer')
## InconclusiveAttribute Class
This attribute maps the source enum value to the [Inconclusive](ServiceLayer_ResultType.md#ServiceLayer_ResultType_Inconclusive 'ServiceLayer.ResultType.Inconclusive') result type.



Use this attribute to mark enum values which should be considered inconclusive result types.

<remarks>By default, unless otherwise specified, ServiceLayer will consider an enum value to be an inconclusive result type.</remarks>
```csharp
public class InconclusiveAttribute : ServiceLayer.ResultTypeAttribute
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [System.Attribute](https://docs.microsoft.com/en-us/dotnet/api/System.Attribute 'System.Attribute') &#129106; [ResultTypeAttribute](ServiceLayer_ResultTypeAttribute.md 'ServiceLayer.ResultTypeAttribute') &#129106; InconclusiveAttribute  

| Constructors | |
| :--- | :--- |
| [InconclusiveAttribute()](ServiceLayer_InconclusiveAttribute_InconclusiveAttribute().md 'ServiceLayer.InconclusiveAttribute.InconclusiveAttribute()') | Initializes a new instance of the [InconclusiveAttribute](ServiceLayer_InconclusiveAttribute.md 'ServiceLayer.InconclusiveAttribute') class<br/> |
#### See Also
- [ResultTypeAttribute](ServiceLayer_ResultTypeAttribute.md 'ServiceLayer.ResultTypeAttribute')
