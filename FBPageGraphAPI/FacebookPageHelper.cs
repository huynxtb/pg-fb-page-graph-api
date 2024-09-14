using Newtonsoft.Json;
using RestSharp;

namespace FBPageGraphAPI;

public class FacebookPageHelper
{
    private static readonly string _baseUrl = "https://graph.facebook.com";

    public static async Task<string> CreateAsync(string pageId, string accessToken, string link, string message)
    {
        var client =
            new RestClient(_baseUrl + $"/{pageId}/feed?message={message}&access_token={accessToken}&link={link}");
        var request = new RestRequest { Method = Method.Post };
        var response = await client.ExecuteAsync(request);

        if (!response.IsSuccessful || string.IsNullOrEmpty(response.Content)) return "";

        var res = JsonConvert.DeserializeObject<FacebookHelperModel>(response.Content);

        return res == null ? "" : res.Id;
    }
    
    public static async Task<bool> DeleteAsync(string facebookPostId, string accessToken)
    {
        var client =
            new RestClient(_baseUrl + $"/{facebookPostId}/?access_token={accessToken}");
        var request = new RestRequest { Method = Method.Delete };
        var response = await client.ExecuteAsync(request);

        if (!response.IsSuccessful || string.IsNullOrEmpty(response.Content)) return false;

        var res = JsonConvert.DeserializeObject<FacebookHelperModel>(response.Content);

        return res?.Success ?? false;
    }
}

public class FacebookHelperModel
{
    public string Id { get; set; }
    public bool Success { get; set; }
}