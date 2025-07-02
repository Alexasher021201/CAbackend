## Prerequisites

- MySQL Workbench is installed and running locally.
- .NET 8 SDK and ASP.NET Core runtime are set up.

---

## Setup Instructions

### 1. Initialize the Database

Open MySQL Workbench and execute the provided `init.sql` file to create the necessary schema and seed the initial data.

### 2. Configure Database Connection

Open the `appsettings.json` file and update the following section with your MySQL username, password, and database name:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "server=localhost;user=your_username;password=your_password;database=game_db"
  }
}
```


