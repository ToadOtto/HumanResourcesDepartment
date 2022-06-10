namespace CoreInterfaces;

public interface IDocument
{
    string Message { get; set; }
    string CompanyName { get; set; }
    DateTime DateTime { get; set; }
}
