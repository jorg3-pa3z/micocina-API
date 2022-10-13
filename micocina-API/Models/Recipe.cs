using System;
namespace micocina_API.Models
{
    public class Recipe:BlogPost
    {
        private String[] _types;
        public String[] Types { get => _types; set => _types = value; }
    }
}
