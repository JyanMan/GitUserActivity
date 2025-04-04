using System.Net.Http.Headers;

namespace Program;

public class ApiHandler
{
    public required string Url { get; set; }

    public HttpResponseMessage SendRequest()
    {
        HttpClient client = new();

        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json")
                );
        client.DefaultRequestHeaders.Add(
                "User-Agent",	"Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:136.0) Gecko/20100101 Firefox/136.0"
                );

        HttpRequestMessage request = new(HttpMethod.Get, Url);
        HttpResponseMessage response = client.Send(request);
        return response;
        //StreamReader reader = new StreamReader(response.Content.ReadAsStream());
        //string content = reader.ReadToEnd();

    }
    
}
