using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValueObjects
{
    public class SitePasswords
    {
        public string Password { set; get; }
        public string Username { set; get; }
        public string UsedByEmail { set; get; }
        public string UsedByPhone { set; get; }
        public string Site { set; get; }
    }
}
