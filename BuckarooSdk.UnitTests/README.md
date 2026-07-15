# BuckarooSdk.UnitTests

Fast, deterministic, **network-free** unit tests for the Buckaroo .NET SDK. The goal is to give
confidence that changes to the SDK are safe *without* ever calling the Buckaroo API.

## Why a new project

The existing `BuckarooSdk.Tests` project is a legacy .NET Framework 4.7.1 (`packages.config`)
harness whose "tests" call `request.Execute()` against the live `testcheckout.buckaroo.nl`
gateway, require real credentials, and in places open a browser. It is an integration/manual
harness — it cannot run on CI and gives no isolated feedback. This project complements it with
true unit tests.

## What is covered

Everything the SDK does *before* the bytes leave the machine — which is where almost all logic
(and almost all regressions) live:

| Area | Suite | What it protects |
| --- | --- | --- |
| HMAC-SHA256 auth | `Connection/SignatureCalculationServiceTests` | The request/response/push signature — pinned known-answer + tamper sensitivity |
| Push (webhook) handling | `Base/PushHandlerTests` | Signature verification + deserialization of a signed transaction *and* data-request push, custom-parameter extraction, with no network |
| Request → parameter mapping | `Services/ServiceHelperTests` | The reflection engine that flattens typed requests (groups, collections, decimals, culture) |
| Fluent builder | `Transaction/FluentBuilderTests` | Authentication wiring, endpoint selection, service/action/version assembly, and multi-service chaining |
| Service catalog | `Services/ServiceCatalogTests` | Pins the `(service, action, version)` contract for the major payment methods and their non-Pay actions |
| Data-request path | `Transaction/DataRequestTests` | The data-request endpoint, distinct from the transaction endpoint |
| Wire-format serialization | `Serialization/TransactionRequestSerializationTests` | The exact camelCase JSON that would be POSTed (incl. custom/additional parameter shapes) |
| Response deserialization | `Serialization/ResponseDeserializationTests` | Parsing a recorded gateway response into `RequestResponse` + `GetActionResponse<T>` mapping |
| Client entry point | `SdkClientTests` | `CreateRequest` / logger selection / push + signature factories |
| Status contract | `Constants/StatusCodeTests` | The numeric status codes consumers branch on |

Tests are written with **xUnit** and the built-in `Assert` (no extra assertion/mocking
dependencies), mirroring the approach used by the Stripe .NET SDK.

## Running

```bash
# from the repository root
dotnet test BuckarooSdk.UnitTests/BuckarooSdk.UnitTests.csproj

# with code coverage (coverlet is referenced)
dotnet test BuckarooSdk.UnitTests/BuckarooSdk.UnitTests.csproj --collect:"XPlat Code Coverage"
```

The project targets `net8.0` (LTS). `RollForward=Major` lets the suite also execute on newer
runtimes (e.g. .NET 10) when the .NET 8 runtime is not installed.

## How it stays network-free

- The deterministic pieces (signature, request building, serialization) are exercised directly.
- Push handling is tested by **signing a fixture with the SDK's own `SignatureCalculationService`**
  exactly as Buckaroo's servers would, then feeding the signed body to the `PushHandler`.
- Recorded JSON fixtures live under `TestData/` and are copied next to the test assembly.
- The SDK exposes its internals to this assembly via `[InternalsVisibleTo("BuckarooSdk.UnitTests")]`
  (declared in `BuckarooSdk.csproj`), so the assembled request object graph and internal helpers
  can be asserted on precisely.

## Known limitation / possible follow-up

The `Connector` constructs its `HttpClient` (and inner `HttpClientHandler`) internally, so there is
no seam to inject a mocked transport. That means the final `Execute()`/HTTP round-trip is **not**
unit-tested here (it would be an integration test). Stripe and Adyen both test their full client
stack by injecting a mock `HttpMessageHandler`. Adding a small, additive injection point to
`Connector` would allow the same here — driving request serialization, the HMAC `Authorization`
header, and response deserialization end-to-end with a fake handler and still no network. This was
intentionally left out to avoid changing the production send path.

## Latent SDK issue surfaced while writing these tests

`ServiceHelper.StringifyParameter` special-cases only `decimal` with `InvariantCulture`; every other
type (notably `DateTime`) falls through to `value.ToString()`, which uses the current thread culture.
Date-bearing request parameters (birth dates, invoice/due dates, validity windows) therefore serialize
differently depending on the server's locale — a real wire-format hazard. No test was added asserting a
fixed format because doing so would either encode buggy behaviour or fail the build; fixing it in the
SDK (`ToString(CultureInfo.InvariantCulture)`) and then pinning it is the recommended follow-up.
