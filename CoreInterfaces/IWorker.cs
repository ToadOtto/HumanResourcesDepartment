namespace CoreInterfaces;
public interface IWorker
{
    string Name { get; set; }
    string Profession { get; set; }
    int Age { get; set; }
    decimal Salary { get; set; }
    decimal Balance { get; set; }
    void PutOnBalance(decimal sum);
    void ChangeSalary (decimal sum);
}
