namespace SQLData;

using System.Collections.Generic;
using CoreInterfaces;

public class WorkerSQLData : IData<IWorker>
{
    public void Add(IWorker worker)
    {
        WorkerEntity workerEntity = new WorkerEntity(worker);
        using (HRDepartmentAppDBContext db = new HRDepartmentAppDBContext())
        {
            db.Workers.Add(workerEntity);
            db.SaveChanges();
        }
    }

    public IEnumerable<IWorker> ReadAll()
    {
        using (HRDepartmentAppDBContext db = new HRDepartmentAppDBContext())
        {
            return db.Workers.ToList();
        }
    }

    public void Remove(IWorker worker)
    {
        using (HRDepartmentAppDBContext db = new HRDepartmentAppDBContext())
        {
            var workerEntity = db.Workers.Where(w => w.Name == $"{worker.Name}").First();
            db.Workers.Remove(workerEntity);    
            db.SaveChanges();
        }
    }
}
