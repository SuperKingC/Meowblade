using System.Collections.Generic;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Model;

public class WorldMapData
{
	public Dictionary<string, List<string>> SpriteGroupConfigs;

	public Dictionary<string, List<string>> DecoGroupConfigs;

	public Dictionary<string, IslandProps> Islands_Dict;

	public Dictionary<string, NavLineProps> NavLine_Dict;

	public void Init()
	{
		Islands_Dict = new Dictionary<string, IslandProps>();
		NavLine_Dict = new Dictionary<string, NavLineProps>();
		SpriteGroupConfigs = new Dictionary<string, List<string>>();
		DecoGroupConfigs = new Dictionary<string, List<string>>();
	}
}
