dotnet ef migrations add InitialCreate \
  --project YurttaYe.Infrastructure \
  --startup-project YurttaYe.WebApi \
  --context AppDbContext

dotnet ef database update \
  --project YurttaYe.Infrastructure \
  --startup-project YurttaYe.WebApi \
  --context AppDbContext
