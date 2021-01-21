using System;
using System.Text;

namespace Sharedkernel.Configs
{
    public class JwtValidationConfig
    {
        public string Secret { set; get; }
        public bool ValidateIssuerSigningKey { set; get; }
        public bool ValidateIssuer { set; get; }
        public bool ValidateAudience { set; get; }
        // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
        public TimeSpan ClockSkew { set; get; }

        public byte[] KeyBytes => Secret == null ? throw new Exception("No Jwt Secret found") : Encoding.ASCII.GetBytes(Secret);
}
}
