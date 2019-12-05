using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace SecureDataCleaner
{
    
    class HttpRESTCleaner : IHttpDataCleaner
    {
        const char CLEANER = 'X';
        internal string CleanUserInfo(string info)
        {
            string patternUser = @"\S*user[s]?\W(\w*)\W";
            Regex regex = new Regex(patternUser);
            Match match = regex.Match(info);
            var userInfo = match.Groups[1].Value;
            if (userInfo == "")
            {
                return info;
            }
            else
            {
                return info.Replace(userInfo, new String(CLEANER, userInfo.Length));
            }
        }
        internal string CleanPassInfo(string info)
        {
            string patternPass = @"\S*pass[=](\S*)";
            Regex regex = new Regex(patternPass);
            Match match = regex.Match(info);
            var pass = match.Groups[1].Value;
            if (pass == "")
            {
                return info;
            }
            else
            {
                return info.Replace(pass, new String(CLEANER, pass.Length));
            }

        }
        public string CleanHttpRequest(string request)
        {
            request = CleanUserInfo(request);
            request = CleanPassInfo(request);
            return request;
        }

        public string CleanHttpResponse(string response)
        {
            response = CleanUserInfo(response);
            response = CleanPassInfo(response);
            return response;
        }

        public string CleanHttpURL(string url)
        {
            url = CleanUserInfo(url);
            return url;
        }

        public void CleanHttp(HttpResult httpResult)
        {
            httpResult.URL = CleanHttpURL(httpResult.URL);
            httpResult.ResponseBody = CleanHttpResponse(httpResult.ResponseBody);
            httpResult.RequestBody = CleanHttpRequest(httpResult.RequestBody);
        }
    }
}
