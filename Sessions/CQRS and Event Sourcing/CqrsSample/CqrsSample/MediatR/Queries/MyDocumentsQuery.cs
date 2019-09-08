using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CqrsSample.MediatR.Queries
{
    public class MyDocumentsQuery : IRequest<MyDocumentsQueryResult>
    {
        public string UserId { get; set; }
    }

    public class MyDocumentsQueryResult
    {
        public IEnumerable<DocumentVm> Documents { get; set; }
    }

    public class DocumentVm
    {
        public string Id { get; set; }
        public string Title { get; set; }
    }

    public class MyDocumentsQueryHandler : IRequestHandler<MyDocumentsQuery, MyDocumentsQueryResult>
    {
        // Konstruktor kann Dependencies anfordern
        public MyDocumentsQueryHandler()
        {
        }

        public async Task<MyDocumentsQueryResult> Handle(MyDocumentsQuery request, CancellationToken cancellationToken)
        {
            // Evaluate if User exists
            // Query all Documents for the user
            await Task.Delay(TimeSpan.FromSeconds(5));
            return new MyDocumentsQueryResult();
        }
    }
}
