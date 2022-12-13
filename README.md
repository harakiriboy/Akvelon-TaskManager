# Akvelon-TaskManager
This is the API for managing Projects and Tasks using differnt restAPI commands

## Installation and usage
Firslty you need to clone this repository to your environment. And then you have one of two options to run the code.

### On local machine
For this you need sdk and runtime for dotnet6 to run it on your machine.
Run this command on terminal inside project's directory:
```dotnet run```<br>
You can use it with swagger


### On docker container
For this you need Docker installed on your machine.
To run docker container run this command inside project's directory:
```docker-compose up```<br>
You can use app by going to the link: `http://localhost/api/Projects`<br>
To use sorting or filtering type: `http://localhost/api/Projects/getSortedProjects?orderBy=priority` or `http://localhost/api/Projects/getProjectsByName?projectName=someName`<br>
And the same procedures for Tasks endpoint<br><br>
You can sort Projects by priority, in the reverse order "priorityDesc", startDate, completionDate, by status/statusDesc.<br>
For the Tasks, you can use status/statusDesc and priority/priorityDesc.

## Program class pipeline description

