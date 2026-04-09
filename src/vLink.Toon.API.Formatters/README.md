# vLink.Toon.API.Formatters

`vLink.Toon.API.Formatters` adds ASP.NET Core MVC formatter support for TOON.

## Installation

```bash
dotnet add package vLink.Toon.API.Formatters
```

## Features

- Registers TOON MVC formatters with `AddToon(...)`
- Supports `text/toon` and `application/toon`
- Reuses `vLink.Toon.Format` for TOON encoding, decoding, and options
- Allows per-request response encode overrides through `X-Toon-Option-*` headers

## Basic Usage

```csharp
using vLink.Toon.API.Formatters;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddControllers()
    .AddToon(useAsDefaultFormatter: false);
```

## Per-Request Response Encode Overrides

Callers can override response encoding behavior for a single request by sending request headers in the format `X-Toon-Option-<OptionName>: <value>`.

Example:

```http
GET /products
Accept: application/toon
X-Toon-Option-IgnoreNullOrEmpty: true
```

This overlay is applied only for the current response and does not change the application's registered `ToonServiceOptions`.

See [Documentation/PerRequestEncodeOptions.md](/home/valdi/Projects/vLink.Toon.API.Formatters/Documentation/PerRequestEncodeOptions.md) for details.

## Package Notes

`vLink.Toon.API.Formatters` depends on `vLink.Toon.Format` for the runtime TOON implementation.
