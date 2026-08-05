using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FairyGUI;
using GameDataEditor;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.ClientApi.Protocol.Store;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.ClientApi.Sources.Protocol.UserAction;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Models.Store;
using Shift.Legion.Common.Services;
using Shift.Legion.Common.Sources.Enums;
using Shift.Legion.GvG.Common.Models.OuterTech;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3Common.Manager;

public class GvGOuterTechManager : Singleton<GvGOuterTechManager>
{
	public const string GIFTBAG_ACTIVITY_ID = "GvG3_OuterTechLottery_Gift";

	public const string LOTTERY_ACTIVITY_ID = "GvG3_OuterTechLottery";

	public const string LOTTERY_CHIP_ITEM_ID1 = "I63121";

	public const string LOTTERY_CHIP_ITEM_ID2 = "I63122";

	public List<global::Shift.Legion.Common.Models.Store.StoreItem> StoreItems;

	public Action OnGiftBagChange = delegate
	{
	};

	public Action OnNoticeChange = delegate
	{
	};

	private int? _MaxDrawCount = null;

	public const string SpeedPlanGiftBagId = "GVGCardPack001";

	public bool IsAvailable => Define.GvGMode3OuterTechAvailable();

	public bool HasRedDot => IsAvailable && !Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.HasEnterIZ && Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.LastIZId == -1 && (HasDrawChance || HasPushedGiftBag);

	public bool HasDrawChance => ChipCount > 0;

	public bool HasPushedGiftBag => GameManagers.Instance.StockController.GetStock("I63121") == 0 && StoreItems != null && StoreItems.Count > 0 && StoreItems.Any((global::Shift.Legion.Common.Models.Store.StoreItem item) => !item.IsExpired && !item.IsSoldOut);

	public int ChipCount => GameManagers.Instance.StockController.GetStock("I63121") + GameManagers.Instance.StockController.GetStock("I63122");

	public int MaxDrawCount => (_MaxDrawCount ?? (_MaxDrawCount = "GvGMode3OuterTechDrawCardCountLimit".ToConfiguration<int>())).Value;

	public OuterTechSpeedPlan SpeedPlan { get; set; }

	public bool IsSpeedPlanAvailable => SpeedPlan != null && (SpeedPlan.CouldClaimCount > 0 || SpeedPlan.NextClaimCount > 0 || GameLocalDataManager.GetSpeedPlanLastClaim() > 0);

	public int SpeedPlanGiftBagRemaining
	{
		get
		{
			Dictionary<string, int> purchaseStat = GameManagers.Instance.StoreManager.PurchaseStat.GetValue().PurchaseStat;
			if (!purchaseStat.TryGetValue("GVGCardPack001", out var value))
			{
				value = 0;
			}
			return SpeedPlan.GiftPurchaseLimit - value;
		}
	}

	public bool IsSpeedPlanGiftBagAvailable => SpeedPlan != null && (SpeedPlanGiftBagRemaining > 0 || GameLocalDataManager.GetSpeedPlanLastPurchase() > 0);

	public int GvGTotalJoined
	{
		get
		{
			GameManagers instance = GameManagers.Instance;
			List<string> list = instance.UserArchiveManager.LoadGvGMode3CompletedHistory();
			int num = instance.UserArchiveManager.LoadGvGMode3HistoryRecord();
			GvGMode3ObserverRecord gvGMode3ObserverRecord = instance.UserArchiveManager.LoadGvGMode3Record();
			return (gvGMode3ObserverRecord.HasEnterIZ || gvGMode3ObserverRecord.LastIZId != -1) ? (list.Count + num + 1) : (list.Count + num);
		}
	}

	public override void InitInstance()
	{
		base.InitInstance();
		StoreItems = new List<global::Shift.Legion.Common.Models.Store.StoreItem>();
		SharedMessenger.AddListener<List<Bonus>, List<Bonus>>("ORDER_SHIP_SUCCESS", OrderShipSuccessEvent);
		SharedMessenger.AddListener<string>("ORDER_SHIP_SUCCESS_WITH_STOREITEM", OrderShipSuccessEventWithStoreItemId);
		SharedMessenger.AddListener<string, int, (StockInContext, string)>("ON_STOCK_CHANGE", OnStockChange);
		GvGMode3RoomManager instance = Singleton<GvGMode3RoomManager>.Instance;
		instance.OnRoomClose = (Action)Delegate.Combine(instance.OnRoomClose, new Action(OnRoomClose));
	}

	private void OnRoomClose()
	{
		SyncGiftBag();
	}

	private void OnStockChange(string itemId, int incr, (StockInContext, string) context)
	{
		if (itemId == "I63121")
		{
			OnNoticeChange?.Invoke();
		}
		if (itemId == "I63122")
		{
			OnNoticeChange?.Invoke();
		}
	}

	private void OrderShipSuccessEvent(List<Bonus> arg1, List<Bonus> arg2)
	{
		SyncGiftBag();
	}

	private void OrderShipSuccessEventWithStoreItemId(string storeItemId)
	{
		if (storeItemId == "GVGCardPack001")
		{
			GameLocalDataManager.SetSpeedPlanLastPurchase(DateTimeHelper.ServerNowTimestamp);
		}
	}

	public void UpgradeTech(string itemId, Action onFinished = null)
	{
		if (!IsAvailable)
		{
			return;
		}
		ILRequestHelper<ExchangeOuterTechResponse>.Request((EventContext)null, (Func<Task<ExchangeOuterTechResponse>>)(() => GameController.Contexts.Service<INetworkService>().ExchangeOuterTech("GvG3_OuterTechLottery", itemId)), (Action<ExchangeOuterTechResponse>)delegate(ExchangeOuterTechResponse response)
		{
			if (response.ErrorCode != 0)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
				onFinished?.Invoke();
			}
			else
			{
				GameManagers.Instance.StockController.ReadStockChangeRecords(response.StockChangeRecords);
				onFinished?.Invoke();
			}
		});
	}

	public void DrawOuterTech(Action<DrawOuterTechResponse> onFinished = null)
	{
		if (!IsAvailable)
		{
			return;
		}
		ILRequestHelper<DrawOuterTechResponse>.Request((EventContext)null, (Func<Task<DrawOuterTechResponse>>)(() => GameController.Contexts.Service<INetworkService>().DrawOuterTech("GvG3_OuterTechLottery")), (Action<DrawOuterTechResponse>)delegate(DrawOuterTechResponse response)
		{
			if (response.ErrorCode != 0)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
				onFinished?.Invoke(null);
			}
			else
			{
				onFinished?.Invoke(response);
				GameManagers.Instance.StockController.ReadStockChangeRecords(response.StockChangeRecords);
				SyncGiftBag();
			}
		});
	}

	public void InitGiftBag()
	{
		if (IsAvailable)
		{
			SyncGiftBag();
		}
	}

	public void SyncGiftBag()
	{
		if (!Define.GvGMode3UnderDevelopment() || !IsAvailable)
		{
			return;
		}
		ILRequestHelper<GetOuterTechGiftResponse>.Request((EventContext)null, (Func<Task<GetOuterTechGiftResponse>>)(() => GameController.Contexts.Service<INetworkService>().GetOuterTechGift("GvG3_OuterTechLottery_Gift")), (Action<GetOuterTechGiftResponse>)delegate(GetOuterTechGiftResponse response)
		{
			StoreItems = new List<global::Shift.Legion.Common.Models.Store.StoreItem>();
			if (response.ErrorCode != 0)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
				OnGiftBagChange?.Invoke();
			}
			else
			{
				List<global::Shift.Legion.ClientApi.Protocol.Store.StoreItem> storeItems = response.StoreItems;
				if (storeItems != null)
				{
					foreach (global::Shift.Legion.ClientApi.Protocol.Store.StoreItem item in storeItems)
					{
						global::Shift.Legion.Common.Models.Store.StoreItem storeItem = new global::Shift.Legion.Common.Models.Store.StoreItem(GameManagers.Instance, item.StoreItemId)
						{
							Icon = item.Icon,
							Rarity = item.Rarity,
							Category = (StoreCategory)item.Category,
							DoubleAtFirst = item.DoubleAtFirst,
							BonusAtFirst = item.BonusAtFirst,
							Tags = item.Tags,
							ValidTime = item.ValidTime,
							KickOffTimestamp = item.KickOffTimestamp,
							ExpireTimestamp = item.ExpireTimestamp,
							Content = item.Content,
							DisplayContent = item.DisplayContent,
							OriginPrice = item.OriginPrice,
							Price = item.Price,
							Discount = item.Discount,
							PurchaseLimit = item.PurchaseLimit,
							PurchaseLimitPeriod = (PurchaseLimitType)item.PurchaseLimitPeriod,
							IsExpo = item.IsExpo,
							Substitution = item.Substitution,
							IsResident = item.IsResident,
							UserLevelFilter = item.UserLevelFilter,
							DungeonLevelFilter = item.DungeonLevelFilter,
							GameLevelFilter = item.GameLevelFilter,
							OwnedItemFilter = item.OwnedItemFilter,
							PurchaseFilter = item.PurchaseFilter
						};
						if (!storeItem.IsExpired && !storeItem.IsSoldOut)
						{
							StoreItems.Add(storeItem);
						}
					}
				}
				OnGiftBagChange?.Invoke();
				OnNoticeChange?.Invoke();
			}
		});
	}

	public void SyncSpeedPlan(Action callback = null)
	{
		if (!IsAvailable)
		{
			return;
		}
		ILRequestHelper<GetOuterTechSpeedPlanResponse>.Request((EventContext)null, (Func<Task<GetOuterTechSpeedPlanResponse>>)(() => GameController.Contexts.Service<INetworkService>().GetOuterTechSpeedPlan()), (Action<GetOuterTechSpeedPlanResponse>)delegate(GetOuterTechSpeedPlanResponse response)
		{
			if (response.ErrorCode != 0)
			{
				if (response.ErrorCode != 81200122)
				{
					ILRequestHelper.ShowErrorCode(response.ErrorCode);
				}
			}
			else
			{
				if (SpeedPlan == null)
				{
					SpeedPlan = new OuterTechSpeedPlan();
				}
				SpeedPlan.SyncData(response);
				callback?.Invoke();
			}
		});
	}

	public void ClaimSpeedPlan(Action callback = null)
	{
		if (!IsAvailable)
		{
			return;
		}
		ILRequestHelper<ClaimOuterTechSpeedPlanResponse>.Request((EventContext)null, (Func<Task<ClaimOuterTechSpeedPlanResponse>>)(() => GameController.Contexts.Service<INetworkService>().ClaimOuterTechSpeedPlan()), (Action<ClaimOuterTechSpeedPlanResponse>)delegate(ClaimOuterTechSpeedPlanResponse response)
		{
			if (response.ErrorCode != 0)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				foreach (StockChangeRecord stockChangeRecord in response.StockChangeRecords)
				{
					if (stockChangeRecord.Offset > 0)
					{
						ILRequestHelper.ShowMessage($"{GDMgr.Get<GDEItemData>(stockChangeRecord.ItemId).Name}+{stockChangeRecord.Offset}");
					}
				}
				GameManagers.Instance.StockController.ReadStockChangeRecords(response.StockChangeRecords);
				GameLocalDataManager.SetSpeedPlanLastClaim(DateTimeHelper.ServerNowTimestamp);
				callback?.Invoke();
			}
		});
	}
}
