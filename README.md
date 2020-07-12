# Aspnet Core 3.1 + Angular 9+ Boilerplate


```diff
- Please note: This template is still under development
```

This is an asp.net core + Angular 9 Boilerplate 


This Boilerplate is a monolithic application works as Asp.net Core and Angualr 9. Here are the technologies I have used : 


**The structure** 

![General View](diagram.jpg)

# **Asp.net Core API:**

An Asp.net core 3 simple api project. We create the asp.net core project separately as a back-end for the Angular app. 


**Naming and structure:** 

all the names starts with "Meys". Consider it as an example of a project. Then all the project can be named Mey.XXX like, 	Meys.Data, Meys.Service.Tests

Folder and Solution structure: 
I am using the solution folders to organize my solution, the solution folders are very useful specially when you use numbers in them. At a glance, in terms of dataase,  I can tell what is my lowest layer. 



**Dependency Injection:** 

The default IOC of the asp.net core is used. There is an extension ServiceExtensions.cs in this file I have created an extension for IServiceLocation and in that we have injected all the required depenencies. 

**Entityframwork .net core:** 

ORM is EF Core. All the Data related projects are in "1.Data folder". 

Meys.Domain: contains all the entity of the database. we have to keep this project separate of any other items other than entities because any other project can include them. 

Meys.Data: all files related to the pattern of unit of work and general repository implemented in UnitOfWorkAndGeneralRepo folder. 

Fluent API Mapping: mapping between entities and the tables in the database is done via an overridden  method called OnModelCreating in the ApplicationDbContext. 

     protected override void OnModelCreating(ModelBuilder modelBuilder)
     {
	    modelBuilder.ApplyConfiguration(new UserMapping()); 
     }
And for each entity you need to create a Mapping file. For User we have this: 

    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder) => builder.ToTable("User").HasKey(x => x.Id);        
    }

If you dont know about mapping please read the [Fluent Api in EntityFramework](https://www.entityframeworktutorial.net/efcore/fluent-api-in-entity-framework-core.aspx) . 

<br>

**JWT token Authentication:** 
JWT is one of the most common method for authentication, this is how it works:

1- client (in our case the frontend angular app) send its credentials to back-end. 
2- back-end will check the credentials and if they are valid creates a token. 
3- the token is received by frontend and stored in storage. 
4- for all the subsequent calls to the backend the token is added to the header and is sent to the backend. 
5- backend reads the header and decrypts  token and validate it. 


**Dto maker :**
You need to find a way to map some of the model you use between the two services, like Frontend and backend applications. 

this is about how to sync  your models between Api  And Angular projects.  
As you may know there should be some models shared between the client app (angular) and your api. So when you prepare some data to send it to the client that call your api, you need to create a model that client expect to get. These models that are for data transfer called DTO(data transfer object). 

You need to have these models in two places, in your api solution and in your client application. And, here comes the tricky part,  you have to keep these two group of models sync all the time. Keeping two group of models in sync, in two places, is anti pattern and gives way to mistake. It is best to find a way to generate one based on the other. One way to do this is to create and update the DTOs in the Api solution and automatically sync them with the client app. There is a package called [MTT](https://github.com/CodySchrank/MTT "MTT") which does this for us.  
This package will read all your model in a specific folder and convert them to Typescript models in the target folder, when a specific  project is built.  

how to use MTT package in an efficient way : 
1- create a project (because we want that project excluded from the build list so we can trigger the build manually whenever is needed) 
2- install the latest version of [MTT](https://github.com/CodySchrank/MTT "MTT") package on the project you have created in the step 1.
3- edit the .csproj file to set the working and out put folder like this:  


    <Target Name="Convert" BeforeTargets="PrepareForBuild">
        <ConvertMain WorkingDirectory="../Meys.Common/Dtos/" ConvertDirectory="../../clientApp/"/>
      </Target>
      
4- remove the project from the build list of the solution, because you dont want all the model to be built every time you build your project. 

5- when you changed  a model or create a new model, then you build the dto maker manually and you will get the changes in the out put folder. So the  ConvertDirectory folder is the out put and you need to set on a folder in an angular app.  



**Angular 9,  Frontend app:**


**Migration App**: 

it is a console app written in c# to do the migration of the database with [this](https://fluentmigrator.github.io/articles/intro.html) package called : FluetnMigrator




