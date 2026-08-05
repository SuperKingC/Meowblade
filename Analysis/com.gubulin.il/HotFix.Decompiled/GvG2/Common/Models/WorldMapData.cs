using System.Collections.Generic;

namespace GvG2.Common.Models;

public class WorldMapData
{
	public Dictionary<string, IslandProps> Islands_Dict;

	public Dictionary<string, NavLineProps> NavLine_Dict;

	public void Init()
	{
		Islands_Dict = new Dictionary<string, IslandProps>();
		NavLine_Dict = new Dictionary<string, NavLineProps>();
	}
}
