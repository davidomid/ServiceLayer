### [ServiceLayer](ServiceLayer.md 'ServiceLayer').[Plugin](ServiceLayer_Plugin.md 'ServiceLayer.Plugin')
## Plugin.Context Property
Gets the static plugin context which is shared between all plugins.  
<remarks>You should use this within your implemented <see cref="M:ServiceLayer.Plugin.Install"/> and <see cref="M:ServiceLayer.Plugin.Uninstall"/> methods for making changes to ServiceLayer.</remarks>
```csharp
protected static ServiceLayer.IPluginContext Context { get; }
```
#### Property Value
[IPluginContext](ServiceLayer_IPluginContext.md 'ServiceLayer.IPluginContext')
