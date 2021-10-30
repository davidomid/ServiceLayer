### [ServiceLayer](ServiceLayer.md 'ServiceLayer').[AnyToAnyResultTypeConverter](ServiceLayer_AnyToAnyResultTypeConverter.md 'ServiceLayer.AnyToAnyResultTypeConverter')
## AnyToAnyResultTypeConverter.Convert(Enum, Type) Method
This needs to be implemented so that any source result type enum value can be converted to any destination result type enum.
```csharp
public abstract System.Enum Convert(System.Enum sourceResultType, System.Type destinationEnumType);
```
#### Parameters
<a name='ServiceLayer_AnyToAnyResultTypeConverter_Convert(System_Enum_System_Type)_sourceResultType'></a>
`sourceResultType` [System.Enum](https://docs.microsoft.com/en-us/dotnet/api/System.Enum 'System.Enum')  
The source result type enum value.
  
<a name='ServiceLayer_AnyToAnyResultTypeConverter_Convert(System_Enum_System_Type)_destinationEnumType'></a>
`destinationEnumType` [System.Type](https://docs.microsoft.com/en-us/dotnet/api/System.Type 'System.Type')  
The destination result type enum which the given [sourceResultType](ServiceLayer_AnyToAnyResultTypeConverter_Convert(System_Enum_System_Type).md#ServiceLayer_AnyToAnyResultTypeConverter_Convert(System_Enum_System_Type)_sourceResultType 'ServiceLayer.AnyToAnyResultTypeConverter.Convert(System.Enum, System.Type).sourceResultType') will be converted to.
  
#### Returns
[System.Enum](https://docs.microsoft.com/en-us/dotnet/api/System.Enum 'System.Enum')  
An [System.Enum](https://docs.microsoft.com/en-us/dotnet/api/System.Enum 'System.Enum') value with the same type as the given [destinationEnumType](ServiceLayer_AnyToAnyResultTypeConverter_Convert(System_Enum_System_Type).md#ServiceLayer_AnyToAnyResultTypeConverter_Convert(System_Enum_System_Type)_destinationEnumType 'ServiceLayer.AnyToAnyResultTypeConverter.Convert(System.Enum, System.Type).destinationEnumType'), after being converted from the given [sourceResultType](ServiceLayer_AnyToAnyResultTypeConverter_Convert(System_Enum_System_Type).md#ServiceLayer_AnyToAnyResultTypeConverter_Convert(System_Enum_System_Type)_sourceResultType 'ServiceLayer.AnyToAnyResultTypeConverter.Convert(System.Enum, System.Type).sourceResultType').  
`null` can be returned when no conversion to [destinationEnumType](ServiceLayer_AnyToAnyResultTypeConverter_Convert(System_Enum_System_Type).md#ServiceLayer_AnyToAnyResultTypeConverter_Convert(System_Enum_System_Type)_destinationEnumType 'ServiceLayer.AnyToAnyResultTypeConverter.Convert(System.Enum, System.Type).destinationEnumType') is possible.  
### Remarks
If no direct conversion from [sourceResultType](ServiceLayer_AnyToAnyResultTypeConverter_Convert(System_Enum_System_Type).md#ServiceLayer_AnyToAnyResultTypeConverter_Convert(System_Enum_System_Type)_sourceResultType 'ServiceLayer.AnyToAnyResultTypeConverter.Convert(System.Enum, System.Type).sourceResultType') to [destinationEnumType](ServiceLayer_AnyToAnyResultTypeConverter_Convert(System_Enum_System_Type).md#ServiceLayer_AnyToAnyResultTypeConverter_Convert(System_Enum_System_Type)_destinationEnumType 'ServiceLayer.AnyToAnyResultTypeConverter.Convert(System.Enum, System.Type).destinationEnumType') is possible, you can return `null`.  
ServiceLayer will then automatically fall back to the next valid converter.  
If you want to prevent ServiceLayer from falling back to the next converter, you can throw any [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception').  
