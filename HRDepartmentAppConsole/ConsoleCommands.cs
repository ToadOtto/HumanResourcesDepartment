using System;
using System.Linq;
using CoreInterfaces;

namespace HRDepartmentAppConsole;

partial class Program
{
    private static void AddWorker()
    {
        IWorker worker = CreateNewWorker();
        IDocument document = CreateNewDocument($"Hired worker: {worker.Name}");

        var company = container.GetInstance<ICompany>();
        company.AddWorker(worker);
        company.AddDocument(document);

        WriteMessage($"Added worker: {worker.Name}");
    }

    private static void FireWorker()
    {
        IWorker chosenWorker = SelectWorker();

        if (chosenWorker is null)
        {
            return;
        }
        IDocument document = CreateNewDocument($"Fired worker: {chosenWorker.Name}");

        var company = container.GetInstance<ICompany>();
        company.FireWorker(chosenWorker);
        company.AddDocument(document);

        WriteMessage($"Fired worker: {chosenWorker.Name}");
    }

    private static void ChangeSalary()
    {
        IWorker chosenWorker = SelectWorker();

        if (chosenWorker is null)
        {
            return;
        }
        IDocument document = CreateNewDocument($"Changed salary of {chosenWorker.Name} to {chosenWorker.Salary}");

        chosenWorker.ChangeSalary(ReadIntLine($"Current salary is {chosenWorker.Salary}. Enter new salary: "));

        WriteMessage($"Changed salary of {chosenWorker.Name} to {chosenWorker.Salary}");
    }

    private static void PaySalary()
    {
        IWorker chosenWorker = SelectWorker();

        if (chosenWorker is null)
        {
            return;
        }
        IDocument document = CreateNewDocument($"Payed salary to worker: {chosenWorker.Name}");

        chosenWorker.PutOnBalance(chosenWorker.Salary);

        var company = container.GetInstance<ICompany>();
        company.AddDocument(document);

        WriteMessage($"Payed salary to {chosenWorker.Name}");
    }

    private static void ShowAllWorkers()
    {
        var workers = GetAllWorkers();

        if (workers is null || workers.Any() == false)
        {
            WriteErrorMessage($"There are no workers!");
            return;
        }

        foreach (var worker in workers)
        {
            Console.WriteLine($"Name: {worker?.Name}. Age: {worker?.Age}. Profession: {worker?.Profession}. " +
                              $"Salary: {worker?.Salary}. Balance: {worker?.Balance}");
        }
    }

    private static void ShowAllDocuments()
    {
        var documents = GetAllDocuments();

        if (documents is null || documents.Any() == false)
        {
            Console.WriteLine($"There are no documents!");
            return;
        }

        foreach (var document in documents)
        {
            Console.WriteLine(String.Format($"Document created at {document.DateTime:G} in the {document.CompanyName}. {document.Message})"));
        }
    }

    private static void ShowCompanyInfo()
    {
        var company = container.GetInstance<ICompany>();
        Console.WriteLine($"Company Name: {company.Name}\nLocated at: {company.Adress}");
    }

    private static void ShowCommandsList()
    {
        Command ID = 0;
        foreach (string command in Enum.GetNames(typeof(Command)))
        {
            Console.WriteLine($"{(int)ID}.{command}");
            ID++;
        }
    }

    private static void ConsoleExit()
    {
        System.Diagnostics.Process.GetCurrentProcess().Kill();
        Environment.Exit(0);
    }
}
