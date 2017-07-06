# IReports API use case examples
This is an in progress selection of example use cases. They use the IReports APIs in order to demonstrate how they may be used in a production environment. The ApiWrapper.cs and ViewModels.cs files are files that have been generated using [NSwag](https://github.com/NSwag/NSwag) and then heavily edited to make them easy to read. For more information on the specifics of our APIs please go to the API specification page in the IReports admin panel. This will give our definative API specification and should be used as the source of truth when writing your own code. These are just to give examples of use cases to be used as inspiration when integrating our system.

## Reading the examples
In the examples folder each use case has been put in its own file. The title of these should hopefully make it clear what they are doing but there is also commenting within to explain what they do.
Each example takes the form of a static class with a method in called DoWork. This is intended to be the entry point and should be where you start reading.