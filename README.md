# QuickSort

The project was developed as a course work. The task of the course work was to study the algorithm and study the possibility of its parallelization. Parallelization was performed using C# tools, including the following:
- `TPL library` facilities **_([Task](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task?view=net-7.0), [Parallel](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.parallel?view=net-7.0))_**
- Using namespace `System.Threading`

You can learn more about the algorithm [here](https://en.wikipedia.org/wiki/Quicksort):

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

## Information about tools

The `Parallel.Invoke()` method enables parallel execution several subtasks. The `Parallel.Invoke` method takes an array of Action objects as a parameter, i.e we can pass to this method a set of methods that will be called when its implementation, and the number of methods may be different.

![image](https://user-images.githubusercontent.com/70714177/218137680-78fc5497-103a-4b4c-9e8d-1a45cba00daa.png)

**Working diagram of the Parallel.Invoke method**

The Task class is not normally used for similar tasks, so implementing the algorithm using it is simple an experiment conducted to demonstrate this possibility. Task class used for `I/O bound` tasks, in this case it is used for a `CPU bound` task, i.e. not as intended.

![image](https://user-images.githubusercontent.com/70714177/218137813-cee7c861-9257-49d9-a335-065ef0611ec3.png)

**Working diagram of Task class**
