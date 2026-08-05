using System.Collections.Generic;

namespace HotFix.Sources.Shift.Legion.Shift.Legion.Common.Sources.Models;

public class Intl_RegionConfig
{
	public string code;

	public string name;

	public string currency;

	public List<Intl_LocaleConfig> locales;

	public Dictionary<string, Intl_ChannelConfig> channel;
}
