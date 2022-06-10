namespace SQLData;

using System.Collections.Generic;
using CoreInterfaces;

public class DocumentSQLData : IData<IDocument>
{
    public void Add(IDocument document)
    {
        var documentEntity = new DocumentEntity(document);
        using (HRDepartmentAppDBContext db = new HRDepartmentAppDBContext())
        {
            db.Documents.Add(documentEntity);
            db.SaveChanges();
        }
    }

    public IEnumerable<IDocument> ReadAll()
    {
        using (HRDepartmentAppDBContext db = new HRDepartmentAppDBContext())
        {
            return db.Documents.ToList();
        }
    }

    public void Remove(IDocument document)
    {
        using (HRDepartmentAppDBContext db = new HRDepartmentAppDBContext())
        {
            var documentEntity = db.Documents.Where(d => d.Message == document.Message).First();
            db.Remove(documentEntity);
            db.SaveChanges();
        }
    }
}
