using OpenRscRandomizer.Library.Interfaces;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace OpenRscRandomizer.Library.Models
{
    public class GitLabDefSource : IDefSource
    {
        private const string BASE_URL = @"https://gitlab.com/openrsc/openrsc/-/raw/develop/server/conf/server/defs/";
        private readonly HttpClient _client;
        
        public GitLabDefSource(HttpClient client)
        {
            _client = client;
        }

        public async Task<T> LoadAsync<T>(string fileName, CancellationToken ct = default)
        {
            await using (var stream = await _client.GetStreamAsync(BASE_URL + fileName, ct))
            {
                return (await JsonSerializer.DeserializeAsync<T>(stream, cancellationToken: ct))!;
            }
        }
    }
}
