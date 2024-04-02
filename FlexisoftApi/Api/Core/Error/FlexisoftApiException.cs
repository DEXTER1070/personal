using System;

namespace Infomil.Flexisoft.Flexisoft.FlexisoftApi.Api.Core.Error
{
    public class FlexisoftApiException : Exception
    {
        public FlexisoftApiException(string message) : base(message)
        {
        }

        public FlexisoftApiException(string message, Exception exception) : base(message, exception)
        {
        }
    }
}
