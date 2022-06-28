using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Loggers;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Validators;
using NetEscapades.EnumGenerators;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

var benchmarkConfig = new ManualConfig()
                    .WithOptions(ConfigOptions.DisableOptimizationsValidator)
                    .AddValidator(JitOptimizationsValidator.DontFailOnError)
                    .AddLogger(ConsoleLogger.Default)
                    .AddColumnProvider(DefaultColumnProviders.Instance);

BenchmarkRunner.Run<ColorBenchmarks>(benchmarkConfig);

[EnumExtensions(ExtensionClassName ="MyCustomColorExtensionClass", ExtensionClassNamespace = "MyCustomColorExtensionClassNamespace")]
public enum Color
{
    Green,
    Red,
    Blue,
    [Display(Name = "It's yellow")]
    Yellow,
    [Display(Name = "Clear blue")]
    Cyan,
    Pink
}

[MemoryDiagnoser(false)]
public class ColorBenchmarks
{
    [Benchmark]
    public string EnumToString()
    {
        return Color.Blue.ToString();
    }

    [Benchmark]
    public string EnumToStringWithCache()
    {
        return Color.Blue.ToStringWithCache();
    }

    [Benchmark]
    public string EnumToStringFastCustom()
    {
        return Color.Blue.ToStringFastCustom();
    }

    [Benchmark]
    public string EnumToStringFast()
    {
        return Color.Blue.ToStringFast();
    }

    [Benchmark]
    public bool EnumIsDefined()
    {
        return Enum.IsDefined(typeof(Color), "Blue");
    }

    [Benchmark]
    public bool EnumIsDefinedFastCustom()
    {
        return "Blue".IsDefinedFastCustom();
    }

    [Benchmark]
    public bool EnumIsDefinedFast()
    {
        return MyCustomColorExtensionClassNamespace.MyCustomColorExtensionClass.IsDefined("Blue");
    }

    [Benchmark]
    public (bool, Color) EnumTryParse()
    {
        var couldParse = Enum.TryParse("Blue", out Color parsedColor);
        return (couldParse, parsedColor);
    }

    [Benchmark]
    public (bool, Color?) EnumTryParseFastCustom()
    {
        var couldParse = CustomColorExtensions.TryParseFastCustom("Blue", out Color? parsedColor);
        return (couldParse, parsedColor);
    }

    //[Benchmark]
    //public (bool, Color) EnumTryParseFast()
    //{
    //    var couldParse = ColorExtensions.TryParse("Blue", out Color parsedColor);
    //    return (couldParse, parsedColor);
    //}
}

public static class ColorCachingExtensions
{
    private static IDictionary<Color, string> colorNames = new Dictionary<Color, string>();

    public static string ToStringWithCache(this Color color)
    {
        if (colorNames.ContainsKey(color))
        {
            return colorNames[color];
        }

        string colorName = color.ToString();
        colorNames.Add(color, colorName);
        return colorName;
    }
}

public static class CustomColorExtensions
{
    public static string ToStringFastCustom(this Color color)
        => color switch
        {
            Color.Green => nameof(Color.Green),
            Color.Blue => nameof(Color.Blue),
            Color.Red => nameof(Color.Red),
            Color.Yellow => nameof(Color.Yellow),
            Color.Cyan => nameof(Color.Cyan),
            Color.Pink => nameof(Color.Pink),
            _ => color.ToString(),
        };

    public static bool IsDefinedFastCustom(this string color)
        => color switch
        {
            "Green" => true,
            "Blue" => true,
            "Red" => true,
            "Yellow" => true,
            "Cyan" => true,
            "Pink" => true,
            _ => false
        };

    public static bool TryParseFastCustom(string color, out Color? parsedColor)
    {
        parsedColor = null;
        switch (color)
        {
            case "Green":
                parsedColor = Color.Green;
                return true;
            case "Blue":
                parsedColor = Color.Blue;
                return true;
            case "Cyan":
                parsedColor = Color.Cyan;
                return true;
            case "Pink":
                parsedColor = Color.Pink;
                return true;
            case "Red":
                parsedColor = Color.Red;
                return true;
            case "Yellow":
                parsedColor = Color.Yellow;
                return true;
        }
        return false;
    }
}