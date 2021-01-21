using System;
using Travis.Helpers;

namespace Travis.Models
{
    public class Code
    {
        public Code(int codeLength)
        {
            if (codeLength < 1)
                throw new Exception("Code length must be greater than 0");

            Value = CodeGenerator.GenerateCode(codeLength);
        }

        public string Value { get; }
    }
}
