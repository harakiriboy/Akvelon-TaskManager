# Akvelon-TaskManager
This is the API for managing Projects and Tasks using differnt restAPI commands

## Installation and usage
Firslty you need to clone this repository to your environment. And then you have one of two options to run the code.

### On local machine
For this you need sdk and runtime for dotnet6 to run it on your machine.
Run this command on terminal inside project's directory:
```
dotnet run
```
<br>
You can use it with swagger


### On docker container
For this you need Docker installed on your machine.
To run docker container run this command inside project's directory:
```
docker-compose up
```
<br>
### On something else
You can use app by going to the link: `http://localhost/api/Projects`
<br>
To use sorting or filtering type: 
`http://localhost/api/Projects/getSortedProjects?orderBy=priority` 
or `http://localhost/api/Projects/getProjectsByName?projectName=someName`
<br>
And the same procedures for Tasks endpoint<br><br>
You can sort Projects by `priority`, in the reverse order `priorityDesc`, `startDate`, `completionDate`, by `status/statusDesc`.<br>
For the Tasks, you can use `status/statusDesc` and `priority/priorityDesc`.

## Project structure
### Presentation layer
The Presentation Layer consists of two Controllers. For Projects and Tasks. Inside they are uses injected Project and Task Repository Services. 
### Business logic layer
The Repository classes are core of my Business Logic Layer. They are injecting Context form DatabaseContext Service to get access to request data from Database. In the Logic Layer there are not another Service classes because this is simple CRUD application and it doesn't require any additional Services.
### Data access layer
The DAL consists of Models(schemas for Entities), Database Context class to managing Entities and it has `'Initializer'` method for seeding the Database.<br>

## 'Program.cs' class Pipeline
1) The file starts from builder variable declaration to build application
2) Then I created `'connectionString'` var to store in there my `'DbConextConnectionString'` to link with SqlServer
3) After adding Controller Service with options to use Converters(EnumToString and DateTimeToString)
4) Adding Swagger services
5) Adding CORS Service to establish connection with another Servers and data sharing
6) Added AutoMapper Service to allow Mappings between Entities and DTOs
7) Added Scoped Project and Task Repository Services
8) Declaring 'app' var from built app
9) There are some default Startup processes. Mine are UseCors(To use CORS Service we defined above) and MigrateDatabase(To performing Data Migrations to Db)<br>

## Stack 
1) C# .Net 6
2) EFCore ORM 
3) SqlServer
4) Docker

## Additional Screenshots
![pr1](https://user-images.githubusercontent.com/74262437/207388274-22c609aa-5804-4425-b343-91933944ea25.png)
![ts1](https://user-images.githubusercontent.com/74262437/207388362-65d5ac34-ef41-4797-8ceb-e504a9bf683c.png)
![prorder](https://user-images.githubusercontent.com/74262437/207388447-20e718f2-6755-40c1-8794-432b58675ffc.png)
![prname](https://user-images.githubusercontent.com/74262437/207388547-4a3ec531-0b17-44f7-a669-4b84ced313a5.png)

