using System.Collections.Generic;
using GameDataEditor;
using Shift.Legion.Common.Managers;

namespace Shift.Legion.Common.Models;

public class InfoEvo
{
	protected const int EvoCount = 10;

	protected const string DefaultName = "NAME_PLACE_HOLDER";

	public string Id;

	public List<string> NameList;

	public InfoEvo(string evoInfoId)
	{
		Id = evoInfoId;
		NameList = new List<string>();
		GDEInfoEvoData gDEInfoEvoData = GDMgr.Get<GDEInfoEvoData>(evoInfoId);
		if (gDEInfoEvoData == null)
		{
			return;
		}
		for (int i = 0; i < 10; i++)
		{
			object obj = gDEInfoEvoData.GetType().GetProperty($"Name{i + 1}")?.GetValue(gDEInfoEvoData);
			if (obj != null && !string.IsNullOrEmpty(obj.ToString()))
			{
				NameList.Add(obj.ToString());
			}
		}
	}
}
