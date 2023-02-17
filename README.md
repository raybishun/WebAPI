# WebAPI

## Model Binding
* [FromBody] - Data from the body of th eHTTP request, typically POST/PUT.
* [FromRoute] - Data from a route template.
* [FromQuery] - Data form URL, (a query string.)

## Versioning
* HTTP Header - API-Version:1.0 (information may also be part of the Accept HTTP header.)
* URL - /v1.0/products (separates API versions, but breaks the one URI principle.)
* Querystring - /proudcts?api-version-1.0 (might mix with other URL parameters.)

## Microsoft Package
* Microsoft.AspNetCore.Mvc.Versioning
* A service API versioning library for Microsoft ASP.NET Core.
```
dotnet add package Microsoft.AspNetCore.Mvc.Versioning
```