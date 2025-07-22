# Test File Creator

## Overview

Test File Creator is a command-line tool for generating test files with a specific format. It is designed to create files with lines containing a number followed by a string, which can be used for testing sorting algorithms.

## Features

- Generate files with a specific format: `Number. String`
- Specify the number of lines, number of different strings, and maximum number value
- Buffered file writing for performance
- Progress indicator during generation

## Requirements

- .NET Core 8

## Building and Testing

### Build

To build the project, run:

```sh
dotnet build
```

### Test

To run the application, use:

```sh
dotnet run -- -o test_output.txt -n 1000 -s 10 -m 10000
```

This will generate a file named `test_output.txt` with 1000 lines, using 10 different strings, and with numbers ranging from 1 to 10000.

## Usage

### Command-line Options

- `-o` or `--output`: Output file path (required)
- `-n` or `--number`: Number of lines to generate (default: 1000)
- `-s` or `--string-count`: Number of different strings to use (default: 10)
- `-m` or `--max-number`: Maximum number value (default: 10000)

### Example

```sh
dotnet run -- -o test_output.txt -n 1000 -s 10 -m 10000
```

## Project Structure

- `Configuration/`: Command-line options
  - `GeneratorOptions.cs`
- `Generation/`: Line generation
  - `ILineGenerator.cs`
  - `TestFileLineGenerator.cs`
- `Writing/`: File writing
  - `IFileWriter.cs`
  - `BufferedFileWriter.cs`
- `Utils/`: Utility classes
  - `ProgressReporter.cs`
- `Program.cs`: Entry point

## Design Principles

- SOLID Principles
- Strategy Pattern
- Clean Code Practices

## License

This project is licensed under the GNU General Public License. See the [LICENSE](LICENSE) file for details.
