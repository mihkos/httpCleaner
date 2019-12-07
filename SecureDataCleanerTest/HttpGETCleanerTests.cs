using Microsoft.VisualStudio.TestTools.UnitTesting;
using SecureDataCleaner;

namespace SecureDataCleanerTests
{
    [TestClass]
    public class HttpGETCleanerTests
    {
        private IHttpDataCleaner getCleaner;

        [TestInitialize]
        public void TestInitialize()
        {
            getCleaner = new HttpGETCleaner();
        }

        [TestMethod]
        public void HttpGETCleaner_CleanHttpURL_URLWithUserAndPassInfo_URLWithoutUserAndPassInfo()
        {
            //Arrange
            string url = "http://test.com?user=max&pass=123456";
            var expected = "http://test.com?user=XXX&pass=XXXXXX";

            //Act
            var actual = getCleaner.CleanHttpURL(url);

            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void HttpGETCleaner_CleanHttpURL_URLNoUserAndPass_URLNoUserAndPassInfo()
        {
            //Arrange
            string url = "http://test.com/asdas/asgtyh";
            var expected = "http://test.com/asdas/asgtyh";

            //Act
            var actual = getCleaner.CleanHttpURL(url);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void HttpGETCleaner_CleanHttpRequest_RequestWithUserAndPassInfo_RequestWithoutUserAndPassInfo()
        {
            //Arrange
            string request = "http://test.com?user=max&pass=123456";
            var expected = "http://test.com?user=XXX&pass=XXXXXX";

            //Act
            var actual = getCleaner.CleanHttpRequest(request);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void HttpGETCleaner_CleanHttpRequest_RequestNoUserAndPass_RequestNoUserAndPassInfo()
        {
            //Arrange
            string request = "http://test.com/asdas/asgtyh";
            var expected = "http://test.com/asdas/asgtyh";

            //Act
            var actual = getCleaner.CleanHttpRequest(request);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void HttpGETCleaner_CleanHttpResponse_ResponseUserAndPassInfo_ResponseWithoutUserAndPassInfo()
        {
            //Arrange
            string response = "http://test.com?user=max&pass=123456";
            var expected = "http://test.com?user=XXX&pass=XXXXXX";

            //Act
            var actual = getCleaner.CleanHttpResponse(response);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void HttpGETCleaner_CleanHttpResponse_ResponseNoUserAndPass_ResponseNoUserAndPassInfo()
        {
            //Arrange
            string response = "http://test.com/asdas/asgtyh";
            var expected = "http://test.com/asdas/asgtyh";

            //Act
            var actual = getCleaner.CleanHttpResponse(response);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void HttpGETCleaner_CleanHttp_HttpGETUserAndPassInfo_HttpGETWithoutUserAndPassInfo()
        {
            //Arrange
            var bookingcomHttpResult = new HttpResult
            {
                URL = "http://test.com/users/max/info?pass=123456",
                RequestBody = "http://test.com?user=max&pass=123456",
                ResponseBody = "http://test.com?user=max&pass=123456"
            };
            var expected = new HttpResult
            {
                URL = "http://test.com/users/XXX/info?pass=XXXXXX",
                RequestBody = "http://test.com?user=XXX&pass=XXXXXX",
                ResponseBody = "http://test.com?user=XXX&pass=XXXXXX"
            };

            //Act
            getCleaner.CleanHttp(bookingcomHttpResult);

            //Assert
            Assert.AreEqual(expected.URL, bookingcomHttpResult.URL, "URL are not equal");
            Assert.AreEqual(expected.RequestBody, bookingcomHttpResult.RequestBody, "RequestBody are not equal");
            Assert.AreEqual(expected.ResponseBody, bookingcomHttpResult.ResponseBody, "ResponseBody are not equal");
        }

        [TestMethod]
        public void HttpGETCleaner_CleanHttp_HttpGETNoUserAndPass_HttpGETNoUserAndPassInfo()
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
            getCleaner.CleanHttp(bookingcomHttpResult);

            //Assert
            Assert.AreEqual(expected.URL, bookingcomHttpResult.URL, "URL are not equal");
            Assert.AreEqual(expected.RequestBody, bookingcomHttpResult.RequestBody, "RequestBody are not equal");
            Assert.AreEqual(expected.ResponseBody, bookingcomHttpResult.ResponseBody, "ResponseBody are not equal");
        }
    }
}
