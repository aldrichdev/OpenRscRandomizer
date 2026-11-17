using System.Threading;
using System.Threading.Tasks;

namespace OpenRscRandomizer.Library.Interfaces
{
    public interface IDefSource
    {
        /// <summary>
        /// Fetches and deserializes the specified defs file (<c>fileName</c>).
        /// </summary>
        Task<T> LoadAsync<T>(string fileName, CancellationToken ct = default);
    }
}
