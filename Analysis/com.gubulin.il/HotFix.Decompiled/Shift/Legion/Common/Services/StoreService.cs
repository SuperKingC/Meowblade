using System.Collections.Generic;
using GameDataEditor;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;

namespace Shift.Legion.Common.Services;

public class StoreService : Service, IStoreService, IService
{
	private List<StoreCategoryConfig> _storeCategoryConfigs;

	public List<StoreCategoryConfig> StoreCategoryConfigs
	{
		get
		{
			if (_storeCategoryConfigs == null)
			{
				return UpdateStoreCategoryConfigs();
			}
			return _storeCategoryConfigs;
		}
	}

	public StoreService(Contexts contexts)
		: base(contexts)
	{
	}

	public List<StoreCategoryConfig> UpdateStoreCategoryConfigs()
	{
		if (_storeCategoryConfigs == null)
		{
			_storeCategoryConfigs = new List<StoreCategoryConfig>();
		}
		else
		{
			_storeCategoryConfigs.Clear();
		}
		foreach (GDEStoreCategoryData allItem in GDMgr.GetAllItems<GDEStoreCategoryData>())
		{
			_storeCategoryConfigs.Add(new StoreCategoryConfig(allItem));
		}
		return _storeCategoryConfigs;
	}
}
