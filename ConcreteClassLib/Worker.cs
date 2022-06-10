using CoreInterfaces;

namespace ConcreteClassLib;
public class Worker : IWorker
{
#nullable disable
    public string Name { get; set; }
    public int Age { get; set; }
    public string Profession { get; set; }
    public decimal Salary { get; set; }
    public decimal Balance { get; set; }
    public void PutOnBalance(decimal sum)
    {
        Balance += sum;
    }
    public void ChangeSalary(decimal sum)
    {
        Salary = sum;
    }
}
