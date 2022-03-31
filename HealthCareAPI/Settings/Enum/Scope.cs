using System;
using System.ComponentModel;

namespace HealthCareAPI.Settings.Enum
{
	public enum LanguageScope
	{

		[Description("all")]
		all = 0,

		[Description("dictionary")]
		dictionary = 1,

		[Description("translation")]
		translation = 2,

		[Description("transliteration")]
		transliteration = 3,

	}
}
