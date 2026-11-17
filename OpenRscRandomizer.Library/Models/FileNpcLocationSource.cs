using OpenRscRandomizer.Library.Interfaces;
using System.IO;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace OpenRscRandomizer.Library.Models
{
    public class FileDefSource : IDefSource
    {
        private readonly string _dir;

        public FileDefSource(string dir)
        {
            _dir = dir;
        }

        public async Task<T> LoadAsync<T>(string fileName, CancellationToken ct = default)
        {
            await using (var stream = File.OpenRead(Path.Combine(_dir, fileName)))
            {
                return (await JsonSerializer.DeserializeAsync<T>(stream, cancellationToken: ct))!;
            }
        }
    }
}
