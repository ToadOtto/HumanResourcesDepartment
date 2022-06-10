using System;
using CoreInterfaces;
using System.Linq;

namespace HRDepartmentAppConsole;

partial class Program
{
    private static string ReadLineCheckIfEmpty(string title)
    {
        while (true)
        {
            Console.Write(title);
            string input = Console.ReadLine();

            if (string.IsNullOrEmpty(input))
            {
                WriteErrorMessage("Input can't be empty!");
                continue;
            }

            return input;
        }
    }

    private static int ReadIntLine(string title)
    {
        while (true)
        {
            if (int.TryParse(ReadLineCheckIfEmpty(title), out int value) == false || value < 0)
            {
                WriteErrorMessage("Input needs to be a number!");
                continue;
            }

            return value;
        }

    }

    private static Command ReadCommand()
    {
        while (true)
        {
            if (Enum.TryParse(ReadLineCheckIfEmpty("Введите комманду: "), true, out Command command) == false || (int)command >= Enum.GetNames(typeof(Command)).Length)
            {
                WriteErrorMessage("Input needs to be a command!");
                continue;
            }

            return command;
        }
    }

    private static IWorker SelectWorker()
    {
        var workers = GetAllWorkers();

        while (true)
        {

            if (workers is null || workers.Any() == false)
            {
                WriteErrorMessage("There are no workers!");
                return null;
            }

            var workerName = ReadLineCheckIfEmpty("Enter worker's name: ");
            var chosenWorker = workers.FirstOrDefault(worker => worker.Name.Equals(workerName));

            if (chosenWorker is null)
            {
                WriteErrorMessage($"Worker {chosenWorker} doesn't exist!");
                continue;
            }

            return chosenWorker;
        }
    }
    private static void WriteMessage(string message)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"{message}");
        Console.ForegroundColor = ConsoleColor.Yellow;
    }
    private static void WriteErrorMessage(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"{message}");
        Console.ForegroundColor = ConsoleColor.Yellow;
    }
}
