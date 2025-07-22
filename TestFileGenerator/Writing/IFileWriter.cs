using System.Threading.Tasks;

namespace TestFileGenerator.Writing
{
    public interface IFileWriter : IDisposable
    {
        Task WriteLineAsync(string line);
        Task FlushAsync();
        new void Dispose();
    }
}
