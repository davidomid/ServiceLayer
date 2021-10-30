### [ServiceLayer](ServiceLayer.md 'ServiceLayer')
## IPluginCollection Interface
This interface provides access to a list of ServiceLayer plugins which are already installed.
```csharp
public interface IPluginCollection
```
### Remarks
A static instance of this collection is available to you via the static [Plugins](ServiceLayer_ServiceLayerConfig_Plugins.md 'ServiceLayer.ServiceLayerConfig.Plugins') property. You can also access it directly from a Plugin instance, via the [Context](ServiceLayer_Plugin_Context.md 'ServiceLayer.Plugin.Context') property.

| Properties | |
| :--- | :--- |
| [Installed](ServiceLayer_IPluginCollection_Installed.md 'ServiceLayer.IPluginCollection.Installed') | A collection of plugins which are already installed.<br/> |

| Methods | |
| :--- | :--- |
| [Install(Plugin)](ServiceLayer_IPluginCollection_Install(ServiceLayer_Plugin).md 'ServiceLayer.IPluginCollection.Install(ServiceLayer.Plugin)') | Installs a new plugin, which can then be accessed via the [Installed](ServiceLayer_IPluginCollection_Installed.md 'ServiceLayer.IPluginCollection.Installed') property.<br/> |
| [Uninstall(Plugin)](ServiceLayer_IPluginCollection_Uninstall(ServiceLayer_Plugin).md 'ServiceLayer.IPluginCollection.Uninstall(ServiceLayer.Plugin)') | Uninstalls an installed plugin.<br/> |
