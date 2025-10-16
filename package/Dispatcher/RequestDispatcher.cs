using CQRS.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace CQRS.Dispatcher
{
    public class RequestDispatcher : IRequestDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public RequestDispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TResponse> Send<TResponse>(IRequest<TResponse> request)
        {
            // Resolve handler
            var handlerType = typeof(IRequestHandler<,>).MakeGenericType(request.GetType(), typeof(TResponse));
            dynamic handler = _serviceProvider.GetRequiredService(handlerType);

            // Resolve any pipelines for this request type
            var pipelineType = typeof(IRequestPipeline<,>).MakeGenericType(request.GetType(), typeof(TResponse));
            var pipelines = _serviceProvider.GetServices(pipelineType)
                .Cast<dynamic>()
                .ToList();

            // Build delegate chain
            RequestHandlerDelegate<TResponse> handlerDelegate = () => handler.Handle((dynamic)request);

            foreach (var pipeline in pipelines.AsEnumerable().Reverse())
            {
                var next = handlerDelegate;
                handlerDelegate = () => pipeline.Handle((dynamic)request, next);
            }

            return await handlerDelegate();
        }
    }
}
