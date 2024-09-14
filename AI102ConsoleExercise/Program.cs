using System;
using Azure;
using Azure.AI.TextAnalytics;
using AzureAIServices;

namespace AI102ConsoleExercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var serviceDetails = ReadUserSecrets.ReadSecrets<UserSecretOptions>("TextAnalytics");

            var textAnalytics = new TextAnalytics(serviceDetails);
            textAnalytics.SingleLanguageDetection();

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
