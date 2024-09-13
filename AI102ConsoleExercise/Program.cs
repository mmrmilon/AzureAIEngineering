using System;
using Azure;
using Azure.AI.TextAnalytics;

namespace AI102ConsoleExercise
{
    internal class Program
    {
        private static readonly AzureKeyCredential credential = new("<apiKey>");
        private static readonly Uri endpoint = new("<endpoint>");
        
        
        static void Main(string[] args)
        {
            var client = new TextAnalyticsClient(endpoint, credential);

            MultiLanguageDetection(client);

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        static void SingleLanguageDetection(TextAnalyticsClient client)
        {
            var document = "Este documento está escrito en un lenguaje diferente al inglés. Su objectivo es demostrar cómo" 
                + "The hotel has some great staff but the location is not in a good neighborhood.";

            var response = client.DetectLanguage(document);

            Console.WriteLine($"Language: {response.Value.Name}, \tISO-6391: {response.Value.Iso6391Name}");        
        }

        static void MultiLanguageDetection(TextAnalyticsClient client)
        {
            var documents = new List<string>
            {
                @"Este documento está escrito en un lenguaje diferente al inglés.",
                @"The hotel has some great staff but the location is not in a good neighborhood.",
                @"Selamat pagi. Mau makan untuk sarapan?",
                @"Hola, buenos dias. Me gustaria una torlilla de patata y dos cafes con leche."
            };

            foreach (var document in documents) 
            {
                var response = client.DetectLanguage(document);

                Console.WriteLine($"Language: {response.Value.Name}, \tISO-6391: {response.Value.Iso6391Name}");
            }
        }
    }
}
