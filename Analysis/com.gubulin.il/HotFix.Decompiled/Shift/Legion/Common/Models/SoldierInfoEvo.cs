using System.Collections.Generic;
using Assets.Scripts.Managers;
using GameDataEditor;
using Shift.Legion.Common.Managers;
using Shift.Legion.Helpers;

namespace Shift.Legion.Common.Models;

public class SoldierInfoEvo : InfoEvo
{
	private const string KeyDesc = "Desc";

	public List<string> DescList;

	private string DefaultDesc => LanguagesManager.GetDesc("CsharpCodeZhTcText825");

	public SoldierInfoEvo(string evoInfoId)
		: base(evoInfoId)
	{
		DescList = new List<string>();
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
				DescList.Add(DefaultDesc);
				continue;
			}
			Dictionary<string, string> dictionary = JsonHelper.ToObject<Dictionary<string, string>>(obj.ToString());
			DescList.Add(dictionary.ContainsKey("Desc") ? dictionary["Desc"] : DefaultDesc);
		}
	}
}
