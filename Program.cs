using System;
using System.IO;
using System.Net;
using HtmlAgilityPack;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = "https://liquipedia.net/wildrift/Wild_Rift_League_Asia/2023/Season_1"; // URL do site que você deseja baixar
            string outputFilePath = "dados.txt"; // Caminho do arquivo de texto de saída

            WebClient client = new WebClient();

            try
            {
                // Baixa o conteúdo da página da web como uma string
                string html = client.DownloadString(url);

                // Analisa o conteúdo da página usando o HtmlAgilityPack
                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(html);

                // Localiza o elemento "title" e extrai seu valor
                string title = doc.DocumentNode.SelectSingleNode("//title").InnerText;

                // Salva o título extraído em um arquivo de texto
                File.WriteAllText(outputFilePath, title);

                Console.WriteLine($"O título da página foi extraído com sucesso e salvo em {outputFilePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro ao extrair os dados: {ex.Message}");
            }
        }
    }
}
