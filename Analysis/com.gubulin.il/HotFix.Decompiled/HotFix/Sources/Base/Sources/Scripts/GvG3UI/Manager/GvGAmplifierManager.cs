using System;
using System.Collections.Generic;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Services;
using Shift.Legion.Common.Sources.Enums;
using Shift.Legion.GvG.Common.Models;
using Shift.Legion.GvG.Common.Models.GvGMode3;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket;
using Shift.Legion.Helpers;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;

public class GvGAmplifierManager : Singleton<GvGAmplifierManager>
{
	public class AmplifierStorageData
	{
		public Dictionary<int, int> AmplifierStorage;

		public List<string> UnlockedFormulas;
	}

	public class ShipAmplifiersData
	{
		public string ShipId;

		public Dictionary<int, int> ShipsAmplifiers;
	}

	public class StorageAndShipAmplifiersData
	{
		public string ShipId;

		public Dictionary<int, int> ShipsAmplifiers;

		public Dictionary<int, int> AmplifierStorage;
	}

	public class ForgeData
	{
		public Dictionary<int, int> AmplifierStorage;

		public Dictionary<int, int> ForgedAmplifiers;

		public List<int> CriticalAmps;

		public List<ForgedExtraAmplifier> ExtraAmps;

		public List<ForgedExtraItem> ExtraItems;
	}

	private Dictionary<int, int> AmplifierStorage = new Dictionary<int, int>();

	private Dictionary<int, int> TotalLoadedAmplifiersCount = new Dictionary<int, int>();

	private List<string> UnlockedFormulas = new List<string>();

	private Dictionary<string, Dictionary<int, int>> ShipsAmplifiers = new Dictionary<string, Dictionary<int, int>>();

	private Action<ForgeData> onFinishedForgeAmp;

	public bool NeedSyncStorage = true;

	private bool _isEventRegistered = false;

	public Action<bool> OnUpdateTotalAmpFormulaRedDot = delegate
	{
	};

	private string FAVOURITE_AMP_FORMULA_KEY = "FAVOURITE_AMP_FORMULA_KEY";

	private HashSet<string> FavouriteFormulas = null;

	private HashSet<string> FavouriteFormulaConsumeItems = null;

	public RealTimeAmplifierTalentModel TalentData { get; private set; }

	public bool HasNewAmpFormulas => GvGAmplifierData?.HasNewAmpFormulas ?? false;

	public GvGAmplifierForgeModel GvGAmplifierData { get; set; }

	public void RegisterSocketEvents()
	{
		if (!_isEventRegistered)
		{
			_isEventRegistered = true;
			S2C_UnlockedAmpFormulas.OnPushEvent = (Action<S2C_UnlockedAmpFormulas.Request>)Delegate.Combine(S2C_UnlockedAmpFormulas.OnPushEvent, new Action<S2C_UnlockedAmpFormulas.Request>(OnPushUnlockedAmpFormulas));
		}
	}

	public void UnregisterSocketEvents()
	{
		if (_isEventRegistered)
		{
			_isEventRegistered = false;
			S2C_UnlockedAmpFormulas.OnPushEvent = (Action<S2C_UnlockedAmpFormulas.Request>)Delegate.Remove(S2C_UnlockedAmpFormulas.OnPushEvent, new Action<S2C_UnlockedAmpFormulas.Request>(OnPushUnlockedAmpFormulas));
		}
	}

	public void ClearData()
	{
		GvGAmplifierData = null;
		NeedSyncStorage = true;
		AmplifierStorage.Clear();
		TotalLoadedAmplifiersCount.Clear();
		UnlockedFormulas.Clear();
		ShipsAmplifiers.Clear();
		onFinishedForgeAmp = null;
		TalentData = null;
	}

	public void GetAmplifierStorage(Action<AmplifierStorageData> onFinished = null)
	{
		if (NeedSyncStorage)
		{
			NeedSyncStorage = false;
			SyncAmplifierStorage(onFinished);
		}
		else
		{
			onFinished?.Invoke(ToAmplifierStorageData());
		}
	}

	public void GetShipAmplifiers(string shipId, Action<ShipAmplifiersData> onFinished = null)
	{
		if (!ShipsAmplifiers.ContainsKey(shipId))
		{
			SyncShipAmplifiers(shipId, onFinished);
		}
		else
		{
			onFinished?.Invoke(ToShipsAmplifiersData(shipId));
		}
	}

	public ShipAmplifiersData TryGetShipAmplifiers(string shipId)
	{
		if (!ShipsAmplifiers.ContainsKey(shipId))
		{
			return null;
		}
		return ToShipsAmplifiersData(shipId);
	}

	public void ChangeShipAmplifiers(string shipId, Dictionary<int, int> shipAmpChanges, Action<StorageAndShipAmplifiersData> onFinished = null)
	{
		SocketManager.Instance.GetConnection(eConType.GvGMode3IslandManager).Request(new C2S_ChangeShipAmplifiers
		{
			Req = new C2S_ChangeShipAmplifiers.Request
			{
				ShipId = shipId,
				ShipAmplifierChanges = shipAmpChanges
			}
		}, delegate(SocketManager.BaseSocketPackageBodyContext context_response)
		{
			C2S_ChangeShipAmplifiers.Response response = (C2S_ChangeShipAmplifiers.Response)context_response.Resp;
			if (response.ErrorCode != 0)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
				onFinished?.Invoke(null);
			}
			else
			{
				Dictionary<int, int> dictionary = new Dictionary<int, int>();
				foreach (KeyValuePair<int, int> shipAmpChange in shipAmpChanges)
				{
					dictionary.Add(shipAmpChange.Key, -shipAmpChange.Value);
				}
				SyncAmplifierStorageWithChanges(dictionary);
				SyncShipAmplifiersWithChanges(shipId, shipAmpChanges);
				RemoveEmptyAmpRecord(shipId);
				onFinished?.Invoke(ToStorageAndShipAmplifiersData(shipId));
			}
		});
	}

	public void ForgeAmplifier(string formulaId, int forgeCount, Action<ForgeData> onFinished = null)
	{
		S2C_ForgeAmplifier.OnPushEvent = OnPushForgedAmplifiers;
		onFinishedForgeAmp = onFinished;
		SocketManager.Instance.GetConnection(eConType.GvGMode3IslandManager).Request(new C2S_ForgeAmplifier
		{
			Req = new C2S_ForgeAmplifier.Request
			{
				FormulaId = formulaId,
				ForgeCount = forgeCount
			}
		}, delegate(SocketManager.BaseSocketPackageBodyContext context_response)
		{
			C2S_ForgeAmplifier.Response response = (C2S_ForgeAmplifier.Response)context_response.Resp;
			if (response.ErrorCode < 0)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
				onFinished?.Invoke(null);
			}
		});
	}

	private void OnPushForgedAmplifiers(S2C_ForgeAmplifier.Request req)
	{
		S2C_ForgeAmplifier.OnPushEvent = null;
		if (req.ErrorCode < 0)
		{
			GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: false);
			ILRequestHelper.ShowErrorCode(req.ErrorCode);
			return;
		}
		if (req.GsItems != null)
		{
			foreach (RItem gsItem in req.GsItems)
			{
				GameManagers.Instance.StockController.SetStock(gsItem.ItemId, gsItem.cnt, (StockInContext)req.StockInContext);
			}
		}
		GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: false);
		Dictionary<string, int> curValueChanges = req.StorehouseCurValueChanges ?? new Dictionary<string, int>();
		Singleton<GvGStoreHouseManager>.Instance.SyncStoreHouseWithCurValueChanges(curValueChanges);
		Dictionary<int, int> dictionary = req.AmplifierStorageChanges ?? new Dictionary<int, int>();
		SyncAmplifierStorageWithChanges(dictionary);
		onFinishedForgeAmp?.Invoke(ToForgeData(dictionary, req.CriticalAmps ?? new List<int>(), req.ExtraAmps ?? new List<ForgedExtraAmplifier>(), req.ExtraItems ?? new List<ForgedExtraItem>()));
	}

	private void OnPushUnlockedAmpFormulas(S2C_UnlockedAmpFormulas.Request req)
	{
		UnlockedFormulas = req.Unlocked ?? new List<string>();
		GvGAmplifierData?.UpdateUnlockedFormulas(UnlockedFormulas);
		OnUpdateTotalAmpFormulaRedDot?.Invoke(HasNewAmpFormulas);
	}

	public int GetAmplifierOwnedCount(int idx)
	{
		return GetAmplifierOnStorageCount(idx) + GetAmplifierOnShipsTotalCount(idx);
	}

	public int GetAmplifierOnStorageCount(int idx)
	{
		if (!AmplifierStorage.TryGetValue(idx, out var value))
		{
			return 0;
		}
		return value;
	}

	public int GetAmplifierOnShipsTotalCount(int idx)
	{
		if (!TotalLoadedAmplifiersCount.TryGetValue(idx, out var value))
		{
			return 0;
		}
		return value;
	}

	public Dictionary<int, int> PreviewShipAmpChanges(string shipId, Dictionary<int, int> changes)
	{
		if (!ShipsAmplifiers.ContainsKey(shipId))
		{
			return changes;
		}
		Dictionary<int, int> dictionary = new Dictionary<int, int>(ShipsAmplifiers[shipId]);
		StorageHelper.DoStorageOffsetChanges(dictionary, changes);
		return dictionary;
	}

	public void SyncAmplifierTalentData(Action onFinished = null)
	{
		SocketManager.Instance.GetConnection(eConType.GvGMode3IslandManager).Request(new C2S_GetAmplifierTalentData
		{
			Req = new C2S_GetAmplifierTalentData.Request
			{
				NonStr = ""
			}
		}, delegate(SocketManager.BaseSocketPackageBodyContext context_response)
		{
			C2S_GetAmplifierTalentData.Response response = (C2S_GetAmplifierTalentData.Response)context_response.Resp;
			if (response.ErrorCode < 0)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				TalentData = response.Model;
				onFinished?.Invoke();
			}
		});
	}

	private AmplifierStorageData ToAmplifierStorageData()
	{
		return new AmplifierStorageData
		{
			UnlockedFormulas = UnlockedFormulas,
			AmplifierStorage = AmplifierStorage
		};
	}

	private ShipAmplifiersData ToShipsAmplifiersData(string shipId)
	{
		return new ShipAmplifiersData
		{
			ShipId = shipId,
			ShipsAmplifiers = ShipsAmplifiers[shipId]
		};
	}

	private StorageAndShipAmplifiersData ToStorageAndShipAmplifiersData(string shipId)
	{
		return new StorageAndShipAmplifiersData
		{
			ShipId = shipId,
			ShipsAmplifiers = ShipsAmplifiers[shipId],
			AmplifierStorage = AmplifierStorage
		};
	}

	private ForgeData ToForgeData(Dictionary<int, int> forgedAmplifiers, List<int> criticalAmps, List<ForgedExtraAmplifier> extraAmps, List<ForgedExtraItem> extraItems)
	{
		return new ForgeData
		{
			AmplifierStorage = AmplifierStorage,
			ForgedAmplifiers = forgedAmplifiers,
			CriticalAmps = criticalAmps,
			ExtraAmps = extraAmps,
			ExtraItems = extraItems
		};
	}

	private void SyncAmplifierStorage(Action<AmplifierStorageData> onFinished = null)
	{
		SocketManager.Instance.GetConnection(eConType.GvGMode3IslandManager).Request(new C2S_GetAmplifierStorage
		{
			Req = new C2S_GetAmplifierStorage.Request
			{
				NonStr = ""
			}
		}, delegate(SocketManager.BaseSocketPackageBodyContext context_response)
		{
			C2S_GetAmplifierStorage.Response response = (C2S_GetAmplifierStorage.Response)context_response.Resp;
			if (response.ErrorCode < 0)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				AmplifierStorage = response.AmplifierStorage ?? new Dictionary<int, int>();
				TotalLoadedAmplifiersCount = response.LoadedAmplifiers ?? new Dictionary<int, int>();
				UnlockedFormulas = response.HasUnlockAmp ?? new List<string>();
				AmplifierStorageData obj = ToAmplifierStorageData();
				onFinished?.Invoke(obj);
			}
		});
	}

	private void SyncShipAmplifiers(string shipId, Action<ShipAmplifiersData> onFinished = null)
	{
		SocketManager.Instance.GetConnection(eConType.GvGMode3IslandManager).Request(new C2S_GetShipAmplifiers
		{
			Req = new C2S_GetShipAmplifiers.Request
			{
				ShipId = shipId
			}
		}, delegate(SocketManager.BaseSocketPackageBodyContext context_response)
		{
			C2S_GetShipAmplifiers.Response response = (C2S_GetShipAmplifiers.Response)context_response.Resp;
			if (response.ErrorCode < 0)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				Dictionary<int, int> value = ((response.Amplifiers == null) ? new Dictionary<int, int>() : response.Amplifiers);
				if (ShipsAmplifiers.ContainsKey(shipId))
				{
					ShipsAmplifiers[shipId] = value;
				}
				else
				{
					ShipsAmplifiers.Add(shipId, value);
				}
				ShipAmplifiersData obj = ToShipsAmplifiersData(shipId);
				onFinished?.Invoke(obj);
			}
		});
	}

	public void SyncAmplifierStorageWithChanges(Dictionary<int, int> changes)
	{
		if (changes != null)
		{
			StorageHelper.DoStorageOffsetChanges(AmplifierStorage, changes);
		}
	}

	public void SyncAmplifierStorageWithCurValueChanges(Dictionary<int, int> curValueChanges)
	{
		if (curValueChanges != null)
		{
			StorageHelper.DoStorageChanges_SyncCurValue(AmplifierStorage, curValueChanges);
		}
	}

	private void SyncShipAmplifiersWithChanges(string shipId, Dictionary<int, int> changes)
	{
		if (!ShipsAmplifiers.ContainsKey(shipId))
		{
			ShipsAmplifiers.Add(shipId, new Dictionary<int, int>());
		}
		StorageHelper.DoStorageOffsetChanges(ShipsAmplifiers[shipId], changes);
		StorageHelper.DoStorageOffsetChanges(TotalLoadedAmplifiersCount, changes);
	}

	private void RemoveEmptyAmpRecord(string shipId)
	{
		Dictionary<int, int> dictionary = ShipsAmplifiers[shipId];
		if (dictionary == null || dictionary.Count <= 0)
		{
			return;
		}
		List<int> list = new List<int>();
		foreach (KeyValuePair<int, int> item in dictionary)
		{
			if (item.Value <= 0)
			{
				list.Add(item.Key);
			}
		}
		foreach (int item2 in list)
		{
			dictionary.Remove(item2);
		}
	}

	public void GetGvGAmplifierData()
	{
		if (GvGAmplifierData == null)
		{
			GvGAmplifierData = new GvGAmplifierForgeModel();
		}
		Singleton<GvGStoreHouseManager>.Instance.SyncStoreHouse(GetData);
		void GetData()
		{
			GvGAmplifierData.GetData(UpdateRedDot, isInit: true);
		}
		void UpdateRedDot()
		{
			OnUpdateTotalAmpFormulaRedDot?.Invoke(HasNewAmpFormulas);
		}
	}

	public void SwitchFormulaFavouriteState(string formulaId)
	{
		EnsureToLoadFavouriteData();
		if (FavouriteFormulas.Contains(formulaId))
		{
			FavouriteFormulas.Remove(formulaId);
		}
		else
		{
			FavouriteFormulas.Add(formulaId);
		}
		RefreshFavouriteFormulaConsumeItems();
		SaveFavouriteData();
	}

	public bool CheckIsFormulaFavourite(string formulaId)
	{
		EnsureToLoadFavouriteData();
		return FavouriteFormulas.Contains(formulaId);
	}

	public bool CheckIsFormulaConsumeItemFavourite(string itemId)
	{
		EnsureToLoadFavouriteData();
		return FavouriteFormulaConsumeItems.Contains(itemId);
	}

	private void EnsureToLoadFavouriteData()
	{
		if (FavouriteFormulas == null)
		{
			string text = GameLocalDataManager.GetString(FAVOURITE_AMP_FORMULA_KEY);
			if (string.IsNullOrEmpty(text))
			{
				FavouriteFormulas = new HashSet<string>();
			}
			else
			{
				List<string> collection = JsonHelper.ToObject<List<string>>(text);
				FavouriteFormulas = new HashSet<string>(collection);
			}
			RefreshFavouriteFormulaConsumeItems();
		}
	}

	private void SaveFavouriteData()
	{
		List<string> obj = new List<string>(FavouriteFormulas);
		string value = JsonHelper.ToJson(obj);
		GameLocalDataManager.SetString(FAVOURITE_AMP_FORMULA_KEY, value);
	}

	private void RefreshFavouriteFormulaConsumeItems()
	{
		FavouriteFormulaConsumeItems = new HashSet<string>();
		foreach (string favouriteFormula in FavouriteFormulas)
		{
			AmplifierFormulaModel amplifierFormulaModel = AmpConfigHelper.TryGetAmplifierFormula(favouriteFormula);
			foreach (string key in amplifierFormulaModel.Input_Dict.Keys)
			{
				if (!FavouriteFormulaConsumeItems.Contains(key))
				{
					FavouriteFormulaConsumeItems.Add(key);
				}
			}
		}
	}
}
