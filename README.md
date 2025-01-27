This is an interview coding assignment for Fourth Enterprises LLC., Inc.
------------------------------------------------------------------------

To run your ASP.NET Core and Angular application using Docker Compose in Visual Studio, follow these steps:

#1 Clone the Repository

#2 Open Your Solution in Visual Studio:

#3 Launch Visual Studio and open your existing solution that includes both the ASP.NET Core backend and the Angular frontend projects.
Set Docker Compose as the Startup Project:

#4 In the Solution Explorer, locate the docker-compose project.
Right-click on the docker-compose project and select Set as Startup Project.

#5 Run the Application:

Press F5 or click the Start Debugging button.
Visual Studio will build and run your Docker containers as defined in your docker-compose.yml file.
Once the services are up and running, your default web browser should automatically open to the specified launchUrl.

Additional Tips:

Ensure Docker Desktop is Running:

Before starting, make sure that Docker Desktop is installed and running on your machine.
Verify Service Configurations:

Double-check your docker-compose.yml file to ensure that all services are correctly defined and configured.
Monitor Output:

Keep an eye on the Output window in Visual Studio for any build or runtime errors that may occur during the process.
