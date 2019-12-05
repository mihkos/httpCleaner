using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureDataCleaner
{
    public class HttpHandler
    {
        HttpResult _currentLog;
        public HttpResult CurrentLog { get { return _currentLog; } }

        public HttpHandler() { _currentLog = null; }
        public HttpHandler(HttpResult currentLog)
        {
            _currentLog = currentLog;
        }
        public string Process(string url, string body, string response, IHttpDataCleaner secureCleaner)
        {
            var httpResult = new HttpResult
            {
                URL = url,
                RequestBody = body,
                ResponseBody = response
            };

            secureCleaner.CleanHttp(httpResult);

            Log(httpResult);
            return response;
        }

        protected void Log(HttpResult result)
        {
            _currentLog = new HttpResult
            {
                URL = result.URL,
                RequestBody = result.RequestBody,
                ResponseBody = result.ResponseBody
            };
        }
    }
}
