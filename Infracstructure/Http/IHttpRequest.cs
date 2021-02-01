using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infracstructure.Http
{
    public interface IHttpRequest
    {
        Task Get();
        Task Post();
        Task Put();
        Task Delete();
    }
}
