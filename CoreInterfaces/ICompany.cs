namespace CoreInterfaces;
public interface ICompany
{
    IData<IWorker> WorkerData { get; }
    IData<IDocument> DocumentData { get; }
    string Name { get; set; }
    string Adress { get; set; }
    void AddWorker(IWorker worker);
    void FireWorker(IWorker worker);
    IEnumerable<IWorker> GetAllWorkers();
    void AddDocument(IDocument document);
    IEnumerable<IDocument> GetAllDocuments();
}