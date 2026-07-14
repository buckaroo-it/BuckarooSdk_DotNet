# Releasing a new version

This package (`BuckarooSdk` on [nuget.org](https://www.nuget.org/packages/BuckarooSdk/)) is
published automatically by GitHub Actions using **NuGet Trusted Publishing** (OIDC). There is
**no API key** to manage — publishing is triggered by creating a **GitHub Release**, and the
workflow exchanges a short-lived OIDC token for a temporary nuget.org key at publish time.

The workflow is [`.github/workflows/publish.yml`](.github/workflows/publish.yml).

## TL;DR

1. Make sure `master` contains everything you want to ship (and builds).
2. Create a GitHub Release with a tag like **`v1.5.5`**, targeting `master`.
3. Approve the deployment when prompted (the `release` environment requires a reviewer).
4. Confirm the new version appears on nuget.org a few minutes later.

That's it — you never touch a NuGet API key.

## How versioning works

- The package version comes **entirely from the release tag** — the `.csproj` intentionally has
  no `<Version>`.
- Use the tag format **`vMAJOR.MINOR.PATCH`** (the leading `v` is stripped, so `v1.5.5` publishes
  `1.5.5`). Follow [SemVer](https://semver.org/).
- Pre-releases are supported: `v1.6.0-beta.1` → `1.6.0-beta.1` (published as a pre-release on
  nuget.org).
- The workflow **validates the tag** and refuses to publish if it isn't a well-formed version, so
  a stray tag like `nightly` won't accidentally push a package.
- Versions are immutable on nuget.org — you **cannot overwrite** an already-published version.
  If something is wrong, bump the version and release again.

## Step-by-step

1. **Prepare `master`.** Merge the changes you want to release. Build/test locally first —
   see [Local build & test](#local-build--test); the publish workflow does **not** run the tests.

2. **Pick the next version.** Check the [current versions on nuget.org](https://www.nuget.org/packages/BuckarooSdk/#versions-body-tab)
   and increment per SemVer.

3. **Create the GitHub Release.**
   - GitHub → **Releases** → **Draft a new release**.
   - **Choose a tag** → type the new tag, e.g. `v1.5.5` → *Create new tag on publish*.
   - **Target**: `master`.
   - Title + release notes describing what changed.
   - Click **Publish release**.

   Or from the CLI:
   ```bash
   gh release create v1.5.5 --target master --title "v1.5.5" --notes "…what changed…"
   ```

4. **Approve the deployment.** Publishing the release starts the *Publish NuGet package* workflow.
   Because it runs in the protected `release` environment, a required reviewer must approve it
   (Actions → the running workflow → **Review deployments** → Approve). This is the intentional
   human gate before anything hits nuget.org.

5. **Verify.** Watch the workflow finish green, then check the version on
   [nuget.org](https://www.nuget.org/packages/BuckarooSdk/). Indexing/validation usually takes a
   few minutes.

## What the workflow does

On a published release it:

1. Checks out the repo and installs the .NET SDK.
2. Derives and validates the version from the release tag.
3. Runs `dotnet pack` on **`BuckarooSdk/BuckarooSdk.csproj` only** (see note below).
4. Logs in to nuget.org via OIDC (`NuGet/login`), receiving a temporary API key valid for 1 hour.
5. Pushes the `.nupkg` with `--skip-duplicate`, so re-running a release that already published is
   harmless (it won't error, but it also won't overwrite).

> **Why only the library project?** `BuckarooSdk.Tests` is a legacy .NET Framework 4.7.1
> (`packages.config`) project that can't restore or run on the Linux build agent, so the workflow
> packs the netstandard2.0 library directly instead of the whole solution.

## Local build & test

```bash
# Build/pack the library (matches what CI publishes)
dotnet pack BuckarooSdk/BuckarooSdk.csproj -c Release -p:Version=1.5.5-local -o ./artifacts

# The test project is .NET Framework 4.7.1 — build/run it on Windows with Visual Studio
# or msbuild + nuget restore (packages.config). It does not run under `dotnet test` on Linux.
```

## Troubleshooting

| Symptom | Cause / fix |
|---|---|
| Workflow fails at *Derive version* with "not a valid version" | The tag isn't `vX.Y.Z` (or a valid SemVer). Delete the tag/release and recreate with a proper version. |
| Workflow doesn't start at all | It only triggers on **release: published** — a plain `git tag`/push won't do it. Create an actual GitHub Release. Also confirm the tag matches the environment's allowed tag pattern (`v*`). |
| NuGet login fails with "No matching trust policy owned by user" (HTTP 401) | `NUGET_USER` is wrong. It must be the username of the **user account that created** the Trusted Publishing policy — *not* the `BuckarooBV` package owner, and *not* an email. See the `NUGET_USER` note under [One-time setup](#one-time-setup-reference). |
| Push fails with 403 / policy not found | The nuget.org Trusted Publishing policy is inactive. Usually the policy-creator service account was removed from the `BuckarooBV` org, or the policy's Repository/Workflow/Environment values drifted from this workflow. Re-check the policy. |
| "already exists" but exits green | Expected — `--skip-duplicate`. That version is already published; bump and release again. |
| Temporary key expired | Only happens if the job stalls > 1 hour between login and push. Just re-run the job. |

## One-time setup (reference)

This is already configured; documented here so it can be recreated.

- **nuget.org Trusted Publishing policy** (nuget.org → your account → *Trusted Publishing*):
  - Package Owner: `BuckarooBV`
  - Repository Owner: `buckaroo-it`
  - Repository: `BuckarooSdk_DotNet`
  - Workflow File: `publish.yml`
  - Environment: `release`
  - Created by (and owned by) a **dedicated service account** that is a permanent member of the
    `BuckarooBV` org. Trusted Publishing policies belong to the individual **user** who creates
    them — even when they publish packages on behalf of the org — so if that user leaves the org
    the policy goes inactive. This account's username is what goes in the `NUGET_USER` secret below.
- **GitHub environment `release`** (repo → Settings → Environments): required reviewer(s) and
  deployment restricted to **tags** matching `v*` (add it as a *tag* rule, not a branch rule —
  a branch rule never matches a release tag).
- **Environment secret `NUGET_USER`**: the nuget.org username (profile name, *not* email) of the
  **account that created the Trusted Publishing policy** — the *policy creator*, **not** the
  `BuckarooBV` package-owner org. The OIDC token exchange returns HTTP 401 ("No matching trust
  policy owned by user") if this is set to anything other than that user's exact username.
