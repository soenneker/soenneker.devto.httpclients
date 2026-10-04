using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;

namespace Soenneker.Devto.HttpClients.Abstract;

/// <summary>
/// Provides a cached HTTP client for the DEV.to v1 API.
/// </summary>
public interface IDevtoOpenApiHttpClient: IDisposable, IAsyncDisposable
{
    /// <summary>Gets the shared client with the API key, API version, and user agent headers.</summary>
    ValueTask<HttpClient> Get(CancellationToken cancellationToken = default);
}


