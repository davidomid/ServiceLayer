## ServiceLayer Namespace

| Classes | |
| :--- | :--- |
| [DefaultResultTypeAttribute](ServiceLayer_DefaultResultTypeAttribute.md 'ServiceLayer.DefaultResultTypeAttribute') | The default result type attribute class.<br/><br/><br/><br/>This attribute is used for annotating the default value of an enum to use when it's treated as a result type.<br/><br/> |
| [FailureAttribute](ServiceLayer_FailureAttribute.md 'ServiceLayer.FailureAttribute') | This attribute maps the source enum value to the [Failure](ServiceLayer_ResultType.md#ServiceLayer_ResultType_Failure 'ServiceLayer.ResultType.Failure') result type.<br/><br/><br/><br/>Use this attribute to mark enum values which should be considered failure result types.<br/><br/> |
| [InconclusiveAttribute](ServiceLayer_InconclusiveAttribute.md 'ServiceLayer.InconclusiveAttribute') | This attribute maps the source enum value to the [Inconclusive](ServiceLayer_ResultType.md#ServiceLayer_ResultType_Inconclusive 'ServiceLayer.ResultType.Inconclusive') result type.<br/><br/><br/><br/>Use this attribute to mark enum values which should be considered inconclusive result types.<br/><br/><remarks>By default, unless otherwise specified, ServiceLayer will consider an enum value to be an inconclusive result type.</remarks> |
| [Plugin](ServiceLayer_Plugin.md 'ServiceLayer.Plugin') | You can inherit this abstract class to create your own ServiceLayer plugin.<br/><remarks>Plugins are the backbone of ServiceLayer's extensibility. They allow you to specify mappings between different result types, using converters. Plugins are also capable of installing and uninstalling other plugins.</remarks> |
| [ResultTypeAttribute](ServiceLayer_ResultTypeAttribute.md 'ServiceLayer.ResultTypeAttribute') | This attribute is used for annotating a source enum value and providing a destination value which it can be mapped to.<br/><br/><br/><br/>This is used for converting between the source value and destination value, or from the destination value to the source value.<br/><br/> |
| [ServiceLayerConfig](ServiceLayer_ServiceLayerConfig.md 'ServiceLayer.ServiceLayerConfig') | Use this class to set the global ServiceLayer configuration for your application.<br/> |
| [SuccessAttribute](ServiceLayer_SuccessAttribute.md 'ServiceLayer.SuccessAttribute') | This attribute maps the source enum value to the [Success](ServiceLayer_ResultType.md#ServiceLayer_ResultType_Success 'ServiceLayer.ResultType.Success') result type.<br/><br/><br/><br/>Use this attribute to mark enum values which should be considered successful result types.<br/><br/> |

| Interfaces | |
| :--- | :--- |
| [IPluginCollection](ServiceLayer_IPluginCollection.md 'ServiceLayer.IPluginCollection') | This interface provides access to a list of ServiceLayer plugins which are already installed.<br/><br/><remarks>A static instance of this collection is available to you via the static <see cref="F:ServiceLayer.ServiceLayerConfig.Plugins"/> property. You can also access it directly from a Plugin instance, via the <see cref="P:ServiceLayer.Plugin.Context"/> property.</remarks> |
| [IPluginContext](ServiceLayer_IPluginContext.md 'ServiceLayer.IPluginContext') | This allows you to retrieve and manipulate the plugins and result type converters which are installed by ServiceLayer, from within the installation and uninstallation logic of your custom plugins.<br/><remarks>An instance of this interface is available via the <see cref="P:ServiceLayer.Plugin.Context"/> property</remarks> |

| Enums | |
| :--- | :--- |
| [ResultType](ServiceLayer_ResultType.md 'ServiceLayer.ResultType') | The default enum representing the status of a result returned from a service method.<br/> |
