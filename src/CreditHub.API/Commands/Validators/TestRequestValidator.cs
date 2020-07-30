using CreditHub.API.Commands.Requests;
using FluentValidation;

namespace CreditHub.API.Commands.Validators
{
    public class TestRequestValidator : AbstractValidator<TestRequest>
    {
        public TestRequestValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();

            RuleFor(x => x.Teste)
                .NotEmpty();
        }
    }
}