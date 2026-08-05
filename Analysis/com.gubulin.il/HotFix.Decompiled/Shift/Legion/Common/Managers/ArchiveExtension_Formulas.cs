using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using GameDataEditor;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Shift.Legion.Helpers;

namespace Shift.Legion.Common.Managers;

public static class ArchiveExtension_Formulas
{
	public class ConfirmBuyStoreItem
	{
		public Formula Formula;

		public string ItemId;

		public int Index;

		public int ItemNum;
	}

	public class GvGStoreItemInfo
	{
		public string MainName;

		public string BlueprintIcon;

		public string MainId;

		public string Desc;

		public string MainEntryText;

		public string SubEntryText;

		public string NewSubEntryText;

		public string FxText;

		public string NewFxText;

		public string NewSetAliasText;

		public string CostText;

		public string GetMainName()
		{
			if (string.IsNullOrEmpty(MainName))
			{
				return string.Empty;
			}
			return LanguagesManager.GetDesc(MainName);
		}

		public string GetDesc()
		{
			if (string.IsNullOrEmpty(Desc))
			{
				return string.Empty;
			}
			return LanguagesManager.GetDesc(Desc);
		}

		public string GetMainEntryText()
		{
			if (string.IsNullOrEmpty(MainEntryText))
			{
				return string.Empty;
			}
			return LanguagesManager.GetDesc(MainEntryText);
		}

		public string GetSubEntryText()
		{
			if (string.IsNullOrEmpty(SubEntryText))
			{
				return string.Empty;
			}
			return LanguagesManager.GetDesc(SubEntryText);
		}

		public string GetNewSubEntryText()
		{
			if (string.IsNullOrEmpty(NewSubEntryText))
			{
				return string.Empty;
			}
			return LanguagesManager.GetDesc(NewSubEntryText);
		}

		public string GetFxText()
		{
			if (string.IsNullOrEmpty(FxText))
			{
				return string.Empty;
			}
			return LanguagesManager.GetDesc(FxText);
		}

		public string GetNewFxText()
		{
			if (string.IsNullOrEmpty(NewFxText))
			{
				return string.Empty;
			}
			return LanguagesManager.GetDesc(NewFxText);
		}

		public string GetNewSetAliasText()
		{
			if (string.IsNullOrEmpty(NewSetAliasText))
			{
				return string.Empty;
			}
			return LanguagesManager.GetDesc(NewSetAliasText);
		}

		public string GetCostText()
		{
			if (string.IsNullOrEmpty(CostText))
			{
				return string.Empty;
			}
			return LanguagesManager.GetDesc(CostText);
		}
	}

	public class PoolDrawRecordModel
	{
		public Dictionary<string, int> DrawRecords = new Dictionary<string, int>();

		public int TotalDrawCount { get; set; }

		public int IzDrawCount { get; set; }

		public HashSet<string> CompleteGuaranteedStrategy { get; set; } = new HashSet<string>();
	}

	private static readonly Lazy<List<Formula>> _freeFormula = new Lazy<List<Formula>>(delegate
	{
		List<string> source = new List<string> { "GvGStoreFreeExchangeLeft1", "GvGStoreFreeExchangeLeft2" };
		IEnumerable<GDEFormulaData> source2 = source.Select(GDMgr.Get<GDEFormulaData>);
		return source2.Select((GDEFormulaData formula) => new Formula(formula)).ToList();
	});

	public static int LimitedFormulaRefreshTimestamp;

	private static List<Formula> _limitedFormulas;

	private const string GvGStoreroomStockLimitKey = "GvGStoreroomStockLimit";

	private const int GvGStoreroomStockOriginalLimit = 15;

	private const string GvGStoreJumpConfigKey = "GvGStoreJumpConfig";

	public const int GvGStoreroomStockMaxLimit = 30;

	private static Dictionary<string, int> _StoreroomEvoRequire;

	private static List<GvGStoreJumpData> _jumpDatas;

	private static int CurrentGvGStoreroomStockLimit;

	public const string TicketId = "I62200";

	public const string ShenJiTicketId = "I62201";

	private static Dictionary<string, Formula> _storeItems;

	private const string GVG_STORE_ITEMS_DRAW_RECORD_KEY = "GvG3StoreItemsDrawRecord";

	public static List<Formula> GetFreeFormula()
	{
		return _freeFormula.Value;
	}

	public static List<GvGStoreJumpData> GetJumpData(this UserArchiveManager manager)
	{
		if (_jumpDatas == null)
		{
			string config = GDMgr.Get<GDEConfigurationData>("GvGStoreJumpConfig").Config;
			_jumpDatas = JsonHelper.ToObject<List<GvGStoreJumpData>>(config);
		}
		return _jumpDatas;
	}

	public static int GvGStoneTotalStock(this UserArchiveManager manager)
	{
		int num = 0;
		foreach (string item in ConfigDataManager.ItemsByType[ItemType.GvGStoreStone])
		{
			num += manager.Managers.StockController.GetStock(item);
		}
		return num;
	}

	public static int GvGStoneCanClaim(this UserArchiveManager manager)
	{
		int num = CurrentGvGStoreroomStockLimit - manager.GvGStoneTotalStock();
		if (num < 0)
		{
			num = 0;
		}
		return num;
	}

	public static Dictionary<string, int> GetStoreroomEvoRequire(this UserArchiveManager manager)
	{
		return _StoreroomEvoRequire;
	}

	public static void GetGvGStoreroomStockLimit(this UserArchiveManager manager, Action<int> action, bool isLevelUp = false)
	{
		if (CurrentGvGStoreroomStockLimit > 0 && !isLevelUp)
		{
			action?.Invoke(CurrentGvGStoreroomStockLimit);
			return;
		}
		ILRequestHelper<GetGvGStoreroomStockLimitResponse>.Request((EventContext)null, (Func<Task<GetGvGStoreroomStockLimitResponse>>)(() => GameController.Contexts.Service<INetworkService>().GetGvGStoreroomStockLimit(isLevelUp)), (Action<GetGvGStoreroomStockLimitResponse>)delegate(GetGvGStoreroomStockLimitResponse response)
		{
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				if (isLevelUp && _StoreroomEvoRequire != null)
				{
					StockChangeRecord[] array = new StockChangeRecord[_StoreroomEvoRequire.Count];
					int num = 0;
					foreach (KeyValuePair<string, int> item in _StoreroomEvoRequire)
					{
						array[num++] = new StockChangeRecord
						{
							ItemId = item.Key,
							Offset = -item.Value,
							Context = 115,
							ContextValue = (item.Key ?? ""),
							Type = 1
						};
					}
					GameManagers.Instance.StockController.ReadStockChangeRecords(array);
				}
				CurrentGvGStoreroomStockLimit = response.StockLimit;
				_StoreroomEvoRequire = response.EvoRequire;
				action?.Invoke(CurrentGvGStoreroomStockLimit);
			}
		});
	}

	public static Formula GetStoreItemFormula(this UserArchiveManager manager, string formulaId)
	{
		if (_storeItems == null)
		{
			_storeItems = new Dictionary<string, Formula>();
		}
		if (_storeItems.TryGetValue(formulaId, out var value))
		{
			return value;
		}
		GDEFormulaData data = GDMgr.Get<GDEFormulaData>(formulaId) ?? throw new NullReferenceException("GetStoreItemFormula : formulaData is null,formulaId=" + formulaId);
		Formula formula = new Formula(data);
		_storeItems.Add(formulaId, formula);
		return formula;
	}

	public static void GetGvGStoreItems(this UserArchiveManager manager, Action<GetGvGStoreItemsResponse> action, bool manual = false)
	{
		ILRequestHelper<GetGvGStoreItemsResponse>.Request((EventContext)null, (Func<Task<GetGvGStoreItemsResponse>>)(() => GameController.Contexts.Service<INetworkService>().GetGvGStoreItems(manual)), (Action<GetGvGStoreItemsResponse>)delegate(GetGvGStoreItemsResponse response)
		{
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				if (manual && response.UseTicket)
				{
					StockChangeRecord[] stockChangeRecords = new StockChangeRecord[1]
					{
						new StockChangeRecord
						{
							ItemId = "I62200",
							Offset = -1,
							Context = 114,
							ContextValue = "I62200",
							Type = 1
						}
					};
					GameManagers.Instance.StockController.ReadStockChangeRecords(stockChangeRecords);
				}
				action?.Invoke(response);
			}
		});
	}

	public static void GetLimitedFormulas(Action<List<Formula>> action)
	{
		if (_limitedFormulas != null)
		{
			action?.Invoke(_limitedFormulas);
			return;
		}
		ILRequestHelper<UpdateGVGStoreLimitedFormulasResponse>.Request((EventContext)null, (Func<Task<UpdateGVGStoreLimitedFormulasResponse>>)(() => GameController.Contexts.Service<INetworkService>().GetGVGStoreLimitedFormulas()), (Action<UpdateGVGStoreLimitedFormulasResponse>)delegate(UpdateGVGStoreLimitedFormulasResponse response)
		{
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				_limitedFormulas = new List<Formula>();
				for (int i = 0; i < response.CurFormulas.Count; i++)
				{
					_limitedFormulas.Add(new Formula(GDMgr.Get<GDEFormulaData>(response.CurFormulas[i])));
				}
				LimitedFormulaRefreshTimestamp = response.NextUpdateTime;
				action?.Invoke(_limitedFormulas);
			}
		});
	}

	public static void UseFormula(this UserArchiveManager manager, Formula formula, Action action, int inputIndex = 0, int outputIndex = 0, string itemId = "", int storeItemIndex = 0)
	{
		ILRequestHelper<UseGVGStoreFormulaResponse>.Request((EventContext)null, (Func<Task<UseGVGStoreFormulaResponse>>)(() => GameController.Contexts.Service<INetworkService>().UseGVGStoreFormula(formula.FormulaId, inputIndex, outputIndex, storeItemIndex)), (Action<UseGVGStoreFormulaResponse>)delegate(UseGVGStoreFormulaResponse response)
		{
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				formula.ClaimFormulaBonus(GameManagers.Instance, null, broadcastInform: true, inputIndex, outputIndex);
				Singleton<GvG3StoreManager>.Instance.UpdateGuaranteedItemPurchasedCount(formula.FormulaId);
				SharedMessenger.Broadcast("UPDATE_GVG_STOREROOM");
				action?.Invoke();
				if (!string.IsNullOrEmpty(response.Blueprints))
				{
					List<string> list = JsonHelper.ToObject<List<string>>(response.Blueprints);
					if (list.Count > 0)
					{
						LegendItemsHelper.OpenBlueprintsBoxResult(list, itemId);
					}
				}
			}
		});
	}

	public static int GvGStoreTotalDrawCount(this UserArchiveManager manager)
	{
		return manager.GetPoolDrawRecord().TotalDrawCount;
	}

	public static void UpdateGvGStoreTotalDrawCount(this UserArchiveManager manager, int totalCount)
	{
		PoolDrawRecordModel poolDrawRecord = manager.GetPoolDrawRecord();
		poolDrawRecord.TotalDrawCount = totalCount;
		manager.SetConfigValue("GvG3StoreItemsDrawRecord", poolDrawRecord);
	}

	private static PoolDrawRecordModel GetPoolDrawRecord(this UserArchiveManager manager)
	{
		PoolDrawRecordModel poolDrawRecordModel = manager.GetConfigValue<PoolDrawRecordModel>("GvG3StoreItemsDrawRecord");
		if (poolDrawRecordModel == null)
		{
			poolDrawRecordModel = new PoolDrawRecordModel
			{
				DrawRecords = new Dictionary<string, int>(),
				TotalDrawCount = 0,
				IzDrawCount = 0,
				CompleteGuaranteedStrategy = new HashSet<string>()
			};
			manager.SetConfigValue("GvG3StoreItemsDrawRecord", poolDrawRecordModel);
		}
		return poolDrawRecordModel;
	}
}
