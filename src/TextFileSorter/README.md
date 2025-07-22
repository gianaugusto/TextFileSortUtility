# Text File Sorter

## Overview

Text File Sorter is a command-line tool for sorting files with a specific format. It is designed to sort lines that contain a number followed by a string, with the sorting criteria being the string first, and the number second.

## Features

- Sort files with lines in the format: `Number. String`
- Efficient sorting algorithm
- Handles large files

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
dotnet run -- -i input.txt -o output.txt
```

This will sort the lines in `input.txt` and write the sorted lines to `output.txt`.

## Usage

### Command-line Options

- `-i` or `--input`: Input file path (required)
- `-o` or `--output`: Output file path (required)

### Example

```sh
dotnet run -- -i input.txt -o output.txt
```

## Project Structure

- `Configuration/`: Command-line options
  - `SorterOptions.cs`
- `FileSorter.cs`: Core sorting functionality
- `Program.cs`: Entry point

## Design Principles

- SOLID Principles
- Clean Code Practices

## License

This project is licensed under the GNU General Public License. See the [LICENSE](LICENSE) file for details.
