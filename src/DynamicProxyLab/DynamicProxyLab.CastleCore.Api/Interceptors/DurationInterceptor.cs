using Castle.DynamicProxy;
using System.Diagnostics;

namespace DynamicProxyLab.CastleCore.Api.Interceptors
{
    public class DurationInterceptor : IInterceptor
    {
        private readonly ILogger<DurationInterceptor> _logger;

        public DurationInterceptor(ILogger<DurationInterceptor> logger)
        {
            _logger = logger;
        }

        public void Intercept(IInvocation invocation)
        {
            var sw = Stopwatch.StartNew();
            try
            {
                invocation.Proceed();
            }
            finally
            {
                sw.Stop();
                _logger.LogInformation("{MethodName} method took {Duration}ms", invocation.Method.Name, sw.ElapsedMilliseconds);
            }
        }
    }
}
