### [ServiceLayer](ServiceLayer.md 'ServiceLayer')
## IPluginCollection Interface
This interface provides access to a list of ServiceLayer plugins which are already installed.

<remarks>A static instance of this collection is available to you via the static <see cref="F:ServiceLayer.ServiceLayerConfig.Plugins"/> property. You can also access it directly from a Plugin instance, via the <see cref="P:ServiceLayer.Plugin.Context"/> property.</remarks>
```csharp
public interface IPluginCollection
```

| Properties | |
| :--- | :--- |
| [Installed](ServiceLayer_IPluginCollection_Installed.md 'ServiceLayer.IPluginCollection.Installed') | A collection of plugins which are already installed.<br/><remarks>This collection can be modified by calling the <see cref="M:ServiceLayer.IPluginCollection.Install(ServiceLayer.Plugin)"/> and <see cref="M:ServiceLayer.IPluginCollection.Uninstall(ServiceLayer.Plugin)"/> methods.</remarks> |

| Methods | |
| :--- | :--- |
| [Install(Plugin)](ServiceLayer_IPluginCollection_Install(ServiceLayer_Plugin).md 'ServiceLayer.IPluginCollection.Install(ServiceLayer.Plugin)') | Installs a new plugin, which can then be accessed via the [Installed](ServiceLayer_IPluginCollection_Installed.md 'ServiceLayer.IPluginCollection.Installed') property.<br/> |
| [Uninstall(Plugin)](ServiceLayer_IPluginCollection_Uninstall(ServiceLayer_Plugin).md 'ServiceLayer.IPluginCollection.Uninstall(ServiceLayer.Plugin)') | Uninstalls an installed plugin.<br/> |
