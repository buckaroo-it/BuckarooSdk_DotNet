# BuckarooSdk_DotNet

.NET SDK for the Buckaroo payment API. The library (`BuckarooSdk`) targets `netstandard2.0`;
its only runtime dependency is Newtonsoft.Json.

## Build & test

- Build the library: `dotnet build BuckarooSdk/BuckarooSdk.csproj`
- Run unit tests: `dotnet test BuckarooSdk.UnitTests/BuckarooSdk.UnitTests.csproj`
- `BuckarooSdk.UnitTests` (xUnit, `net8.0`) is the network-free unit suite — add new tests here.
  Internals are exposed to it via `[InternalsVisibleTo]` in `BuckarooSdk.csproj`.
- `BuckarooSdk.Tests` is a legacy .NET Framework 4.7.1 integration harness that calls the live
  gateway and needs real credentials. Do not run it in CI or use it as a template.

## Conventions

- Prefer self-documenting code over comments; match the style of surrounding code.
- Unit tests must never make network calls — cover the deterministic surface (signatures,
  serialization, push handling, request building) and mock/sign fixtures instead.
- Commits: atomic, self-explanatory, no Claude-branded trailers.

## CI

- `.github/workflows/ci.yml` runs the unit tests on every PR (Linux + Windows).
- `.github/workflows/publish.yml` publishes to NuGet on a published GitHub Release (OIDC); never on PRs.
