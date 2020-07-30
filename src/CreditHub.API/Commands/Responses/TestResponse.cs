namespace CreditHub.API.Commands.Responses
{
    public class TestResponse : CommandResponse
    {
        public TestResponseResult Result { get; set; }
    }

    public class TestResponseResult
    {
        public string Teste { get; set; }
    }
}