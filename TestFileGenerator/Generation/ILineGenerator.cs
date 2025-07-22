using System.Threading.Tasks;

namespace TestFileGenerator.Generation
{
    public interface ILineGenerator
    {
        Task<string> GenerateLineAsync();
    }
}
