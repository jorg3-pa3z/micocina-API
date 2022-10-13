using System;
namespace micocina_API.Models
{
    public class API_Settings
    {
        public API_Settings()
        {
        }

        private string _blogger_ApiKey;
        private string _blogger_BlogId;

        public string Blogger_ApiKey { get => _blogger_ApiKey; set => _blogger_ApiKey = value; }
        public string Blogger_BlogId { get => _blogger_BlogId; set => _blogger_BlogId = value; }
    }
}

