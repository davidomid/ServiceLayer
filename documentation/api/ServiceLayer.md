## ServiceLayer Namespace

| Classes | |
| :--- | :--- |
| [AnyToAnyResultTypeConverter](ServiceLayer_AnyToAnyResultTypeConverter.md 'ServiceLayer.AnyToAnyResultTypeConverter') | Inherit this abstract class to create your own result type converter which converts any source result type enum value to any destination result type enum.<br/> |
| [DefaultResultTypeAttribute](ServiceLayer_DefaultResultTypeAttribute.md 'ServiceLayer.DefaultResultTypeAttribute') | The default result type attribute class.<br/><br/><br/><br/>This attribute is used for annotating the default value of an enum to use when it's treated as a result type.<br/><br/> |
| [FailureAttribute](ServiceLayer_FailureAttribute.md 'ServiceLayer.FailureAttribute') | This attribute maps the source enum value to the [Failure](ServiceLayer_ResultType.md#ServiceLayer_ResultType_Failure 'ServiceLayer.ResultType.Failure') result type.<br/><br/><br/><br/>Use this attribute to mark enum values which should be considered failure result types.<br/><br/> |
| [InconclusiveAttribute](ServiceLayer_InconclusiveAttribute.md 'ServiceLayer.InconclusiveAttribute') | This attribute maps the source enum value to the [Inconclusive](ServiceLayer_ResultType.md#ServiceLayer_ResultType_Inconclusive 'ServiceLayer.ResultType.Inconclusive') result type.<br/><br/><br/><br/>Use this attribute to mark enum values which should be considered inconclusive result types.<br/><br/> |
| [Plugin](ServiceLayer_Plugin.md 'ServiceLayer.Plugin') | You can inherit this abstract class to create your own ServiceLayer plugin.<br/> |
| [ResultTypeAttribute](ServiceLayer_ResultTypeAttribute.md 'ServiceLayer.ResultTypeAttribute') | This attribute is used for annotating a source enum value and providing a destination value which it can be mapped to.<br/><br/><br/><br/>This is used for converting between the source value and destination value, or from the destination value to the source value.<br/><br/> |
| [ServiceLayerConfig](ServiceLayer_ServiceLayerConfig.md 'ServiceLayer.ServiceLayerConfig') | Use this class to set the global ServiceLayer configuration for your application.<br/> |
| [SuccessAttribute](ServiceLayer_SuccessAttribute.md 'ServiceLayer.SuccessAttribute') | This attribute maps the source enum value to the [Success](ServiceLayer_ResultType.md#ServiceLayer_ResultType_Success 'ServiceLayer.ResultType.Success') result type.<br/><br/><br/><br/>Use this attribute to mark enum values which should be considered successful result types.<br/><br/> |

| Interfaces | |
| :--- | :--- |
| [IPluginCollection](ServiceLayer_IPluginCollection.md 'ServiceLayer.IPluginCollection') | This interface provides access to a list of ServiceLayer plugins which are already installed.<br/><br/> |
| [IPluginContext](ServiceLayer_IPluginContext.md 'ServiceLayer.IPluginContext') | This allows you to retrieve and manipulate the plugins and result type converters which are installed by ServiceLayer, from within the installation and uninstallation logic of your custom plugins.<br/> |
| [IService](ServiceLayer_IService.md 'ServiceLayer.IService') | This is a simple interface which can be used to mark a class as being a service.<br/> |

| Enums | |
| :--- | :--- |
| [ResultType](ServiceLayer_ResultType.md 'ServiceLayer.ResultType') | The default enum representing the status of a result returned from a service method.<br/> |
