using System;
namespace micocina_API.Models
{
    public class BlogPost
    {
        public BlogPost()
        {
        }

        private String _name;
        private String _url;

        public string Name { get => _name; set => _name = value; }
        public string Url { get => _url; set => _url = value; }
    }
}
