using System;

namespace Travis.Configurations
{
    public class CodeConfig
    {
        private int _codeLength;
        public TimeSpan ExpireTimeSpan { set; get; }
        public int CodeLength
        {
            get { return _codeLength; }
            set
            {
                if (value < 1) throw new Exception("Code length must be greater than 0");
                else _codeLength = value;
            }
        }
    }
}
