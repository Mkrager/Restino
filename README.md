# Restino

## Project Description
This project is a web platform similar to Booking, where users can publish and book various accommodations. The system includes role-based access, allowing both regular users and administrators to manage different aspects of the platform.

## Technologies Used
- **Frontend:** 
  - **MVC** — for creating interactive web components.
  - **HTML** — for structuring the pages.
  - **CSS** — for styling the interface.

- **Backend:**
  - **ASP.NET Core 8** — the server-side part of the application for request handling and routing.
  - **C#** — the primary programming language used for developing the backend logic, implementing business rules, handling user requests, and interacting with the database through Entity Framework Core.
  - **Entity Framework Core** — for database interaction.
  - **Database** — MSSQL.

## Functionality

1. **User Registration:**
   - Users can register by providing their first name, last name, email, username, and password.

2. **Login:**
   - After registration, users can log in using their email and password.
  
3. **Booking Accommodations:**
   - Users can search for accommodations and reserve them.
    
4. **Accommodation Management:**
   - Users can create new accommodations, update their details, and delete them as needed.
   
5. **Administrator Functionality:**
   - Administrators can create new accommodation categories and manage any data on the platform, including publishing, editing, or deleting accommodations, and managing users and their access rights.
## How to Run the Project Locally

### Getting Started 
1. Clone the repository to your local machine.
```bash
git clone https://github.com/Mkrager/Chat.git
```
2. Set up your development environment. Make sure you have the necessary tools and packages installed.

3. Configure the project settings and dependencies. You may need to create configuration files for sensitive information like API keys and database connection strings.

4. Install the required packages using your package manager of choice (e.g., npm, yarn, NuGet).

5. Run the application locally for development and testing.
```bash
dotnet run
```
6.Access the application in your web browser at http://localhost:port.
