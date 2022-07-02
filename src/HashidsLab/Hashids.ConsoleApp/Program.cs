// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Loggers;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Validators;
using HashidsNet;

var benchmarkConfig = new ManualConfig()
                    .WithOptions(ConfigOptions.DisableOptimizationsValidator)
                    .AddValidator(JitOptimizationsValidator.DontFailOnError)
                    .AddLogger(ConsoleLogger.Default)
                    .AddColumnProvider(DefaultColumnProviders.Instance);
BenchmarkRunner.Run<HashidsBenchmark>(benchmarkConfig);

[MemoryDiagnoser(false)]
public class HashidsBenchmark
{
    private static readonly Hashids hashids = new ("testlab", 8);

    [Benchmark]
    public int IntFromHash()
    {
        return hashids.Decode("rBaLjAgw")[0];
    }

    [Benchmark]
    public string HashFromInt()
    {
        return hashids.Encode(1);
    }
}