# symbl-csharp-sdk

SymblAISharp is a C# library for the Sybml API

API Reference - https://docs.symbl.ai/docs/api-reference/getting-started

## Features

- Async API
    - Audio
    - Video
    - Text
    - Job
- Conversation
    - Abstract Topic
    - Action Item
    - Analytics
    - Conversation
    - Conversation Data
    - Entity
    - Experience
    - Follow Up
    - Formatted Transcript
    - Member
    - Question
    - Sentiment
    - Speaker Event
    - Speech To Text
    - Topic
- Management
    - Conversation
    - Tracker
- Telephony

## Code Snippet

Get the Authentication Token

```
AuthenticationApi authentication = new AuthenticationApi();
var authResponse = authentication.GetAuthToken(
    new AuthRequest
    {
        type = "application",
        appId = appId,
        appSecret = appSecret
    });
```

Async Audio API Usage

```
var response = GetAuthToken();
IAudioApi audioApi = new AudioApi(response.accessToken);
var audioResponse = await audioApi.PostAudioUrl(new AudioRequest
{
    url = "https://symbltestdata.s3.us-east-2.amazonaws.com/sample_audio_file.wav",
});
```

Async Video API Usage

```
var response = GetAuthToken();
IVideoApi videoApi = new VideoApi(response.accessToken);
var videoResponse = await videoApi.PostVideoUrl(new VideoRequest
{
    url = "https://symbltestdata.s3.us-east-2.amazonaws.com/sample_video_file.mp4",
});
```

Get All Conversation API Usage
```
var response = GetAuthToken();
IConversationApi conversationApi = new ConversationApi(response.accessToken);
var allConversationResponse = conversationApi.GetAllConversations();
```

Telephony API Usage
```
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
```

<h2 class="code-line" data-line-start=91 data-line-end=92 ><a id="License_91"></a>License</h2>
<p class="has-line-data" data-line-start="93" data-line-end="94">MIT</p>
<p class="has-line-data" data-line-start="95" data-line-end="103"><strong>Free Software, Hell Yeah!</strong><br/><br/>
[Async API]: <a href="https://docs.symbl.ai/docs/async-api/introduction">https://docs.symbl.ai/docs/async-api/introduction</a><br>
[Telephony API]: <a href="https://docs.symbl.ai/docs/telephony/introduction">https://docs.symbl.ai/docs/telephony/introduction</a><br>
[Conversation API]: <a href="https://docs.symbl.ai/docs/conversation-api/introduction">https://docs.symbl.ai/docs/conversation-api/introduction</a><br>
[Experience API]: <a href="https://docs.symbl.ai/docs/api-reference/experience-api/post-text-summary-ui">https://docs.symbl.ai/docs/api-reference/experience-api/post-text-summary-ui</a><br>
[Tracker API]: <a href="https://docs.symbl.ai/docs/management-api/trackers/overview">https://docs.symbl.ai/docs/management-api/trackers/overview</a><br>
[Management API]: <a href="https://docs.symbl.ai/docs/management-api/introduction">https://docs.symbl.ai/docs/management-api/introduction</a><br>
[Conversation Group API]: <a href="https://docs.symbl.ai/docs/management-api/conversation-groups/conversation-groups-intro">https://docs.symbl.ai/docs/management-api/conversation-groups/conversation-groups-intro</a></p>
  
