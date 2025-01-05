# .NET Developer Task

A Web API application demonstrating key-value storage, RabbitMQ integration, and Entity Framework Core configuration.

## Technical Stack

- Language: C#
- Framework: .NET 8
- Database: PostgreSQL
- Message Broker: RabbitMQ
- Container Orchestration: Docker Compose

## Project Requirements

### 1. Web API Endpoint

The application exposes the following REST API endpoint:
- **Method**: POST
- **Route**: `/Calculation/{key:int}`
- **Body**: `{"input": decimal}`
- **Media Type**: text/json

### 2. Key-Value Storage Implementation

The application implements an in-memory key-value storage with the following rules:
- If the key doesn't exist in storage, create it with value = 2
- If the key exists but is older than 15 seconds, reset value to 2
- Otherwise, calculate the new value using the formula:
  ```
  output = ∛(ln(input) / current_storage_value)
  ```

### 3. Response Format

The endpoint returns a JSON response in the following format:
```json
{
    "computed_value": "newly calculated value stored in global storage",
    "input_value": "original input value",
    "previous_value": "previous value from global storage"
}
```

### 4. RabbitMQ Integration

- Calculation results are sent to a RabbitMQ queue
- A background service listens to the queue and logs messages to the console

### 5. Entity Framework Core Configuration

The application includes EF Core configuration for the following models:
- Author
- Article
- Site
- Image

Key features:
- Fluent API configuration
- Explicit relationship mapping
- Automatic migration application on startup

#### Database Schema

```
Author
- Id (PK)
- Name (Unique Index)
- One-to-One relationship with Image

Article
- Id (PK)
- Title (Index)
- Many-to-Many relationship with Author
- One-to-Many relationship with Site

Site
- Id (PK)
- CreatedAt

Image
- Id (PK)
- Description
```

## Setup and Deployment

### Docker Compose

The application is containerized using Docker Compose with the following services:
1. Web API application
2. RabbitMQ
3. PostgreSQL

To run the application:

```bash
docker-compose up
```

## Project Structure

The solution includes:
1. ASP.NET Web API project
2. Entity Framework Core configurations
3. RabbitMQ integration
4. Background service for message processing
5. Docker configuration files
6. Implemted FluentValidation and MediatR in CalculationController

## Input Validation

The application includes appropriate input validation for:
- Route parameters
- Request body
- Data type constraints

## Note

- The key-value storage is implemented using native .NET capabilities
- Storage is in-memory only and not persisted
- Database migrations are applied automatically on application startup
- No CRUD operations implementation is required for the database models

## Areas for Improvement

### **1. Docker Configuration**
   - Ensure `docker-compose.override.yml` and `Dockerfile` configurations handle environment variables securely.
   - Provide better separation for development and production settings.

### **2. Error Handling**
   - Add centralized exception handling middleware in the API to log and format error responses.
   - Improve error handling in services such as:
     - `CalculationService`: Handle invalid inputs or edge cases in mathematical operations.
     - `RabbitMqService`: Add robust handling for connection failures or serialization errors.
   - Use `ILogger` to log exceptions with sufficient context for debugging.

### **3. Validation**
   - Enhance validation for keys and values in `KeyValueStorageService`.
   - Add more extensive validation rules in FluentValidation for inputs beyond basic constraints.

### **4. Test Coverage**
   - Expand tests to cover services, including:
     - `RabbitMqService`
     - `CalculationService`
     - `KeyValueStorageService`
   - Add integration tests to ensure end-to-end functionality of the API.

### **5. Code Quality**
   - Refactor repeated patterns (e.g., RabbitMQ queue declaration) into reusable utility methods.
   - Consolidate database migrations to remove redundant or unused entries.

### **6. Logging**
   - Use structured logging with context (e.g., method names, input values).
   - Ensure consistent logging levels (e.g., `Error` for exceptions, `Information` for routine events).

### **7. Unused or Redundant Code**
   - Remove empty or unused files such as `Program.cs` in the `Application` project.
   - Evaluate the necessity of interfaces like `ICalculationResult` and `IStorageEntry`.

### **8. API Design**
   - Ensure all controllers and endpoints return meaningful HTTP status codes.
   - Use standard conventions for route definitions.

### **9. Documentation**
   - Extend the README with:
     - Detailed setup instructions.
     - Explanation of configurations for different environments (e.g., local, development, production).
     - Examples of API usage with sample requests and responses.

### **10. Performance Optimization**
   - Assess memory usage of `ConcurrentDictionary` in `KeyValueStorageService` for scalability.
   - Optimize database schema for indexing and normalization where necessary.


