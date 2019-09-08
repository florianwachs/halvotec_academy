using CqrsSample.MediatR.Behaviors;
using CqrsSample.MediatR.Queries;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace CqrsSample
{
    internal class Program
    {
        private IServiceProvider Provider { get; set; }
        private IMediator Mediator => Provider.GetService<IMediator>();

        private static async Task Main(string[] args)
        {
            await new Program().Run();
        }

        public async Task Run()
        {
            SetupDiSystem();
            await RunQuery();
        }

        private async Task RunQuery()
        {
            MyDocumentsQueryResult result = await Mediator.Send(new MyDocumentsQuery());
        }

        private void SetupDiSystem()
        {
            ServiceCollection services = new ServiceCollection();
            services.AddMediatR(typeof(MyDocumentsQuery).Assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AnalyticsBehavior<,>));
            Provider = services.BuildServiceProvider();
        }
    }
}
