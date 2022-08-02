# ContactSim -

Table of Contents:
* Description
* Technology Used
* Requirements
* Building Your Own
* Testing
* Future Considerations


## Description -
#### ContactSim is an API that allows a user to create, read, update, and delete contacts as well as get a special Call-List that returns contacts which have a specified home phone number present in their contact info.


## Technology Used - 
* C#
* ASP.NET Core Web API
* LiteDB ( a light weight in-memory db in this case. - check appSettings for config)
* Swagger UI

* Repository Pattern for Dependency Injection of services

**** NOTE I did not add a unit testing project to the solution because I was coming up on the end of the alloted time, so I spent time fixing formatting and making sure my logic, comments, and coding style was readable.


## Requirements -

* Endpoints listed below needed to be created and functional
* Use some kind of DB
* Make it testable
![SingleS1](https://user-images.githubusercontent.com/53095806/182327737-23e2501e-dde7-436f-a8ec-4417242d352e.jpg)


## Building Your Own - 
* Clone the project
* Open the solution
* Build the solution
* May need to restore Nuget packages
* Run in Debug mode to test with Swagger UI or Test it with other apps like Insomnia or Postman
* Copy entire SeedFile.txt and paste its contents into the text area for the api/contacts/seed-db api request - This will give the user some data to play around with


## Testing - 
I prefer to use Postman normally, but by running the build in debug mode you cant test the API using Swagger UI like so:

* #### Loading Screen
![Swgger1](https://user-images.githubusercontent.com/53095806/182326605-7d94140e-1d0c-4823-98e2-163f43d4cc7b.jpg)

* #### Sample Request Object
![Swagger2](https://user-images.githubusercontent.com/53095806/182326630-b1a0aa71-54b0-46ce-8e60-d89165abddf2.jpg)

* #### Copying and Pasting the Request Object directly from the Coding Prompt into the Swagger UI text area
![Swagger3](https://user-images.githubusercontent.com/53095806/182326653-1cd01dc7-a7e2-4cd0-927b-8492f253b327.jpg)

* #### Resposne returned by executing the API request
![Swagger4](https://user-images.githubusercontent.com/53095806/182326662-a8c93612-c3f4-4052-9c56-d33574f5c29e.jpg)

## Future Considerations -
* Add a seed file for easier testing
* Create a post method that can take a seed file, or seed the db through one of the Controller's constructors, or another automatic method


## Please let me know if you have any questions, comments, concerns, or suggestions!
