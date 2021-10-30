### [ServiceLayer](ServiceLayer.md 'ServiceLayer').[IPluginCollection](ServiceLayer_IPluginCollection.md 'ServiceLayer.IPluginCollection')
## IPluginCollection.Installed Property
A collection of plugins which are already installed.  
```csharp
System.Collections.Generic.IReadOnlyCollection<ServiceLayer.Plugin> Installed { get; }
```
#### Property Value
[System.Collections.Generic.IReadOnlyCollection&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyCollection-1 'System.Collections.Generic.IReadOnlyCollection`1')[Plugin](ServiceLayer_Plugin.md 'ServiceLayer.Plugin')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyCollection-1 'System.Collections.Generic.IReadOnlyCollection`1')
### Remarks
This collection can be modified by calling the [Install(Plugin)](ServiceLayer_IPluginCollection_Install(ServiceLayer_Plugin).md 'ServiceLayer.IPluginCollection.Install(ServiceLayer.Plugin)') and [Uninstall(Plugin)](ServiceLayer_IPluginCollection_Uninstall(ServiceLayer_Plugin).md 'ServiceLayer.IPluginCollection.Uninstall(ServiceLayer.Plugin)') methods.
