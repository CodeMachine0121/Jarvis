using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Jarvis.Interfaces;
using Jarvis.Models;
using Jarvis.Services;
using Newtonsoft.Json;

namespace Jarvis.Proxies;

public class LineProxy : ILineProxy
{
    private readonly HttpClient _httpClient;
    private readonly TokenService _tokenService;

    public LineProxy(HttpClient httpClient, TokenService tokenService)
    {
        _httpClient = httpClient;
        _tokenService = tokenService;
    }

    public async Task ReplayMessage(string messageToReply, BotEvent botEvent)
    {
        var messageResponse = new MessageResponse(botEvent.ReplyToken);
        messageResponse.messages.Add(new MessageToReply(){text = messageToReply});
        
        var serializeObject = JsonConvert.SerializeObject(messageResponse);
        var stringContent = new StringContent(serializeObject, Encoding.UTF8, "application/json");
        
        _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_tokenService.GetToken("line")}");
        var response = await _httpClient.PostAsync("/v2/bot/message/reply", stringContent );
        response.EnsureSuccessStatusCode();
    }

    public async Task<UserProfile> GetUserProfile(BotEvent botEvent)
    {
        var response = await _httpClient.GetAsync($"/v2/bot/profile/{botEvent.Source.userId}");
        response.EnsureSuccessStatusCode();

        var infoContent = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<UserProfile>(infoContent)!;
    }

    private HttpRequestMessage SetHttpRequestMessage(Uri requestUri)
    {
        var request = new HttpRequestMessage(new HttpMethod("POST"), requestUri);
        request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {_tokenService.GetToken("line")}");
        return request;
    }
}
