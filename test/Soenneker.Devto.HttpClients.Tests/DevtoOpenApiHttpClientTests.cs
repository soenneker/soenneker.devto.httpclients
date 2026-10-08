using Soenneker.Devto.HttpClients.Abstract;
using Soenneker.Tests.HostedUnit;
using System.Threading;

namespace Soenneker.Devto.HttpClients.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class DevtoOpenApiHttpClientTests : HostedUnitTest
{
    private readonly IDevtoOpenApiHttpClient _httpclient;

    public DevtoOpenApiHttpClientTests(Host host) : base(host)
    {
        _httpclient = Resolve<IDevtoOpenApiHttpClient>(true);
    }

    [Test]
    public async System.Threading.Tasks.Task Get_configures_and_reuses_client(CancellationToken cancellationToken)
    {
        var client = await _httpclient.Get(cancellationToken: cancellationToken);
        await Assert.That(client.BaseAddress!.AbsoluteUri).IsEqualTo("https://dev.to/");
        await Assert.That(System.Linq.Enumerable.Single(client.DefaultRequestHeaders.GetValues("api-key"))).IsEqualTo("test-api-key");
        await Assert.That(System.Linq.Enumerable.Single(client.DefaultRequestHeaders.GetValues("Accept"))).IsEqualTo("application/vnd.forem.api-v1+json");
        await Assert.That(object.ReferenceEquals(client, await _httpclient.Get(cancellationToken: cancellationToken))).IsTrue();
    }
}


