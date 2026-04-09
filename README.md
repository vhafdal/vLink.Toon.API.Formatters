# vLink.Toon.API.Formatters

Repository for the `vLink.Toon.API.Formatters` package, an ASP.NET Core MVC transport-layer companion to `vLink.Toon.Format`.

## Repository Layout

- `src/vLink.Toon.API.Formatters/` contains the package source and the NuGet package README
- `Documentation/` contains repository-level implementation and behavior notes

## Package

The package adds ASP.NET Core MVC input and output formatters for TOON payloads so an API can accept and return `text/toon` or `application/toon` through the normal formatter pipeline.

Package-facing usage and installation guidance lives in [src/vLink.Toon.API.Formatters/README.md](/home/valdi/Projects/vLink.Toon.API.Formatters/src/vLink.Toon.API.Formatters/README.md).

## Documentation

- [BuildConfiguration.md](/home/valdi/Projects/vLink.Toon.API.Formatters/Documentation/BuildConfiguration.md)
- [PerRequestEncodeOptions.md](/home/valdi/Projects/vLink.Toon.API.Formatters/Documentation/PerRequestEncodeOptions.md)
