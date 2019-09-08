using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CqrsSample.NoCQRS
{
    public interface IDocumentAccess
    {
        void UploadDocumentToQueue(Document document);
        void UploadToSharePoint(string documentId);
        void DeleteDocument(string documentId);
        void UploadToSharePointOverExternalApi(Document document);
        IEnumerable<Document> GetMyDocuments();
        IEnumerable<Document> QueryDocuments(DocumentFilter filter);
        IEnumerable<DocumentWithPermissions> GetDocumentsWithPermissions(DocumentFilter filter);
    }

    #region Helpers
    public class Document
    {
    }

    public class DocumentWithPermissions : Document
    {
    }

    public class DocumentFilter
    {
    }
    #endregion
}
