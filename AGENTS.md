# Repository Guidelines

## Project Structure & Module Organization
This repository contains a single .NET class library for ASP.NET Core TOON formatters. The solution file is [`vLink.Toon.API.Formatters.slnx`](/home/valdi/Projects/vLink.Toon.API.Formatters/vLink.Toon.API.Formatters.slnx). Production code lives under [`src/vLink.Toon.API.Formatters`](/home/valdi/Projects/vLink.Toon.API.Formatters/src/vLink.Toon.API.Formatters): `ToonInputFormatter.cs`, `ToonOutputFormatter.cs`, and `ToonServiceCollectionExtensions.cs`. Root [`README.md`](/home/valdi/Projects/vLink.Toon.API.Formatters/README.md) documents package usage; the project-level `README.md` is packed with the NuGet package. No test project is checked in yet; add future tests under `tests/` to keep source and verification separate.

## Build, Test, and Development Commands
Use the .NET CLI from the repository root:

- `dotnet restore` restores package dependencies.
- `dotnet build vLink.Toon.API.Formatters.slnx -c Release` builds both target frameworks: `net8.0` and `net10.0`.
- `dotnet pack src/vLink.Toon.API.Formatters/vLink.Toon.API.Formatters.csproj -c Release` produces the NuGet package.
- `dotnet test` should be used once a `tests/` project exists; keep test projects in the solution.

## Coding Style & Naming Conventions
Follow existing C# conventions in `src/`: 4-space indentation, file-scoped namespaces, nullable reference types enabled, and concise XML docs on public APIs. Use `PascalCase` for public types and members, `_camelCase` only for local private fields if introduced, and keep extension methods grouped in `*Extensions.cs` files. Match existing formatter naming such as `ToonInputFormatter` and `ToonOutputFormatter`. Prefer `var` when the right-hand side is obvious.

## Testing Guidelines
Add automated tests for formatter registration, supported media types, and request/response behavior. Name test files after the subject under test, for example `ToonOutputFormatterTests.cs`. Prefer framework-specific behavior tests over broad integration smoke tests. Run `dotnet test` before opening a pull request.

## Commit & Pull Request Guidelines
Current history is minimal (`Initial commit`, `Initial after Migration`), so adopt short imperative subjects and keep them specific, for example `Add MVC formatter registration tests`. Pull requests should include a brief summary, linked issue if applicable, test evidence (`dotnet build`, `dotnet test`), and note any package or API surface changes.

## Documentation Process
Project documentation belongs in the `TA` Confluence space: <https://vlink-team.atlassian.net/wiki/spaces/TA/>. When behavior, configuration, package usage, or release expectations change, update the relevant Confluence page as part of the same change set. Keep the repository `README.md` focused on package-facing setup and examples, and use Confluence for broader team process, architecture, and operational notes. The canonical source repository is <https://github.com/vhafdal/vLink.Toon.API.Formatters>.

## Security & Configuration Notes
The project signs assemblies with [`src/vLink.Toon.API.Formatters/vLink.snk`](/home/valdi/Projects/vLink.Toon.API.Formatters/src/vLink.Toon.API.Formatters/vLink.snk). Do not rotate or replace signing material casually. Package metadata and framework targets are defined in the project file; update them intentionally when changing release scope.
