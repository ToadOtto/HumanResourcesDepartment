using System;
using System.Collections.Generic;
using System.Linq;
using ConcreteClassLib;
using ConcreteClassLib.Data;
using SQLData;
using CoreInterfaces;
using SimpleInjector;

namespace HRDepartmentAppConsole;

partial class Program
{
    #region Dependency Injection
    #region DIContainer
    static Container container = new Container();
    private static void RegistrateAll()
    {
        container.Register<ICompany, Company>(Lifestyle.Singleton);
        container.Register<IWorker, Worker>(Lifestyle.Transient);
        container.Register<IDocument, Document>(Lifestyle.Transient);
        container.Register<IData<IWorker>, WorkerSQLData>(Lifestyle.Singleton);
        container.Register<IData<IDocument>, DocumentSQLData>(Lifestyle.Singleton);
    }
    #endregion
    public static void CreateNewCompany(string name, string adress)
    {
        var company = container.GetInstance<ICompany>();

        company.Name = name;
        company.Adress = adress;
    }

    public static IWorker CreateNewWorker()
    {
        var worker = container.GetInstance<IWorker>();

        worker.Name = ReadLineCheckIfEmpty("Enter name: ");
        worker.Profession = ReadLineCheckIfEmpty("Enter profession: ");
        worker.Age = ReadIntLine("Enter age: ");
        worker.Salary = ReadIntLine("Enter salary: ");

        return worker;
    }

    public static IDocument CreateNewDocument(string message)
    {
        var documents = GetAllDocuments();
        var document = container.GetInstance<IDocument>();
        
        document.Message = message;

        return document;
    }

    private static IEnumerable<IDocument> GetAllDocuments()
    {
        var company = container.GetInstance<ICompany>();

        return company.GetAllDocuments();
    }

    private static IEnumerable<IWorker> GetAllWorkers()
    {
        var company = container.GetInstance<ICompany>();

        return company.GetAllWorkers();
    }
    #endregion
    public static void Main(string[] args)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;

        RegistrateAll();

        CreateNewCompany("Microsoft", "18 Turtle Street, California");

        Console.WriteLine($"Human Resource Department: Console Application\n-Type help for a commands list");

        while (true)
        {
            try
            {
                switch (ReadCommand())
                {
                    case Command.AddWorker:
                        AddWorker();
                        break;

                    case Command.FireWorker:
                        FireWorker();
                        break;

                    case Command.ChangeSalary:
                        ChangeSalary();
                        break;

                    case Command.PaySalary:
                        PaySalary();
                        break;

                    case Command.ShowAllWorkers:
                        ShowAllWorkers();
                        break;

                    case Command.ShowAllDocuments:
                        ShowAllDocuments();
                        break;

                    case Command.ShowCompanyInfo:
                        ShowCompanyInfo();
                        break;

                    case Command.Help:
                        ShowCommandsList();
                        break;

                    case Command.Exit:
                        ConsoleExit();
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
        }
    }

}