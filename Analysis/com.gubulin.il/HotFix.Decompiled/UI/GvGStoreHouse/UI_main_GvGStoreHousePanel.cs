using System;
using System.Collections.Generic;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Controller;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Manager;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket;
using UI.AddCredit;
using UI.CraftItemPopup;
using UI.GiftBag;
using UI.GvGAmplifierStorage;
using UI.GvGFlagship3;
using UI.GvGWorldMap3;
using UnityEngine;

namespace UI.GvGStoreHouse;

public class UI_main_GvGStoreHousePanel : GComponent, IUiController
{
	public Controller PageSwitch;

	public GLoader background;

	public GButton backBtn;

	public UI_com_Title Title;

	public GGroup nameGroup;

	public GImage n56;

	public GGroup backAndCrack;

	public GList TabListBack;

	public GImage backB;

	public GGroup backGroup;

	public GImage EmptyTip;

	public GList ItemList_0;

	public GList ItemList_1;

	public GList ItemList_2;

	public GList TabListFront;

	public GImage n42;

	public GImage n83;

	public GTextField stockLimitTitle;

	public GTextField stockLimit;

	public GImage n64;

	public GButton ExclamationMarkBtn;

	public GGroup stockLimitGroup;

	public GTextField n95;

	public GTextField RemainingTime;

	public GTextField DateTimeName;

	public GGroup n97;

	public GTextField n101;

	public GTextField n98;

	public UI_GoToFlagShip GotoFlagShip;

	public GButton Help;

	public Transition t0;

	public const string URL = "ui://6ym14r0dn0uk0";

	public static string Name = "UI_main_GvGStoreHousePanel";

	private List<string> Trophy_List;

	private List<string> Unpurified_List;

	private List<string> Supply_List;

	private int StockItemCountLimit = -1;

	private readonly Color32[] ItemNameColor = (Color32[])(object)new Color32[6]
	{
		new Color32((byte)149, (byte)91, (byte)54, byte.MaxValue),
		new Color32((byte)26, (byte)122, (byte)0, byte.MaxValue),
		new Color32((byte)0, (byte)70, (byte)174, byte.MaxValue),
		new Color32((byte)161, (byte)46, (byte)209, byte.MaxValue),
		new Color32((byte)218, (byte)87, (byte)0, byte.MaxValue),
		new Color32((byte)217, (byte)0, (byte)36, byte.MaxValue)
	};

	public static string GetURL()
	{
		return "ui://6ym14r0dn0uk0";
	}

	public static UI_main_GvGStoreHousePanel CreateInstance()
	{
		return (UI_main_GvGStoreHousePanel)(object)UIPackage.CreateObject("GvGStoreHouse", "main_GvGStoreHousePanel");
	}

	public static UI_main_GvGStoreHousePanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_GvGStoreHousePanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://6ym14r0dn0uk0", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Expected O, but got Unknown
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Expected O, but got Unknown
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Expected O, but got Unknown
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Expected O, but got Unknown
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Expected O, but got Unknown
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		//IL_014e: Expected O, but got Unknown
		//IL_015a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0164: Expected O, but got Unknown
		//IL_0170: Unknown result type (might be due to invalid IL or missing references)
		//IL_017a: Expected O, but got Unknown
		//IL_0186: Unknown result type (might be due to invalid IL or missing references)
		//IL_0190: Expected O, but got Unknown
		//IL_01d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e3: Expected O, but got Unknown
		//IL_01ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f9: Expected O, but got Unknown
		//IL_0205: Unknown result type (might be due to invalid IL or missing references)
		//IL_020f: Expected O, but got Unknown
		//IL_021b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0225: Expected O, but got Unknown
		//IL_0231: Unknown result type (might be due to invalid IL or missing references)
		//IL_023b: Expected O, but got Unknown
		//IL_0284: Unknown result type (might be due to invalid IL or missing references)
		//IL_028e: Expected O, but got Unknown
		//IL_029a: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a4: Expected O, but got Unknown
		//IL_02b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ba: Expected O, but got Unknown
		//IL_02c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d0: Expected O, but got Unknown
		//IL_0319: Unknown result type (might be due to invalid IL or missing references)
		//IL_0323: Expected O, but got Unknown
		//IL_0382: Unknown result type (might be due to invalid IL or missing references)
		//IL_038c: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		PageSwitch = ((GComponent)this).GetController("PageSwitch");
		background = (GLoader)((GComponent)this).GetChild("background");
		backBtn = (GButton)((GComponent)this).GetChild("backBtn");
		Title = (UI_com_Title)(object)((GComponent)this).GetChild("Title");
		nameGroup = (GGroup)((GComponent)this).GetChild("nameGroup");
		n56 = (GImage)((GComponent)this).GetChild("n56");
		backAndCrack = (GGroup)((GComponent)this).GetChild("backAndCrack");
		TabListBack = (GList)((GComponent)this).GetChild("TabListBack");
		backB = (GImage)((GComponent)this).GetChild("backB");
		backGroup = (GGroup)((GComponent)this).GetChild("backGroup");
		EmptyTip = (GImage)((GComponent)this).GetChild("EmptyTip");
		ItemList_0 = (GList)((GComponent)this).GetChild("ItemList_0");
		ItemList_1 = (GList)((GComponent)this).GetChild("ItemList_1");
		ItemList_2 = (GList)((GComponent)this).GetChild("ItemList_2");
		TabListFront = (GList)((GComponent)this).GetChild("TabListFront");
		n42 = (GImage)((GComponent)this).GetChild("n42");
		n83 = (GImage)((GComponent)this).GetChild("n83");
		stockLimitTitle = (GTextField)((GComponent)this).GetChild("stockLimitTitle");
		string id = "ui://6ym14r0dn0uk0".Replace("ui://", "") + "-" + ((GObject)stockLimitTitle).id;
		((GObject)stockLimitTitle).text = LanguagesManager.GetDesc(id);
		stockLimit = (GTextField)((GComponent)this).GetChild("stockLimit");
		n64 = (GImage)((GComponent)this).GetChild("n64");
		ExclamationMarkBtn = (GButton)((GComponent)this).GetChild("ExclamationMarkBtn");
		stockLimitGroup = (GGroup)((GComponent)this).GetChild("stockLimitGroup");
		n95 = (GTextField)((GComponent)this).GetChild("n95");
		string id2 = "ui://6ym14r0dn0uk0".Replace("ui://", "") + "-" + ((GObject)n95).id;
		((GObject)n95).text = LanguagesManager.GetDesc(id2);
		RemainingTime = (GTextField)((GComponent)this).GetChild("RemainingTime");
		DateTimeName = (GTextField)((GComponent)this).GetChild("DateTimeName");
		n97 = (GGroup)((GComponent)this).GetChild("n97");
		n101 = (GTextField)((GComponent)this).GetChild("n101");
		string id3 = "ui://6ym14r0dn0uk0".Replace("ui://", "") + "-" + ((GObject)n101).id;
		((GObject)n101).text = LanguagesManager.GetDesc(id3);
		n98 = (GTextField)((GComponent)this).GetChild("n98");
		string id4 = "ui://6ym14r0dn0uk0".Replace("ui://", "") + "-" + ((GObject)n98).id;
		((GObject)n98).text = LanguagesManager.GetDesc(id4);
		GotoFlagShip = (UI_GoToFlagShip)(object)((GComponent)this).GetChild("GotoFlagShip");
		Help = (GButton)((GComponent)this).GetChild("Help");
		t0 = ((GComponent)this).GetTransition("t0");
	}

	public void Init(Dictionary<string, object> parameters)
	{
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Expected O, but got Unknown
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		((GObject)this).sortingOrder = 1;
		StockItemCountLimit = -1;
		Singleton<GvGStoreHouseManager>.Instance.SyncStoreHouse(OnSyncStoreHouse);
		RenderStoreHouseLimit();
		UpdateRemainingTime(null);
		Timers.inst.Add(1f, 0, new TimerCallback(UpdateRemainingTime));
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Expected O, but got Unknown
		((GObject)backBtn).onClick.Set(new EventCallback0(End));
		((GObject)Help).onClick.Set(new EventCallback0(OnHelpClick));
		PageSwitch.onChanged.Set(new EventCallback1(OnSwitchPage));
		((GObject)GotoFlagShip).onClick.Set(new EventCallback0(OnClickGotoFlagship));
		GvGStoreHouseManager instance = Singleton<GvGStoreHouseManager>.Instance;
		instance.OnChange = (Action)Delegate.Combine(instance.OnChange, new Action(OnSyncStoreHouse));
		GvGStoreHouseManager instance2 = Singleton<GvGStoreHouseManager>.Instance;
		instance2.OnUseItem = (Action<string>)Delegate.Combine(instance2.OnUseItem, new Action<string>(OnGvGStoreHouseUseItem));
		Singleton<GvGStoreHouseManager>.Instance.AddOnRedDotChange(UpdateRedDot);
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)backBtn).onClick.Clear();
		((GObject)Help).onClick.Clear();
		PageSwitch.onChanged.Clear();
		((GObject)GotoFlagShip).onClick.Clear();
		GvGStoreHouseManager instance = Singleton<GvGStoreHouseManager>.Instance;
		instance.OnChange = (Action)Delegate.Remove(instance.OnChange, new Action(OnSyncStoreHouse));
		GvGStoreHouseManager instance2 = Singleton<GvGStoreHouseManager>.Instance;
		instance2.OnUseItem = (Action<string>)Delegate.Remove(instance2.OnUseItem, new Action<string>(OnGvGStoreHouseUseItem));
		Singleton<GvGStoreHouseManager>.Instance.RemoveOnRedDotChange(UpdateRedDot);
	}

	private void OnHelpClick()
	{
		UiHelper.OpenHelpPage("天空货栈", "远征相关", "远征大厅", "远征玩法哪些东西会保留？哪些会重置？");
	}

	private void OnSwitchPage(EventContext context)
	{
		UpdateStoreHouse();
	}

	private void OnGvGStoreHouseUseItem(string useItemId)
	{
		if (Item.ItemType(useItemId) == 47)
		{
			End();
		}
	}

	private void OnSyncStoreHouse()
	{
		if (Singleton<GvGStoreHouseManager>.Instance.Items == null)
		{
			return;
		}
		Trophy_List = new List<string>();
		Supply_List = new List<string>();
		Unpurified_List = new List<string>();
		Dictionary<string, int> items = Singleton<GvGStoreHouseManager>.Instance.Items;
		foreach (KeyValuePair<string, int> item in items)
		{
			string key = item.Key;
			if (StockController.StorehouseDataDictionary.TryGetValue("SH_" + key, out var value) && Singleton<GvGStoreHouseManager>.Instance.GetItemCount(key) != 0)
			{
				switch ((StockCategory)value.Category)
				{
				case StockCategory.GvGTrophy:
					Trophy_List.Add(key);
					break;
				case StockCategory.GvGUnpurified:
					Unpurified_List.Add(key);
					break;
				case StockCategory.GvGSupply:
					Supply_List.Add(key);
					break;
				}
			}
		}
		UpdateStoreHouse();
	}

	private void OnClickGem()
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_BlackMarketerAddCredit.Name, new Dictionary<string, object>
		{
			{
				"Activity",
				FGUIManager.Instance.GetBlackMarketerActivity("UI_BlackMarketerAddCredit")
			},
			{
				"Order",
				((GObject)this).sortingOrder
			}
		});
	}

	private void OnClickMoney()
	{
		if (((GObject)this).parent != null && ((GObject)this).parent is UI_GiftBagPanel)
		{
			((UI_GiftBagPanel)(object)((GObject)this).parent).MoneyBtnEvent();
			End();
		}
		else if (GameManagers.Instance.BuildingManager.GetBuildingByType("16").Level > 0)
		{
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_GiftBagPanel.Name, new Dictionary<string, object>
			{
				{
					"Activity",
					FGUIManager.Instance.GetBlackMarketerActivity("UI_GiftBagPanel")
				},
				{
					"Order",
					((GObject)this).sortingOrder
				}
			});
		}
		else
		{
			List<string> arg = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText152") };
			SharedMessenger.Broadcast("SHOW_TIPS", arg, 1, arg3: false);
		}
	}

	private void OnOpenItemTip(string itemId)
	{
		ItemType itemType = (ItemType)Item.ItemType(itemId);
		if (itemType == ItemType.GvGServer_CraftItems)
		{
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_CraftItemPopupPanel_GvG.Name, new Dictionary<string, object>
			{
				{ "ItemId", itemId },
				{
					"OnConfirmCraft",
					new UICallbackParam<Action<int>>(delegate(int num)
					{
						OnConfirmCraft(itemId, num);
					})
				}
			});
		}
		else if (!UI_main_SelectAmplifier.TryShowSelectAmplifier(itemId))
		{
			FGUIManager.Instance.ItemTip(itemId, ((GObject)this).sortingOrder, noCheckBtn: false, reserveRes: false, this, isPack: true);
		}
	}

	private void OnConfirmCraft(string itemId, int num)
	{
		Singleton<GvGStoreHouseManager>.Instance.UseItem(itemId, num);
	}

	private void OnClickGotoFlagship()
	{
		int ourFlagShipStayIslandId = Singleton<WorldStateManager>.Instance.Data.OurFlagShipStayIslandId;
		string shipIdStaySomeIsland = Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.GetShipIdStaySomeIsland(ourFlagShipStayIslandId);
		if (string.IsNullOrEmpty(shipIdStaySomeIsland))
		{
			ILRequestHelper.ShowMessage("GvG3CanNotUseFlagShipTip".ToLanguage());
			End();
			GvGWorldMapController.Instance.FocusIslandById(ourFlagShipStayIslandId);
		}
		else
		{
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_GvGFlagshipPanel.Name, new Dictionary<string, object> { { "PlayTransition", "PurificationScale" } });
		}
	}

	private void UpdateRemainingTime(object param)
	{
		int num = Mathf.Max(0, Singleton<WorldStateManager>.Instance.Data.IZEndTimestamp - (int)GameController.Instance.GetServerTime());
		if (num >= 86400)
		{
			((GObject)RemainingTime).text = $"{num / 86400}";
			((GObject)DateTimeName).text = "DateTime_Days".ToLanguage();
		}
		else if (num >= 3600)
		{
			((GObject)RemainingTime).text = $"{num / 3600}";
			((GObject)DateTimeName).text = "DateTime_Hours".ToLanguage();
		}
		else if (num >= 60)
		{
			((GObject)RemainingTime).text = $"{num / 60}";
			((GObject)DateTimeName).text = "DateTime_Minutes".ToLanguage();
		}
		else
		{
			((GObject)RemainingTime).text = $"{num}";
			((GObject)DateTimeName).text = "DateTime_Seconds".ToLanguage();
		}
	}

	private void UpdateRedDot()
	{
		GvGStorehouseRedDot redDot = Singleton<GvGStoreHouseManager>.Instance.RedDot;
		((GObject)((UI_btn_PageTabFront)(object)((GComponent)TabListFront).GetChildAt(0)).note).visible = redDot.Trophy;
		((GObject)((UI_btn_PageTabFront)(object)((GComponent)TabListFront).GetChildAt(1)).note).visible = redDot.Unpurified;
	}

	private void RenderStoreHouseLimit()
	{
		((GObject)stockLimit).text = "";
		Singleton<GvGStoreHouseManager>.Instance.GetRealtimeStockLimit(delegate(C2S_GetRealTimeStorehouseLimitParModel.Response res)
		{
			//IL_008c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0096: Expected O, but got Unknown
			string desc;
			if (!((GObject)this).isDisposed)
			{
				RealTimeStorehouseLimitParModel model = res.Model;
				StockItemCountLimit = res.StorehouseLimit;
				((GObject)stockLimit).text = StockItemCountLimit.ToString();
				((GObject)ExclamationMarkBtn).visible = model.Total > 1f;
				((GObject)ExclamationMarkBtn).enabled = true;
				desc = model.GetStorehouseLimitParText();
				((GObject)ExclamationMarkBtn).onClick.Set(new EventCallback1(OnClickExclamationMarkBtn));
				UpdateStoreHouse();
			}
			void OnClickExclamationMarkBtn(EventContext context)
			{
				//IL_000c: Unknown result type (might be due to invalid IL or missing references)
				//IL_0011: Unknown result type (might be due to invalid IL or missing references)
				//IL_0016: Unknown result type (might be due to invalid IL or missing references)
				//IL_001d: Unknown result type (might be due to invalid IL or missing references)
				//IL_001e: Unknown result type (might be due to invalid IL or missing references)
				//IL_0023: Unknown result type (might be due to invalid IL or missing references)
				//IL_0026: Unknown result type (might be due to invalid IL or missing references)
				//IL_0032: Unknown result type (might be due to invalid IL or missing references)
				//IL_0069: Unknown result type (might be due to invalid IL or missing references)
				Vector2 val = ((GObject)ExclamationMarkBtn).LocalToGlobal(Vector2.zero);
				val = ((GObject)this).GlobalToLocal(val);
				((Vector2)(ref val))._002Ector(val.x - 80f, val.y);
				GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_ShowEfficiencyBuff.Name, new Dictionary<string, object>
				{
					{ "Text", desc },
					{ "Pos", val }
				});
				context.StopPropagation();
			}
		});
	}

	private void UpdateStoreHouse()
	{
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Expected O, but got Unknown
		List<string> listData = new List<string>();
		if (PageSwitch.selectedIndex == 0)
		{
			listData = Trophy_List;
			Singleton<GvGStoreHouseManager>.Instance.CheckTrophyPage();
		}
		else if (PageSwitch.selectedIndex == 1)
		{
			listData = Unpurified_List;
			Singleton<GvGStoreHouseManager>.Instance.CheckUnpurifiedPage();
		}
		else if (PageSwitch.selectedIndex == 2)
		{
			listData = Supply_List;
		}
		GList asList = ((GComponent)this).GetChild($"ItemList_{PageSwitch.selectedIndex}").asList;
		asList.SetVirtual();
		asList.itemRenderer = (ListItemRenderer)delegate(int i, GObject o)
		{
			RenderListItem(i, o, listData);
		};
		asList.numItems = listData.Count;
		asList.RefreshVirtualList();
		((GObject)EmptyTip).visible = listData.Count <= 0;
	}

	private void RenderListItem(int index, GObject item, List<string> listData)
	{
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0142: Unknown result type (might be due to invalid IL or missing references)
		//IL_014c: Expected O, but got Unknown
		GButton asButton = item.asButton;
		string itemId = listData[index];
		int num = ((Item.ItemType(itemId) == 2) ? GameManagers.Instance.UserArchiveManager.GetWeaponEvoLevel(itemId) : Item.Level(GameManagers.Instance, itemId));
		num = ((num > 0) ? num : Item.Rarity(itemId));
		((GComponent)asButton).GetChild("frame").asLoader.url = $"ui://PublicResources/kuang_round 2_lv{num}";
		int itemCount = Singleton<GvGStoreHouseManager>.Instance.GetItemCount(itemId);
		((GComponent)asButton).GetChild("icon").asLoader.url = "ui://PublicResources/" + UiHelper.GetIcon(itemId);
		asButton.title = itemCount.ToString();
		((GObject)((GComponent)asButton).GetChild("name").asTextField).text = SchemaIndexHelper.GetNameById(GameManagers.Instance, itemId);
		((GComponent)asButton).GetChild("name").asTextField.color = Color32.op_Implicit(ItemNameColor[(num - 1 >= 0) ? (num - 1) : 0]);
		((GObject)asButton).onClick.Set((EventCallback0)delegate
		{
			OnOpenItemTip(itemId);
		});
		if (StockItemCountLimit > 0)
		{
			((GComponent)asButton).GetChild("max").alpha = ((itemCount >= StockItemCountLimit) ? 1 : 0);
		}
	}

	private void UpdateRightTopMenu()
	{
		UpdateGemstone();
		UpdateMoney();
	}

	private void UpdateGemstone()
	{
		int stock = GameManagers.Instance.StockController.GetStock("Gem");
	}

	private void UpdateMoney()
	{
		int stock = GameManagers.Instance.StockController.GetStock("Money");
	}

	public void End()
	{
		Singleton<GvGStoreHouseManager>.Instance.CheckTrophyPage();
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
	}

	public void OnShow()
	{
	}

	public void BeforeDestroy()
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Expected O, but got Unknown
		Timers.inst.Remove(new TimerCallback(UpdateRemainingTime));
	}

	public void Destroy()
	{
	}
}
