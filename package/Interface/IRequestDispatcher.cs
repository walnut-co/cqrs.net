namespace CQRS.Interface
{
    public interface IRequestDispatcher
    {
        Task<TResponse> Send<TResponse>(IRequest<TResponse> request);
    }
}
