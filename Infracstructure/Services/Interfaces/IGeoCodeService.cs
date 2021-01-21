using Domain.ValueObjects;

namespace Infracstructure.Services.Interfaces
{
    public interface IGeoCodeService
    {
        GeoCode GetGeoCodeByAddress(Address address);
    }
}
