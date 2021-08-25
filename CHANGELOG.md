# Changelog

Todos los cambios notables a este proyecto serán documentados en este archivo.

El formato está basado en [Keep a Changelog](http://keepachangelog.com/en/1.0.0/)
y este proyecto adhiere a [Semantic Versioning](http://semver.org/spec/v2.0.0.html).

## [2.6.1] - 2021-08-25

### Fixed

- Se actualiza certificado Público de Transbank

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
