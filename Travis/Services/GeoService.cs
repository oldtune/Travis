using Grpc.Core;
using System.Threading.Tasks;

namespace Travis.Services
{
    public class GeoService : Geo.GeoBase
    {
        public override async Task<Address> DetermineAddress(GeoCode request, ServerCallContext context)
        {
            return null;
        }

        public override async Task<GeoCode> DetermineGeoCode(Address request, ServerCallContext context)
        {
            return null;
        }
    }
}
