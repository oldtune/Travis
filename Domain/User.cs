using Domain.ValueObjects;
using System.Collections.Generic;

namespace Domain
{
    public class User
    {
        public IList<GeoCode> GeoCodes { set; get; }
    }
}
