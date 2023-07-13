## Setup instructions
- [Download .NET](https://dotnet.microsoft.com/download/dotnet)
- [dotnet-install scripts](https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-install-script)
- [Installation docs](https://learn.microsoft.com/en-us/dotnet/core/install/)

## Overview
This project created to store events of changes state in UI,
as from this version it's depended on `audit table` in DB.

> Architecture approach was selected `CORQS` event based,
> with `MediatR` using `Entity Framework` to handle DB inserts.

## Environment variables
##### Overview:
When need to use locally you can set environment variables inside your local `env` or inside docker.
> Docker:
```yaml
environment:  
- POSTGRES_DB=${Database Name}
- POSTGRES_USER=${Username}
- POSTGRES_PASSWORD=${Password}
- POSTGRES_HOST=${Database host}
- POSTGRES_PORT=${Database port}
```

> Environment:

```bash
export POSTGRES_DB=${Database Name}
```
_______
###  Tech Stack
- .NET 7.0
- C# 10
- NuGet
- MediatR
- Entity Framework 7.0

