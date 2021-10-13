#### [ServiceLayer](index 'index')
### Namespaces
<a name='ServiceLayer'></a>
## ServiceLayer Namespace

| Classes | |
| :--- | :--- |
| [DefaultResultTypeAttribute](ServiceLayer_DefaultResultTypeAttribute 'ServiceLayer.DefaultResultTypeAttribute') | The default result type attribute class.<br/><br/><br/><br/>This attribute is used for annotating the default value of an enum to use when it's treated as a result type.<br/><br/> |
| [FailureAttribute](ServiceLayer_FailureAttribute 'ServiceLayer.FailureAttribute') | This attribute maps the source enum value to the [Failure](ServiceLayer_ResultType#ServiceLayer_ResultType_Failure 'ServiceLayer.ResultType.Failure') result type.<br/><br/><br/><br/>Use this attribute to mark enum values which should be considered failure result types.<br/><br/> |
| [InconclusiveAttribute](ServiceLayer_InconclusiveAttribute 'ServiceLayer.InconclusiveAttribute') | This attribute maps the source enum value to the [Inconclusive](ServiceLayer_ResultType#ServiceLayer_ResultType_Inconclusive 'ServiceLayer.ResultType.Inconclusive') result type.<br/><br/><br/><br/>Use this attribute to mark enum values which should be considered inconclusive result types.<br/><br/><remarks>By default, unless otherwise specified, ServiceLayer will consider an enum value to be an inconclusive result type.</remarks> |
| [ResultTypeAttribute](ServiceLayer_ResultTypeAttribute 'ServiceLayer.ResultTypeAttribute') | This attribute is used for annotating a source enum value and providing a destination value which it can be mapped to.<br/><br/><br/><br/>This is used for converting between the source value and destination value, or from the destination value to the source value.<br/><br/> |
| [SuccessAttribute](ServiceLayer_SuccessAttribute 'ServiceLayer.SuccessAttribute') | This attribute maps the source enum value to the [Success](ServiceLayer_ResultType#ServiceLayer_ResultType_Success 'ServiceLayer.ResultType.Success') result type.<br/><br/><br/><br/>Use this attribute to mark enum values which should be considered successful result types.<br/><br/> |

| Enums | |
| :--- | :--- |
| [ResultType](ServiceLayer_ResultType 'ServiceLayer.ResultType') | The default enum representing the status of a result returned from a service method.<br/> |
  
