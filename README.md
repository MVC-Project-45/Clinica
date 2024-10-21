## Clinica - Online Doctor Appointment Reservation System
#### Clinica is an online reservation system designed to help patients schedule appointments with doctors efficiently. It streamlines the process of finding available doctors and booking appointments online.

## Features :
  - Patients can browse available doctors and schedule appointments.
  - Real-time updates for doctor availability and appointment confirmation using SignalR.
  - Secure and efficient data handling using Entity Framework Core and SQL Server.
  - User-friendly interface built with ASP.NET Core MVC.
  - Support for real-time notifications and updates.
  - Data querying and manipulation with LINQ.
## Technologies Used :
  - ASP.NET Core MVC: For building the web application framework.
  - Entity Framework Core (EF Core): For managing database access and handling data persistence.
  - SQL Server: For database management.
  - C#: Core programming language used for the back-end logic.
  - LINQ: For querying data efficiently.
  - SignalR: For real-time web functionality, providing live updates to users.
  - Hangfire: For background job scheduling and processing tasks like appointment reminders.
## Setup Instructions :
1- Clone the repository:
```
git clone https://github.com/MVC-Project-45/Clinica.git
```
2- Navigate to the project directory:
```
cd Clinica
```
3- Setup the database:
- Update the connection string in the ```appsettings.json ``` file to match your SQL Server configuration.
- Run migrations to set up the database:
```
dotnet ef database update
```
4- Run the application:
```
dotnet run
```
5- Access the application: Open your browser and navigate to ```https://localhost:{PORT_NUMBER}```.

## Contributing
If you'd like to contribute to Clinica, feel free to fork the repository and submit a pull request.




