using System.Threading;
using System.Threading.Tasks;
using CreditHub.API.Commands.Responses;
using MediatR;

namespace CreditHub.API.Commands.Handlers
{
    public abstract class CommandHandlerBase<T1, T2> : IRequestHandler<T1, T2>
        where T1 : IRequest<T2>
        where T2 : CommandResponse, new()
    {
        public abstract Task<T2> Handle(T1 request, CancellationToken cancellationToken);

        protected T2 ErrorResponse(params string[] errors)
        {
            var response = new T2()
            {
                Success = false
            };

            foreach (var error in errors)
            {
                response.AddError(error);
            }

            return response;
        }
    }
}
