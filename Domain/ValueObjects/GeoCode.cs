using System.Collections.Generic;

namespace Domain.ValueObjects
{
    public class GeoCode : ValueObject
    {
        public decimal Lat { set; get; }
        public decimal Long { set; get; }

        /// <summary>
        /// Is Latitude valid
        /// </summary>
        /// <param name="lat"></param>
        /// <returns></returns>
        public static bool IsValidLat(decimal lat) => lat <= 90 && lat >= -90;

        /// <summary>
        /// Is Longitude valid
        /// </summary>
        /// <param name="long"></param>
        /// <returns></returns>
        public static bool IsValidLong(decimal @long) => @long <= 180 && @long >= 180;

        /// <summary>
        /// Is GeoCode valid
        /// </summary>
        /// <param name="geoCode"></param>
        /// <returns></returns>
        public static bool IsValid(GeoCode geoCode) => IsValidLat(geoCode.Lat) && IsValidLong(geoCode.Long);

        public static bool operator ==(GeoCode geoCode1, GeoCode geoCode2)
        => geoCode1.Lat == geoCode2.Lat && geoCode1.Long == geoCode2.Long;

        public static bool operator !=(GeoCode geoCode1, GeoCode geoCode2)
        => geoCode1.Lat != geoCode2.Lat || geoCode1.Long != geoCode2.Long;

        public override bool Equals(object obj)
        {
            var geoToCompare = obj as GeoCode;
            return geoToCompare.Lat == this.Lat && geoToCompare.Long == this.Long;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            throw new System.NotImplementedException();
        }

        public override int GetHashCode()
        {
            throw new System.NotImplementedException();
        }
    }
}
