[![Build status](https://ci.appveyor.com/api/projects/status/89bp8nprjo3hfwu1/branch/master?svg=true)](https://ci.appveyor.com/project/TransbankDevelopers/transbank-sdk-dotnet/branch/master)
[![Quality Gate](https://sonarcloud.io/api/project_badges/measure?project=dotnetsdk&metric=alert_status)](https://sonarcloud.io/dashboard?id=dotnetsdk)
[![NuGet version](https://badge.fury.io/nu/TransbankSDK.svg)](https://badge.fury.io/nu/TransbankSDK)
# Transbank .Net SDK

SDK Oficial de Transbank

## Requisitos:
 - Target compatible con .NET Framework 4.5.2 y .NET Standard 2.0

## Dependencias
Al realizar la instalación con NuGet las dependencias
debieran instalarse automáticamente.

- [Newtonsoft 13.0.3](https://www.newtonsoft.com/json)
- [System.Net.Http 4.3.4](https://dotnet.microsoft.com/)
- [NETStandard.Library 2.0.3](https://dotnet.microsoft.com/)

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
  [Webpay](https://www.transbankdevelopers.cl/producto/webpay).
- Documentación sobre [ambientes, deberes del comercio, puesta en producción,
  etc](https://www.transbankdevelopers.cl/documentacion/como_empezar#ambientes).
- Primeros pasos con [Webpay](https://www.transbankdevelopers.cl/documentacion/webpay).
- Referencia detallada sobre [Webpay](https://www.transbankdevelopers.cl/referencia/webpay).

## Información para contribuir a este proyecto

### Windows
- VisualStudio (2017 o superior)

### Forma de trabajo

- Para los mensajes de commits, nos basamos en las [Git Commit Guidelines de Angular](https://github.com/angular/angular.js/blob/master/DEVELOPERS.md#commits).
- Usamos inglés para los nombres de ramas y mensajes de commit.
- Los mensajes de commit no deben llevar punto final.
- Los mensajes de commit deben usar un lenguaje imperativo y estar en tiempo presente, por ejemplo, usar "change" en lugar de "changed" o "changes".
- Los nombres de las ramas deben estar en minúsculas y las palabras deben separarse con guiones (-).
- Todas las fusiones a la rama principal se deben realizar mediante solicitudes de Pull Request(PR). ⬇️
- Se debe emplear tokens como "WIP" en el encabezado de un commit, separados por dos puntos (:), por ejemplo, "WIP: this is a useful commit message".
- Una rama con nuevas funcionalidades que no tenga un PR, se considera que está en desarrollo.
- Los nombres de las ramas deben comenzar con uno de los tokens definidos. Por ejemplo: "feat/tokens-configurations".

### Short lead tokens permitidos

`WIP` = En progreso.

`feat` = Nuevos features.

`fix` = Corrección de un bug.

`docs` = Cambios solo de documentación.

`style` = Cambios que no afectan el significado del código. (espaciado, formateo de código, comillas faltantes, etc)

`refactor` = Un cambio en el código que no arregla un bug ni agrega una funcionalidad.

`perf` = Cambio que mejora el rendimiento.

`test` = Agregar test faltantes o los corrige.

`chore` = Cambios en el build o herramientas auxiliares y librerías.

`revert` = Revierte un commit.

`release` = Para liberar una nueva versión.

### Creación de un Pull Request

- El PR debe estar enfocado en un cambio en concreto, por ejemplo, agregar una nueva funcionalidad o solucionar un error, pero un solo PR no puede agregar una nueva funcionalidad y arreglar un error.
- El título del los PR y mensajes de commit no debe comenzar con una letra mayúscula.
- No se debe usar punto final en los títulos.
- El título del PR debe comenzar con el short lead token definido para la rama, seguido de ":"" y una breve descripción del cambio.
- La descripción del PR debe detallar los cambios que se están incorporando.
- La descripción del PR debe incluir evidencias de que los test se ejecutan de forma correcta o incluir evidencias de que los cambios funcionan y no afectan la funcionalidad previa del proyecto.
- Se pueden agregar capturas, gif o videos para complementar la descripción o demostrar el funcionamiento del PR.

#### Flujo de trabajo

1. Crea tu rama desde develop.
2. Haz un push de los commits y publica la nueva rama.
3. Abre un Pull Request apuntando tus cambios a develop.
4. Espera a la revisión de los demás integrantes del equipo.
5. Para poder mezclar los cambios se debe contar con 2 aprobaciones de los revisores y no tener alertas por parte de las herramientas de inspección.

### Esquema de flujo con git

![gitflow](https://wac-cdn.atlassian.com/dam/jcr:cc0b526e-adb7-4d45-874e-9bcea9898b4a/04%20Hotfix%20branches.svg?cdnVersion=1324)

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
    dotnet test 
    ```
## Generar una nueva versión

Para generar una nueva versión, se debe crear un PR (con un título "release: prepare release X.Y.Z" con los valores que correspondan para `X`, `Y` y `Z`). Se debe seguir el estándar [SemVer](https://semver.org/lang/es/) para determinar si se incrementa el valor de `X` (si hay cambios no retrocompatibles), `Y` (para mejoras retrocompatibles) o `Z` (si sólo hubo correcciones a bugs).

En ese PR deben incluirse los siguientes cambios:

1. Modificar el archivo `CHANGELOG.md` para incluir una nueva entrada (al comienzo) para `X.Y.Z` que explique en español los cambios.
2. Modificar el archivo `Transbank.csproj` y modificar la versión.

Luego de obtener aprobación del PR, debe mezclarse a master e inmediatamente generar un release en GitHub con el tag `vX.Y.Z`. En la descripción del release debes poner lo mismo que agregaste al changelog.

Posterior a la liberación debes mezclar la rama release en develop, finalmente realizar un rebase de la rama develop utilizando como base la rama main.
