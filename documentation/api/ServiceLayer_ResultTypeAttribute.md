#### [ServiceLayer](index 'index')
### [ServiceLayer](index#ServiceLayer 'ServiceLayer')
## ResultTypeAttribute Class
This attribute is used for annotating a source enum value and providing a destination value which it can be mapped to.



This is used for converting between the source value and destination value, or from the destination value to the source value.
```csharp
public class ResultTypeAttribute : System.Attribute
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [System.Attribute](https://docs.microsoft.com/en-us/dotnet/api/System.Attribute 'System.Attribute') &#129106; ResultTypeAttribute  

Derived  
&#8627; [FailureAttribute](ServiceLayer_FailureAttribute 'ServiceLayer.FailureAttribute')  
&#8627; [InconclusiveAttribute](ServiceLayer_InconclusiveAttribute 'ServiceLayer.InconclusiveAttribute')  
&#8627; [SuccessAttribute](ServiceLayer_SuccessAttribute 'ServiceLayer.SuccessAttribute')  

| Constructors | |
| :--- | :--- |
| [ResultTypeAttribute(object)](ServiceLayer_ResultTypeAttribute_ResultTypeAttribute(object) 'ServiceLayer.ResultTypeAttribute.ResultTypeAttribute(object)') | Initializes a new instance of the [ResultTypeAttribute](ServiceLayer_ResultTypeAttribute 'ServiceLayer.ResultTypeAttribute') class<br/> |

| Properties | |
| :--- | :--- |
| [IsDefault](ServiceLayer_ResultTypeAttribute_IsDefault 'ServiceLayer.ResultTypeAttribute.IsDefault') | If set to true, a value of the given ResultType will be converted to the annotated enum value by default.<br/><br/><br/><br/>This is useful when you have multiple values in the source enum annotated with the same destination value.<br/><br/> |
| [ResultType](ServiceLayer_ResultTypeAttribute_ResultType 'ServiceLayer.ResultTypeAttribute.ResultType') | Gets the value of the result type<br/> |
#### See Also
- [System.Attribute](https://docs.microsoft.com/en-us/dotnet/api/System.Attribute 'System.Attribute')
