using System.Text;
using FluentAssertions;
using Jarvis.Controllers;
using Jarvis.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using NUnit.Framework;

namespace JarvisUnitTest;

[TestFixture]
public class BotServiceTests
{
    [Test]
    public async Task when_message_notify_comes()
    {
        var webHookEventRequest = new  WebHookEventRequest
        {
            Destination = "",
            Events = new BotEvent[]
            {
                new BotEvent
                {
                    Type = "message",
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
            }
        };

        var webApplicationFactory = new WebApplicationFactory<LineController>();
        var httpClient = webApplicationFactory.CreateDefaultClient();

        var content = new StringContent(JsonConvert.SerializeObject(webHookEventRequest), Encoding.UTF8, "application/json");
        var response = await httpClient.PostAsync("https://localhost:7297/api/Notify",content );
        var stringContent = await response.Content.ReadAsStringAsync();
        var deserializeObject =  JsonConvert.DeserializeObject<ApiResponse>(stringContent);
        deserializeObject!.Data.Should().Be(StatusCodes.Status200OK);
    }
    
}