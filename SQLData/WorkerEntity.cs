using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CoreInterfaces;

namespace SQLData;
public class WorkerEntity : IWorker
{
#nullable disable
    [Key]
    public int ID { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string Profession { get; set; }
    public decimal Salary { get; set; }
    public decimal Balance { get; set; }
    public WorkerEntity() { }

    public WorkerEntity(IWorker worker)
    {
        Name = worker.Name;
        Age = worker.Age;
        Profession = worker.Profession;
        Salary = worker.Salary;
        Balance = worker.Balance;
    }
    public void PutOnBalance(decimal sum)
    {
        using (HRDepartmentAppDBContext db = new HRDepartmentAppDBContext())
        {
            var thisworker = db.Workers.FirstOrDefault(w => w.Name == Name);
            thisworker.Balance += sum;
            db.Update(thisworker);
            db.SaveChanges();
        }
    }
    public void ChangeSalary(decimal sum)
    {
        using (HRDepartmentAppDBContext db = new HRDepartmentAppDBContext())
        {
            var thisworker = db.Workers.FirstOrDefault(w => w.Name == Name);
            thisworker.Salary = sum;
            db.Update(thisworker);
            db.SaveChanges();
        }
    }
}
