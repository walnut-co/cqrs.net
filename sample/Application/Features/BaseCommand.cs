using CQRS.Interface;
using CQRS.Sample.Wrappers;

namespace CQRS.Sample.Application.Features
{
    public class BaseQuery<T> : IRequest<Response<T>>
    {
        
    }
}
