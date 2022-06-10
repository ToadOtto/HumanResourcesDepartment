using CoreInterfaces;

namespace ConcreteClassLib;

public class Document : IDocument
{
#nullable disable
    public string Message { get; set; }
    public string CompanyName { get; set; }
    public DateTime DateTime { get; set; }

    public Document(ICompany company)
    {
        CompanyName = company.Name;

        DateTime = DateTime.Now;
    }

    public override string ToString()
    {
        return String.Format($"Document created at {DateTime:G} in the {CompanyName}. {Message}");
    }
}
