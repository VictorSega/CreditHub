using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CreditHub.API.Commands.Responses;
using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace CreditHub.API.Commands.Pipeline
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
        where TResponse : CommandResponse, new()
    {
        private readonly IEnumerable<IValidator> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var failures = _validators
                .Select(v => v.Validate(request))
                .SelectMany(result => result.Errors)
                .Where(f => f != null)
                .ToList();

            return failures.Any()
                ? Errors(failures)
                : next();
        }

        private static Task<TResponse> Errors(IEnumerable<ValidationFailure> failures)
        {
            var response = new TResponse()
            {
                Success = false
            };

            foreach (var error in failures)
            {
                response.AddError(error.ErrorMessage);
            }

            return Task.FromResult(response);
        }
    }
}