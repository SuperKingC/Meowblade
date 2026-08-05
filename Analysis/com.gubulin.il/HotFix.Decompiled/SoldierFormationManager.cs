using System.Collections.Generic;
using GameDataEditor;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;

public class SoldierFormationManager : Singleton<SoldierFormationManager>
{
	private Dictionary<string, int[]> _dict = new Dictionary<string, int[]>();

	public override void InitInstance()
	{
		LoadAllData();
	}

	public void LoadAllData()
	{
		IEnumerable<GDESoldierFormationData> allItems = GDMgr.GetAllItems<GDESoldierFormationData>();
		_dict.Clear();
		foreach (GDESoldierFormationData item in allItems)
		{
			if (_dict.ContainsKey(item.SoldierId))
			{
				continue;
			}
			int num = 100;
			int[] array = new int[num];
			string[] array2 = item.Config.Split('|');
			string[] array3 = array2;
			foreach (string text in array3)
			{
				string[] array4 = text.Split(',');
				int num2 = int.Parse(array4[0]);
				int num3 = int.Parse(array4[1]);
				for (int j = num2 - 1; j < num; j++)
				{
					array[j] = num3;
				}
			}
			_dict.Add(item.SoldierId, array);
		}
	}

	public int GetSoldierFormationNumber(string soldierId, int level, int levelAdded = 0)
	{
		if (!_dict.TryGetValue(soldierId, out var value))
		{
			string text = GDMgr.Get<GDESoldierData>(soldierId)?.ParentSoldierId;
			if (string.IsNullOrEmpty(text))
			{
				return 1;
			}
			_dict.TryGetValue(text, out value);
		}
		level = ((levelAdded > 0) ? (level + levelAdded) : level);
		if (value == null || level > value.Length || level <= 0)
		{
			return 1;
		}
		return value[level - 1];
	}
}
