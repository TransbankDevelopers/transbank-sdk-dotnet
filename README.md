[![Build Status](https://semaphoreci.com/api/v1/projects/93c66958-6ec3-43d1-9dba-805fdba66c5c/2078331/badge.svg)](https://semaphoreci.com/continuum/transbank-onepay-sdk-dotnet)
# Transbank .Net SDK

SDK Oficial de Transbank

## Soporte:
 - .Net Standard 1.3+
 - .Net Core 1.0+
 - .Net Framework 4.6+

## Dependencias
Al realizar la instalaci�n con NuGet las dependencias
debieran instalarse autom�ticamente.

- Newtonsoft 11.0.2

# Instalaci�n

### Instalar con NuGet

Desde una l�nea de comandos:

```bash
nuget install TransbankSDK
```

Desde Package Manager:

```bash
PM> Install-Package TransbankSDK
```

Desde Visual Studio:

1. Abrir el explorador de soluciones.
2. Clic derecho en un proyecto dentro de tu soluci�n.
3. Clic en Administrar paquetes NuGet.
4. Clic en la pesta�a Examinar y busque `TransbankSDK`
5. Clic en el paquete `TransbankSDK`, seleccione la versi�n que desea utilizar y finalmente selecciones instalar.

## Primeros pasos

### OnePay

#### Configuraci�n del APIKEY y APISECRET

Existen 2 formas de configurar esta informaci�n, la cual es �nica para cada comercio.

a. En la inicializaci�n de tu proyecto. (Solo una vez, al iniciar)

    Primero es necesario importar el espacio de nombres:

    ```csharp
    using Transbank.OnePay;
    ```

    La clase `OnePay` contiene la configuraci�n b�sica de tu comercio.

    ```csharp
    OnePay.ApiKey = "[your api key here]";
    OnePay.SharedSecret = "[your shared secret here]";
    ```

b. Pasando el `APIKEY` y `APISECRET` a cada petici�n

    Utilizando un objeto `Transbank.OnePay.Model.Options`

    ```csharp
     TransactionCreateResponse response = Transaction.Create(cart, new Options()
            {
                ApiKey = "[your api key here]",
                SharedSecret = "[your shared secret here]"
            });
    ```

#### Ambientes
Adicionalmente, puedes configurar el SDK para utilizar los servicios del ambiente de `LIVE` (Producci�n) o un `MOCK` alternativo.

La clase `OnePayIntegrationType` dentro del espacio de nombres `Transbank.OnePay.Enums` contiene la informaci�n de los distintos ambientes disponibles.

```csharp
using Transbank.OnePay;
...
OnePay.IntegrationType = Transbank.OnePay.Enums.OnePayIntegrationType.LIVE;
```

El valor por defecto para el tipo de Integraci�n es siempre: `TEST`.

#### Crear una nueva transacci�n

Para iniciar un proceso de pago mediante la aplicaci�n m�vil de OnePay, primero es necesario crear la transacci�n en Transbank.
Para esto se debe crear en primera instancia un objeto `Transbank.OnePay.Model.ShoppingCart` el cual se debe llenar con �tems
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
El monto en el carro de compras, debe ser positivo, en caso contrario se lanzar� una excepci�n del tipo
`Transbank.OnePay.Exceptions.AmountException`

Luego que el carro de compras contiene todos los �tems. Se crea la transacci�n:

```csharp
using Transbank.OnePay:
using Transbank.OnePay.Model:
...
    TransactionCreateResponse response = Transaction.Create(cart);
```

El resultado entregado contiene la confirmaci�n de la creaci�n de la transacci�n, en la forma de un objeto `TransactionCreateResponse`.

```json
"occ": "1807983490979289",
"ott": 64181789,
"signature": "USrtuoyAU3l5qeG3Gm2fnxKRs++jQaf1wc8lwA6EZ2o=",
"externalUniqueNumber": "f506a955-800c-4185-8818-4ef9fca97aae",
"issuedAt": 1532103896,
"qrCodeAsBase64": "QRBASE64STRING"
```

En el caso que no se pueda completar la transacci�n o la respuesta del servicio sea distinta a `http 200`
Se lanzara una excepci�n `Transbank.OnePay.Exceptions.TransactionCreateResponse`

Posteriormente, se debe presentar al usuario el c�digo QR y el n�mero de OTT para que pueda proceder al pago
mediante la aplicaci�n m�vil.

#### Confirmar una transacci�n

Una vez que el usuario realiz� el pago mediante la aplicaci�n, dispones de 30 segundos
para realizar la confirmaci�n de la transacci�n, de lo contrario, se realizar� autom�ticamente
la reversa de la transacci�n.

```csharp
 TransactionCommitResponse commitResponse = Transaction.Commit(
               createResponse.Occ, createResponse.ExternalUniqueNumber);
```

#### Anular una transacci�n

Cuando una transacci�n fue creada correctamente, se dispone de un plazo de 30 d�as para realizar la anulaci�n de esta.

```csharp
 RefundCreateResponse refundResponse = Refund.Create(commitResponse.Amount,
                commitResponse.Occ, response.ExternalUniqueNumber,
                commitResponse.AuthorizationCode);
```
