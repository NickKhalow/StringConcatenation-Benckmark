using System.Text;
using BenchmarkDotNet.Attributes;

BenchmarkDotNet.Running.BenchmarkRunner.Run<StringBenchmark>();

[MemoryDiagnoser]
public class StringBenchmark
{
    [Params(1, 10, 100, 10000)]
    public int repeats;

    [Benchmark]
    public string StringBuilder()
    {
        var stringBuilder = new StringBuilder();
        for (int i = 0; i < repeats; i++)
        {
            stringBuilder.Append(i);
        }
        return stringBuilder.ToString();
    }

    [Benchmark]
    public string StringBuilderAllocated()
    {
        var stringBuilder = new StringBuilder(repeats);
        for (int i = 0; i < repeats; i++)
        {
            stringBuilder.Append(i);
        }
        return stringBuilder.ToString();
    }

    [Benchmark]
    public string StringPlusString()
    {
        var s = string.Empty;
        for (int i = 0; i < repeats; i++)
        {
            s += i.ToString();
        }
        return s;
    }
}