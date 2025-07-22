using System.Threading.Tasks;

namespace TextFileSorter
{
    public interface IFileSorter
    {
        Task SortFileAsync(string inputFile, string outputFile);
    }
}
