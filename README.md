# Text File Sorting Utility

## Overview

This repository contains two command-line tools for working with text files:

1. **Test File Creator**: Generates test files with lines in the format `Number. String`.
2. **Text File Sorter**: Sorts files with lines in the format `Number. String` based on the string part first, and the number part second.

## Features

- Generate and sort files with a specific format: `Number. String`
- Specify the number of lines, number of different strings, and maximum number value
- Buffered file writing for performance
- Progress indicator during generation
- Efficient sorting algorithm
- Handles large files

## Requirements

- .NET Core 8

## Projects

### 1. Test File Creator

#### Overview

Test File Creator is a command-line tool for generating test files with a specific format. It is designed to create files with lines containing a number followed by a string, which can be used for testing sorting algorithms.

#### Usage

```sh
cd src/TestFileCreator
dotnet run -- -o output.txt -n 1000 -s 10 -m 10000
```

This will generate a file named `output.txt` with 1000 lines, using 10 different strings, and with numbers ranging from 1 to 10000.

#### Command-line Options

- `-o` or `--output`: Output file path (required)
- `-n` or `--number`: Number of lines to generate (default: 1000)
- `-s` or `--string-count`: Number of different strings to use (default: 10)
- `-m` or `--max-number`: Maximum number value (default: 10000)

### 2. Text File Sorter

#### Overview

Text File Sorter is a command-line tool for sorting files with a specific format. It is designed to sort lines that contain a number followed by a string, with the sorting criteria being the string first, and the number second.

#### Usage

```sh
cd src/TextFileSorter
dotnet run -- -i input.txt -o output.txt
```

This will sort the lines in `input.txt` and write the sorted lines to `output.txt`.

#### Command-line Options

- `-i` or `--input`: Input file path (required)
- `-o` or `--output`: Output file path (required)

## Design Principles

- SOLID Principles
- Strategy Pattern
- Clean Code Practices

## Interface

The `IFileSorter` interface defines the contract for file sorting operations. It is implemented by the `FileSorter` class, which provides the actual sorting functionality.

```csharp
public interface IFileSorter
{
    Task SortFileAsync(string inputFile, string outputFile);
}
```

## License

This project is licensed under the GNU General Public License. See the [LICENSE](LICENSE) file for details.
