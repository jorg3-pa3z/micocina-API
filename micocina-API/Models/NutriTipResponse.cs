using System;
namespace micocina_API.Models
{
    public class NutriTipResponse
    {
        public NutriTipResponse()
        {
        }

        private NutriTip[] _nutriTips;
        private string _nextPage;

        public NutriTip[] NutriTips { get => _nutriTips; set => _nutriTips = value; }
        public string NextPage { get => _nextPage; set => _nextPage = value; }
    }
}
