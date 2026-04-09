# Build Configuration

This repository supports two ways of resolving `vLink.Toon.Format`:

- `Debug` builds can use a local `vLink.Toon.Format` project reference
- `Release` builds always use the published NuGet package

This lets each developer point to their own local checkout without hardcoding machine-specific paths into the repo.

## Default Behavior

By default, `vLink.Toon.API.Formatters` resolves `vLink.Toon.Format` from NuGet:

- package: `vLink.Toon.Format`
- version: `0.2.0`

This is always the behavior for `Release` builds.

## Debug Local Override

For `Debug` builds, the project can switch to a local `vLink.Toon.Format` project reference if either of these is provided:

- MSBuild property: `ToonFormatProjectPath`
- environment variable: `VLINK_TOON_FORMAT_CSPROJ`

The value must point to the local `vLink.Toon.Format.csproj` file.

Example:

```bash
export VLINK_TOON_FORMAT_CSPROJ=/home/valdi/Projects/vLink.Toon.Format/src/vLink.Toon.Format/vLink.Toon.Format.csproj
dotnet build -c Debug
```

Or per command:

```bash
dotnet build -c Debug -p:ToonFormatProjectPath=/home/valdi/Projects/vLink.Toon.Format/src/vLink.Toon.Format/vLink.Toon.Format.csproj
```

## Resolution Rules

The build resolves `vLink.Toon.Format` in this order:

1. If `ToonFormatProjectPath` is set, use that value
2. Otherwise, if `VLINK_TOON_FORMAT_CSPROJ` is set, use that value
3. If the path exists and the build configuration is `Debug`, use a `ProjectReference`
4. Otherwise, use the NuGet package reference

## Practical Guidance

- Use the environment variable if you regularly work on both repos locally
- Use the MSBuild property for one-off builds
- Do not rely on the local override for `Release` packaging or CI
- Keep `Release` builds on NuGet so package outputs stay reproducible
