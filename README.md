[![Build Status](https://semaphoreci.com/api/v1/projects/93c66958-6ec3-43d1-9dba-805fdba66c5c/2078331/badge.svg)](https://semaphoreci.com/continuum/transbank-onepay-sdk-dotnet)
# Transbank .Net SDK

SDK Oficial de Transbank

## Soporte:
 - .Net Standard 1.3+
 - .Net Core 1.0+
 - .Net Framework 4.6+

## Dependencias
Al realizar la instalación con NuGet las dependencias
debieran instalarse automáticamente.

- Newtonsoft 11.0.2

# Instalación

### Instalar con NuGet

Desde una línea de comandos:

```bash
nuget install TransbankSDK
```

Desde Package Manager:

```bash
PM> Install-Package TransbankSDK
```

Desde Visual Studio:

1. Abrir el explorador de soluciones.
2. Clic derecho en un proyecto dentro de tu solución.
3. Clic en Administrar paquetes NuGet.
4. Clic en la pestaña Examinar y busque `TransbankSDK`
5. Clic en el paquete `TransbankSDK`, seleccione la versión que desea utilizar y finalmente selecciones instalar.

## Primeros pasos

### OnePay

#### Configuración del APIKEY y APISECRET

Existen 2 formas de configurar esta información, la cual es única para cada comercio.

a. En la inicialización de tu proyecto. (Solo una vez, al iniciar)

    Primero es necesario importar el espacio de nombres:

    ```csharp
    using Transbank.OnePay;
    ```

    La clase `OnePay` contiene la configuración básica de tu comercio.

    ```csharp
    OnePay.ApiKey = "[your api key here]";
    OnePay.SharedSecret = "[your shared secret here]";
    ```

b. Pasando el `APIKEY` y `APISECRET` a cada petición

    Utilizando un objeto `Transbank.OnePay.Model.Options`

    ```csharp
     TransactionCreateResponse response = Transaction.Create(cart, new Options()
            {
                ApiKey = "[your api key here]",
                SharedSecret = "[your shared secret here]"
            });
    ```

#### Ambientes
Adicionalmente, puedes configurar el SDK para utilizar los servicios del ambiente de `LIVE` (Producción) o un `MOCK` alternativo.

La clase `OnePayIntegrationType` dentro del espacio de nombres `Transbank.OnePay.Enums` contiene la información de los distintos ambientes disponibles.

```csharp
using Transbank.OnePay;
...
OnePay.IntegrationType = Transbank.OnePay.Enums.OnePayIntegrationType.LIVE;
```

El valor por defecto para el tipo de Integración es siempre: `TEST`.

#### Crear una nueva transacción

Para iniciar un proceso de pago mediante la aplicación móvil de OnePay, primero es necesario crear la transacción en Transbank.
Para esto se debe crear en primera instancia un objeto `Transbank.OnePay.Model.ShoppingCart` el cual se debe llenar con ítems
`Transbank.OnePay.Model.Items`

```csharp
using Transbank.OnePay:
using Transbank.OnePay.Model:
...

            ShoppingCart cart = new ShoppingCart();
            cart.Add(new Item(
                description: "Zapatos",
                quantity: 1,
                amount: 10000,
                additionalData: null,
                expire: 10));
```
El monto en el carro de compras, debe ser positivo, en caso contrario se lanzará una excepción del tipo
`Transbank.OnePay.Exceptions.AmountException`

Luego que el carro de compras contiene todos los ítems. Se crea la transacción:

```csharp
using Transbank.OnePay:
using Transbank.OnePay.Model:
...
    TransactionCreateResponse response = Transaction.Create(cart);
```

El resultado entregado contiene la confirmación de la creación de la transacción, en la forma de un objeto `TransactionCreateResponse`.

```json
"occ": "1807983490979289",
"ott": 64181789,
"signature": "USrtuoyAU3l5qeG3Gm2fnxKRs++jQaf1wc8lwA6EZ2o=",
"externalUniqueNumber": "f506a955-800c-4185-8818-4ef9fca97aae",
"issuedAt": 1532103896,
"qrCodeAsBase64": "QRBASE64STRING"
```

En el caso que no se pueda completar la transacción o la respuesta del servicio sea distinta a `http 200`
Se lanzara una excepción `Transbank.OnePay.Exceptions.TransactionCreateResponse`

Posteriormente, se debe presentar al usuario el código QR y el número de OTT para que pueda proceder al pago
mediante la aplicación móvil.

#### Confirmar una transacción

Una vez que el usuario realizó el pago mediante la aplicación, dispones de 30 segundos
para realizar la confirmación de la transacción, de lo contrario, se realizará automáticamente
la reversa de la transacción.

```csharp
 TransactionCommitResponse commitResponse = Transaction.Commit(
               createResponse.Occ, createResponse.ExternalUniqueNumber);
```

#### Anular una transacción

Cuando una transacción fue creada correctamente, se dispone de un plazo de 30 días para realizar la anulación de esta.

```csharp
 RefundCreateResponse refundResponse = Refund.Create(commitResponse.Amount,
                commitResponse.Occ, response.ExternalUniqueNumber,
                commitResponse.AuthorizationCode);
```
