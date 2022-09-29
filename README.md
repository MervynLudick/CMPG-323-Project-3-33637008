# CMPG-323-Project-3-33637008
## Structure
The Project is split into three projects. Core, Data and Web. The core application contains the business logic, in this case there is none as it is a simple crud app, but it contains the domain entities. It also contains the interfaces that are implement in the lower level projects. By doing this we can invert the dependencies and make all project dependant on the main project.

The DataAccess app contains the db context as well as the repositories that wrap around the db context. It is somewhat unneccesary to do this as EF Core already implements the repository pattern, so what we are doing here is wrapping a reposotitory arround another repository. There are some benefits to do this, but I beleive that the cons outweigh them. 

Finally we have the Web app, this is the front facing website that the users will see, it also initliases our depenedency injection container.

<img width="436" alt="Screenshot 2022-09-29 at 14 13 44" src="https://user-images.githubusercontent.com/56234654/193028678-fc1b1bf0-f2d1-4eb9-b87f-0de7fff83567.png">

## Using The app
The app can be accessed from https://connecteddevice-33637008.azurewebsites.net to test it. An account can be created, after which you will be allowed to log in and create Zones, Categories and devices.

## References
[33637008_Project3_References.pdf](https://github.com/MervynLudick/CMPG-323-Project-3-33637008/files/9675480/33637008_Project3_References.pdf)
