using CreditHub.API.Commands.Responses;
using MediatR;

namespace CreditHub.API.Commands.Requests
{
    public class TestRequest : IRequest<TestResponse>
    {
        public int Id { get; set; }
        public string Teste { get; set; }

        public TestRequest(
            int id, 
            string teste)
        {
            Id = id;
            Teste = teste;
        }
    }
}