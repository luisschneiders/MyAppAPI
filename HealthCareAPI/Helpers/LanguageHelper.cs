using System;
using HealthCareAPI.Settings.Enum;

namespace HealthCareAPI.Helpers
{
    public class LanguageHelper
    {
        public List<string> Scopes { get; set; } = new List<string>();

        public LanguageHelper()
        {
            Scopes = ListOfScopes();
        }

        public List<string> ListOfScopes()
        {
            return Enum.GetNames(typeof(LanguageScope)).ToList();
        }
    }
}
