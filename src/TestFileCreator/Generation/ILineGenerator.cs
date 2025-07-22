using System.Threading.Tasks;

namespace TestFileCreator.Generation
{
    public interface ILineGenerator
    {
        Task<string> GenerateLineAsync();
    }
}
