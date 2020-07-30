using System.Collections.Generic;

namespace CreditHub.API.Commands.Responses
{
    public abstract class CommandResponse
    {
        public bool Success { get; set; }

        public IEnumerable<string> Errors => _errors;
        private readonly List<string> _errors;

        public CommandResponse()
        {
            Success = true;

            _errors = new List<string>();
        }

        public void AddError(string error)
        {
            _errors.Add(error);
        }
    }
}
