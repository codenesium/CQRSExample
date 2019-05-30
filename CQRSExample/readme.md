##### Simple CQRS example with .NET Core and MediatR

This application is a simple example of how to use MediatR with .NET Core to build a CQRS solution.

There is a dummy DataStore that is just a class with a list that is used to keep this example as simple as possible.

The idea is controllers call services which dispatch requests and actions which are handled by handlers.

MediatR has the concept of fire and forget requests and requests that return data. This maps nicely
to the CQRS commands and queries. I've added empty interfaces (ICommand and IQuery) to help differentiate 
command and queries because MediatR doesn't care.

This example has a ValuesModel which is missing the id property to demonstrate how the read side can differ from the write side.

This example is contrived. Obviously you wouldn't use CQRS to build a CRUD app. Hopefully it makes sense. If not please submit a PR.

To view the list of values call

https://localhost:44391/api/values

To insert a value 

https://localhost:44391/api/values/create/4/D
