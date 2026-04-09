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

## Basic Usage

```csharp
using vLink.Toon.API.Formatters;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddControllers()
    .AddToon(useAsDefaultFormatter: false);
```

## Package Notes

`vLink.Toon.API.Formatters` depends on `vLink.Toon.Format` for the runtime TOON implementation.
