using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using SecureDataCleaner;

namespace SecureDataCleanerTests
{
    [TestClass]
    public class HttpRESTCleanerTests
    {
        private IHttpDataCleaner restCleaner;
        [TestInitialize]
        public void TestInitialize()
        {
            restCleaner = new HttpRESTCleaner();
        }

        [TestMethod]
        public void HttpRESTCleaner_CleanHttpURL_URLWithUserAndPassInfo_URLWithoutUser()
        {
            //Arrange
            string url = "http://test.com/users/max/info";
            var expected = "http://test.com/users/XXX/info";

            //Act
            var actual = restCleaner.CleanHttpURL(url);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void HttpRESTCleaner_CleanHttpURL_URLNoUser_URLNoUser()
        {
            //Arrange
            string url = "http://test.com/asdas/asgtyh";
            var expected = "http://test.com/asdas/asgtyh";

            //Act
            var actual = restCleaner.CleanHttpURL(url);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void HttpRESTCleaner_CleanHttpRequest_RequestWithUserAndPassInfo_RequestWithoutUserAndPassInfo()
        {
            //Arrange
            string request = "http://test.com?user=max&pass=123456";
            var expected = "http://test.com?user=XXX&pass=XXXXXX";

            //Act
            var actual = restCleaner.CleanHttpRequest(request);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void HttpRESTCleaner_CleanHttpRequest_RequestNoUserAndPass_RequestNoUserAndPassInfo()
        {
            //Arrange
            string url = "http://test.com/asdas/asgtyh";
            var expected = "http://test.com/asdas/asgtyh";

            //Act
            var actual = restCleaner.CleanHttpRequest(url);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void HttpRESTCleaner_CleanHttpResponse_ResponseUserAndPassInfo_ResponseWithoutUserAndPassInfo()
        {
            //Arrange
            string response = "http://test.com?user=max&pass=123456";
            var expected = "http://test.com?user=XXX&pass=XXXXXX";

            //Act
            var actual = restCleaner.CleanHttpResponse(response);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void HttpRESTCleaner_CleanHttpResponse_ResponseNoUserAndPass_ResponseNoUserAndPassInfo()
        {
            //Arrange
            string url = "http://test.com/asdas/asgtyh";
            var expected = "http://test.com/asdas/asgtyh";

            //Act
            var actual = restCleaner.CleanHttpResponse(url);

            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void HttpGETCleaner_CleanHttp_HttpRESTUserAndPassInfo_HttpRESTWithoutUserAndPassInfo()
        {
            //Arrange
            var bookingcomHttpResult = new HttpResult
            {
                URL = "http://test.com/users/max/info",
                RequestBody = "http://test.com?user=max&pass=123456",
                ResponseBody = "http://test.com?user=max&pass=123456"
            };
            var expected = new HttpResult
            {
                URL = "http://test.com/users/XXX/info",
                RequestBody = "http://test.com?user=XXX&pass=XXXXXX",
                ResponseBody = "http://test.com?user=XXX&pass=XXXXXX"
            };

            //Act
            restCleaner.CleanHttp(bookingcomHttpResult);

            //Assert
            Assert.AreEqual(expected.URL, bookingcomHttpResult.URL, "URL are not equal");
            Assert.AreEqual(expected.RequestBody, bookingcomHttpResult.RequestBody, "RequestBody are not equal");
            Assert.AreEqual(expected.ResponseBody, bookingcomHttpResult.ResponseBody, "ResponseBody are not equal");
        }

        [TestMethod]
        public void HttpRESTCleaner_CleanHttp_HttpRESTNoUserAndPass_HttpRESTNoUserAndPassInfo()
        {
            //Arrange
            var bookingcomHttpResult = new HttpResult
            {
                URL = "http://test.com/asdas/asgtyh",
                RequestBody = "http://test.com/asdas/asgtyh",
                ResponseBody = "http://test.com/asdas/asgtyh"
            };
            var expected = new HttpResult
            {
                URL = "http://test.com/asdas/asgtyh",
                RequestBody = "http://test.com/asdas/asgtyh",
                ResponseBody = "http://test.com/asdas/asgtyh"
            };

            //Act
            restCleaner.CleanHttp(bookingcomHttpResult);

            //Assert
            Assert.AreEqual(expected.URL, bookingcomHttpResult.URL, "URL are not equal");
            Assert.AreEqual(expected.RequestBody, bookingcomHttpResult.RequestBody, "RequestBody are not equal");
            Assert.AreEqual(expected.ResponseBody, bookingcomHttpResult.ResponseBody, "ResponseBody are not equal");
        }
    }
}
