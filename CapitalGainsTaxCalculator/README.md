# Capital Gains Tax Calculator

This console application is designed to help users calculate the capital gains tax owed in a given year in Ireland. It provides a user-friendly interface for inputting capital gain transactions and computes the tax based on the current regulations.

## Project Structure

- **Program.cs**: Entry point of the application, handling user input and output.
- **Models/CapitalGain.cs**: Defines the `CapitalGain` class representing a capital gain transaction.
- **Services/TaxCalculator.cs**: Contains the `TaxCalculator` class with methods for calculating capital gains tax.
- **Utils/InputParser.cs**: Provides the `InputParser` class for parsing user input into `CapitalGain` objects.
- **CapitalGainsTaxCalculator.csproj**: Project file containing configuration settings for the .NET application.

## Usage Instructions

1. Clone the repository or download the project files.
2. Open a terminal and navigate to the project directory.
3. Build the project using the .NET CLI:
   ```
   dotnet build
   ```
4. Run the application:
   ```
   dotnet run
   ```
5. Follow the prompts to enter your capital gain transactions.

## Developer Information

This project is built using .NET and follows standard coding practices. Contributions are welcome, and any issues or feature requests can be submitted via the project's issue tracker.