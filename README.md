# GoRest API Testing Project

## Overview
This project focuses on testing the GoRest API, an online RESTful web service for testing and prototyping. It's designed to demonstrate proficiency in handling various HTTP requests, creating and managing data, and implementing automated tests using C# and .NET.

## Features
- **Automated API Testing**: Automates tests for creating, retrieving, updating, and deleting user data from the GoRest API.
- **Data Randomization**: Utilizes `RandomizingData` class to generate randomized user data for diverse test scenarios.
- **Comprehensive Test Cases**: Includes various test cases covering different aspects of API interaction.
- **Async/Await**: Implements asynchronous programming for efficient API calls.
- **Reusable HTTP Client**: Uses a static `HttpClient` for resource reusability and efficient network operations.

## Getting Started
These instructions will get you a copy of the project up and running on your local machine for development and testing purposes.

### Prerequisites
- .NET SDK
- An IDE like Visual Studio or VS Code
- A Git client to clone the repository

### Installation
1. **Clone the Repository**
   ```bash
   git clone https://github.com/minalaz/GoRestApiTesting.git
2. **Navigate to the project directory**
   ```bash
   cd GoRestApiTesting
3. **Restore NuGet Packages**(if using Visual Studio, this might be automatic)
   ```bash
   dotnet restore
4. **Open the project in your IDE**

## Configuration
- Update the API Token
- Ensure the URI is correct as per the latest GoRest API endpoint.

## Running Tests
Run the tests using the Test Explorer in Visual Studio or by running the following command in the terminal:
```bash
dotnet test


