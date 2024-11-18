QuickBooks Integration API
Overview
This project is an API designed to interact with QuickBooks using the QuickBooks SDK. It allows you to query and retrieve data from QuickBooks such as Company, Invoice, Bill, Check, Item Sales Tax, and other entities. The API also provides a structure for displaying the retrieved data and includes JWT authentication for secure access.

This project demonstrates how to integrate QuickBooks with a C# ASP.NET application.

Features
QuickBooks Integration: Retrieves data from QuickBooks using the QuickBooks SDK.
Endpoints for Different Queries:
Retrieve Company data
Retrieve Invoice details
Retrieve Bill data
Retrieve Check data
Retrieve Item Sales Tax data
JWT Authentication: Provides secure access to the API using JSON Web Tokens (JWT).
REST API: Exposes RESTful endpoints for integration with other microservices or applications.
Error Handling: Proper error handling and validation are implemented for the API.
Prerequisites
Before running the project, ensure that you have the following installed:

.NET 6.0 or later
QuickBooks SDK (Download from QuickBooks Developer portal)
Visual Studio Code or Visual Studio
QuickBooks Developer Account (For SDK and sample company data)
Postman or any other API testing tool
Getting Started
1. Clone the repository:
bash
Copy code
git clone https://github.com/your-username/quickbooks-integration-api.git
cd quickbooks-integration-api
2. Install the required NuGet packages:
Run the following command to install the necessary packages:

bash
Copy code
dotnet restore
3. Setup QuickBooks SDK
Download and install the QuickBooks SDK.
Configure the QuickBooks SDK with your credentials and ensure the sample company is available for queries.
4. Configure JWT Authentication
Modify the Program.cs file to include your secret key and other JWT settings:

csharp
Copy code
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "your_issuer",
            ValidAudience = "your_audience",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("your_secret_key"))
        };
    });
Replace "your_secret_key", "your_issuer", and "your_audience" with your own values.

5. Run the Application
Start the application using the following command:

bash
Copy code
dotnet run
The application will start and listen for API requests on the specified port.

6. Testing the API
You can test the API using tools like Postman or any other HTTP client. The following endpoints are available:

GET /api/quickbooks/company - Get company data from QuickBooks
GET /api/quickbooks/invoices - Get all invoices from QuickBooks
GET /api/quickbooks/bills - Get all bills from QuickBooks
GET /api/quickbooks/checks - Get all checks from QuickBooks
GET /api/quickbooks/item-sales-tax - Get all item sales tax data from QuickBooks
7. JWT Authentication
For testing the API with JWT, you can send a POST request to the authentication endpoint (if implemented) to receive a token, and then include it in the Authorization header of your requests:

css
Copy code
Authorization: Bearer {your_jwt_token}
Additional Features (Optional)
Receive Bill and Check Data: Additional endpoints can be added for querying Bill and Check data from QuickBooks.
REST API: The API is designed to be modular, allowing you to easily extend it with additional functionality.
User Authentication & Authorization: JWT-based authentication allows secure access to the endpoints.
License
This project is licensed under the MIT License - see the LICENSE file for details.

Troubleshooting
If you encounter any issues with the QuickBooks SDK integration, ensure that the SDK is properly installed and configured.
If JWT authentication is not working, make sure the secret key and other parameters are correctly configured in the Program.cs file.
Ensure that the required dependencies are installed using dotnet restore.
For further assistance, please refer to the official QuickBooks Developer documentation or open an issue in the GitHub repository.
