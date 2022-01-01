using SymblAI.Test;
using System.Threading.Tasks;
using SymblAISharp.Async.TextApi;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SymblAI.Async.Test
{
    [TestClass]
    public class UnitTest_Text : BaseTest
    {
        [TestMethod]
        public async Task TestMethod_TextApi_POST_Success()
        {
            var response = GetAuthToken();

            ITextApi textApi = new TextApi(response.accessToken);
            var textResponse = await textApi.Post(new TextPostRequest
            {
                messages = new List<Message>
                {
                    new Message
                    {
                        payload = new Payload
                        {
                            contentType = "text/plain",
                            content = "Hello"
                        },
                        from = new From
                        {
                            name = "Ranjan",
                            userId = "ranjancse@gmail.com"
                        }
                    }
                }
            });

            Assert.IsTrue(textResponse != null);
            Assert.IsTrue(textResponse.conversationId != "");
            Assert.IsTrue(textResponse.jobId != "");
        }

        [TestMethod]
        public async Task TestMethod_TextApi_PUT_Success()
        {
            var response = GetAuthToken();
            string conversationId = "5420356157308928";

            ITextApi textApi = new TextApi(response.accessToken);
            var textResponse = await textApi.Put(new TextPutRequest
            {
                messages = new List<Message>
                {
                    new Message
                    {
                        payload = new Payload
                        {
                            contentType = "text/plain",
                            content = "World"
                        },
                        from = new From
                        {
                            name = "Ranjan",
                            userId = "ranjancse@gmail.com"
                        }
                    }
                }
            }, conversationId);

            Assert.IsTrue(textResponse != null);
            Assert.IsTrue(textResponse.conversationId != "");
            Assert.IsTrue(textResponse.jobId != "");
        }
    }
}
