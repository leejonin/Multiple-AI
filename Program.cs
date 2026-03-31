using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

class Program
{
    static string GPT_KEY = "OPENAI_KEY";
    static string GEMINI_KEY = "GEMINI_KEY";
    static string CLAUDE_KEY = "CLAUDE_KEY";

    static async Task Main()
    {
        Console.WriteLine("Choose which AI to use:");
        Console.WriteLine("1. GPT");
        Console.WriteLine("2. Gemini");
        Console.WriteLine("3. Claude");
        Console.Write("Enter number: ");

        string choice = Console.ReadLine();

        Console.Write("Enter prompt: ");
        string prompt = Console.ReadLine();

        string result = "";

        switch (choice)
        {
            case "1":
                result = await CallGPT(GPT_KEY, prompt);
                break;

            case "2":
                result = await CallGemini(GEMINI_KEY, prompt);
                break;

            case "3":
                result = await CallClaude(CLAUDE_KEY, prompt);
                break;

            default:
                Console.WriteLine("Invalid input");
                return;
        }

        Console.WriteLine("\n===== Result =====");
        Console.WriteLine(result);
    }

    // ================= GPT =================
    static async Task<string> CallGPT(string apiKey, string prompt)
    {
        using var client = new HttpClient();
        client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

        var json = JsonSerializer.Serialize(new
        {
            model = "gpt-5.3",
            messages = new[]
            {
                new { role = "user", content = prompt }
            }
        });

        var res = await client.PostAsync(
            "https://api.openai.com/v1/chat/completions",
            new StringContent(json, Encoding.UTF8, "application/json")
        );

        var body = await res.Content.ReadAsStringAsync();

        using var doc = JsonDocument.Parse(body);
        return doc.RootElement
            .GetProperty("choices")[0]
            .GetProperty("message")
            .GetProperty("content")
            .GetString();
    }

    // ================= Gemini =================
    static async Task<string> CallGemini(string apiKey, string prompt)
    {
        using var client = new HttpClient();

        var url = $"https://generativelanguage.googleapis.com/v1/models/gemini-pro:generateContent?key={apiKey}";

        var json = JsonSerializer.Serialize(new
        {
            contents = new[]
            {
                new
                {
                    parts = new[]
                    {
                        new { text = prompt }
                    }
                }
            }
        });

        var res = await client.PostAsync(
            url,
            new StringContent(json, Encoding.UTF8, "application/json")
        );

        var body = await res.Content.ReadAsStringAsync();

        using var doc = JsonDocument.Parse(body);
        return doc.RootElement
            .GetProperty("candidates")[0]
            .GetProperty("content")
            .GetProperty("parts")[0]
            .GetProperty("text")
            .GetString();
    }

    // ================= Claude =================
    static async Task<string> CallClaude(string apiKey, string prompt)
    {
        using var client = new HttpClient();

        client.DefaultRequestHeaders.Add("x-api-key", apiKey);
        client.DefaultRequestHeaders.Add("anthropic-version", "2023-06-01");

        var json = JsonSerializer.Serialize(new
        {
            model = "claude-3-opus-20240229",
            max_tokens = 1024,
            messages = new[]
            {
                new { role = "user", content = prompt }
            }
        });

        var res = await client.PostAsync(
            "https://api.anthropic.com/v1/messages",
            new StringContent(json, Encoding.UTF8, "application/json")
        );

        var body = await res.Content.ReadAsStringAsync();

        using var doc = JsonDocument.Parse(body);
        return doc.RootElement
            .GetProperty("content")[0]
            .GetProperty("text")
            .GetString();
    }
}