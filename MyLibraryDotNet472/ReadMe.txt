ASP .Net, MVC, MS SQL DB

in console
PM>Install-Package EntityFramework -Version 6.4.0
Create DBContext
add DB ConnectionString in web.config file

Data seeding by method 1
PM> Enable-Migration
PM> add-migration adddata_TableName

In Project
go to Migration folder 
class adddata_TableName has two method up and down

add up method insert query statement.

PM> Update-Database
Data seeding completed

Data seeding by method 2
BookInitializer class
web.Config add 
<contexts>
      <context type="MyLibraryDotNet472.Context.BookDBContext, MyLibraryDotNet472">
        <databaseInitializer type="MyLibraryDotNet472.Context.BookInitializer, MyLibraryDotNet472" />
      </context>
 </contexts>

for json package at older core (System.Text.Json 5.0.2)
use
PM> Install-Package System.Text.Json -Version 5.0.2