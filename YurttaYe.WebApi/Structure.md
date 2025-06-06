YurttaYe/
├── src/
│   ├── YurttaYe.Application/
│   │   ├── Abstractions/
│   │   │   ├── Repositories/
│   │   │   │   ├── IMenuItemRepository.cs
│   │   │   │   ├── IUserRepository.cs
│   │   │   │   └── IUnitOfWork.cs
│   │   │   └── Services/
│   │   │       ├── IMenuItemService.cs
│   │   │       ├── IAuthService.cs
│   │   │       └── IFileProcessingService.cs
│   │   ├── DTOs/
│   │   │   ├── MenuItemDto.cs
│   │   │   ├── MenuItemCreateDto.cs
│   │   │   └── UserDto.cs
│   │   ├── Features/
│   │   │   ├── Commands/
│   │   │   │   ├── CreateMenuItemCommand.cs
│   │   │   │   ├── UpdateMenuItemCommand.cs
│   │   │   │   └── ProcessMenuFileCommand.cs
│   │   │   ├── Queries/
│   │   │   │   ├── GetAllMenuItemsQuery.cs
│   │   │   │   └── GetMenuItemByIdQuery.cs
│   │   │   └── Handlers/
│   │   │       ├── CreateMenuItemHandler.cs
│   │   │       ├── UpdateMenuItemHandler.cs
│   │   │       ├── GetAllMenuItemsHandler.cs
│   │   │       ├── GetMenuItemByIdHandler.cs
│   │   │       └── ProcessMenuFileHandler.cs
│   │   ├── Common/
│   │   │   ├── Result.cs
│   │   │   └── MappingProfile.cs
│   │   └── Services/
│   │       └── MenuItemService.cs
│   ├── YurttaYe.Domain/
│   │   ├── Entities/
│   │   │   ├── MenuItem.cs
│   │   │   ├── Menu.cs
│   │   │   └── User.cs
│   │   └── ValueObjects/
│   │       ├── Price.cs
│   │       ├── Gramaj.cs
│   │       ├── Calorie.cs
│   │       └── CalorieRange.cs
│   ├── YurttaYe.Infrastructure/
│   │   ├── Persistence/
│   │   │   ├── Configurations/
│   │   │   │   ├── MenuItemConfiguration.cs
│   │   │   │   ├── MenuConfiguration.cs
│   │   │   │   └── UserConfiguration.cs
│   │   │   ├── Migrations/
│   │   │   │   └── InitialCreate.cs
│   │   │   ├── Repositories/
│   │   │   │   ├── MenuItemRepository.cs
│   │   │   │   ├── UserRepository.cs
│   │   │   │   └── UnitOfWork.cs
│   │   │   └── AppDbContext.cs
│   │   └── Services/
│   │       ├── AuthService.cs
│   │       └── FileProcessingService.cs
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
│   │   │   │   │   ├── Edit.cshtml
│   │   │   │   │   └── Upload.cshtml
│   │   │   ├── Menu.cshtml
│   │   │   └── Shared/
│   │   │       └── _Layout.cshtml
│   │   ├── wwwroot/
│   │   │   ├── css/
│   │   │   │   └── site.css
│   │   │   ├── js/
│   │   │   │   └── site.js
│   │   │   └── lib/
│   │   │       └── tailwind/
│   │   │           └── tailwind.min.css
│   │   ├── Program.cs
│   │   ├── appsettings.json
│   │   └── YurttaYe.WebApi.csproj
├── tests/
│   ├── YurttaYe.Tests.Unit/
│   │   ├── Application/
│   │   │   ├── MenuItemServiceTests.cs
│   │   │   └── FileProcessingServiceTests.cs
│   │   ├── Domain/
│   │   │   └── MenuItemTests.cs
│   │   └── Infrastructure/
│   │       └── MenuItemRepositoryTests.cs
│   └── YurttaYe.Tests.Integration/
│       ├── MenuControllerTests.cs
│       └── FileUploadTests.cs
├── storage/
│   └── uploaded_files/
│       └── temp/
├── docker/
│   ├── Dockerfile
│   └── docker-compose.yml
├── .gitignore
├── README.md
├── YurttaYe.sln
└── LICENSE