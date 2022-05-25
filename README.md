

Whats the weather like?
We would like you to build a REST API using ASP.NET with C#
We would like your API to take a CityName input parameter and then use this parameter to pull data from the https://openweathermap.org/ APIs, returning information about the current weather conditions.
You can retrieve the current weather data here: https://openweathermap.org/current#name 
All the weather API requests require an API key, you can use the following: da60d21da98419e708a2cbb21141e684

It’s down to you to fill in the blanks in the brief and although there is no right or wrong solution, we will be looking at the following:


How you have structured your project and models- 
The C# features you have used
How you serialize data
Routing and URL path attributes
What security topics you have considered
If you have thought about how the solution can scale
How testable is your code


1.Created  using Asp.Net core Rest API
2. Created Structuredformat with Controller and Models.
3. Used NugetPackages.Asp .Net Core
4.With JsonConvert serialize the data.
5.Used Route[Api/Controller] on the APicontroller class and in the action method [HttpGet("[action]/{weatherparameter}")] follow the attribute routing.
6.I used Authorize attribute for both ApiController class and action method
7. Instead of giving input parameter as City . I created two string variables with parameter( city name) and parametertype(City) . Say for an instance in future if they add  country as input parameter .
8. Tested with Nunit framework .


