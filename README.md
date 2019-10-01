# Tone
This project is a reference application that demonstrates the implementation of assignments from the Aspire TONE program.

## How it works
There are two main projects with several supporting projects
- **Tone.LibraryManagment.Web**:
  This application is a .NET Core 2.2 MVC application that consumes EF Core and Azure Storage Service for the BookController
- **Tone.LibraryManagement.WebApi**:
  This application is a .NET Core 2.2 WebApi application that consumes EF Core and the Repository Pattern for CRUD operations
- **Tone.LibraryManagement.Core**:
  This is a .NET Core 2.2 Class Library project that houses the base classes and interfaces for both the Data and Services projects
- **Tone.LibraryManagement.Data**:
  This is a .NET Core 2.2 Class Library project that implements EF Core and the Repository Pattern form the Data project
- **Tone.LibraryManagement.Azure.Services**:
  This is a .NET Core 2.2 Class Library project that consumes the Microsoft.WindowsAzure.Storage nuget package for implementing an IStorageService 
- **Tone.LibraryManagement.AWS.Services**:
  This is a .NET Core 2.2 Class Library project that consumes the AWS .NET SDK nuget package for implementing an IStorageService
  
## How it runs
This solution requires the creation of a LocalDb database using [EF Core code first](https://entityframeworkcore.com/approach-code-first) and the use of the [Azure Storage Emulator](https://docs.microsoft.com/en-us/azure/storage/common/storage-use-emulator) for the Storage Service. 

- To run the MVC application, make sure you set the MVC project as the Startup project by right clicking the project in Solution Explorer and clicking 'Set as Startup Project'.  If you are looking to run the WebApi project follow the same instructions for the WebApi project
- Before running either the Web(MVC) or WebApi project, you'll need to create the database for the first time.  Open the Package Manager Console in Visual Studio and run the 'Update-Database' command at the prompt.  this should read the configuration for the desired project, find the DbContext referenced in the Startup.cs file and then create an empty database using the name in the connection string.
- If running the Web(MVC) application, you'll need to start the Azure Storage Emulator from the start command by searching for 'Storage Emulator'.  you should see a match in the search results that you can click, this will automatically start the emulator.
- Finally, Hit F5 on your keyboard to start the application either using IISExpress or Dotnet.exe.
- Browser should open and your application will load.  If you don't have any books in the database, it is recommended you start the MVC app first and add books using the /books/add route to add a new book.
