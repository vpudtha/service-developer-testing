﻿using Alba;
using Alba.Security;
using Microsoft.Extensions.DependencyInjection;


namespace BugTrackingApi.ContractTests.Fixtures;
public abstract class BaseAlbaFixture : IAsyncLifetime
{

    public IAlbaHost AlbaHost = null!;
    public async Task DisposeAsync()
    {
        await AlbaHost.DisposeAsync();
    }

    public async Task InitializeAsync()
    {

        AlbaHost = await Alba.AlbaHost.For<Program>(builder => builder.ConfigureServices(services => RegisterServices(services)), GetStub());
    }

    protected abstract void RegisterServices(IServiceCollection services);
    protected virtual Task? Initializeables() { return default; }
    protected virtual Task? Disposables() { return default; }
    protected virtual AuthenticationStub GetStub()
    {
        return new AuthenticationStub();
    }
}