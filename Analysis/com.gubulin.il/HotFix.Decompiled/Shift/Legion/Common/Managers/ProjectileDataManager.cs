using System.Collections.Generic;
using GameDataEditor;
using Shift.Legion.Common.Helpers;

namespace Shift.Legion.Common.Managers;

public class ProjectileDataManager : Singleton<ProjectileDataManager>
{
	private Dictionary<string, GDEProjectileData> _dict = new Dictionary<string, GDEProjectileData>();

	public override void InitInstance()
	{
		LoadAllData();
	}

	public void LoadAllData()
	{
		IEnumerable<GDEProjectileData> allItems = GDMgr.GetAllItems<GDEProjectileData>();
		_dict.Clear();
		foreach (GDEProjectileData item in allItems)
		{
			if (!_dict.ContainsKey(item.Key))
			{
				_dict.Add(item.Key, item);
			}
		}
	}

	public GDEProjectileData Get(string id)
	{
		if (_dict.ContainsKey(id))
		{
			return _dict[id];
		}
		return null;
	}
}
