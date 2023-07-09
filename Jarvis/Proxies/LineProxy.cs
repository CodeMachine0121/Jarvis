using System.Net;
using System.Text;
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
        
        _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_tokenService!.GetToken("line")}");
    }

    public async Task<HttpStatusCode> ReplayMessage(string messageToReply, BotEventDto botEventDto)
    {
        var messageResponse = new MessageResponse(botEventDto.ReplyToken);
        messageResponse.messages.Add(new MessageToReply(){text = messageToReply});
        
        var serializeObject = JsonConvert.SerializeObject(messageResponse);
        var stringContent = new StringContent(serializeObject, Encoding.UTF8, "application/json");
        
        var response = await _httpClient.PostAsync("/v2/bot/message/reply", stringContent );
        response.EnsureSuccessStatusCode();
        return response.StatusCode;

    }

    public async Task<UserProfile> GetUserProfile(BotEventDto botEventDto)
    {
        var response = await _httpClient.GetAsync($"/v2/bot/profile/{botEventDto.Source.userId}");
        response.EnsureSuccessStatusCode();

        var infoContent = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<UserProfile>(infoContent)!;
    }

}
