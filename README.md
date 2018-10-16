[![Build Status](https://travis-ci.org/TransbankDevelopers/transbank-sdk-dotnet.svg?branch=master)](https://travis-ci.org/TransbankDevelopers/transbank-sdk-dotnet)
[![Quality Gate](https://sonarcloud.io/api/project_badges/measure?project=dotnetsdk&metric=alert_status)](https://sonarcloud.io/dashboard?id=dotnetsdk)
[![NuGet version](https://badge.fury.io/nu/TransbankSDK.svg)](https://badge.fury.io/nu/TransbankSDK)
# Transbank .Net SDK

SDK Oficial de Transbank

## Requisitos:
 - .Net Standard 1.3+
 - .Net Core 1.0+
 - .Net Framework 4.6+

## Dependencias
Al realizar la instalación con NuGet las dependencias
debieran instalarse automáticamente.

- [Newtonsoft 11.0.2](https://www.newtonsoft.com/json)

## Instalación

### Instalar con NuGet

Desde una línea de comandos:

```bash
nuget install TransbankSDK
```

Desde Package Manager:

```bash
PM> Install-Package TransbankSDK
```

Con .Net CLI:

```bash
dotnet add package TransbankSDK
```

Desde Visual Studio:

1. Abrir el explorador de soluciones.
2. Clic derecho en un proyecto dentro de tu solución.
3. Clic en Administrar paquetes NuGet.
4. Clic en la pestaña Examinar y busque `TransbankSDK`
5. Clic en el paquete `TransbankSDK`, seleccione la versión que desea utilizar y finalmente selecciones instalar.

## Documentación 

Puedes encontrar toda la documentación de cómo usar este SDK en el sitio https://www.transbankdevelopers.cl.

La documentación relevante para usar este SDK es:

- Documentación general sobre los productos y sus diferencias:
  [Webpay](https://www.transbankdevelopers.cl/producto/webpay) y
  [Onepay](https://www.transbankdevelopers.cl/producto/onepay).
- Documentación sobre [ambientes, deberes del comercio, puesta en producción,
  etc](https://www.transbankdevelopers.cl/documentacion/como_empezar#ambientes).
- Primeros pasos con [Webpay](https://www.transbankdevelopers.cl/documentacion/webpay) y [Onepay](https://www.transbankdevelopers.cl/documentacion/onepay).
- Referencia detallada sobre [Webpay](https://www.transbankdevelopers.cl/referencia/webpay) y [Onepay](https://www.transbankdevelopers.cl/referencia/onepay).

## Información para contribuir y desarrollar este SDK

### Windows
- VisualStudio (2017 o superior)

### Standares

- Para los commits respetamos las siguientes normas: https://chris.beams.io/posts/git-commit/
- Usamos ingles, para los mensajes de commit.
- Se pueden usar tokens como WIP, en el subject de un commit, separando el token con `:`, por ejemplo:
`WIP: This is a useful commit message`
- Para los nombres de ramas también usamos ingles.
- Se asume, que una rama de feature no mezclada, es un feature no terminado.
- El nombre de las ramas va en minúsculas.
- Las palabras se separan con `-`.
- Las ramas comienzan con alguno de los short lead tokens definidos, por ejemplo: `feat/tokens-configuration`

#### Short lead tokens
##### Commits
- WIP = Trabajo en progreso.
##### Ramas
- feat = Nuevos features
- chore = Tareas, que no son visibles al usuario.
- bug = Resolución de bugs.

### Todas las mezclas a master se hacen mediante Pull Request.

### Construir el proyecto localmente
1. Si estas usando VisualStudio: (**F6**) o :
    - Click derecho sobre la solución en el explorador de soluciones.
    - Compilar

2. Si estas usando tu propio editor
    ```bash
    dotnet build
    ```

### Correr test localmente
1. Si estas usando VisualStudio (**CTR** + **R**, **CTR** + **A**) o:
    - Abrir el explorador de Test
    - Click derecho sobre el proyecto de test
    - Ejecutar todos los test

2. Si estas usando tu propio editor
    ```bash
    dotnet test TransbankTest
    ```
## Generar una nueva versión (con deploy automático a NuGet)

Para generar una nueva versión, se debe crear un PR (con un título "Prepare release X.Y.Z" con los valores que correspondan para `X`, `Y` y `Z`). Se debe seguir el estándar semver para determinar si se incrementa el valor de `X` (si hay cambios no retrocompatibles), `Y` (para mejoras retrocompatibles) o `Z` (si sólo hubo correcciones a bugs).

En ese PR deben incluirse los siguientes cambios:

1. Modificar el archivo CHANGELOG.md para incluir una nueva entrada (al comienzo) para `X.Y.Z` que explique en español los cambios **de cara al usuario del SDK**.
2. Modificar el archivo `Transbank/Transbank.csproj` para que la versión sea `X.Y.{Z+1}` (de manera que los pre-releases que se generen después del release sean de la siguiente versión).

Luego de obtener aprobación del pull request, debe mezclarse a master e inmediatamente generar un release en GitHub con el tag `vX.Y.Z`. En la descripción del release debes poner lo mismo que agregaste al changelog.

Con eso Travis CI generará automáticamente una nueva versión de la librería y la publicará en NuGet.
