using System.Threading.Tasks;

namespace TestFileCreator.Writing
{
    public interface IFileWriter : IDisposable
    {
        Task WriteLineAsync(string line);
        Task FlushAsync();
        new void Dispose();
    }
}
