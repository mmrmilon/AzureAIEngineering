using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureAIServices
{
    public class UserSecretOptions
    {
        public string? Endpoint { get; set; }
        public string? Key { get; set; }
        public string? Region { get; set; }
        public string? TextTranslationEndpoint { get; set; }
        public string? DocumentTranslationEndpoint { get; set; }
    }
}
