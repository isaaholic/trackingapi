using System.Net.Http.Headers;
using System.Net.Http.Json;
using tracking.client;

HttpClient client = new();
client.BaseAddress = new Uri("https://localhost:7229");
client.DefaultRequestHeaders.Accept.Clear();
client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

while (true)
{
    HttpResponseMessage response = await client.GetAsync("api/issue");
    response.EnsureSuccessStatusCode();

    if (response.IsSuccessStatusCode)
    {

        var issues = await response.Content.ReadFromJsonAsync<IEnumerable<IssueDto>>();
        foreach (var issue in issues)
        {
            Console.WriteLine(issue.Title);
        }
        Console.WriteLine("Press any key for Reload...");
        Console.ReadKey();
    }
    else
    {
        Console.WriteLine("No results");
    }
}

