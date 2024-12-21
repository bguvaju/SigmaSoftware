# Candidate API - Create and Update Candidate

This API allows for creating and updating a candidate in the system through a single API endpoint. The API follows the **Database-First** approach, and the project is structured using **Clean Architecture** principles. The project also includes **Integration Testing** to ensure seamless functionality and reliability.

## Table of Contents

- [Overview](#overview)
- [Technologies](#technologies)
- [Architecture](#architecture)
- [Usage](#usage)
- [API Endpoints](#api-endpoints)

## Overview

This API allows users to create and update candidate records. The key features of this project include:
- **Database-First Approach**: The project generates models directly from the existing database schema.
- **Clean Architecture Design**: The application is structured in a way that separates concerns between the presentation layer, business logic, and data access layer.
- **Integration Testing**: The application includes automated tests to ensure the proper functionality of the API endpoints.

## Technologies

- **.NET 8** (version being used)
- **Entity Framework Core** (EF Core) with **PostgreSQL**
- **Clean Architecture** principles
- **XUnit** for Integration Testing
- **Swagger** for API Documentation
- **In-Memory Database** for Testing

## Architecture

The project follows **Clean Architecture** and is divided into the following layers:

1. **API Layer**: Contains controllers to handle HTTP requests.
2. **Application Layer**: Includes services and business logic to process requests.
3. **Domain Layer**: Represents the core entities and business rules.
4. **Infrastructure Layer**: Handles data access using Entity Framework Core, interacting with the database.

## Usage

This application is implemented as part of the assessment provided by **Sigma Software**. It allows for the creation and updating of candidate records through a single API endpoint. The application follows a **Database-First** approach and implements **Clean Architecture** for separation of concerns. It is designed to be tested seamlessly with **Integration Testing**.


## API Endpoints

### 1. `POST /api/v1/candidates`
This endpoint handles both **creation** and **update** of a candidate. If a candidate with the given email already exists, the record will be updated. Otherwise, a new candidate will be created.

#### Request Body Example:
```json
{
  "firstName": "Bikram",
  "lastName": "Guvaju",
  "email": "bguvaju@hotmail.com",
  "phoneNumber": "9843684422",
  "timeToCall": "2024-12-20T14:00:00Z",
  "linkedInProfile": "https://www.linkedin.com/in/bikram-guvaju/",
  "githubProfile": "https://github.com/bikram0",
  "comment": "Sigma Software Assesment."
}





