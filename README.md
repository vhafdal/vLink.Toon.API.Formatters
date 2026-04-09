# vLink.Toon.API.Formatters

`vLink.Toon.API.Formatters` adds ASP.NET Core MVC input and output formatters for TOON payloads.

It is the transport-layer companion to `vLink.Toon.Format`. Use it when an ASP.NET Core API should accept and return `text/toon` or `application/toon` payloads through the normal MVC formatter pipeline.

## Installation

```bash
dotnet add package vLink.Toon.API.Formatters
```

## Features

- Adds MVC `TextInputFormatter` and `TextOutputFormatter` implementations for TOON
- Registers TOON formatters through `AddToon(...)` extension methods
- Uses `vLink.Toon.Format` for encoding, decoding, media types, and service options
- Supports `text/toon` and `application/toon`

## Basic Usage

```csharp
using vLink.Toon.API.Formatters;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddControllers()
    .AddToon(useAsDefaultFormatter: false);
```

## Package Notes

`vLink.Toon.API.Formatters` depends on `vLink.Toon.Format`.
Use `vLink.Toon.Format` directly for non-HTTP encoding and decoding workflows.
