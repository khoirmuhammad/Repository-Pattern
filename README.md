# Repository-Pattern
Base Practice Repository Pattern in Separate Project ASP NET Core Web API

According to existing folder (project), we have 3 diffrent project
## Domain Project
Within this project there are several folders
### 1. Models
It will store all models that will be implemented as table in database. So our models will be migrated are stored here. Within folder also has sub folder called "Configuration", it contains configuration of table column for each model
### 2. Common Models
It likes a model helper such as "BaseResponse" for storing data from API etc. In case we need to add models that wont to be implemented in migration, just store here.
### 3. DTO
It similar to our model in Models folder. The difference, perhaps we don't include several critical data. For example in user model we have password property, then in our DTO we will exclude the password property. It makes our data secure. DTO models will be thrown or consumed by the user

## Repository Project
### 1. Contracts
Basically we can use Interfaces or Abstract or whatever if the name make sense. We will store all of interfaces / abtractions / contract here.
### 2. Repositories
We shall create repo class here. Basically each model will have one repo class. These repo class will implement corresponding interface that created on contracts folder
### 3. Migration
All migrations that performed by us will store here as well.

Aside fro that, we have application context that hold critical role in application.

### Application Project
It's like presentation layer. wwwroot , controllers and view will be stored here. In case you will create extensions of class, helper class, constats class also can be put here.

