# WallOfArticles
 Resources to create, remove, read and like all articles published by any user of the system.


# Back-end Techinical Specification 

### Environment 
Visual Studio 2019, .Net Core 3, language C#, ORM Entity Framework Core 3.1, MySQL Database, Mapper and DDD.

### Check these steps before instalation
1 - In the WebApi project open appsetings.json file and change database string connection configuration; </br>
2 - In my environment was configured port 44379 from localhost; </br>
3 - Open terminal and select project folder called "RockContent.Infra.Data";</br>
4 - In the project "RockContent.Infra.Data" there is appsetings.json file, change database string connection configuration too;</br>
5 - In this folder execute the command "dotnet ef database update" to create database;</br>
6 - Play.</br>

# Front-end Techinical Specification 

### Environment 
Visual Code, Angular 9 and NodeJs.

### Check these steps before instalation
1 - Install NodeJs Server;</br>
2 - Open the root folder of the front-end project in Visual Code; </br>  
3 - In the Visual Code terminal install agular cli; </br>  
4 - Find environments.ts file, check if url property is correct. This is back-end url; </br> 
5 - In the Visual Code terminal type the command ng serve --open .
