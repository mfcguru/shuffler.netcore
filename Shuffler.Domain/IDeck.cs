using System.Threading.Tasks;

namespace Shuffler.Domain
{
    public interface IDeck
    {
        Task<CardDto[]> Shuffle();
    }
}
