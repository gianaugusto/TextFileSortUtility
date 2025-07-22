# Test File Generator

## Overview

Test File Generator is a command-line tool for generating test files with random data. It is designed to be highly configurable and extensible, following SOLID principles and clean code practices.

## Features

- Generate files with random data
- Specify the number of lines and average line size
- Buffered file writing for performance
- Progress indicator during generation
- Extensible architecture using the Strategy Pattern

## Requirements

- .NET Core net8

## Building and Testing

### Build

To build the project, run:

```sh
dotnet build
```

### Test

To run the application, use:

```sh
dotnet run -- -o test_output.txt -l 1000 -s 100
```

This will generate a file named `test_output.txt` with 1000 lines of random data, each with an average size of 100 bytes.

## Usage

### Command-line Options

- `-o` or `--output`: Output file path (required)
- `-l` or `--lines`: Number of lines to generate (default: 1000)
- `-s` or `--line-size`: Average line size in bytes (default: 100)

### Example

```sh
dotnet run -- -o test_output.txt -l 1000 -s 100
```

## Project Structure

- `Configuration/`: Command-line options
  - `GeneratorOptions.cs`
- `Generation/`: Line generation
  - `ILineGenerator.cs`
  - `RandomLineGenerator.cs`
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
