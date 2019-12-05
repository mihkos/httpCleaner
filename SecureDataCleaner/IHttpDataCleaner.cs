using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureDataCleaner
{
    public interface IHttpDataCleaner
    {
        string CleanHttpURL(string url);
        string CleanHttpRequest(string request);
        string CleanHttpResponse(string response);
        void CleanHttp(HttpResult httpResult);
    }
}
