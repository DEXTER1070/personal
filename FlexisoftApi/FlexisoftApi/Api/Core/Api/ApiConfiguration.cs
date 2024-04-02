using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Api.Core.Cors;

namespace Infomil.Flexisoft.Flexisoft.FlexisoftApi.Api.Core.Api
{
    public class ApiConfiguration
    {
        public string Environment { get; set; }
        public string ApplicationName { get; set; }
        public string CreationCourante { get; set; }
        public string AplCourante { get; set; }
        public bool EnableMock { get; set; }
        public bool EnableSwagger { get; set; }
        public string ApiSecret { get; set; }
        public CorsConfiguration CorsConfiguration { get; set; }
        public string DataProtectionSecurityPath { get; set; }
    }
}

