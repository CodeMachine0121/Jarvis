using System.Text;
using FluentAssertions;
using Jarvis.Controllers;
using Jarvis.Enums;
using Jarvis.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;

namespace JarvisUnitTest;

[TestFixture]
public class BotServiceTests
{
    private HttpClient _httpClient;
    private WebApplicationFactory<LineController> _webApplicationFactory;

    [SetUp]
    public void SetUp()
    {
        _webApplicationFactory = new WebApplicationFactory<LineController>();
        _httpClient = _webApplicationFactory.CreateDefaultClient();
    }

    [Test]
    public async Task when_message_notify_comes()
    {
        var webHookEventRequest = CreateWebHookEventRequest("message");
        var deserializeObject = await DoRequestNotify(webHookEventRequest);
        deserializeObject.Status.Should().Be(ApiStatus.Success);
    }

    [Test]
    public async Task when_follow_notify_comes()
    {
        var webHookEventRequest = CreateWebHookEventRequest("follow");
        var deserializeObject = await DoRequestNotify(webHookEventRequest);
        deserializeObject.Status.Should().Be(ApiStatus.Success);
    }

    [Test]
    public async Task when_unfollow_notify_comes()
    {
        var webHookEventRequest = CreateWebHookEventRequest("unfollowd");
        var deserializeObject = await DoRequestNotify(webHookEventRequest);
        deserializeObject.Status.Should().Be(ApiStatus.Success);
    }

    private async Task<ApiResponse?> DoRequestNotify(WebHookEventRequest webHookEventRequest)
    {
        var content = new StringContent(JsonConvert.SerializeObject(webHookEventRequest), Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync("https://localhost:7297/api/Notify", content);
        var stringContent = await response.Content.ReadAsStringAsync();
        var deserializeObject = JsonConvert.DeserializeObject<ApiResponse>(stringContent);
        return deserializeObject;
    }

    private static WebHookEventRequest CreateWebHookEventRequest(string type)
    {
        return new WebHookEventRequest
        {
            Destination = "",
            Events = CreateBotEvents(type)
        };
    }

    private static BotEvent[] CreateBotEvents(string type)
    {
        return new BotEvent[]
        {
            new BotEvent
            {
                Type = type,
                Message = new Message
                {
                    type = "text",
                    id = "460553830653493477",
                    text = "12"
                },
                WebhookEventId = "01H3EQF2ZKQRZJJDZD8N2YJDR1",
                DeliveryContext = new DeliveryContext
                {
                    IsRedelivery = false
                },
                Source = new Source
                {
                    type = "user",
                    userId = "U1bb2d879ac7f2ef49eca62ae419b786b"
                },
                ReplyToken = "422dd110c77b46f1be244fad4cb46d7e",
                Mode = "activate"
            }
        };
    }
}