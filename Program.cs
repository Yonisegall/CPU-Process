
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {

        int iterations = int.Parse(args[0]);  // Number of the iterations

        int concurrentInstances = int.Parse(args[1]); // Number of concurrent instances

        Task<double>[] tasks = new Task<double>[concurrentInstances];

        Console.WriteLine("Running intensive calculations...");

        for (int i = 0; i < concurrentInstances; i++){
            tasks[i] = Task.Run(() => RunIntensiveCalculations(iterations));
        }

        Task.WaitAll(tasks);

        double totalTime = 0;

        for (int i = 0; i < concurrentInstances; i++){
            totalTime += tasks[i].Result;
        }

        double averageTime = totalTime / concurrentInstances;

        Console.WriteLine($"Average time for {concurrentInstances} instances: {averageTime} ms");
    }



    static double RunIntensiveCalculations(int iterations){

        Stopwatch runinng_time = new Stopwatch();

        double result = 1.0;

        runinng_time.Start();

        for (int i = 1; i < iterations; i++){

            result += Math.Pow(Math.Sin(Math.Pow(Math.Cos(Math.Sqrt(i) * 1999), 10)), 22) /
                      Math.Pow(Math.Sin(Math.Pow(Math.Cos(Math.Sqrt(i) * 1999), 9)), 5);

            for (int j = 1; j < iterations; j++){

                result += Math.Log(Math.Sqrt(j) * result);
            }
        }

        runinng_time.Stop();

        return runinng_time.Elapsed.TotalMilliseconds;

        //Console.WriteLine(result);

        //Console.WriteLine($"Time for {iterations} iterations: {runinng_time.Elapsed.TotalMilliseconds} ms");
    }
}

