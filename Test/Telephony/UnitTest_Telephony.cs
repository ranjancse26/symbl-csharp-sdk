using System.Threading.Tasks;
using SymblAISharp.TelephonyApi;
using SymblAISharp.TelephonyApi.SIP;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SymblAI.Test.Telephony
{
    [TestClass]
    public class UnitTest_Telephony : BaseTest
    {
        [TestMethod]
        public async Task TestMethod_StartPSTNConnection()
        {
            string email = "ranjancse@gmail.com";
            string phone = "+12248773182";

            var response = GetAuthToken();

            ITelephonyApi telephonyApi = new TelephonyApi(response.accessToken);
            var telephonyResponse = await telephonyApi.StartPSTNConnection(new TelephonyRequest
            {
                operation = "start",
                endpoint = new SymblAISharp.TelephonyApi.Endpoint
                {
                    phoneNumber = phone,
                    type = "pstn"
                },
                actions = new System.Collections.Generic.List<SymblAISharp.TelephonyApi.Action>
                {
                    new SymblAISharp.TelephonyApi.Action
                    {
                        invokeOn = "stop",
                        name = "sendSummaryEmail",
                        parameters = new SymblAISharp.TelephonyApi.Parameters
                        {
                            emails = new System.Collections.Generic.List<string>
                            {
                                email
                            }
                        }
                    }
                },
                data = new SymblAISharp.TelephonyApi.Data
                {
                    session = new SymblAISharp.TelephonyApi.Session
                    {
                        name = "Unit Test Session"
                    }
                }
            });

            Assert.IsTrue(telephonyResponse != null);
        }

        [TestMethod]
        public async Task TestMethod_StopConnection()
        {
            // TODO - Before running this test, please replace with the appropriate connection id
            string connectionId = "1da5a40e-d4fc-43e0-81ab-05fdcee1fa9a";

            var response = GetAuthToken();
            ITelephonyApi telephonyApi = new TelephonyApi(response.accessToken);
            
            var telephonyStopResponse = await telephonyApi.StopConnection(new StopTelephonyRequest
            {
                connectionId = connectionId,
                operation = "stop"
            });

            Assert.IsTrue(telephonyStopResponse != null);
        }

        [TestMethod]
        public async Task TestMethod_StartSIPConnection()
        {
            string email = "ranjancse@gmail.com";
            var response = GetAuthToken();

            ITelephonyApi telephonyApi = new TelephonyApi(response.accessToken);
            var telephonyResponse = await telephonyApi.StartSIPConnection(new SIPConnectRequest
            {
                operation = "start",
                endpoint = new SymblAISharp.TelephonyApi.SIP.Endpoint
                {
                    providerName = "Symbl",
                    type = "sip",
                    uri = "sip:8021@sip.rammer.ai",
                    audioConfig = new AudioConfig
                    {
                        sampleRate = 48000,
                        encoding = "OPUS",
                        sampleSize = 16
                    }
                },
                actions = new System.Collections.Generic.List<SymblAISharp.TelephonyApi.SIP.Action>
                {
                    new SymblAISharp.TelephonyApi.SIP.Action
                    {
                        invokeOn = "stop",
                        name = "sendSummaryEmail",
                        parameters = new SymblAISharp.TelephonyApi.SIP.Parameters
                        {
                            emails = new System.Collections.Generic.List<string>
                            {
                                email
                            }
                        }
                    }
                },
                data = new SymblAISharp.TelephonyApi.SIP.Data
                {
                    session = new SymblAISharp.TelephonyApi.SIP.Session
                    {
                        name = "Unit Test Session"
                    }
                }
            });

            Assert.IsTrue(telephonyResponse != null);
        }
    }
}
