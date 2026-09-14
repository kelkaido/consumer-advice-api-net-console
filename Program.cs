using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        using HttpClient httpClient = new HttpClient();

        string url = "https://api.adviceslip.com/advice";

        try
        {
            string json = await httpClient.GetStringAsync(url);

            using JsonDocument documento = JsonDocument.Parse(json);

            string? conselho = documento
                .RootElement
                .GetProperty("slip")
                .GetProperty("advice")
                .GetString();

            Console.WriteLine("Conselho de Hoje:");
            Console.WriteLine(conselho);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao buscar conselho: " + ex.Message);
        }
    }
}

//O código está rodando pelo console com dotnet run mas está funcionando. Saída:
// PS C:\Users\Raquel\OneDrive\Desktop\Desenvolvimento web\API\Api_Advice\ConsomerAdviceApi> dotnet run
//Conselho de Hoje:
//If you don't want something to be public, don't post it on the Internet.