# Tone
This project is a reference application that demonstrates the implementation of assignments from the Aspire TONE program.

## How it works
There are two main projects with several supporting projects
- **Tone.LibraryManagment.Web**:
  This application is a .NET Core 2.2 MVC application that implements EF Core and Azure Storage Service for the BookController
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
  
