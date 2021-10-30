### [ServiceLayer](ServiceLayer.md 'ServiceLayer').[Plugin](ServiceLayer_Plugin.md 'ServiceLayer.Plugin')
## Plugin.Context Property
Gets the static plugin context which is shared between all plugins.  
```csharp
protected static ServiceLayer.IPluginContext Context { get; }
```
#### Property Value
[IPluginContext](ServiceLayer_IPluginContext.md 'ServiceLayer.IPluginContext')
### Remarks
You should use this within your implemented [Install()](ServiceLayer_Plugin_Install().md 'ServiceLayer.Plugin.Install()') and [Uninstall()](ServiceLayer_Plugin_Uninstall().md 'ServiceLayer.Plugin.Uninstall()') methods for making changes to ServiceLayer.
