using System;
using System.Net.Http;
using System.Net.Http.Headers;
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

    public async Task ReplayMessage(string messageToReply, string replyToken)
    {
        var request = SetHttpRequestMessage(new Uri("https://api.line.me/v2/bot/message/reply"));

        var messageResponse = new MessageResponse(replyToken);

        messageResponse.messages.Add(new MessageToReply(){text = messageToReply});

        request.Content = new StringContent(JsonConvert.SerializeObject(messageResponse));
        request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
                
        var response = await _httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();
    }


    public async Task<UserProfile> GetUserProfile(BotEvent botEvent)
    {
        var request = SetHttpRequestMessage(new Uri($"https://api.line.me/v2/bot/profile/{botEvent.Source.userId}"));

        var response = await _httpClient.SendAsync(request);
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