using System;
using HealthCareAPI.Settings.Enum;

namespace HealthCareAPI.Shared
{
    public class AppSettings
    {
        public static string scopeLanguage { get; set; } = "";

        public string BuildScope(LanguageScope scope)
        {
            switch (scope)
            {
                case LanguageScope.dictionary:
                    scopeLanguage = "dictionary";
                    break;
                case LanguageScope.translation:
                    scopeLanguage = "translation";
                    break;
                case LanguageScope.transliteration:
                    scopeLanguage = "transliteration";
                    break;
                case LanguageScope.all:
                    scopeLanguage = "all";
                    break;
            }

            return scopeLanguage;
        }
    }
}

