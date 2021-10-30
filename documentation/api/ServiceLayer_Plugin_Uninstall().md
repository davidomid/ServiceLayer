### [ServiceLayer](ServiceLayer.md 'ServiceLayer').[Plugin](ServiceLayer_Plugin.md 'ServiceLayer.Plugin')
## Plugin.Uninstall() Method
This method should contain all of your plugin's uninstallation logic.  
```csharp
public abstract void Uninstall();
```
### Remarks
This method is executed automatically after calling [Uninstall(Plugin)](ServiceLayer_IPluginCollection_Uninstall(ServiceLayer_Plugin).md 'ServiceLayer.IPluginCollection.Uninstall(ServiceLayer.Plugin)') and passing an instance of the plugin.
