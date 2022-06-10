using CoreInterfaces;

namespace ConcreteClassLib;

public class Company : ICompany
{
#nullable disable
    public IData<IWorker> WorkerData { get; private set; }

    public IData<IDocument> DocumentData { get; private set; }

    public string Name { get; set; }

    public string Adress { get; set; }

    public Company(IData<IWorker> workerData, IData<IDocument> documentData)
    {
        WorkerData = workerData ?? throw new NullReferenceException("Worker data doesn't exist");
        DocumentData = documentData ?? throw new NullReferenceException("Document data doesn't exist");
    }

    public void AddWorker(IWorker worker)
    {
        WorkerData?.Add(worker);
    }

    public void FireWorker(IWorker worker)
    {
        WorkerData?.Remove(worker);
    }

    public void AddDocument(IDocument document)
    {
        DocumentData?.Add(document);
    }

    public IEnumerable<IWorker> GetAllWorkers()
    {
        return WorkerData?.ReadAll();
    }

    public IEnumerable<IDocument> GetAllDocuments()
    {
        return DocumentData?.ReadAll();
    }
}
