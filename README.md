# GUID Generator API

A simple .NET 8.0 Minimal Web API that generates a GUID with options to customize its format. It also supports Docker containerization for easy deployment.

## Features

- Generates a GUID with optional formatting:
    - Convert to uppercase
    - Remove hyphens
- Swagger UI for easy testing in development environment
- Docker container support for deployment

## API Endpoints

- **GET** `/api/guid` - Generates a GUID with optional query parameters:
    - `uppercase` (bool): Convert the GUID to uppercase (default: false).
    - `hyphens` (bool): Include hyphens in the GUID (default: true).

### Example Requests and Responses

#### 1. Default Request (Lowercase, Hyphens Included)

**Request:**

```bash
GET /api/guid
```

**Response:**

```json
{
  "guid": "7c9e1a18-7a6d-4f6f-b220-9c9837f3f72b"
}
```

#### 2. Uppercase GUID, Hyphens Included

**Request:**

```bash
GET /api/guid?uppercase=true
```

**Response:**

```json
{
  "guid": "7C9E1A18-7A6D-4F6F-B220-9C9837F3F72B"
}
```

#### 3. Lowercase GUID, Hyphens Excluded

**Request:**

```bash
GET /api/guid?hyphens=false
```

**Response:**

```json
{
  "guid": "7c9e1a187a6d4f6fb2209c9837f3f72b"
}
```

#### 4. Uppercase GUID, Hyphens Excluded

**Request:**

```bash
GET /api/guid?uppercase=true&hyphens=false
```

**Response:**

```json
{
  "guid": "7C9E1A187A6D4F6FB2209C9837F3F72B"
}
```

## Setup

### Prerequisites

- .NET 8.0 SDK or higher
- Docker (optional for containerized deployment)

### Running Locally

1. Clone the repository or download the source code.
2. Open a terminal and navigate to the project directory.
3. Restore the dependencies:
    
    ```bash
    dotnet restore
    ```
    
4. Run the application:
    
    ```bash
    dotnet run
    ```
    
5. Access the API at `https://localhost:7170/api/guid` or `http://localhost:5282/api/guid`.

### Swagger UI (Development Only)

- In development mode, you can access the interactive Swagger UI at:
    - `https://localhost:7170/swagger` (HTTPS)
    - `http://localhost:5282/swagger` (HTTP)

## License

This project is open-source and available under the MIT License.