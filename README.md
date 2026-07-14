# Buckaroo .NET SDK

[![NuGet version](https://img.shields.io/nuget/v/BuckarooSdk.svg)](https://www.nuget.org/packages/BuckarooSdk/)
[![NuGet downloads](https://img.shields.io/nuget/dt/BuckarooSdk.svg)](https://www.nuget.org/packages/BuckarooSdk/)
[![License: MIT](https://img.shields.io/badge/license-MIT-blue.svg)](LICENSE)

Official .NET SDK for the [Buckaroo](https://www.buckaroo.nl/) payment platform. It provides a
strongly-typed, fluent wrapper around the Buckaroo JSON API so you can create transactions, add
services, and handle status pushes without hand-rolling requests or signatures.

## Requirements

- **.NET Standard 2.0** or higher — works with .NET 6/7/8+, .NET Core 2.0+, and .NET Framework 4.6.1+.
- A Buckaroo account with a **website key** and **secret key** from the
  [Buckaroo Payment Plaza](https://plaza.buckaroo.nl/).

The only runtime dependency is [Newtonsoft.Json](https://www.nuget.org/packages/Newtonsoft.Json/).

## Installation

Install the [`BuckarooSdk`](https://www.nuget.org/packages/BuckarooSdk/) package from NuGet.

**.NET CLI**

```bash
dotnet add package BuckarooSdk
```

**Package Manager Console**

```powershell
Install-Package BuckarooSdk
```

**PackageReference**

```xml
<PackageReference Include="BuckarooSdk" Version="*" />
```

## Getting started

### Create a client

`SdkClient` is a lightweight factory — it holds no credentials. You pass your keys and choose the
environment per request via `Authenticate(...)`, so a single client instance can be reused across
requests and is safe to register as a singleton.

```csharp
using BuckarooSdk;

var client = new SdkClient();
```

### Create a payment

The API is a fluent chain: `CreateRequest → Authenticate → TransactionRequest → SetBasicFields →
<payment method> → <action> → Execute`. Here is a minimal iDEAL payment:

```csharp
using System.Globalization;
using BuckarooSdk;
using BuckarooSdk.DataTypes.RequestBases;
using BuckarooSdk.Services.Ideal.TransactionRequest;

var client = new SdkClient();

var response = client.CreateRequest()
    .Authenticate(websiteKey, secretKey, isLive: false, new CultureInfo("nl-NL"))
    .TransactionRequest()
    .SetBasicFields(new TransactionBase
    {
        Currency = "EUR",
        AmountDebit = 10.00m,
        Invoice = "INV-0001",
        Description = "Order 0001",
        ReturnUrl = "https://your-shop.example/return",
        PushUrl = "https://your-shop.example/webhooks/buckaroo",
    })
    .Ideal()
    .Pay(new IdealPayRequest
    {
        Issuer = BuckarooSdk.Services.Ideal.Constants.Issuers.IngBank,
    })
    .Execute();
```

`ReturnUrl` and `PushUrl` are optional per transaction; when omitted, Buckaroo falls back to the URLs
configured for your website key in the Payment Plaza.

Other payment methods are selected the same way — `.Visa()`, `.MasterCard()`, `.Maestro()`,
`.Bancontact()`, `.Paypal()`, and so on — each exposing method-specific actions such as `.Pay(...)`,
`.Refund(...)`, or `.Authorize(...)`. See the [`BuckarooSdk/Services`](BuckarooSdk/Services) folder
for the full list.

### Handle the response

`Execute()` returns a `RequestResponse`. Check the status code against `BuckarooSdk.Constants.Status`,
and for redirect-based methods like iDEAL send the shopper to the URL in `RequiredAction`:

```csharp
using BuckarooSdk.Services.Ideal.TransactionRequest;

if (response.Status.Code.Code == BuckarooSdk.Constants.Status.PendingProcessing)
{
    // Redirect the shopper to their bank to complete the payment.
    var redirectUrl = response.RequiredAction.RedirectURL;
}

var transactionKey = response.Key;                              // reference for later lookups/pushes
var ideal = response.GetActionResponse<IdealPayResponse>();     // typed, method-specific fields
```

Common status codes (`BuckarooSdk.Constants.Status`): `Success = 190`, `Failed = 490`,
`Declined = 690`, `PendingInput = 790`, `PendingProcessing = 791`, `CanceledByUser = 890`.

### Async

Every action also has an awaitable variant — prefer it in async code. `Execute()` is just a blocking
wrapper around `ExecuteAsync()`:

```csharp
var response = await client.CreateRequest()
    .Authenticate(websiteKey, secretKey, isLive: false, new CultureInfo("nl-NL"))
    .TransactionRequest()
    .SetBasicFields(/* ... */)
    .Ideal()
    .Pay(/* ... */)
    .ExecuteAsync();
```

### Handle status pushes

Buckaroo confirms the final result of a transaction with a signed **push** to your `PushUrl`. Use
the push handler to verify the signature and deserialize the payload — it throws
`AuthenticationException` if the signature is invalid, so an unverified push never reaches your code:

```csharp
using BuckarooSdk;
using BuckarooSdk.DataTypes.Push;

var pushHandler = client.GetPushHandler(secretKey);

// body: the raw request bytes; requestUri: the absolute URL Buckaroo posted to;
// authorizationHeader: the incoming "Authorization" header value.
Push push = pushHandler.DeserializePush(body, requestUri, authorizationHeader);

if (push.Status.Code.Code == BuckarooSdk.Constants.Status.Success)
{
    var transactionKey = push.Key;
    // Mark the order as paid.
}
```

## Test vs live

The environment is chosen entirely by the `isLive` argument to `Authenticate(...)`:

| `isLive` | Endpoint |
|---|---|
| `false` | `https://testcheckout.buckaroo.nl` (test) |
| `true`  | `https://checkout.buckaroo.nl` (production) |

Use your **test** website/secret keys against the test endpoint while integrating, then switch
`isLive` to `true` with your live keys.

## Documentation

- **Buckaroo developer documentation:** https://docs.buckaroo.io/
- **API reference & supported payment methods:** https://docs.buckaroo.io/reference
- **This package on NuGet:** https://www.nuget.org/packages/BuckarooSdk/

## Development

```bash
# Restore & build the library
dotnet build BuckarooSdk/BuckarooSdk.csproj -c Release

# Pack locally (matches what CI publishes)
dotnet pack BuckarooSdk/BuckarooSdk.csproj -c Release -p:Version=0.0.1-local -o ./artifacts
```

**Tests.** `BuckarooSdk.Tests` is a legacy .NET Framework 4.7.1 (`packages.config`) project, so it
builds and runs on **Windows** via Visual Studio or `msbuild` + `nuget restore` — not under
`dotnet test` on Linux/macOS. The tests read credentials from a local, git-ignored
`TestSettings` class (via user secrets); supply your own website/secret keys to run them.

Contributions are welcome — please open an issue or pull request against
[`buckaroo-it/BuckarooSdk_DotNet`](https://github.com/buckaroo-it/BuckarooSdk_DotNet).

## Releasing

Maintainers: see [RELEASING.md](RELEASING.md) for how to publish a new version to NuGet. Releases are
published automatically via GitHub Actions using NuGet Trusted Publishing (OIDC) — no API key to
manage.

## Support

For questions about your account or the API, contact Buckaroo support at
[support@buckaroo.nl](mailto:support@buckaroo.nl). For bugs or feature requests in this SDK, open an
issue on [GitHub](https://github.com/buckaroo-it/BuckarooSdk_DotNet/issues).

## License

Released under the [MIT License](LICENSE).
