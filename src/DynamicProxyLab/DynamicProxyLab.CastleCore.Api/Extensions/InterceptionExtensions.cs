using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace DynamicProxyLab.CastleCore.Api.Extensions
{
    internal static class InterceptionExtensions
    {
        internal static void AddInterceptedSingleton<TInterface, TImplementation, TInterceptor>(this IServiceCollection services)
            where TInterface : class
            where TImplementation : class, TInterface
            where TInterceptor : class, IInterceptor
        {
            services.TryAddSingleton<IProxyGenerator, ProxyGenerator>();
            services.AddSingleton<TImplementation>();
            services.TryAddTransient<TInterceptor>();
            services.AddSingleton(provider =>
            {
                var proxyGenerator = provider.GetRequiredService<IProxyGenerator>();
                var implementation = provider.GetRequiredService<TImplementation>();
                var interceptor = provider.GetRequiredService<TInterceptor>();
                return proxyGenerator.CreateInterfaceProxyWithTarget<TInterface>(implementation, interceptor);
            });
        }
    }
}
