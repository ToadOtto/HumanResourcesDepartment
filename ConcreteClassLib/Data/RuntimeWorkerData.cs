using CoreInterfaces;

namespace ConcreteClassLib.Data;

public class RuntimeWorkerData : IData<IWorker>
{
    public List<IWorker> Workers { get; private set; }

    public RuntimeWorkerData()
    {
        Workers = new List<IWorker>();
    }

    public void Add(IWorker worker)
    {
        Workers.Add(worker);
    }

    public IEnumerable<IWorker> ReadAll()
    {
        return Workers;
    }

    public void Remove(IWorker worker)
    {
        Workers.Remove(worker);
    }
}
