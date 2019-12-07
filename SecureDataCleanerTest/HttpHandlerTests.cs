using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using SecureDataCleaner;

namespace SecureDataCleanerTests
{
    [TestClass]
    public class HttpHandlerTests
    {
        private HttpHandler httpHundler;

        [TestInitialize]
        public void TestInitialize()
        {
            httpHundler = new HttpHandler();
        }

        [TestMethod]
        public void HttpHandler_Process_BookingcomResults_ClearSecureData()
        {
            //Arrange
            var bookingcomHttpResult = new HttpResult
            {
                URL = "http://test.com/users/max/info?pass=123456",
                RequestBody = "http://test.com?user=max&pass=123456",
                ResponseBody = "http://test.com?user=max&pass=123456"
            };
            IHttpDataCleaner getCleaner = new HttpGETCleaner();
            var expectedLog = new HttpResult
            {
                URL = "http://test.com/users/XXX/info?pass=XXXXXX",
                RequestBody = "http://test.com?user=XXX&pass=XXXXXX",
                ResponseBody = "http://test.com?user=XXX&pass=XXXXXX"
            };
            var expectedHandler = new HttpHandler(expectedLog);

            //Act
            httpHundler.Process(bookingcomHttpResult.URL, bookingcomHttpResult.RequestBody, bookingcomHttpResult.ResponseBody, getCleaner);

            //Assert
            Assert.AreEqual(expectedHandler.CurrentLog.URL, httpHundler.CurrentLog.URL, "URL are not equal");
            Assert.AreEqual(expectedHandler.CurrentLog.RequestBody, httpHundler.CurrentLog.RequestBody, "RequestBody are not equal");
            Assert.AreEqual(expectedHandler.CurrentLog.ResponseBody, httpHundler.CurrentLog.ResponseBody, "ResponseBody are not equal");
        }
    }
}
