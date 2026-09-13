 using System.Text.Json;
 using ConsumerViaCep.Models;
 using static System.Console;

 WriteLine("Digite o seu CEP: ");
 ConsumerViaCep - Program.cs
var cep = ReadLine();

var enderecoUrl = $@"https://viacep.com.br/ws/{cep}/json/";

 WriteLine($"Realizando requisisição para o endpoint: {enderecoUrl}");

var client = new HttpClient();

 try
{
HttpResponseMessage? response = await client.GetAsync(enderecoUrl);
response.EnsureSuccessStatusCode();
string responseString = await response.Content.ReadAsStringAsync();

Endereco? enderecoRetornadoDaApi = JsonSerializer.Deserialize<Endereco>(responseString);
WriteLine($"CEP: {enderecoRetornadoDaApi.Cep}");
 WriteLine($"Rua: {enderecoRetornadoDaApi.Logradouro}");
 WriteLine($"Cidade: {enderecoRetornadoDaApi.Localidade}");
 }
 catch (System.Exception e)
 {
 WriteLine("Erro: " + e.InnerException);
 WriteLine("Aconteceu um erro ao consultar a api: " + e.Message);
}