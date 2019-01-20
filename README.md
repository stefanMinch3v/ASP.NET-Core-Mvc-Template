# ASP.NET-Core-Mvc-Template
## ASP.NET Core MVC custom template

## Features
* Auto-database migrations
* AutoMapper
* Auto-injecting services

## Seeded user
> * **Default administrator**
>   * Username: admin
>   * Password: admin12
> * **Default role**
>   * Admin

## StyleCop warnings:
* warning disabled SA1601 // The partial class element must have a documentation header containing either * a summary tag or a content tag
* warning disabled SA1600 // All elements must have a documentation header
* warning disabled SA1633 // The file has no header, header Xml is invalid, or the header is not located at the top of the file
* warning disabled SA1208 // System using directives must be placed before all other using directives
* warning disabled SA1112 // Closing parenthesis must be on line of opening parenthesis
* warning disabled SA1114 // Parameter list must follow declaration
* warning disabled SA1116 // Parameters must start on line after declaration
* warning disabled SA1117 // Parameters must be on the same line or separate lines
* warning disabled SA1118 // Parameter must not span multiple lines
* warning disabled SA1305 // Field names must not use hungarian notation

### Only for data layer (due to migrations which are auto-generated)
* warning disabled SA1400 // The class must have an access modifier
* warning disabled SA1115 // Parameter must follow comma.The parameter must begin on the line after the previous parameter