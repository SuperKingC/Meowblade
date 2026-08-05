using System.Collections.Generic;
using GameDataEditor;
using Shift.Legion.Common.Managers;
using Shift.Legion.Helpers;

namespace Shift.Legion.Common.Models;

public class BuildingInfoEvo : InfoEvo
{
	private const string KeyBg = "Bg";

	private const string DefaultBg = "";

	public List<string> BgList;

	public BuildingInfoEvo(string evoInfoId)
		: base(evoInfoId)
	{
		BgList = new List<string>();
		GDEInfoEvoData gDEInfoEvoData = GDMgr.Get<GDEInfoEvoData>(evoInfoId);
		if (gDEInfoEvoData == null)
		{
			return;
		}
		for (int i = 0; i < NameList.Count; i++)
		{
			object obj = gDEInfoEvoData.GetType().GetProperty($"Extra{i + 1}")?.GetValue(gDEInfoEvoData);
			if (obj == null || string.IsNullOrEmpty(obj.ToString()))
			{
				BgList.Add("");
				continue;
			}
			Dictionary<string, string> dictionary = JsonHelper.ToObject<Dictionary<string, string>>(obj.ToString());
			BgList.Add(dictionary.ContainsKey("Bg") ? dictionary["Bg"] : "");
		}
	}
}
