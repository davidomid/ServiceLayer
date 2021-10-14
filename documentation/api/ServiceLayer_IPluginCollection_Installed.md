### [ServiceLayer](ServiceLayer.md 'ServiceLayer').[IPluginCollection](ServiceLayer_IPluginCollection.md 'ServiceLayer.IPluginCollection')
## IPluginCollection.Installed Property
A collection of plugins which are already installed.  
<remarks>This collection can be modified by calling the <see cref="M:ServiceLayer.IPluginCollection.Install(ServiceLayer.Plugin)"/> and <see cref="M:ServiceLayer.IPluginCollection.Uninstall(ServiceLayer.Plugin)"/> methods.</remarks>
```csharp
System.Collections.Generic.IReadOnlyCollection<ServiceLayer.Plugin> Installed { get; }
```
#### Property Value
[System.Collections.Generic.IReadOnlyCollection&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyCollection-1 'System.Collections.Generic.IReadOnlyCollection`1')[Plugin](ServiceLayer_Plugin.md 'ServiceLayer.Plugin')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyCollection-1 'System.Collections.Generic.IReadOnlyCollection`1')
