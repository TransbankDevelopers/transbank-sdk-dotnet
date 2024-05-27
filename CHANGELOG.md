# Changelog

Todos los cambios notables a este proyecto serán documentados en este archivo.

El formato está basado en [Keep a Changelog](http://keepachangelog.com/en/1.0.0/)
y este proyecto adhiere a [Semantic Versioning](http://semver.org/spec/v2.0.0.html).

## [7.0.0] - 2024-05-27

### Added

- Ahora los productos se pueden instanciar de 3 maneras: pasando en el constructor un objeto `Options` con la configuración que corresponda, o utilizando uno de los dos métodos de configuración según el ambiente que quieras utilizar. Por ejemplo: *producto*.`buildForIntegration(CC, apiKey)` o *producto*.`buildForProduction(CC, apiKey)`

### Changed

- Se cambia la versión de API de Transbank de 1.3 a 1.2
- Se actualiza el retorno del método `Delete` para las inscripciones de Oneclick. Ahora retorna un booleano en `true` si la inscripción se eliminó correctamente, de lo contrario lanzará una excepción.
- Se elimina la configuración por defecto para el ambiente de integración para todos los productos, ahora es necesario utilizar siempre las credenciales en la creación del objeto.
- Se actualiza la ruta para importar Patpass Comercio. Ahora se debe importar de esta forma: `using Transbank.PatpassComercio;`

### Removed

- Se quitan los métodos 'increaseAmount', 'increaseAuthorizationDate', 'reversePreAuthorizedAmount', 'deferredCaptureHistory' a las versiones diferidas de WebpayPlus, WebpayPlus Mall, Oneclick Mall, Transaccion Completa y Transaccion Completa Mall
- Se quita el campo 'captureExpirationDate' de todos los productos
- Se eliminan los productos `Patpass by Webpay` y `Webpay Modal`

## [6.0.0] - 2022-09-01

### Changed

- Se migra el API desde la versión 1.2 a la versión 1.3

### Added

- Se agrega los métodos 'increaseAmount', 'increaseAuthorizationDate', 'reversePreAuthorizedAmount', 'deferredCaptureHistory' a las versiones diferidas de WebpayPlus, WebpayPlus Mall, Oneclick Mall, Transaccion Completa y Transaccion Completa Mall
- Ahora los métodos status y commit de las versiones diferidas de WebpayPlus, WebpayPlus Mall, Transaccion Completa y Transaccion Completa Mall retornan el campo 'captureExpirationDate'
- Ahora los métodos status y authorize de la versión diferida de Oneclick Mall retornan el campo 'captureExpirationDate'
- El método commit de Transaccion Completa y Transaccion Completa Mall ahora permite los atributos 'idQueryInstallments' y 'deferredPeriodIndex' en nulo

## [5.0.0] - 2022-03-23

### Changed

- Se mejora el uso de las conexiones http permitiendo dos modos: a. Reutilizando una única instancia estática de 'HttpClient' y b. Permitiendo a los constructores recibir una instancia del 'HttpClient' administrada externamente 
- Se agrega el atributo 'OriginalRequest' en todos los responses, que retornara el payload en json de la petición enviada a Transbank
- Se agrega el atributo 'OriginalResponse' en todos los responses, que retornará la respuesta original en json entregada por Transbank
- Todos los atributos ahora permiten valores nulos (ahora son decimal?, DateTime?, byte?, int?) esto permite preservar los valores entregados por Transbank
- Se cambia el tipo de dato de todos los campos 'AuthorizationCode' a 'string' 
- Se cambia el tipo de dato de todos los campos monto (Amount, InstallmentsAmount, PrepaidBalance, Balance, NullifiedAmount) a 'decimal?' 
- Se cambia el tipo de dato de todos los campos date (TransactionDate) a 'DateTime?' 
- Se corrije el nombramiento en el campo 'prepaidBalance' hacia 'PrepaidBalance'
- Se modifica el constructor de parámetro 'Options options' a los parámetros 'Options options, HttpClient httpClient' a todas las clases 
- Se agrega un constructor con los parámetros 'string commerceCode, string apiKey, IIntegrationType integrationType, HttpClient httpClient'  a todas las clases 

### Removed

- Se elimina los atributos 'CardNumber' y 'SessionId' a la clase 'MallAuthorizeResponse' de Oneclick

## [4.0.1] - 2022-01-18

### Changed

- Se deprecan los atributos 'CardNumber' y 'SessionId' a la clase 'MallAuthorizeResponse' de Oneclick
- Se agrega el atributo 'CardDetail' a la clase 'MallAuthorizeResponse' de Oneclick
- Se agrega manejo de errores para Patpass Comercio

## [4.0.0] - 2021-12-22

### Removed

- Se elimina Onepay
- Se elimina la librería 'MQTTnet'

### Changed

- Se migra el api desde la versión 1.0 a la versión 1.2
- Ahora el método de retorno al crear la transacción en WebPayPlus debe tener soporte GET (cuando es exitosa) y POST (cuando se retorna sin concluir el ingreso de la tarjeta)
- Ahora el método de retorno al inscribirse en Oneclick debe tener soporte GET (cuando es exitosa) y POST (cuando se retorna sin concluir la inscripción)
- Se refactoriza y migra todos los productos desde clases estáticas a clases instanciables
- Se unifica 'Transaction' y 'DeferredTransaction' en WebpayPlus
- Se unifica 'MallTransaction' y 'MallDeferredTransaction' en WebpayPlus y Oneclick
- Se reordenan los parámetros del método capture de WebpayPlus Mall a 'Capture(string childCommerceCode, string token, string buyOrder, string authorizationCode, decimal captureAmount)'
- Se reordenan los parámetros del método delete de Oneclick a 'Delete(string tbkUser, string userName)'
- Se reordenan los parámetros del método capture de Oneclick a 'Capture(string childCommerceCode, string childBuyOrder, string authorizationCode, decimal captureAmount)'
- Se reordenan los parámetros del método create de Transacción Completa Mall a 'Create(string buyOrder, string sessionId, string cardNumber, string cardExpirationDate, List<CreateDetails> details, short? cvv)'

### Added

- Se agrega soporte a Webpay Modal
- Se agregan validaciones de obligatoriedad y tamaño de los parámetros a los métodos de WebpayPlus, Oneclick, Webpay Modal, Transacción Completa
- Se agrega una clase de constantes con los códigos de comercio de integración: 'IntegrationCommerceCodes'
- Se agrega una clase de constantes con las claves de comercio de integración: 'IntegrationApiKeys'
- Se agrega el método Capture a Transacción Completa
- Se agrega el método Capture a Transacción Completa Mall

## [3.0.1] - 2021-06-23

### Fixed
- Se corrigio el mapeo de las propiedades Status y UrlVoucher de la clase StatusResponse de Patpass Comercio.

## [3.0.0] - 2021-05-26

### Removed
- Se quita soporte para todos los productos en versión REST

### Changed
- Ya no es necesario pasar los headers del producto en las opciones, el SDK lo hace por su cuenta.

### Added
- Se agrega soporte para .NET Standard 2.0, puedes revisar la lista de compatibilidad en este link https://dotnet.microsoft.com/platform/dotnet-standard

## [2.6.0] - 2020-12-17

### Added

- Se Agrega soporte para Oneclick Mall Diferido

### Changed

- Se mantiene la retro compatibilidad, pero todas las clases Oneclick "Normal" tienen su reemplazo "Mall" y las clases "Normal" se marcaron como deprecadas.

## [2.5.1] - 2020-11-09

### Fixed

- Se agregan headers faltantes para Webpay Plus Diferido

## [2.5.0] - 2020-10-20

### Added

- Se agrega soporte para:
  - Webpay Plus Rest
    - modalidad normal
    - modalidad captura diferida
    - modalidad mall
    - modalidad mall captura diferida
  - Patpass by Webpay Rest
  - Patpass Comercio Rest
  - Transacción completa Rest
    - modalidad mall

## [2.4.0] - 2019-12-26

### Added

- Se agrega soporte para Oneclick Mall y Transacción Completa en sus versiones REST.

## [2.3.0] - 2019-11-12

### Added

- Se agregan las clases necesarias para conectarse al Websocket de Onepay. Estas clases pueden ser utilizadas independientes, pero estan especialmente diseñadas para ser utilizadas por el SDK de POSIntegrado

- Se agregan templates para crear Issues en Github.

## [2.2.1] - 2019-05-20

### Fixed

- Se soluciona error asignando certificado de Transbank automáticamente, si no se configura es asignado según el entorno.
- Se mejora compatibilidad con servidores de Transbank.

## [2.2.0] - 2019-04-04

### Added

- Se agregaron los parámetros `qr_width_height` y `commerce_logo_url` a Options, para especificar el tamaño del QR generado para la transacción, y especificar la ubicación del logo de comercio para ser mostrado en la aplicación móvil de Onepay. Puedes configurar estos parámetros globalmente o por transacción.

## [2.1.0] - 2019-02-25

### Changed

- Los archivos de certificado ahora estan en la raiz del proyecto, ya que ahora tambien se encuentran disponibles los certificados de PatPass.
- Refactorisa codigo para cumplir con el estandar definido para C#.
- El metodo `getEnvironmentDefault` fue deprecado.

### Added

- Agrega metodo `GetEnvironmentDefault` en remplazo del deprecado `getEnvironmentDefault`.
- Agrega soporte para PatPass
- La clase `Configuration` ahora tiene los atributos `CommerceMail` y `PatPassCurrency` para operar con PatPass.
- La clase `Configuration` ahora tambien entrega la configuracion de Testing para PatPass `.ForTestingPatPassByWebpayNormal`.
- La clase `Webpay` ahora entrega una transaccion de tipo `PatPassByWebpayNormal` al llamar a la propiedad `PatPassByWebpayTransaction`.

## [2.0.1] - 2019-02-08

### Changed

- Corrige bug en `WSSecurity.CreateToken()` cuando Serial Number del certificado es muy largo.

## [2.0.0] - 2019-01-31

### Added

- Agrega soporte para Webpay
- `WebpayCapture.cs`:
  - Sobrecarga del metodo `capture` para soportar entregar como parametro el codigo de comercio `storeCode`
- `WebpayNullify.cs`:
  - Sobrecarga del metodo `nullify` para no enviar el parametro `commerceCode` cuando la anulación es para el mismo comercio.
- `WebpayOneClick.cs`
  - Metodo `RemoveUser` como wrapper de `oneClickremoveUserOutput`

### Changed

- TargetFramework .net452
- Se cambia el namespace `Webpay.Transbank.Library` por `Transbank.Webpay`
- `Configuration.cs`:
  - Para ser consistentes con los demas SDK
    - `WebpayCert` que representaba al certificado del comercio, ahora se llama `PrivateCertPfxPath` y hace referencia a que es la ruta a un archivo pfx o p12 generado por el commercio.
    - `PublicCert` que representaba al certificado publico de Transbank, ahora se llama `TbkPublicCertPath` y es proporcionado por el SDK de aceurdo al ambiente configurado.
  - Se agregan metodos estaticos que permiten obtener un objeto `Configuration` preparado para distintos tipos de pruebas:
    - `ForTestingWebpayPlusNormal()`
    - `ForTestingWebpayOneClickNormal()`
    - `ForTestingWebpayPlusCapture()`
    - `ForTestingWebpayPlusMall()`

- `Webpay.cs`:
  - Los siguientes metodos se transformaron en Properties:
    - `getNormalTransaction()` => `NormalTransaction`
    - `getMallNormalTransaction()` => `MallNormalTransaction`
    - `getNullifyTransaction()` => `NullifyTransaction`
    - `getCaptureTransaction()` => `CaptureTransaction`
    - `getCompleteTransaction()` => `CompleteTransaction`
    - `getOneClickTransaction()` => `OneClickTransaction`

## [1.3.0] - 2018-10-02

### Added

- Se implementa `ChannelTyep.Parse` para obtener una instancia de `ChannelType` en base a un string.

## [1.2.1] - 2018-10-02

### Added

- Credenciales pre-configuradas para Onepay. No es necesario configurar Api Key ni Shared Secret para operar en ambiente TEST.

## [1.2.0] - 2018-08-30

### Changed

- Apunta entornos a los servidores oficiales para TEST y LIVE. De ahora en adelante, el SDK puede ser usado para validaciones oficiales y será interoperable con las herramientas provistas por Transbank para ayudar esa integración y validación (como el dashboard para simular transacciones).

## [1.1.1] - 2018-08-27

### Changed

- Corrige bug relacionado a `CallbackURL` no siendo usado para crear la firma y ocasionando que
las nuevas transacciones se generen con errores.

## [1.1.0] - 2018-08-23

### Changed

- Agrega `ExternalUniqueNumber` como parámetro, para que el comercio pueda proveer sus propios valores.
- Agrega nuevo parámetro de configuración `CallbackUrl` a Onepay.
- Agrega nuevo parámetro de configuración `AppScheme` a Onepay
- Agrega nuevo parámetro opcional `Channel` a Transaction.create

## [1.0.1] - 2018-08-03

### Changed

- Corrige bug relacionado al total de items en el carro de compras.
