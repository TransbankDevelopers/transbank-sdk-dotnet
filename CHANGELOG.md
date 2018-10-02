# Changelog
Todos los cambios notables a este proyecto serán documentados en este archivo.

El formato está basado en [Keep a Changelog](http://keepachangelog.com/en/1.0.0/)
y este proyecto adhiere a [Semantic Versioning](http://semver.org/spec/v2.0.0.html).

## [1.2.0] - 2018-08-30
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
