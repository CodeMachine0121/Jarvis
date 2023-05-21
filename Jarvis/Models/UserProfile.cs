namespace Jarvis.Models;

public class UserProfile
{
    public string displayName;
    public string userId { get; set; }
    public string language { get; set; }
    public string pictureUrl { get; set; }
    public string statusMessage { get; set; }
}