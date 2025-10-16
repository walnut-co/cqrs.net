using CQRS.Interface;
using CQRS.Sample.Application.Features;
using CQRS.Sample.Models;
using CQRS.Sample.Wrappers;

namespace CQRS.Sample.Features
{

    public class SayHelloCommand : BaseCommand<SayHelloModel>
    {
        public string Name { get; set; }
    }

    public class SayHelloCommandHandler : IRequestHandler<SayHelloCommand, Response<SayHelloModel>>
    {
        public SayHelloCommandHandler()
        {
        }

        public async Task<Response<SayHelloModel>> Handle(SayHelloCommand request, CancellationToken cancellationToken = default)
        {
            return new Response<SayHelloModel>(new SayHelloModel()
            {
                Name = request.Name,
                Message = $"Hello {request.Name}"
            });
        }
    }
}
