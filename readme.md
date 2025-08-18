##To create required project files
First I created a new solution with dotnet new sln -n {solutionName}
Then all classlibrary(Core, Infrastructure, Application) are created using dotnet new classlib -n {NewClassLibName}
Finally  Web api is created with dotnet new webapi -n {newWebApi}

##To make the required files relatible such thant when the .sln is opened it includes all(core, infrastructure, Application and API)
dotnet sln add MyStore.Core/MyStore.Core.csproj
dotnet sln add MyStore.Application/MyStore.Application.csproj
dotnet sln add MyStore.Infrastructure/MyStore.Infrastructure.csproj
dotnet sln add MyStore.Api/MyStore.Api.csproj


##How each layer references each other:
API --> Application --> Infrastructure ---> Core

##Core is the foundational layer, so no need to add it first; it’s the starting point in the hierarchy, and other layers will reference it. Application depends on Core. So, after Core is set up, we add the reference for Application to Core.
dotnet add MyStore.Application reference MyStore.Core

##Infrastructure depends on both Core (for domain models) and Application (for the business logic). So, add references to Core and Application next.
dotnet add MyStore.Infrastructure reference MyStore.Core
dotnet add MyStore.Infrastructure reference MyStore.Application

##API layer depends on both Application and Infrastructure, so add the references last.
dotnet add MyStore.Api reference MyStore.Application
dotnet add MyStore.Api reference MyStore.Infrastructure

##Now skeleton folders are added

##SwashBuckle package is added for swagger
##For EF core these packages are added in MyStore.Infrastructure and the MyStore.Api will also be able to use it because of previous reference:
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools

##ApplicationDbContext is created on Infrastructure-->Data
and database connection string is also included in Api-->Program.cs

##Now lets create some entities in Core: Product, Order, User, Role, cart and mention it in Infrastracture-->DbContext

##NOTE: don't forget to install this dotnet add package Microsoft.EntityFrameworkCore.Design
ON MyStore.Api. This has design-time services EF Core needs to generate and apply migrations, build models, and read configuration from the app.

##Now this is run: dotnet ef migrations add InitialCreate -s ./MyStore.Api -p MyStore.Infrastructure
what does actually does is takes the dbcontext from -p MyStore.Infrastructure and then starts building the Api from MyStore.Api.

##Now run this: dotnet ef database update -s ./MyStore.Api -p MyStore.Infrastructure 
This will create a schema and stores it in MyStore.Infrastructure-->migrations in a timestamp and context models. It will also create tables and data on the server on the basis of the Entities data.