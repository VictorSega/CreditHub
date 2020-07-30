using System.Threading;
using System.Threading.Tasks;
using CreditHub.API.Commands.Requests;
using CreditHub.API.Commands.Responses;

namespace CreditHub.API.Commands.Handlers
{
    public class TestHandler : CommandHandlerBase<TestRequest, TestResponse>
    {

        public override async Task<TestResponse> Handle(TestRequest testRequest, CancellationToken cancellationToken)
        {
            return new TestResponse
            {
                Result = new TestResponseResult
                {
                    Teste = $"{testRequest.Id} -- Kk eae men, {testRequest.Teste}"
                }
            };
        }
    }
}