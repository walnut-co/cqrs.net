using CQRS.Interface;
using CQRS.Sample.Wrappers;

namespace CQRS.Sample.Application.Features
{
    public class BaseCommand<T> : IRequest<Response<T>>
    {
        
    }
}
