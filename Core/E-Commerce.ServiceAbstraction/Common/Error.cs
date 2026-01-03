using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.ServiceAbstraction.Common
{
    public partial class Error
    {
        public string Code { get; }
        public string Description { get; }
        public ErrorType Type { get; }

        private Error(string code, string description, ErrorType type)
        {
            Code = code;
            Description = description;
            Type = type;
        }
        //static factory methods to create errors

        public static Error Failure(string code = "General Failure", string description = "A Failure has occurred")
            => new(code, description, ErrorType.Failure);

        public static Error Validation(string code = "General Validation", string description = "A Validation has occurred")
            => new(code, description, ErrorType.Validation);

        public static Error NotFound(string code = "General Not Found", string description = "A Not Found has occurred")
            => new(code, description, ErrorType.NotFound);

        public static Error Conflict(string code = "General Conflict", string description = "A Conflict has occurred")
            => new(code, description, ErrorType.Conflict);

        public static Error Unauthorized(string code = "General Unauthorized", string description = "A Unauthorized has occurred")
             => new(code, description, ErrorType.Unauthorized);

    }
}
