### [ServiceLayer](ServiceLayer.md 'ServiceLayer')
## IPluginContext Interface
This allows you to retrieve and manipulate the plugins and result type converters which are installed by ServiceLayer, from within the installation and uninstallation logic of your custom plugins.  
```csharp
public interface IPluginContext
```
### Remarks
An instance of this interface is available via the [Context](ServiceLayer_Plugin_Context.md 'ServiceLayer.Plugin.Context') property

| Properties | |
| :--- | :--- |
| [Plugins](ServiceLayer_IPluginContext_Plugins.md 'ServiceLayer.IPluginContext.Plugins') | Contains a collection of plugins which are currently installed.<br/> |
| [ResultTypeConverters](ServiceLayer_IPluginContext_ResultTypeConverters.md 'ServiceLayer.IPluginContext.ResultTypeConverters') | Contains a collection of result type converters which are currently installed.<br/> |
