using GameDataEditor;
using HotFix.Sources.Base.Scripts.Helper;
using Shift.Legion.Common.Managers;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Model.Medal;

public class GvGMedalConfig
{
	public string Name { get; private set; }

	public string BigIcon { get; private set; }

	public string SmallIcon { get; private set; }

	public int Rarity { get; private set; }

	public string PostScript { get; private set; }

	public int Index { get; private set; }

	public GvGMedalConfig(string medalId)
	{
		GDEItemData gDEItemData = GDMgr.Get<GDEItemData>(medalId);
		Name = gDEItemData.Name;
		BigIcon = (gDEItemData.Icon + "_0").ToPublicResourcesRgbIcon();
		SmallIcon = (gDEItemData.Icon + "_1").ToPublicResourceIcon();
		Rarity = gDEItemData.Rarity;
		PostScript = gDEItemData.PostScript;
		Index = (int.TryParse(gDEItemData.Key.Replace("I", string.Empty), out var result) ? result : 0);
	}
}
