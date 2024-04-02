using System.Collections.Generic;

namespace Infomil.Flexisoft.Flexisoft.FlexisoftApi.Api.Core.Cors
{
    public class CorsConfiguration
    {
        public List<CorsPolicyConfiguration> Policies { get; set; }
    }

    public class CorsPolicyConfiguration
    {
        public string Name { get; set; }
        public List<string> AllowedOrigins { get; set; }
        public List<string> AllowedMethods { get; set; }
    }
}
