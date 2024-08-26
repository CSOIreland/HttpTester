
using System.Net;

Console.WriteLine("Please enter the url of the API you wish to access: ");
string url=Console.ReadLine();

string userAgent;

Console.WriteLine("Please enter a user agent header string, or alternatively just press Enter if you don't want to send a user agent header:");
userAgent = Console.ReadLine();

using (HttpClient client = new())
{
    try
    {
        if(!String.IsNullOrEmpty(userAgent))
            client.DefaultRequestHeaders.Add("User-Agent", userAgent);

        HttpResponseMessage response = await client.GetAsync(url);
        if (response.IsSuccessStatusCode)
        {
            string content = await response.Content.ReadAsStringAsync();
            Console.WriteLine("Success:");
            Console.WriteLine(content);
        }
        else
        {
            Console.WriteLine("API call failure: "  + response.StatusCode.ToString());
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine("System Error:");
        Console.WriteLine(ex.ToString());
    }

}
