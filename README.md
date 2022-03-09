# Repository-Pattern
Base Practice Repository Pattern in Separate Project ASP NET Core Web API

According to existing folder (project), we have 3 diffrent project
## Domain Project
Within this project there are several folders
### 1. Models
It will store all models that will be implemented as table in database. So our models will be migrated are stored here. Within folder also has sub folder called "Configuration", it contains configuration of table column for each model
### 2. Common Models
It likes a model helper such as "BaseResponse" for storing data from API etc
### 3. DTO
It similar to our model in Models folder. The difference, perhaps we don't include several critical data. For example in user model we have password property, then in our DTO we will exclude the password property. It makes our data secure. DTO models will be thrown or consumed by the user

