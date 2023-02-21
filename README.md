# WebAPI Notes

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

## Adding Identity (on the client app)
1. Microsoft.VisualStudio.Web.CodeGeneration.Design

## Add Scaffolding (on the client app)
1. Add
2. New Scaffolded Item...
3. Identity
4. Identity
5. Add
6. Override all files
7. Select an existing layout page
8. ...
9. Pages
10. Shared
11. _Layout.cshtml
12. OK
13. Data context class +
14. New data context type: HPlusSport.Web.Data.HPlusSportWebContext
15. Add
16. User class +
17. New user class type: HPlusSportWebUser
18. Add
19. Add

## Verify Identity Components
1. Areas\Identify\Data folder, and Pages\Account\Manage folder

## Update the Main Layout Page
1. Pages\Shared\_Layout
```
<partial name="_LoginPartial" />
```

## Add Migration
1. Package Manager Console
2. Change the Default project to: HPlusSport.Web
```
Add-Migration Initial
Update-Database
```

## Validate Identity Added Successfully
1. Start the app
2. Verify Register and Login link appear in the top-right corner
3. Register
4. Complete the registration with a fictitious account
5. Normally this would be emailed: Click here to confirm your account
6. Login
7. Enter the fictitious credentials entered above
8. Log in




