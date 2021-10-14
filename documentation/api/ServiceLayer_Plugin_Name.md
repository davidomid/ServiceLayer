### [ServiceLayer](ServiceLayer.md 'ServiceLayer').[Plugin](ServiceLayer_Plugin.md 'ServiceLayer.Plugin')
## Plugin.Name Property
Gets the name of the plugin.  
<remarks>Installed plugins are expected to have unique names. When installing a plugin, if an already installed plugin with the same name is found, it will be automatically installed before the new plugin is installed.</remarks>
```csharp
public string Name { get; }
```
#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
