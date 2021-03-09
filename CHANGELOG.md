# 2021-02-09T21.00 Continue with the actual implementation after the design

The plan here is to model the database so that we can generate the models and generate (admittedly pretty rough) CRUD API. For the simple tables I am not really going to bother with any real verification. It might be worth the hassle to figure out if there are any views we'd like to make our life easier. Although I think it is generally a good thing most of the data is not mostly implied and only truly found by joining a bunch of tables.

So as predicted; I regretted modeling the `fee` table as I did, now I am stuck with a record I have to update and not forward to some sort of payment processor and keep an eye on later. And I also figured out that I'm unhappy with how I manage books. This should be modeled as "one book" with multiple copies available in the library which are then loaned out to the public. This way we'd be allowed to constrain the entire thing as it is now not possible to enforce a foreign key relation on `isbn` in the `isbn_author` table.

Generate the models and context of the application with: `dotnet ef dbcontext scaffold --data-annotations --context "LibraryContext" --context-dir "." --output-dir "./Model" --schema "public" "Host=localhost;Database=library;Username=postgres;Password=postgres" Npgsql.EntityFrameworkCore.PostgreSQL`

# 2021-03-09T14.00 An interview REST API using libraries as an example

Like with many of these the choice of technology is free but as always roughly sticking to what is applicable for the position is what is advised. In this case I am going for the following stack;

* .NET 5.0 (I'm on linux here so it is going to be all commandline)
* `make` to actually make my life easier
* docker and docker-compose
* As a database I'm going to use postgres (running in a docker container)
* `Sqitch` for the database migrations

This specific iteration also requires two additional "half-way" deliveries, these will be done using draw.io

* A data model / API diagram of some sorts
* General application structure
