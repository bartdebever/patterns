# Bartdebever.Patterns

![Nuget](https://img.shields.io/nuget/v/Bartdebever.Patterns.svg)
![Nuget](https://img.shields.io/nuget/dt/Bartdebever.Patterns.svg)

The popular Repository and Service pattern written for Entity Framework 6 and Core.

## Getting Started

There are 3 main classes (with interfaces) to use

### IEntity and BaseEntity

These are the main classes to use when defining entities.
This will make sure that the `Id` property is defined and set as the key.
When using the `BaseEntity` class, the `Id` property will be a `long`.
The `IEntity` interfaces allows the developer to define the type that the `Id`
property should have.

### IRepository, BaseRepository and EntityRepository

The `IRepository` defines the methods available to be used in the `service`.
These methods are the basic CRUD (Create, read, update and delete) actions.
> Note that if you are using Entity Framework 6, there is no update method available.
> Tracked entities should be gathered from the database and stay tracked when updated.

The `BaseRepository` provides a base implementation for these methods using the
`DbSet<>` class.
This `DbSet<>` is not available in the repository itself, there is the `Queryable`
property. This `IQueryable` should be used for querying the database.
This is done cause I generally believe using `DbSet<>` goes hand in hand with writing
hacky, unmaintainable code.

The `EntityRepository` is written so that it works off the `BaseEntity` class.
This means the developer does not need to specify the `TKey` being used.

### IService, BaseService and EntityService

The same principles as for the `Repository` side of things is still at play here.
The `IService` defines the methods to be used for CRUD actions. The `BaseService`
provides an implementation for these methods using `IEntity`.
`EntityService` wraps these methods using `BaseEntity`.

### Dependency injection

Both `BaseRepository` and `BaseService` make use of constructor based dependency injection.

The repository relies on a `DbContext` being inserted into its constructor.
The service relies on a `IRepository` being inserted into its constructor.

It is highly encouraged to use the dependency injection pattern when using this package.

## Contributing

This package was mostly made for personal use but I do accept contributions.
Feel free to send in a pull request or issue.
