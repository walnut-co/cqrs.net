using CQRS.Interface;
using Microsoft.Extensions.Caching.Distributed;

namespace CQRS.Sample.Behaviour
{
    public class AuthorizationBehaviour<TRequest, TResponse> : IRequestPipeline<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        public IDistributedCache distributedCache;

        public AuthorizationBehaviour() { }

        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="next"></param>
        /// <returns></returns>
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next)
        {
            // write logic here for authorization

            return await next();
        }
    }
}
