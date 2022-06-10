using CoreInterfaces;

namespace ConcreteClassLib.Data;

public class RuntimeDocumentData : IData<IDocument>
{
#nullable disable
    public List<IDocument> Documents { get; private set; }
    public string Message { get; set; }

    public RuntimeDocumentData()
    {
        Documents = new List<IDocument>();
    }

    public void Add(IDocument document)
    {
        Documents.Add(document);
    }

    public IEnumerable<IDocument> ReadAll()
    {
        return Documents;
    }

    public void Remove(IDocument document)
    {
        Documents.Remove(document);
    }
}
