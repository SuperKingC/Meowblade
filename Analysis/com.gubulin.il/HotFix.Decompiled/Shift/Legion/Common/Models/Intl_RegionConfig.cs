using System.Collections.Generic;

namespace Shift.Legion.Common.Models;

public class Intl_RegionConfig
{
	public string code;

	public string name;

	public string currency;

	public List<Intl_LocaleConfig> locales;

	public Dictionary<string, Intl_ChannelConfig> channel;

	public Intl_URLConfig url;
}
