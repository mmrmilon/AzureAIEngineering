using System;
using Azure;
using Azure.AI.TextAnalytics;

namespace AzureAIServices
{
    public class TextAnalytics
    {
        public TextAnalytics(UserSecretOptions secretOptions)
        {
            credential = new(secretOptions.Key!);
            endpoint = new(secretOptions.Endpoint!);
        }

        public void SingleLanguageDetection()
        {
            var document = "Este documento está escrito en un lenguaje diferente al inglés. Su objectivo es demostrar cómo"
                + "The hotel has some great staff but the location is not in a good neighborhood.";

            var response = ServiceClient().DetectLanguage(document);

            Console.WriteLine($"Language: {response.Value.Name}, \tISO-6391: {response.Value.Iso6391Name}");
        }

        public void MultiLanguageDetection()
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
                var response = ServiceClient().DetectLanguage(document);

                Console.WriteLine($"Language: {response.Value.Name}, \tISO-6391: {response.Value.Iso6391Name}");
            }
        }

        #region Private Method and Attributes
        private readonly AzureKeyCredential credential;
        private readonly Uri endpoint;

        private TextAnalyticsClient ServiceClient()
        {
            return new TextAnalyticsClient(endpoint, credential);
        }
        #endregion
    }
}
