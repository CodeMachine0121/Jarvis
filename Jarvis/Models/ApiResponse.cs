using Jarvis.Enums;
using Newtonsoft.Json;

namespace Jarvis.Models;

public class ApiResponse
{
    private const string Hint = "hint";

    [JsonProperty("status")]
    public ApiStatus Status { get; set; }

    [JsonProperty("errorCode")]
    public string ErrorCode { get; set; }

    [JsonProperty("message")]
    public string Message { get; set; }

    [JsonProperty("data")]
    public object Data { get; set; }
    
    public static ApiResponse SuccessWithData(object data)
    {
        return new ApiResponse
        {
            Status = ApiStatus.Success,
            Message = ApiStatus.Success.ToString(),
            Data = data
        };
    }
    
    public static ApiResponse Success => new()
    {
        Status = ApiStatus.Success
    };
    
    public static ApiResponse Error => new()
    {
        Status = ApiStatus.Error,
        ErrorCode = "000",
        Message = "Unexpected error, please contact with support"
    };
    
}