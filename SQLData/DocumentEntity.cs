using System.ComponentModel.DataAnnotations;
using CoreInterfaces;

namespace SQLData;

public class DocumentEntity : IDocument
{
#nullable disable
    [Key]
    public int ID { get; set; }
    public string Message { get; set; }
    public string CompanyName { get; set; }
    public DateTime DateTime { get; set; }
    public DocumentEntity() { }
    public DocumentEntity(IDocument document)
    {
        Message = document.Message;
        CompanyName = document.CompanyName;
        DateTime = DateTime.Now;
    }
}
