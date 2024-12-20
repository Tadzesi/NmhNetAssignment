## EF migration helper
**Initial creation**
-  dotnet ef migrations add InitialCreate -p NmhNetAssignment.Domain/NmhNetAssignment.Domain.csproj -s NmhNetAssignment.Api/NmhNetAssignment.Api.csproj

**Update database**
- dotnet ef database update -p NmhNetAssignment.Domain/NmhNetAssignment.Domain.csproj -s NmhNetAssignment.Api/NmhNetAssignment.Api.csproj

**Create new migration**
- dotnet ef migrations add '<MigrationName>' -p NmhNetAssignment.Domain/NmhNetAssignment.Domain.csproj -s NmhNetAssignment.Api/NmhNetAssignment.Api.csproj