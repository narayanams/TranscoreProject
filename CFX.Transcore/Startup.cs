using System;
using System.IO;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;


[assembly: FunctionsStartup(typeof(CallSPFromAzureFunction.Startup))]

namespace CallSPFromAzureFunction
{
    public class Startup : FunctionsStartup
    {
       

        static string basePath = IsDevelopmentEnvironment() ?
            Environment.GetEnvironmentVariable("AzureWebJobsScriptRoot") :
            $"{Environment.GetEnvironmentVariable("HOME")}\\site\\wwwroot";

        public static IConfiguration Configuration { get; } = new ConfigurationBuilder()
          .SetBasePath(basePath)
          .AddJsonFile("appsettings.json", false, true)
          .AddEnvironmentVariables()
          .Build();

        public static bool IsDevelopmentEnvironment()
        {
            return "Development".Equals(Environment.GetEnvironmentVariable("AZURE_FUNCTIONS_ENVIRONMENT"), StringComparison.OrdinalIgnoreCase);
        }

        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddSingleton<IConfiguration>(Configuration);

            //builder.Services.AddTransient<IKeyvaultProvider>(x => new KeyvaultProvider(Configuration));
            //builder.Services.AddLogging(
            //    x => x.AddSerilog(
            //        new LoggerConfiguration()
            //       .MinimumLevel.Information()
            //       .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
            //       .Enrich.FromLogContext()
            //       .WriteTo.Console()
            //       .WriteTo.ApplicationInsights(TelemetryConfiguration.Active, TelemetryConverter.Traces)
            //       .CreateLogger(),
            //        dispose: true
            //        ));

            //builder.Services.AddTransient<IMasterDataService, MasterDataService>();
            //builder.Services.AddTransient<IOdataService, ODataService>();
            //builder.Services.AddTransient<IProxyService, ProxyService>();
            //builder.Services.AddTransient<IGeoService, GeoService>();
            //builder.Services.AddTransient<IOptionSetDataService, OptionSetDataService>();
            //builder.Services.AddTransient<IAccountService, AccountService>();
            //builder.Services.AddTransient<IBatchService, BatchService>();

            //var maxNumberOfRetriesFromConfig = Configuration[ConfigurationKeys.CircuiBreakerMaxNumberOfRetries];
            //var incrementalDelayWhenRetryingFromConfig = Configuration[ConfigurationKeys.CircuiBreakerIncrementalDelayWhenRetryingInMilliseconds];
            //var maxTimeDifferenceToResetCircuitBreakerFromConfig = Configuration[ConfigurationKeys.CircuiBreakerMaximumTimeDifferenceToResetCircuitBreakerInMinutes];
            //var minExceptionCounterToOpenCircuitFromConfig = Configuration[ConfigurationKeys.CircuiBreakerMinimumExceptionCounterToOpenCircuit];
            //var minTimeToTryClosingCircuitFromConfig = Configuration[ConfigurationKeys.CircuiBreakerMinimumTimeToTryClosingCircuitInSeconds];

            //bool isNumberOfRetriesAvailable = int.TryParse(maxNumberOfRetriesFromConfig, out int maxNumberOfRetries);
            //bool isIncrementalDelayAvailable = int.TryParse(incrementalDelayWhenRetryingFromConfig, out int incrementalDelayWhenRetrying);
            //bool isMaxTimeDiffToResetAvailable = int.TryParse(maxTimeDifferenceToResetCircuitBreakerFromConfig, out int maxTimeDifferenceToResetCircuitBreakerInMinutes);
            //bool isMinExceptionCounterToOpenCircuitAvailable = int.TryParse(minExceptionCounterToOpenCircuitFromConfig, out int minExceptionCounterToOpenCircuit);
            //bool isMinTimeToTryClosingCircuitAvailable = int.TryParse(minTimeToTryClosingCircuitFromConfig, out int minTimeToTryClosingCircuitInSeconds);

            //if (!isNumberOfRetriesAvailable || !isIncrementalDelayAvailable || !isMaxTimeDiffToResetAvailable || !isMinExceptionCounterToOpenCircuitAvailable || !isMinTimeToTryClosingCircuitAvailable)
            //{
            //    throw new Exception(CommonUtility.ErrorMessages.CircuitBreakerConfigError);
            //}

            //var circuitBreakerPatternConstants = new CircuitBreakerPatternConstants
            //{
            //    InitialTimespanDifference = (DateTime.UtcNow.Ticks - DateTime.MinValue.Ticks),
            //    MaximumNumberOfRetries = maxNumberOfRetries,
            //    IncrementalDelayWhenRetrying = incrementalDelayWhenRetrying,
            //    MaximumTimeDifferenceToResetCircuitBreaker = new TimeSpan(0, maxTimeDifferenceToResetCircuitBreakerInMinutes, 0).Ticks,
            //    MinimumExceptionCounterToOpenCircuit = minExceptionCounterToOpenCircuit,
            //    MinimumTimeToTryClosingCircuit = new TimeSpan(0, 0, minTimeToTryClosingCircuitInSeconds).Ticks,
            //};

            //builder.Services.AddSingleton<IExecuteDynamicsServiceCall>(x => new ExecuteDynamicsServiceCall(x.GetRequiredService<ILogger<ExecuteDynamicsServiceCall>>(), x.GetRequiredService<IOdataService>(), circuitBreakerPatternConstants));

            //var redisCacheExpirationTimeSpan = Configuration[ConfigurationKeys.RedisCacheDefaultExpiration];
            //if (string.IsNullOrEmpty(redisCacheExpirationTimeSpan))
            //{
            //    redisCacheExpirationTimeSpan = new TimeSpan(1, 0, 0, 0).ToString();
            //}

            //var memoryCacheExpirationTimeSpan = Configuration[ConfigurationKeys.MemoryCacheDefaultExpiration];
            //if (string.IsNullOrEmpty(memoryCacheExpirationTimeSpan))
            //{
            //    memoryCacheExpirationTimeSpan = new TimeSpan(1, 0, 0, 0).ToString();
            //}

            //builder.Services.AddScoped((x) =>
            //{
            //    return new RedisCacheProvider(x.GetService<IDistributedCache>(), Constants.MicroservicePrefixName, redisCacheExpirationTimeSpan);
            //});
            //builder.Services.AddScoped((x) =>
            //{
            //    return new InMemoryCacheProvider(x.GetService<IMemoryCache>(), Constants.MicroservicePrefixName, memoryCacheExpirationTimeSpan);   //Prefix value can be different or same for both cache implementations.
            //});
            //builder.Services.AddScoped<ICacheService, CacheService>();
            //builder.Services.AddTransient<Func<CacheProviderType, ICacheProvider>>(serviceProvider => key =>
            //{
            //    switch (key)
            //    {
            //        case CacheProviderType.RedisCacheProvider:
            //            return serviceProvider.GetService<RedisCacheProvider>();
            //        case CacheProviderType.InMemoryCacheProvider:
            //            return serviceProvider.GetService<InMemoryCacheProvider>();
            //        default:
            //            return null;
            //    }
            //});

            //builder.Services.AddMemoryCache();
            //builder.Services.AddDistributedRedisCache(option =>
            //{
            //    option.Configuration = keyvaultProvider.GetSecretKeyAsync(KeyVaultKeys.RedisCacheConnectionString);
            //    option.InstanceName = keyvaultProvider.GetSecretKeyAsync(KeyVaultKeys.RedisCacheInstance);
            //});
        }
    }
}
