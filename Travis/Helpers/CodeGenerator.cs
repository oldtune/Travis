using System;
using System.Security.Cryptography;

namespace Travis.Helpers
{
    public static class CodeGenerator
    {
        public static string GenerateCode(int size = 6)
        {
            var randomNumber = new byte[size];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }
    }
}
