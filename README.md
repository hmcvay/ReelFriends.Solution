# 🎥 ReelFriends 🎬 

#### By Hayley McVay, Brenna Lavin, Tiffany Rodrigo, Will Greenberg, Jake Haley


## Technologies Used

* C#
* ASP.NET Core
* Entity Framework Core
* MySQL Workbench

## Description

We all want some good company when watching our favorite movies. That's where ReelFriends comes in. With ReelFriends, you simply add your favorite movies to a watchlist. ReelFriends then compares your watchlist to the other user's watchlist and shows you the movies you have in common in your watchlist. Now you have a Reel Friend! 

## Setup/Installation Requirements

* To use this application you have to have MySql Workbench installed. Follow setup instructions [here!](https://www.learnhowtoprogram.com/c-and-net/getting-started-with-c/installing-and-configuring-mysql)
* Clone this repository down to your local machine.
* In the top directory (PierresBakery2.Solution) create an appsettings.json file with the following information `{ "ConnectionStrings":{ "DefaultConnection":"Server=localhost;Port=3306;database=firstname_lastname;uid=root; pwd=[YOURPASSWORDHERE];" } }`
* Save this file then navigate to the main project folder by typing `cd PierresBakery` into your terminal.
* Type `dotnet restore` into the terminal to install project dependencies.
* Type `dotnet ef database update` into the terminal to ensure database is properly connected.
* To run program, type `dotnet run` into the terminal in the main project folder. (PierresBakery)
_{Leave nothing to chance! You want it to be easy for potential users, employers and collaborators to run your app. Do I need to run a server? How should I set up my databases? Is there other code this application depends on? We recommend deleting the project from your desktop, re-cloning the project from GitHub, and writing down all the steps necessary to get the project working again.}_

## Known Bugs

* _Any known issues_
* _should go here_

## License

_{Let people know what to do if they run into any issues or have questions, ideas or concerns.  Encourage them to contact you or make a contribution to the code.}_

Copyright (c) _date_ _author name(s)_