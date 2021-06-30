using Microsoft.Extensions.Configuration;

namespace Newbe.Claptrap.Ticketing.Models
{
    public static class TyeExtensions
    {
        public static bool IsRunOnTye(this IConfiguration config)
        {
            var serviceName = config.GetValue<string>("App:Name");
            return config.GetServiceUri(serviceName) is not null;
        }
    }
}