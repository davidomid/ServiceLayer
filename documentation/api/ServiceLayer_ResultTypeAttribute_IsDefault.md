#### [ServiceLayer](index 'index')
### [ServiceLayer](index#ServiceLayer 'ServiceLayer').[ResultTypeAttribute](ServiceLayer_ResultTypeAttribute 'ServiceLayer.ResultTypeAttribute')
## ResultTypeAttribute.IsDefault Property
If set to true, a value of the given ResultType will be converted to the annotated enum value by default.



This is useful when you have multiple values in the source enum annotated with the same destination value.
```csharp
public bool IsDefault { get; set; }
```
#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')
