namespace CQRS.Interface
{
    public delegate Task<TResponse> RequestHandlerDelegate<TResponse>();

    public interface IRequestPipeline<TRequest, TResponse>
     where TRequest : IRequest<TResponse>
    {
        Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next);
    }
}
