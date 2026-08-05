using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Model;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Shift.Legion.GvG.Common.Models.GvGMode3.Collecting;
using Shift.Legion.Helpers;
using Spine.Unity;
using UI.MonthCard;
using UnityEngine;

namespace UI.GvGMode3Collecting;

public class UI_main_GvGMode3CollectingPanel : GComponent, IUiController
{
	public Controller Type;

	public GLoader background;

	public GImage n5;

	public UI_eff_FloatingIsland n11;

	public GGraph ui_portal_solardoor;

	public GButton BackBtn;

	public UI_com_Title Title;

	public GComponent addWorkerBtn;

	public UI_com_CollectingOverview CollectingOverview;

	public GList ShipList;

	public GImage n9;

	public GTextField n8;

	public GGroup NoCollectingTip;

	public GGraph CollectingPos;

	public GTextField n15;

	public GButton Help;

	public const string URL = "ui://n2y4xuvarxuq0";

	public static string Name = "UI_main_GvGMode3CollectingPanel";

	private const float _WAIT_SECONDS = 30f;

	private CollectingInfo _collectingInfo;

	private RealTimeStorehouseLimitParModel _stockLimitPar;

	private readonly WaitForSeconds _updateNPCRebellion = new WaitForSeconds(1f);

	private readonly WaitForSeconds _updateInfoInterval = new WaitForSeconds(30f);

	private long _lastSyncTime;

	private Coroutine _updateItemsCoroutine;

	private Coroutine _updateShipsCoroutine;

	private ShipAnimCacheManager _shipAnimCacheManager;

	private const string ShipSpineSkin = "skin1";

	private const string ShipSpineAnimation = "idle";

	private const float ShipSpineScale = 100f;

	private const string PanelSfx = "ui_portal_solardoor";

	private Dictionary<string, ShipCollectingPopupController> _shipControllerDict;

	private static int GvGItemStockLimit => StockController.GetGvgSupplyOriginLimit();

	public static string GetURL()
	{
		return "ui://n2y4xuvarxuq0";
	}

	public static UI_main_GvGMode3CollectingPanel CreateInstance()
	{
		return (UI_main_GvGMode3CollectingPanel)(object)UIPackage.CreateObject("GvGMode3Collecting", "main_GvGMode3CollectingPanel");
	}

	public static UI_main_GvGMode3CollectingPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_GvGMode3CollectingPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://n2y4xuvarxuq0", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Expected O, but got Unknown
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Expected O, but got Unknown
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Expected O, but got Unknown
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_015f: Expected O, but got Unknown
		//IL_016b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0175: Expected O, but got Unknown
		//IL_0181: Unknown result type (might be due to invalid IL or missing references)
		//IL_018b: Expected O, but got Unknown
		//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01de: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		background = (GLoader)((GComponent)this).GetChild("background");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		n11 = (UI_eff_FloatingIsland)(object)((GComponent)this).GetChild("n11");
		ui_portal_solardoor = (GGraph)((GComponent)this).GetChild("ui_portal_solardoor");
		BackBtn = (GButton)((GComponent)this).GetChild("BackBtn");
		Title = (UI_com_Title)(object)((GComponent)this).GetChild("Title");
		addWorkerBtn = (GComponent)((GComponent)this).GetChild("addWorkerBtn");
		CollectingOverview = (UI_com_CollectingOverview)(object)((GComponent)this).GetChild("CollectingOverview");
		ShipList = (GList)((GComponent)this).GetChild("ShipList");
		n9 = (GImage)((GComponent)this).GetChild("n9");
		n8 = (GTextField)((GComponent)this).GetChild("n8");
		string id = "ui://n2y4xuvarxuq0".Replace("ui://", "") + "-" + ((GObject)n8).id;
		((GObject)n8).text = LanguagesManager.GetDesc(id);
		NoCollectingTip = (GGroup)((GComponent)this).GetChild("NoCollectingTip");
		CollectingPos = (GGraph)((GComponent)this).GetChild("CollectingPos");
		n15 = (GTextField)((GComponent)this).GetChild("n15");
		string id2 = "ui://n2y4xuvarxuq0".Replace("ui://", "") + "-" + ((GObject)n15).id;
		((GObject)n15).text = LanguagesManager.GetDesc(id2);
		Help = (GButton)((GComponent)this).GetChild("Help");
	}

	private int NPCRebellionMax(int islandId)
	{
		return WorldMapConfigHelper.GetGvGMode3DefenderZoneConfigs(islandId).NPCRebellionMax;
	}

	public void BeforeDestroy()
	{
		if (_updateItemsCoroutine != null)
		{
			FGUIManager.Instance.CloseIEnumerator(_updateItemsCoroutine);
		}
		if (_updateShipsCoroutine != null)
		{
			FGUIManager.Instance.CloseIEnumerator(_updateShipsCoroutine);
		}
	}

	public void Destroy()
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Expected O, but got Unknown
		Timers.inst.Remove(new TimerCallback(UpdateControllers));
		foreach (ShipCollectingPopupController value in _shipControllerDict.Values)
		{
			value.Reset();
		}
		_shipAnimCacheManager.ClearCache();
	}

	public void Init(Dictionary<string, object> parameters)
	{
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Expected O, but got Unknown
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		_shipControllerDict = new Dictionary<string, ShipCollectingPopupController>();
		CheckWorkersCanAssign();
		_shipAnimCacheManager = new ShipAnimCacheManager();
		LoadPanelSfx();
		SetPanelType();
		Timers.inst.Add(0.2f, 0, new TimerCallback(UpdateControllers));
	}

	public void OnShow()
	{
		_updateItemsCoroutine = FGUIManager.Instance.OpenIEnumerator(UpdateCollectingInfo());
		_updateShipsCoroutine = FGUIManager.Instance.OpenIEnumerator(UpdateShipNPCRebellion());
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Expected O, but got Unknown
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Expected O, but got Unknown
		((GObject)BackBtn).onClick.Add(new EventCallback0(End));
		((GObject)Help).onClick.Set(new EventCallback0(OnHelpClick));
		addWorkerBtn.GetChild("addButton").onClick.Add(new EventCallback1(AddWorker));
		addWorkerBtn.GetChild("ExclamationMarkBtn").onClick.Add(new EventCallback1(FGUIManager.Instance.OpenExclamationMarkPanel));
		((GObject)CollectingOverview.ExclamationMarkBtn).onClick.Add(new EventCallback1(FGUIManager.Instance.OpenExclamationMarkPanel));
		GvGCollectingManager instance = Singleton<GvGCollectingManager>.Instance;
		instance.OnCollectingSync = (Action)Delegate.Combine(instance.OnCollectingSync, new Action(OnCollectingSync));
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Expected O, but got Unknown
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Expected O, but got Unknown
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Expected O, but got Unknown
		((GObject)BackBtn).onClick.Remove(new EventCallback0(End));
		((GObject)Help).onClick.Clear();
		addWorkerBtn.GetChild("addButton").onClick.Remove(new EventCallback1(AddWorker));
		addWorkerBtn.GetChild("ExclamationMarkBtn").onClick.Remove(new EventCallback1(FGUIManager.Instance.OpenExclamationMarkPanel));
		((GObject)CollectingOverview.ExclamationMarkBtn).onClick.Remove(new EventCallback1(FGUIManager.Instance.OpenExclamationMarkPanel));
		GvGCollectingManager instance = Singleton<GvGCollectingManager>.Instance;
		instance.OnCollectingSync = (Action)Delegate.Remove(instance.OnCollectingSync, new Action(OnCollectingSync));
	}

	private static void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
	}

	private static void OnHelpClick()
	{
		UiHelper.OpenHelpPage("空之门", "远征相关", "空之门");
	}

	private void OnCollectingSync()
	{
		Dictionary<string, ShipCollectingPopupController> dictionary = _shipControllerDict ?? new Dictionary<string, ShipCollectingPopupController>();
		Dictionary<string, ShipCollectingModel> shipCollecting_Dict = Singleton<GvGCollectingManager>.Instance.ShipCollecting_Dict;
		List<CollectingInfoPerShip> list = ((_collectingInfo == null) ? new List<CollectingInfoPerShip>() : _collectingInfo.ShipInfos);
		HashSet<string> hashSet = new HashSet<string>();
		foreach (CollectingInfoPerShip item in list)
		{
			if (item == null)
			{
				continue;
			}
			string shipId = item.ShipId;
			hashSet.Add(shipId);
			if (shipCollecting_Dict.TryGetValue(shipId, out var value) && value.WorkersStates != null)
			{
				if (!dictionary.TryGetValue(shipId, out var value2))
				{
					value2 = new ShipCollectingPopupController(this, UpdateItemStock);
					dictionary.Add(shipId, value2);
				}
				value2.SetShipCollectingData(value);
			}
		}
		List<string> list2 = dictionary.Keys.ToList();
		foreach (string item2 in list2)
		{
			if (!hashSet.Contains(item2))
			{
				dictionary[item2].Reset();
				dictionary.Remove(item2);
			}
		}
	}

	private void UpdateControllers(object param)
	{
		foreach (ShipCollectingPopupController value in _shipControllerDict.Values)
		{
			value.Update();
		}
	}

	private void RenderShipsList()
	{
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		if (!((GObject)this).isDisposed && _collectingInfo?.ShipInfos != null)
		{
			ShipList.itemRenderer = new ListItemRenderer(RenderShipInfo);
			ShipList.numItems = _collectingInfo.ShipInfos.Count;
			OnCollectingSync();
		}
	}

	private void RenderShipInfo(int index, GObject obj)
	{
		//IL_0220: Unknown result type (might be due to invalid IL or missing references)
		//IL_022a: Expected O, but got Unknown
		if (!(obj is UI_com_ShipOverview uI_com_ShipOverview))
		{
			return;
		}
		CollectingInfoPerShip shipInfo = _collectingInfo.ShipInfos[index];
		if (shipInfo == null)
		{
			uI_com_ShipOverview.Type.selectedIndex = 1;
			((GObject)uI_com_ShipOverview).data = null;
			return;
		}
		shipInfo.InitCollectingStockModel();
		((GObject)uI_com_ShipOverview).data = shipInfo.ShipId;
		((GObject)uI_com_ShipOverview.islandName).data = shipInfo.ShipTargetIslandId;
		uI_com_ShipOverview.Type.selectedIndex = 0;
		((GObject)uI_com_ShipOverview.WorkerNum.Num).text = shipInfo.WorkersOnboardCount.ToString();
		((GObject)uI_com_ShipOverview.Compliance).data = shipInfo.IsladnObedienceValue;
		((GObject)uI_com_ShipOverview.Compliance.Num).text = "";
		((GObject)uI_com_ShipOverview.islandName).text = "";
		if (WorldMapConfigHelper.IsLoaded)
		{
			((GObject)uI_com_ShipOverview.Compliance.Num).text = ((shipInfo.IsladnObedienceValue < 0f) ? "100%" : $"{Convert.ToInt32(shipInfo.IsladnObedienceValue / (float)NPCRebellionMax(shipInfo.ShipTargetIslandId) * 100f)}%");
			IslandConfigData islandConfigData = WorldMapConfigHelper.Configs.TryGetIsland(shipInfo.ShipTargetIslandId);
			if (islandConfigData != null)
			{
				((GObject)uI_com_ShipOverview.islandName).text = islandConfigData.Name;
			}
		}
		GvGMode3ObserverRecord observerRecord_OnGS = Singleton<GvGMode3RoomManager>.Instance.ObserverRecord_OnGS;
		GvGMode3ShipModel myShipData = observerRecord_OnGS.GetMyShipData(shipInfo.ShipId);
		if (myShipData != null)
		{
			((GObject)uI_com_ShipOverview.ShipName).text = observerRecord_OnGS.GetMyShipName(shipInfo.ShipId);
			uI_com_ShipOverview.SpineLoader.url = observerRecord_OnGS.GetShipRaceIcon(shipInfo.ShipId);
		}
		uI_com_ShipOverview.CollectingItemList.itemRenderer = new ListItemRenderer(RenderCollectingItem);
		uI_com_ShipOverview.CollectingItemList.numItems = shipInfo.SelectedCollectingStockModels.Count;
		void RenderCollectingItem(int collectingItemIndex, GObject itemGObject)
		{
			if (itemGObject is UI_com_CollectingItem uI_com_CollectingItem)
			{
				CollectingStockModel collectingStockModel = shipInfo.SelectedCollectingStockModels[collectingItemIndex];
				((GObject)uI_com_CollectingItem.Num).text = collectingStockModel.CurStock.ToString();
				FGUIManager.Instance.SetItemIconAndFrame(uI_com_CollectingItem.Icon, collectingStockModel.GetItemId(), null, "", frameVisible: false);
			}
		}
	}

	private void InitShipAnimation(GGraph spineLoader, int shipSkinId, string shipId)
	{
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		GameObject cache = _shipAnimCacheManager.GetCache(shipId, shipSkinId, delegate(SkeletonAnimation animation)
		{
			SpineHelper.SetSkin((ISkeletonAnimation)(object)animation, "skin1");
			animation.AnimationState.SetAnimation(0, "idle", true);
		}, isMask: true);
		cache.transform.localScale = new Vector3(20f, 20f, 20f);
		if (((GObject)spineLoader).data == null)
		{
			GoWrapper val = new GoWrapper(cache)
			{
				supportStencil = true
			};
			spineLoader.SetNativeObject((DisplayObject)(object)val);
			((GObject)spineLoader).data = val;
		}
		else
		{
			((GoWrapper)((GObject)spineLoader).data).wrapTarget = cache;
		}
	}

	private void RenderCollectingInfoList()
	{
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Expected O, but got Unknown
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		if (!((GObject)this).isDisposed && _collectingInfo?.ItemInfos != null)
		{
			((GObject)CollectingOverview.stockLimit).text = Convert.ToInt32((float)GvGItemStockLimit * _stockLimitPar?.Total).ToString();
			RealTimeStorehouseLimitParModel stockLimitPar = _stockLimitPar;
			bool flag = stockLimitPar != null && stockLimitPar.Total > 1f;
			((GObject)CollectingOverview.ExclamationMarkBtn).visible = flag;
			if (flag)
			{
				((GObject)CollectingOverview.ExclamationMarkBtn).data = new Dictionary<string, object>
				{
					{
						"Title",
						_stockLimitPar?.GetStorehouseLimitParText()
					},
					{
						"Pos",
						(object)new Vector2(551f, 750f)
					}
				};
			}
			CollectingOverview.ItemList.itemRenderer = new ListItemRenderer(RenderItemInfo);
			CollectingOverview.ItemList.numItems = _collectingInfo.ItemInfos.Count;
		}
	}

	private void RenderItemInfo(int index, GObject obj)
	{
		//IL_0157: Unknown result type (might be due to invalid IL or missing references)
		//IL_0161: Expected O, but got Unknown
		if (obj is UI_com_OverviewItem uI_com_OverviewItem)
		{
			CollectingItemInfo itemInfo = _collectingInfo.ItemInfos[index];
			UI_goodItemLarge icon = uI_com_OverviewItem.Icon;
			FGUIManager.Instance.SetItemIconAndFrame(icon.icon, itemInfo.ItemId);
			icon.StockType.selectedIndex = (((float)itemInfo.CuStock >= (float)GvGItemStockLimit * _stockLimitPar?.Total) ? 1 : 0);
			((GObject)uI_com_OverviewItem.Num).text = itemInfo.CuStock.ToString();
			((GObject)uI_com_OverviewItem.ItemName).text = Shift.Legion.Common.Models.Item.Name(GameManagers.Instance, itemInfo.ItemId);
			uI_com_OverviewItem.LastType.selectedIndex = ((index == _collectingInfo.ItemInfos.Count - 1) ? 1 : 0);
			((GObject)uI_com_OverviewItem).onClick.Set((EventCallback0)delegate
			{
				FGUIManager.Instance.ItemTip(itemInfo.ItemId, 1, noCheckBtn: true, reserveRes: false, null, isPack: false, null, itemInfo.CuStock);
			});
		}
	}

	private void UpdateItemStock(PopItemIncrement increment)
	{
		if (!((GObject)CollectingOverview.ItemList).isDisposed && _lastSyncTime <= increment.LastSyncTime)
		{
			int? num = _collectingInfo?.ItemInfos?.FindIndex((CollectingItemInfo item) => item.ItemId == increment.ItemId);
			if (num.HasValue && !(num < 0) && ((GComponent)CollectingOverview.ItemList).GetChildAt(num.Value) is UI_com_OverviewItem uI_com_OverviewItem)
			{
				CollectingItemInfo collectingItemInfo = _collectingInfo.ItemInfos[num.Value];
				SyncItemStock(collectingItemInfo);
				collectingItemInfo.CuStock += increment.Value;
				((GObject)uI_com_OverviewItem.Num).text = collectingItemInfo.CuStock.ToString();
			}
		}
	}

	private void SyncItemStock(CollectingItemInfo itemInfo)
	{
		Dictionary<string, int> changes = new Dictionary<string, int> { { itemInfo.ItemId, itemInfo.CuStock } };
		SyncStockChangesAndRenderShips(changes);
	}

	private void LoadPanelSfx()
	{
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		FGUIManager.Instance.AddTextSpecialEffects(ui_portal_solardoor, "ui_portal_solardoor", Vector3.one * 100f);
	}

	private void SetPanelType()
	{
		if (!((GObject)this).isDisposed)
		{
			Type.selectedIndex = ((_collectingInfo == null) ? 1 : 0);
		}
	}

	private void CheckWorkersCanAssign()
	{
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_0106: Unknown result type (might be due to invalid IL or missing references)
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		GTextField asTextField = addWorkerBtn.GetChild("AllWorkerAmount").asTextField;
		GObject child = addWorkerBtn.GetChild("ExclamationMarkBtn");
		GTextField asTextField2 = addWorkerBtn.GetChild("CurrentWorkerAmount").asTextField;
		GTextField asTextField3 = addWorkerBtn.GetChild("separate").asTextField;
		((GObject)asTextField2).text = Dungeon.GetFreeManPower(GameManagers.Instance).ToString();
		((GObject)asTextField).text = Dungeon.GetTotalManPower(GameManagers.Instance).ToString();
		asTextField2.strokeColor = Color32.op_Implicit(new Color32((byte)0, (byte)0, (byte)0, (byte)153));
		asTextField3.strokeColor = Color32.op_Implicit(new Color32((byte)0, (byte)0, (byte)0, (byte)153));
		asTextField.strokeColor = Color32.op_Implicit(new Color32((byte)0, (byte)0, (byte)0, (byte)153));
		if (GameManagers.Instance.LeaseholdManager.GetLeaseholdManPower() > 0)
		{
			asTextField.color = Color32.op_Implicit(new Color32((byte)175, (byte)246, (byte)39, byte.MaxValue));
			child.data = new Dictionary<string, object>
			{
				{
					"Title",
					LanguagesManager.GetDesc("CsharpCodeZhTcText153") + Environment.NewLine + string.Format("{0}：{1}", LanguagesManager.GetDesc("CsharpCodeZhTcText164"), Dungeon.GetTotalManPower(GameManagers.Instance) - GameManagers.Instance.LeaseholdManager.GetLeaseholdManPower())
				},
				{
					"Pos",
					(object)new Vector2(1718f, 88f)
				}
			};
			child.visible = true;
		}
		else
		{
			asTextField.color = Color32.op_Implicit(new Color32((byte)243, (byte)221, (byte)170, byte.MaxValue));
			child.visible = false;
		}
	}

	private void AddWorker(EventContext context)
	{
		context.StopPropagation();
		int level = GameManagers.Instance.BuildingManager.GetBuildingByType("16").Level;
		if (level > 0)
		{
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_MonthCardPanel.Name, new Dictionary<string, object>
			{
				{
					"Activity",
					FGUIManager.Instance.GetBlackMarketerActivity("UI_MonthCardPanel")
				},
				{
					"Order",
					((GObject)this).sortingOrder
				},
				{ "Parent", this }
			});
		}
		else
		{
			SharedMessenger.Broadcast("SHOW_TIPS", new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText152") }, 1, arg3: false);
		}
	}

	private void UpdateNPCRebellion()
	{
		for (int i = 0; i < ShipList.numItems; i++)
		{
			if (!(((GComponent)ShipList).GetChildAt(i) is UI_com_ShipOverview uI_com_ShipOverview) || ((GObject)uI_com_ShipOverview.Compliance).data == null)
			{
				continue;
			}
			float num = (float)((GObject)uI_com_ShipOverview.Compliance).data - 1f;
			((GObject)uI_com_ShipOverview.Compliance).data = num;
			if (((GObject)uI_com_ShipOverview.islandName).data != null)
			{
				int islandId = (int)((GObject)uI_com_ShipOverview.islandName).data;
				if (WorldMapConfigHelper.IsLoaded)
				{
					((GObject)uI_com_ShipOverview.Compliance.Num).text = ((num < 0f) ? "100%" : $"{Convert.ToInt32(num / (float)NPCRebellionMax(islandId) * 100f)}%");
				}
				else
				{
					((GObject)uI_com_ShipOverview.Compliance.Num).text = "";
				}
			}
		}
	}

	private void GetNewCollectingInfo()
	{
		ILRequestHelper<GetCollectingInfoResponse>.Request((EventContext)null, (Func<Task<GetCollectingInfoResponse>>)(() => GameController.Contexts.Service<INetworkService>().GetCollectingInfo()), (Action<GetCollectingInfoResponse>)delegate(GetCollectingInfoResponse response)
		{
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				DeserializeCollectingInfo(response);
				UpdateSyncTime();
				SetPanelType();
				RenderCollectingInfoList();
				SyncGvGStoreHouseStockChanges();
			}
		});
	}

	private void UpdateSyncTime()
	{
		_lastSyncTime = GameController.Instance.GetServerTime();
	}

	private void DeserializeCollectingInfo(GetCollectingInfoResponse response)
	{
		if (((GObject)this).isDisposed)
		{
			return;
		}
		if (string.IsNullOrEmpty(response.jsonInfo) || response.jsonInfo == "null")
		{
			_collectingInfo = null;
			return;
		}
		_collectingInfo = JsonHelper.ToObject<CollectingInfo>(response.jsonInfo);
		SyncGvGStoreHouseStockChanges();
		_stockLimitPar = _collectingInfo.StorehouseLimitParModel;
		if (_collectingInfo.ShipInfos.Count < 3)
		{
			int num = 3 - _collectingInfo.ShipInfos.Count;
			for (int i = 0; i < num; i++)
			{
				_collectingInfo.ShipInfos.Add(null);
			}
		}
	}

	private IEnumerator UpdateCollectingInfo()
	{
		while (!((GObject)this).isDisposed)
		{
			GetNewCollectingInfo();
			yield return _updateInfoInterval;
		}
	}

	private IEnumerator UpdateShipNPCRebellion()
	{
		while (!((GObject)this).isDisposed)
		{
			UpdateNPCRebellion();
			yield return _updateNPCRebellion;
		}
	}

	private void SyncGvGStoreHouseStockChanges()
	{
		if (_collectingInfo?.ItemInfos != null)
		{
			Dictionary<string, int> storeHouseWithCurValueChanges = GetStoreHouseWithCurValueChanges();
			SyncStockChangesAndRenderShips(storeHouseWithCurValueChanges);
		}
	}

	private Dictionary<string, int> GetStoreHouseWithCurValueChanges()
	{
		Dictionary<string, int> dictionary = new Dictionary<string, int>();
		foreach (CollectingItemInfo itemInfo in _collectingInfo.ItemInfos)
		{
			dictionary.Add(itemInfo.ItemId, itemInfo.CuStock);
		}
		return dictionary;
	}

	private void SyncStockChangesAndRenderShips(Dictionary<string, int> changes)
	{
		Singleton<GvGStoreHouseManager>.Instance.SyncStoreHouseWithCurValueChanges(changes);
		Singleton<GvGMode3RoomManager>.Instance.GetGSObserverRecord(delegate
		{
			RenderShipsList();
			WorldMapConfigHelper.Init(Singleton<GvGMode3RoomManager>.Instance.ObserverRecord_OnGS.IZConfigId, RenderShipsList);
		});
	}
}
