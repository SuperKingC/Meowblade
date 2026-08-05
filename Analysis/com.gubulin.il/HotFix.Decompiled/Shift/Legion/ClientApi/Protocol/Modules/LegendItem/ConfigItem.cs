using System.Collections.Generic;

namespace Shift.Legion.ClientApi.Protocol.Modules.LegendItem;

public class ConfigItem
{
	public string MainId;

	public string EnhanceFxEntryId;

	public string PoolConfig;

	public Dictionary<string, FxConfigItem> RandomFXConfig;
}
