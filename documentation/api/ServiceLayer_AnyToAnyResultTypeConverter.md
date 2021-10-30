### [ServiceLayer](ServiceLayer.md 'ServiceLayer')
## AnyToAnyResultTypeConverter Class
Inherit this abstract class to create your own result type converter which converts any source result type enum value to any destination result type enum.  
```csharp
public abstract class AnyToAnyResultTypeConverter : ServiceLayer.ResultTypeConverter
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ServiceLayer.ResultTypeConverter](https://docs.microsoft.com/en-us/dotnet/api/ServiceLayer.ResultTypeConverter 'ServiceLayer.ResultTypeConverter') &#129106; AnyToAnyResultTypeConverter  

| Constructors | |
| :--- | :--- |
| [AnyToAnyResultTypeConverter()](ServiceLayer_AnyToAnyResultTypeConverter_AnyToAnyResultTypeConverter().md 'ServiceLayer.AnyToAnyResultTypeConverter.AnyToAnyResultTypeConverter()') | Initializes a new instance of the [AnyToAnyResultTypeConverter](ServiceLayer_AnyToAnyResultTypeConverter.md 'ServiceLayer.AnyToAnyResultTypeConverter') class<br/> |

| Methods | |
| :--- | :--- |
| [Convert(Enum, Type)](ServiceLayer_AnyToAnyResultTypeConverter_Convert(System_Enum_System_Type).md 'ServiceLayer.AnyToAnyResultTypeConverter.Convert(System.Enum, System.Type)') | This needs to be implemented so that any source result type enum value can be converted to any destination result type enum.<br/><br/> |
