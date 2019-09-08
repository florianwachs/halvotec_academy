using MediatR;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace CqrsSample.MediatR.Behaviors
{
    public class AnalyticsBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            Stopwatch watch = Stopwatch.StartNew();
            TResponse response = await next();
            watch.Stop();
            // Log to Analytics
            return response;
        }
    }
}
