YurttaYe/
├── src/
│   ├── YurttaYe.Application/
│   │   ├── Abstractions/
│   │   │   ├── Repositories/
│   │   │   │   ├── IMenuItemRepository.cs
│   │   │   │   └── IUnitOfWork.cs
│   │   │   └── Services/
│   │   │       ├── IMenuItemService.cs
│   │   │       └── IAuthService.cs
│   │   ├── DTOs/
│   │   │   ├── MenuItemDto.cs
│   │   │   └── MenuItemCreateDto.cs
│   │   ├── Features/
│   │   │   ├── Commands/
│   │   │   │   ├── CreateMenuItemCommand.cs
│   │   │   │   └── UpdateMenuItemCommand.cs
│   │   │   ├── Queries/
│   │   │   │   ├── GetAllMenuItemsQuery.cs
│   │   │   │   └── GetMenuItemByIdQuery.cs
│   │   │   └── Handlers/
│   │   │       ├── CreateMenuItemHandler.cs
│   │   │       ├── UpdateMenuItemHandler.cs
│   │   │       ├── GetAllMenuItemsHandler.cs
│   │   │       └── GetMenuItemByIdHandler.cs
│   │   └── Common/
│   │       └── Result.cs
│   ├── YurttaYe.Domain/
│   │   ├── Entities/
│   │   │   └── MenuItem.cs
│   │   └── ValueObjects/
│   │       └── Price.cs
│   ├── YurttaYe.Infrastructure/
│   │   ├── Persistence/
│   │   │   ├── Configurations/
│   │   │   │   └── MenuItemConfiguration.cs
│   │   │   ├── Migrations/
│   │   │   │   └── InitialCreate.cs
│   │   │   ├── Repositories/
│   │   │   │   └── MenuItemRepository.cs
│   │   │   └── AppDbContext.cs
│   │   └── Services/
│   │       └── AuthService.cs
│   ├── YurttaYe.WebApi/
│   │   ├── Controllers/
│   │   │   ├── MenuController.cs
│   │   │   └── AuthController.cs
│   │   ├── Middleware/
│   │   │   └── ErrorHandlingMiddleware.cs
│   │   ├── Pages/
│   │   │   ├── Admin/
│   │   │   │   ├── Menu/
│   │   │   │   │   ├── Index.cshtml
│   │   │   │   │   ├── Create.cshtml
│   │   │   │   │   └── Edit.cshtml
│   │   │   ├── Menu.cshtml
│   │   │   └── Menu.cshtml.cs
│   │   ├── Program.cs
│   │   ├── Startup.cs (opsiyonel, .NET 6 öncesi)
│   │   └── appsettings.json
├── tests/
│   ├── YurttaYe.Tests.Unit/
│   │   ├── Application/
│   │   │   └── MenuItemServiceTests.cs
│   │   ├── Domain/
│   │   │   └── MenuItemTests.cs
│   │   └── Infrastructure/
│   │       └── MenuItemRepositoryTests.cs
│   └── YurttaYe.Tests.Integration/
│       └── MenuControllerTests.cs
├── wwwroot/
│   ├── css/
│   │   └── site.css
│   ├── js/
│   │   └── site.js
│   └── lib/
│       └── tailwind/
│           └── tailwind.min.css
├── docker/
│   ├── Dockerfile
│   └── docker-compose.yml
├── .gitignore
├── README.md
├── YurttaYe.sln
└── LICENSE