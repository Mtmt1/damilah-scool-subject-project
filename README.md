# School Subjects Information System

A console-based application for managing school subjects information. This system allows users to view, add, and manage information about different school subjects.

## Features

- View all available subjects
- View detailed information about specific subjects
- Add new subjects with custom information
- Delete existing subjects
- Persistent storage using JSON file

## Prerequisites

- .NET SDK (version 6.0 or higher)
- Windows, macOS, or Linux operating system

## How to Run

1. Clone or download this repository
2. Open a terminal in the project directory
3. Run the following command:
   ```
   dotnet run
   ```

## Usage

The program provides a menu-driven interface with the following options:

1. **View All Subjects**: Displays a list of all available subjects
2. **View Subject Details**: Shows detailed information about a specific subject
3. **Add New Subject**: Allows you to add a new subject with:
   - Name
   - Description
   - Number of weekly classes
   - Literature references
4. **Delete Subject**: Remove an existing subject from the system
5. **Exit**: Close the application

## Data Storage

The system automatically saves all custom subjects to a `subjects.json` file in the project directory. This ensures that your data persists between program runs.

## Default Subjects

The system comes with three default subjects:
- Mathematics
- English
- Art

