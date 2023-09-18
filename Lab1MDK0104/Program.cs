using System.Diagnostics;

Console.Write("Введите размер массиива: ");
int number = Convert.ToInt32(Console.ReadLine());
Thread.CurrentThread.Name = "main";
Sorts(number);
Thread myThread = new Thread(Sorts);
myThread.Name = "back";
myThread.Start(number);
void Sorts(object? size)
{
    Console.WriteLine();
    Console.WriteLine(Thread.CurrentThread.Name + " начал работу...");
    Random random = new Random();
    int[] Numbers = new int[(int)size!];
    for (int i = 0; i < Numbers.Length; i++)
    {
        Numbers[i] = random.Next(-100, 100);
    }
    Console.WriteLine(String.Join(",", Numbers));
    Stopwatch stpWatch = new Stopwatch();
    stpWatch.Start();
    int[] sortedNumbers = Numbers.Where(num => num >= 0).OrderBy(num => num).ToArray();
    stpWatch.Stop();
    Console.WriteLine();
    foreach (int num in sortedNumbers)
    {
        Console.Write(num + " ");
    }

    Console.WriteLine();
    Console.WriteLine("StopWatch: " + stpWatch.ElapsedTicks.ToString());
}
