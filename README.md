
Project Setup & API Usage Guide
GitHub Link: https://github.com/dineshchandra07/LumelAssesment

Overview:
This project includes:
- Uploading and processing a CSV file
- Fetching revenue by product, category, region, and overall for a given date range

Running Steps:

1. Update the database connection string in appsettings.json.

2. Run the below command in the Package Manager Console to create the database:
   update-database

3. Upload CSV File  
   - Update the localhost URL as needed.  
   - Attach the CSV file.  
   API Type: POST  
   Endpoint: https://localhost:7253/api/upload/uploadCSV

4. Get All Revenue for a Date Range  
   API Type: POST  
   Endpoint: https://localhost:7253/api/upload/allRevenue  
   Body (Id will be empty):
   {
        "From": "2023-01-03",
        "To": "2024-12-15",
        "Id": ""
   }

5. Get Revenue by Product  
   API Type: POST  
   Endpoint: https://localhost:7253/api/upload/productRevenue  
   Body (Provide product ID):
   {
        "From": "2023-01-03",
        "To": "2024-12-15",
        "Id": "P123"
   }

6. Get Revenue by Category  
   API Type: POST  
   Endpoint: https://localhost:7253/api/upload/categroyRevenue  
   Body (Provide category name):
   {
        "From": "2023-01-03",
        "To": "2024-12-15",
        "Id": "Shoes"
   }

7. Get Revenue by Region  
   API Type: POST  
   Endpoint: https://localhost:7253/api/upload/regionRevenue  
   Body (Provide region name):
   {
        "From": "2023-01-03",
        "To": "2024-12-15",
        "Id": "Europe"
   }

