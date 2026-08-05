using System;
using System.Collections.Generic;
using GameDataEditor;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Services;
using Shift.Legion.GvG.Common.Models;
using Shift.Legion.GvGServer.Helper;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket;
using Shift.Legion.Helpers;
using UI.UseItemResult;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3Common.Manager;

public class GvGStoreHouseManager : Singleton<GvGStoreHouseManager>
{
	private const int FORMULA_SCROLL_ITEMTYPE = 40;

	public bool HasSync;

	public Action OnChange = delegate
	{
	};

	public Action<string> OnUseItem = delegate
	{
	};

	public Dictionary<string, int> Items = new Dictionary<string, int>();

	private string UseItemId;

	private bool HasRegisterUpdateRedDots = false;

	private Action OnRedDotChange = delegate
	{
	};

	public GvGStorehouseRedDot _RedDot;

	public GvGStorehouseRedDot RedDot
	{
		get
		{
			if (_RedDot == null)
			{
				LoadRedDotData();
			}
			return _RedDot;
		}
	}

	public void ClearData()
	{
		HasSync = false;
		OnChange = null;
		Items = new Dictionary<string, int>();
	}

	public void UseItem(string itemId, int count = 1, List<string> selectedItems = null, Action onSuccess = null)
	{
		UseItemId = itemId;
		S2C_GvGStorehouseChange.OnPushEvent = OnPushStorehouseChange;
		SocketManager.Instance.GetConnection(eConType.GvGMode3IslandManager).Request(new C2S_UseItem
		{
			Req = new C2S_UseItem.Request
			{
				ItemId = itemId,
				Cnt = count,
				SelectedItems = selectedItems
			}
		}, delegate(SocketManager.BaseSocketPackageBodyContext context_response)
		{
			C2S_UseItem.Response response = (C2S_UseItem.Response)context_response.Resp;
			if (response.ErrorCode != 0)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				onSuccess?.Invoke();
			}
		});
	}

	public void SyncStoreHouse(Action onSuccess = null)
	{
		S2C_GvGStorehouseChange.OnPushEvent = OnPushStorehouseChange;
		SocketManager.Instance.GetConnection(eConType.GvGMode3IslandManager).Request(new C2S_GetStorehouse
		{
			Req = new C2S_GetStorehouse.Request
			{
				NonStr = ""
			}
		}, delegate(SocketManager.BaseSocketPackageBodyContext context_response)
		{
			C2S_GetStorehouse.Response response = (C2S_GetStorehouse.Response)context_response.Resp;
			if (response.ErrorCode != 0)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				HasSync = true;
				Items = response.Items ?? new Dictionary<string, int>();
				OnChange?.Invoke();
				onSuccess?.Invoke();
			}
		});
	}

	private void OnPushStorehouseChange(S2C_GvGStorehouseChange.Request req)
	{
		Dictionary<string, int> storehouseCurValueChanges = req.StorehouseCurValueChanges;
		if (storehouseCurValueChanges == null)
		{
			return;
		}
		SyncStoreHouseWithCurValueChanges(storehouseCurValueChanges);
		if (string.IsNullOrEmpty(UseItemId))
		{
			return;
		}
		OnUseItem?.Invoke(UseItemId);
		if (req.RItems_RewardItems == null && req.TalentRItems == null && req.RItems_Amplifiers == null)
		{
			return;
		}
		if (req.RItems_Amplifiers != null)
		{
			Dictionary<int, int> dictionary = new Dictionary<int, int>();
			foreach (RItem rItems_Amplifier in req.RItems_Amplifiers)
			{
				AmplifierModel amplifierModel = AmpConfigHelper.Configs.TryGetAmplifier(rItems_Amplifier.ItemId);
				dictionary.Add(amplifierModel.Idx, rItems_Amplifier.cnt);
			}
			Singleton<GvGAmplifierManager>.Instance.SyncAmplifierStorageWithChanges(dictionary);
		}
		OpenGvGUseItemResultPanel(UseItemId, req);
		UseItemId = null;
	}

	private void OpenGvGUseItemResultPanel(string useItemId, S2C_GvGStorehouseChange.Request req)
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_GvGUseItemResultPanel.Name, new Dictionary<string, object>
		{
			{ "UseItemId", useItemId },
			{ "Result", req }
		});
	}

	public void SyncStoreHouseWithOffsetChanges(Dictionary<string, int> offsetChanges)
	{
		StorageHelper.DoStorageOffsetChanges(Items, offsetChanges);
		OnChange?.Invoke();
	}

	public void SyncStoreHouseWithCurValueChanges(Dictionary<string, int> curValueChanges)
	{
		StorageHelper.DoStorageChanges_SyncCurValue(Items, curValueChanges);
		OnChange?.Invoke();
		Singleton<GvGAmplifierManager>.Instance.GvGAmplifierData?.UpdateUnlockedFormulas(curValueChanges, notice: true);
	}

	public int GetItemCount(string itemId, bool includingGSStock = false)
	{
		if (StorehouseHelper.IsGvGItem(itemId))
		{
			Items.TryGetValue(itemId, out var value);
			return value;
		}
		if (includingGSStock)
		{
			return GameManagers.Instance.StockController.GetStock(itemId);
		}
		return 0;
	}

	public bool IsFormulaScrollItem(string itemId)
	{
		GDEItemData gDEItemData = GDMgr.Get<GDEItemData>(itemId);
		return gDEItemData != null && gDEItemData.ItemType == 40;
	}

	public void GetRealtimeStockLimit(Action<C2S_GetRealTimeStorehouseLimitParModel.Response> callback)
	{
		SocketManager.Instance.GetConnection(eConType.GvGMode3IslandManager).Request(new C2S_GetRealTimeStorehouseLimitParModel(), delegate(SocketManager.BaseSocketPackageBodyContext contextResponse)
		{
			C2S_GetRealTimeStorehouseLimitParModel.Response response = (C2S_GetRealTimeStorehouseLimitParModel.Response)contextResponse.Resp;
			if (response.ErrorCode < 0)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				callback?.Invoke(response);
			}
		});
	}

	public void AddOnRedDotChange(Action callback)
	{
		if (!HasRegisterUpdateRedDots)
		{
			HasRegisterUpdateRedDots = true;
			OnChange = (Action)Delegate.Combine(OnChange, new Action(UpdateRedDots));
		}
		OnRedDotChange = (Action)Delegate.Combine(OnRedDotChange, callback);
	}

	public void RemoveOnRedDotChange(Action callback)
	{
		if (HasRegisterUpdateRedDots)
		{
			HasRegisterUpdateRedDots = false;
			OnChange = (Action)Delegate.Remove(OnChange, new Action(UpdateRedDots));
		}
		OnRedDotChange = (Action)Delegate.Remove(OnRedDotChange, callback);
	}

	public void UpdateRedDots()
	{
		RedDot.Trophy = false;
		RedDot.Unpurified = false;
		bool flag = RedDot.UnpurifiedRedDotShowTimestamp > GameController.Instance.GetServerTime();
		int num = 0;
		foreach (KeyValuePair<string, int> item in Items)
		{
			if (!StockController.StorehouseDataDictionary.TryGetValue("SH_" + item.Key, out var value))
			{
				continue;
			}
			switch ((StockCategory)value.Category)
			{
			case StockCategory.GvGTrophy:
				num += item.Value;
				if (num > 0)
				{
					RedDot.Trophy = true;
				}
				break;
			case StockCategory.GvGUnpurified:
				if (!flag || item.Value >= value.StockSpace)
				{
					RedDot.Unpurified = true;
				}
				break;
			}
		}
		RedDot.NewTrophy = RedDot.Trophy && RedDot.LastCheckedTrophyCount < num && num > 0;
		OnRedDotChange?.Invoke();
	}

	public void CheckTrophyPage()
	{
		int num = 0;
		RedDot.Trophy = false;
		foreach (KeyValuePair<string, int> item in Items)
		{
			if (!StockController.StorehouseDataDictionary.TryGetValue("SH_" + item.Key, out var value))
			{
				continue;
			}
			StockCategory category = (StockCategory)value.Category;
			if (category == StockCategory.GvGTrophy)
			{
				num += item.Value;
				if (num > 0)
				{
					RedDot.Trophy = true;
				}
			}
		}
		RedDot.NewTrophy = false;
		RedDot.LastCheckedTrophyCount = num;
		SaveRedDotData();
		OnRedDotChange?.Invoke();
	}

	public void CheckUnpurifiedPage()
	{
		if (RedDot.UnpurifiedRedDotShowTimestamp <= GameController.Instance.GetServerTime())
		{
			DateTimeOffset dateTimeOffset = DateTimeHelper.GetDailyRefreshTime(DateTimeHelper.ParseTimeStamp((int)GameController.Instance.GetServerTime()), DateTimeHelper.TimezoneOffset, DateTimeHelper.RefreshHours).AddDays(1.0);
			RedDot.UnpurifiedRedDotShowTimestamp = (int)dateTimeOffset.ToUnixTimeSeconds();
			SaveRedDotData();
		}
		UpdateRedDots();
		OnRedDotChange?.Invoke();
	}

	private void LoadRedDotData()
	{
		_RedDot = new GvGStorehouseRedDot();
		_RedDot.IZId = Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.CurIZId;
		string text = GameLocalDataManager.GetString("GvGStorehouseRedDotSaveData");
		if (string.IsNullOrEmpty(text))
		{
			return;
		}
		try
		{
			GvGStorehouseRedDot gvGStorehouseRedDot = new GvGStorehouseRedDot
			{
				SaveData = JsonHelper.ToObject<int[]>(text)
			};
			if (gvGStorehouseRedDot.IZId == Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.CurIZId)
			{
				_RedDot = gvGStorehouseRedDot;
			}
		}
		catch (Exception)
		{
		}
	}

	private void SaveRedDotData()
	{
		GameLocalDataManager.SetString("GvGStorehouseRedDotSaveData", JsonHelper.ToJson(RedDot.SaveData));
	}
}
