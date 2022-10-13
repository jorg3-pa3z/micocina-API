using System;
namespace micocina_API.Models
{
    public class ExperienceResponse
    {
        public ExperienceResponse()
        {
        }

        private Experience[] _experiences;
        private string _nextPage;

        public Experience[] Experiences { get => _experiences; set => _experiences = value; }
        public string NextPage { get => _nextPage; set => _nextPage = value; }
    }
}
