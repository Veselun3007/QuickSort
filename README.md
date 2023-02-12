# QuickSort

The project was developed as a course work. The task of the course work was to study the algorithm and study the possibility of its parallelization.
You can learn more about the algorithm [here](https://en.wikipedia.org/wiki/Quicksort).

## Project structure
```bash
QuickSortFolder
|   QuickSort.sln
|   
+---BenchmarkForQuickSort
|   |   BenchmarkForQuickSort.csproj
|   |   Program.cs
+---Common
|   |   Common.csproj
|   |   
|   \---ConsoleIO
|           ArraysMethods.cs
|           ConsoleSettings.cs
|           Entering.cs
|           
\---QuickSort
    |   Program.cs
    |   QuickSort.csproj
    |   
    +---AlgorithmsQS
    |       DirectQuickSort.cs
    |       ExperentThreadQuickSort.cs
    |       ParallelQuickSort.cs
    |       TaskQuickSort.cs
    |       ThreadQuickSort.cs
    |       
    +---Commands
    |       CommandInfo.cs
    |       CommandManager.cs
    |       MainManager.cs
    |       
    \---Helpers
            SortingHelpers.cs
 ```           

- **BenchmarkForQuickSort** - contains tests for testing sorting algorithms.
- **Common** - contains auxiliary classes.
- **QuickSort** - contains the main logic of the program and the tool for checking the correctness of sorting

## Information about tools and their use

The main functionality for using threads in the application is concentrated in the `System.Threading` namespace. It defines a class representing a separate thread - the `Thread` class. To parallelize the QuickSort algorithm, it is necessary to transfer subtasks to a separate thread.

![Flow graph of parallel QuickSor for Threads](https://user-images.githubusercontent.com/70714177/218247798-d24fd0a2-91bf-4d33-920a-eb97e6be0d39.png)

**Image 1 - Flow graph of parallel QuickSort**
--- ---

The `Parallel.Invoke()` method enables parallel execution several subtasks. The `Parallel.Invoke` method takes an array of Action objects as a parameter, i.e we can pass to this method a set of methods that will be called when its instantiation, and the number of methods may be different.

![Working diagram of the Parallel.Invoke method](https://user-images.githubusercontent.com/70714177/218247520-5d4c14fe-35c7-4109-8006-5a104e6cf01a.png)

**Image 2 - Working diagram of the Parallel.Invoke method**
--- ---

The Task class is not normally used for similar tasks, so implementing the algorithm using it is simple an experiment conducted to demonstrate this possibility. Task class used for `I/O bound` tasks, in this case it is used for a `CPU bound` task, i.e. not as intended.

![Working diagram of Task class](https://user-images.githubusercontent.com/70714177/218247567-806364ca-0fb9-4da4-9b58-d8f606c22849.png)

**Image 3 - Working diagram of Task class**
--- ---

The `Benchmark.NET` library was used for testing. A benchmark is a simple test that provides a set of quantified results that can help you determine whether your code update increased, decreased, or had no effect on performance. It is necessary to understand performance metrics of your application's methods to use them throughout the code optimization process. A reference test can have wide range or it may be a microtest that assesses small changes in source code.

**Test result for 100,000 items**

|            Method |     Mean |     Error |    StdDev | Rank |   Gen0 | Allocated |
|------------------ |---------:|----------:|----------:|-----:|-------:|----------:|
|     TaskQuickSort | 6.777 ms | 0.1268 ms | 0.1356 ms |    4 | 7.8125 |   40633 B |
|   DirectQuickSort | 4.685 ms | 0.0912 ms | 0.1279 ms |    3 |      - |       3 B |
|   ThreadQuickSort | 4.124 ms | 0.0824 ms | 0.1773 ms |    2 |      - |       3 B |
| ParallelQuickSort | 4.031 ms | 0.0794 ms | 0.1236 ms |    2 |      - |    2837 B |
|    UsingArraySort | 1.180 ms | 0.0206 ms | 0.0393 ms |    1 |      - |       1 B |
 
 **Legends**
 - ``Mean``      : Arithmetic mean of all measurements
 - ``Error``     : Half of 99.9% confidence interval
 - ``StdDev``    : Standard deviation of all measurements
 - ``Rank``      : Relative position of current benchmark mean among all benchmarks (Arabic style)
 - ``Gen0``      : GC Generation 0 collects per 1000 operations
 - ``Allocated`` : Allocated memory per single operation (managed only, inclusive, 1KB = 1024B)

>  #### Testing was carried out on a laptop with the following configurations:
>   - Intel® Core™ i7-8550U;
>   - 16 Gb RAM;
>   - OS - Windows 11.
--- ---

#### I recommend that you familiarize yourself with this:
- [``Thread``](https://learn.microsoft.com/en-us/dotnet/api/system.threading.thread?view=net-7.0)
- [``Parallel``](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.parallel?view=net-7.0) 
- [``Task``](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task?view=net-7.0)
- [``Benchmark.NET``](https://github.com/dotnet/BenchmarkDotNet)
- ``CPU bound``/``I/O bound`` tasks

## Conclusions

From the results of the study, I conclude that the performance of the QuickSort algorithm does not increase from parallelization perhaps this is related to the recursive implementation of the data algorithm. In general, direct and parallel implementations of the algorithm are the same productive, but different data may lead to different results. 

I also assume the following:
- ``Task`` class is intended for ``I/O bound`` tasks, thus, it is not appropriate to use it in our context. But the possibility of its usage exists and it's easy to implement.
- ``Parallel`` is a tool that allows you to easily parallelize code. Its use in such tasks is fully justified, and proper application can increase performance. Unfortunately in the course work, the method did not show itself in the best way.
- ``Thread`` is designed for tasks of this kind. The main drawback is complexity of understanding for correct implementation.

I also recommend that you familiarize yourself with the ``Sort()`` method of the ``Array`` class. This can be done on the [official page](https://github.com/microsoft/referencesource/blob/master/mscorlib/system/array.cs) on the GitHub platform, or by using the ``dotPeek`` tool.

#### I hope this helps someone, good luck.

## License

Distributed under the MIT License. See ``License.txt`` for more information.
