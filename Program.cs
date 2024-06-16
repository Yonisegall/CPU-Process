
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length != 1 || !int.TryParse(args[0], out int n)){

            Console.WriteLine("Usage: CPU-Process <n>");
            return;
        }

        Console.WriteLine("Running intensive calculations...");

        Stopwatch runinng_time = new Stopwatch();

        double result = 1.0;

        runinng_time.Start();

        for (int i = 1; i < n; i++)
        {

            result += Math.Pow(Math.Cos(Math.Sqrt(i) * 9999), 9);
        }
        runinng_time.Stop();

        Console.WriteLine(result);

        Console.WriteLine($"Time for {n} iterations: {runinng_time.Elapsed.TotalMilliseconds} ms");
    }
}

