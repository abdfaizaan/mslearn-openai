using System;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace generate_image
{
    class Program
    {
        private static string aoaiEndpoint;
        private static string aoaiKey;
        static async Task Main(string[] args)
        {
            try
            {
                // Get config settings from AppSettings
                IConfigurationBuilder builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
                IConfigurationRoot configuration = builder.Build();
                aoaiEndpoint = configuration["AzureOAIEndpoint"];
                aoaiKey = configuration["AzureOAIKey"];

                // Get prompt for image to be generated
                Console.Clear();
                Console.WriteLine("Enter a prompt to request an image:");
                string prompt = Console.ReadLine();

                using (var client = new HttpClient())
                {
                    var contentType = new MediaTypeWithQualityHeaderValue("application/json");
                    var deployment = configuration["AzureOAIDeployment"];
                    var api = $"/openai/deployments/{deployment}/images/generations?api-version=2025-04-01-preview";

                    // Ensure endpoint has no trailing slash
                    var endpoint = aoaiEndpoint.TrimEnd('/');
                    client.BaseAddress = new Uri(endpoint);
                    client.DefaultRequestHeaders.Accept.Add(contentType);
                    client.DefaultRequestHeaders.Add("api-key", aoaiKey);
                    Console.WriteLine("Calling URL: " + endpoint + api);

                    // gpt-image-1 supported params: prompt, n, size, quality
                    // quality values: "low", "medium", "high" (NOT "standard"/"hd")
                    // size values: "1024x1024", "1024x1536", "1536x1024"
                    // NOT supported: style, response_format
                    // Response is synchronous (no polling needed) and returns b64_json
                    var data = new
                    {
                        prompt = prompt,
                        n = 1,
                        size = "1024x1024",
                        quality = "high"
                    };

                    var jsonData = JsonSerializer.Serialize(data);
                    var contentData = new StringContent(jsonData, Encoding.UTF8, "application/json");

                    // gpt-image-1 responds synchronously — no polling needed
                    var response = await client.PostAsync(api, contentData);

                    if (!response.IsSuccessStatusCode)
                    {
                        Console.WriteLine("Failed to generate image.");
                        Console.WriteLine("Status Code: " + response.StatusCode);
                        string errorContent = await response.Content.ReadAsStringAsync();
                        Console.WriteLine("Response: " + errorContent);
                        return;
                    }

                    // Parse the base64 image from the response
                    string stringResponse = await response.Content.ReadAsStringAsync();
                    JsonNode contentNode = JsonNode.Parse(stringResponse)!;
                    JsonNode dataNode = contentNode!["data"]!;
                    string b64Json = dataNode[0]!["b64_json"]!.GetValue<string>();

                    // Decode and save as PNG
                    byte[] imageBytes = Convert.FromBase64String(b64Json);
                    string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                    string Path = $"/home/odl_user/mslearn-openai/Labfiles/05-image-generation/CSharp/generated_image_{timestamp}.png";
                    await System.IO.File.WriteAllBytesAsync(Path, imageBytes);
                    string outputPath = $"/mslearn-openai/Labfiles/05-image-generation/CSharp/generated_image_{timestamp}.png";

                    Console.WriteLine($"\n✅ Image saved successfully!");
                    Console.WriteLine($"   Path: {outputPath}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
