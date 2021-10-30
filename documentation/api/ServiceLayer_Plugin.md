### [ServiceLayer](ServiceLayer.md 'ServiceLayer')
## Plugin Class
You can inherit this abstract class to create your own ServiceLayer plugin.  
```csharp
public abstract class Plugin
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; Plugin  
### Remarks
Plugins are the backbone of ServiceLayer's extensibility. They allow you to specify mappings between different result types, using converters. Plugins are also capable of installing and uninstalling other plugins.

| Constructors | |
| :--- | :--- |
| [Plugin(string)](ServiceLayer_Plugin_Plugin(string).md 'ServiceLayer.Plugin.Plugin(string)') | Initializes a new instance of the [Plugin](ServiceLayer_Plugin.md 'ServiceLayer.Plugin') class<br/> |

| Properties | |
| :--- | :--- |
| [Context](ServiceLayer_Plugin_Context.md 'ServiceLayer.Plugin.Context') | Gets the static plugin context which is shared between all plugins.<br/> |
| [Name](ServiceLayer_Plugin_Name.md 'ServiceLayer.Plugin.Name') | Gets the name of the plugin.<br/> |

| Methods | |
| :--- | :--- |
| [Install()](ServiceLayer_Plugin_Install().md 'ServiceLayer.Plugin.Install()') | This method contains all of the plugin's installation logic.<br/> |
| [Uninstall()](ServiceLayer_Plugin_Uninstall().md 'ServiceLayer.Plugin.Uninstall()') | This method should contain all of your plugin's uninstallation logic.<br/> |
