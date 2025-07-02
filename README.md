## Prerequisites

- [MySQL Workbench](https://dev.mysql.com/downloads/workbench/) installed and running locally.
- .NET 8 SDK and ASP.NET Core environment set up.

---

## Setup Instructions

1. **Initialize the Database**

   Open **MySQL Workbench**, and run the provided `.sql` file to create the required schema and tables.

2. **Configure Database Credentials**

   Open the `appsettings.json` file and update the following fields with your own MySQL username and password:

   ```json
   {
   "username": "Alice",
   "bestTime": 99
   }
   ```

