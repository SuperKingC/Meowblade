using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using GameDataEditor;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model.OuterTech;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Shift.Legion.Common.Sources.Enums;
using UI.PublicResources;

namespace UI.GvGOuterTech;

public class UI_com_TechListPage : GComponent
{
	public class TechDataGroup
	{
		public int TechDateLevel;

		public bool Unlocked;

		public TechData Slot1;

		public TechData Slot2;

		public void AddItem(TechData data)
		{
			data.TGroup = this;
			if (Slot1 == null)
			{
				Slot1 = data;
			}
			else
			{
				Slot2 = data;
			}
		}
	}

	[Serializable]
	[CompilerGenerated]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

		public static Func<TechData, bool> _003C_003E9__38_0;

		public static Action<UI_com_UniversalPopupTip> _003C_003E9__41_1;

		public static EventCallback1 _003C_003E9__41_0;

		internal bool _003CFilterTech_003Eb__38_0(TechData t)
		{
			return t.Level > 0;
		}

		internal void _003CRenderRaritySeparator_003Eb__41_0(EventContext context)
		{
			//IL_000e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0014: Expected O, but got Unknown
			//IL_0037: Unknown result type (might be due to invalid IL or missing references)
			//IL_003d: Unknown result type (might be due to invalid IL or missing references)
			context.StopPropagation();
			GObject target = (GObject)context.sender;
			FairyGUITip.ShowTip(target, eFairyGUITipDir.Down, delegate(UI_com_UniversalPopupTip popup)
			{
				((GObject)popup.title).text = "RedRarityOutTechTip".ToLanguage();
			});
		}

		internal void _003CRenderRaritySeparator_003Eb__41_1(UI_com_UniversalPopupTip popup)
		{
			((GObject)popup.title).text = "RedRarityOutTechTip".ToLanguage();
		}
	}

	public GList TechList;

	public GImage n124;

	public UI_com_RarityTabList RarityTabList;

	public UI_com_TechLotteryEntry TechLotteryEntry;

	public UI_btn_ShowOwnedOnly ShowOwnedOnlyBtn;

	public GButton BackBtn;

	public UI_com_Title Title;

	public GButton HelpBtn;

	public Transition Hide;

	public Transition Show;

	public const string URL = "ui://th385mttrg731g";

	public static string Name = "UI_com_TechListPage";

	private bool IsInit;

	private List<RarityData> RarityData_List;

	private int FirstOwnedRarityIndex;

	private static Dictionary<int, int> RarityOwnedCount;

	private static Dictionary<int, List<TechData>> TechRarity_Dict;

	private List<object> Data_List;

	private bool IsShowOwnedOnly;

	public static string GetURL()
	{
		return "ui://th385mttrg731g";
	}

	public static UI_com_TechListPage CreateInstance()
	{
		return (UI_com_TechListPage)(object)UIPackage.CreateObject("GvGOuterTech", "com_TechListPage");
	}

	public static UI_com_TechListPage CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_TechListPage).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://th385mttrg731g", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected O, but got Unknown
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		TechList = (GList)((GComponent)this).GetChild("TechList");
		n124 = (GImage)((GComponent)this).GetChild("n124");
		RarityTabList = (UI_com_RarityTabList)(object)((GComponent)this).GetChild("RarityTabList");
		TechLotteryEntry = (UI_com_TechLotteryEntry)(object)((GComponent)this).GetChild("TechLotteryEntry");
		ShowOwnedOnlyBtn = (UI_btn_ShowOwnedOnly)(object)((GComponent)this).GetChild("ShowOwnedOnlyBtn");
		BackBtn = (GButton)((GComponent)this).GetChild("BackBtn");
		Title = (UI_com_Title)(object)((GComponent)this).GetChild("Title");
		HelpBtn = (GButton)((GComponent)this).GetChild("HelpBtn");
		Hide = ((GComponent)this).GetTransition("Hide");
		Show = ((GComponent)this).GetTransition("Show");
	}

	public void Init()
	{
		IsInit = true;
		Hide.invalidateBatchingEveryFrame = true;
		Show.invalidateBatchingEveryFrame = true;
		InitRarityTab();
		InitTech();
		UpdateTech();
		TimerHelper.CallNextFrame(delegate
		{
			OnClickRarityTab(FirstOwnedRarityIndex);
		});
		((GObject)TechList).touchable = false;
		((GObject)TechLotteryEntry).visible = false;
		((GObject)TechLotteryEntry.AccTip).visible = false;
		Singleton<GvGMode3RoomManager>.Instance.GetGSObserverRecord(delegate
		{
			((GObject)TechList).touchable = true;
			((GObject)TechLotteryEntry).visible = true;
			UpdateTechLotteryEntry();
			UpdateSpeedPlanTip();
		});
		IsInit = false;
	}

	private void InitRarityTab()
	{
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Expected O, but got Unknown
		RarityData_List = new List<RarityData>();
		for (int num = 7; num >= 1; num--)
		{
			RarityData_List.Add(new RarityData(num));
		}
		RarityTabList.List.itemRenderer = (ListItemRenderer)delegate(int i, GObject o)
		{
			RenderRarityTabSlot(i, (UI_btn_RatityTab)(object)o);
		};
		RarityTabList.List.numItems = RarityData_List.Count;
		RarityTabList.List.selectedIndex = 0;
	}

	private void InitTech()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected O, but got Unknown
		TechList.itemProvider = new ListItemProvider(TechSlotProvider);
		TechList.itemRenderer = new ListItemRenderer(RenderTechListItem);
		if (TechRarity_Dict != null)
		{
			return;
		}
		TechRarity_Dict = new Dictionary<int, List<TechData>>();
		foreach (RarityData rarityData_ in RarityData_List)
		{
			TechRarity_Dict.Add(rarityData_.Rarity, new List<TechData>());
		}
		foreach (string item in ConfigDataManager.ItemsByType[ItemType.GvGOuterTech])
		{
			TechData techData = new TechData(item);
			TechRarity_Dict[techData.Rarity].Add(techData);
		}
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		((GObject)HelpBtn).onClick.Set(new EventCallback0(OnHelpClick));
		((GButton)ShowOwnedOnlyBtn.CheckBox).onChanged.Set(new EventCallback0(OnShowOwnedOnlyCheckBoxChanged));
		SharedMessenger.AddListener<string, int, (StockInContext, string)>("ON_STOCK_CHANGE", OnStockChange);
		GvGOuterTechManager instance = Singleton<GvGOuterTechManager>.Instance;
		instance.OnNoticeChange = (Action)Delegate.Combine(instance.OnNoticeChange, new Action(OnNoticeChange));
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)HelpBtn).onClick.Clear();
		((GButton)ShowOwnedOnlyBtn.CheckBox).onChanged.Clear();
		SharedMessenger.RemoveListener<string, int, (StockInContext, string)>("ON_STOCK_CHANGE", OnStockChange);
		GvGOuterTechManager instance = Singleton<GvGOuterTechManager>.Instance;
		instance.OnNoticeChange = (Action)Delegate.Remove(instance.OnNoticeChange, new Action(OnNoticeChange));
	}

	public void OnActive()
	{
		UpdateTech();
	}

	public void OnInactive()
	{
	}

	public void OnDestroy()
	{
	}

	private void OnHelpClick()
	{
		UiHelper.OpenHelpPage("众神回路", "远征相关", "众神回路");
	}

	private void OnClickRarityTab(int index)
	{
		RarityData item = RarityData_List[index];
		int num = Data_List.IndexOf(item);
		GObject childAt = ((GComponent)TechList).GetChildAt(num);
		((GComponent)TechList).scrollPane.SetPosY(childAt.y, true);
	}

	private void OnShowOwnedOnlyCheckBoxChanged()
	{
		UpdateTech();
	}

	private void OnClickTechSlot(TechData data)
	{
		if (data.TechType != eOuterTechType.Empty)
		{
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_TechUpgradePanel.Name, new Dictionary<string, object> { { "TechData", data } });
		}
	}

	private void OnStockChange(string itemId, int incr, (StockInContext, string) context)
	{
		if (Item.ItemType(itemId) == 102)
		{
			UpdateTech();
		}
	}

	private void OnNoticeChange()
	{
		UpdateTechLotteryEntry();
	}

	private void UpdateTech()
	{
		if (IsInit || ((GButton)ShowOwnedOnlyBtn.CheckBox).selected != IsShowOwnedOnly)
		{
			IsShowOwnedOnly = ((GButton)ShowOwnedOnlyBtn.CheckBox).selected;
			Data_List = FilterTech(TechRarity_Dict, IsShowOwnedOnly);
		}
		TechList.numItems = 0;
		TechList.numItems = Data_List.Count;
	}

	private List<object> FilterTech(Dictionary<int, List<TechData>> techs, bool isShowOwnedOnly)
	{
		FirstOwnedRarityIndex = -1;
		RarityOwnedCount = new Dictionary<int, int>();
		List<object> list = new List<object>();
		for (int i = 0; i < RarityData_List.Count; i++)
		{
			RarityData rarityData = RarityData_List[i];
			list.Add(rarityData);
			List<TechData> list2 = techs[rarityData.Rarity];
			List<TechData> list3 = list2.Where((TechData t) => t.Level > 0).ToList();
			List<TechData> list4 = (isShowOwnedOnly ? list3 : list2);
			RarityOwnedCount[rarityData.Rarity] = list3.Count;
			if (FirstOwnedRarityIndex == -1 && list3.Count > 0)
			{
				FirstOwnedRarityIndex = i;
			}
			if (rarityData.RT == RarityData.RarityType.Red)
			{
				List<TechDataGroup> list5 = new List<TechDataGroup>();
				for (int num = 0; num < list2.Count / 2; num++)
				{
					TechDataGroup techDataGroup = new TechDataGroup();
					techDataGroup.TechDateLevel = num;
					techDataGroup.Unlocked = true;
					list5.Add(techDataGroup);
				}
				foreach (TechData item in list4)
				{
					TechDataGroup techDataGroup2 = list5[item.TechEffect.Level];
					techDataGroup2.AddItem(item);
				}
				list.AddRange(list5);
				TechDataGroup techDataGroup3 = list5[1];
				techDataGroup3.Unlocked = list3.Count >= 2;
			}
			else if (list4.Count > 0)
			{
				list.AddRange(list4);
			}
			else
			{
				list.Add(null);
			}
		}
		if (FirstOwnedRarityIndex == -1)
		{
			FirstOwnedRarityIndex = 0;
		}
		list.Add(null);
		list.Add(null);
		return list;
	}

	private string TechSlotProvider(int index)
	{
		object obj = Data_List[index];
		if (obj is RarityData)
		{
			return "ui://GvGOuterTech/com_RaritySeparator";
		}
		if (obj is TechData)
		{
			return "ui://GvGOuterTech/btn_TechSlotBig";
		}
		if (obj is TechDataGroup)
		{
			return "ui://GvGOuterTech/com_TechSlotBigGroup";
		}
		return "ui://GvGOuterTech/com_EmptySpace";
	}

	private void RenderTechListItem(int index, GObject gObject)
	{
		if (gObject is UI_com_RaritySeparator slot)
		{
			RenderRaritySeparator(index, slot);
		}
		else if (gObject is UI_btn_TechSlotBig slot2)
		{
			RenderTechSlotBig(index, slot2);
		}
		else if (gObject is UI_com_TechSlotBigGroup uI_com_TechSlotBigGroup)
		{
			TechDataGroup techDataGroup = (TechDataGroup)Data_List[index];
			uI_com_TechSlotBigGroup.showArrow.SetSelectedIndex((techDataGroup.TechDateLevel % 2 == 0) ? 1 : 0);
			uI_com_TechSlotBigGroup.stage1.activate.SetSelectedIndex(techDataGroup.Unlocked ? 1 : 0);
			uI_com_TechSlotBigGroup.stage1.c2.SetSelectedIndex(techDataGroup.TechDateLevel);
			RenderTechSlotBig(techDataGroup.Slot1, uI_com_TechSlotBigGroup.Card1);
			RenderTechSlotBig(techDataGroup.Slot2, uI_com_TechSlotBigGroup.Card2);
		}
	}

	private void RenderRaritySeparator(int index, UI_com_RaritySeparator slot)
	{
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Expected O, but got Unknown
		RarityData rarityData = (RarityData)Data_List[index];
		slot.Rarity.selectedIndex = rarityData.Rarity;
		((GObject)slot.TechCount).text = $"({RarityOwnedCount[rarityData.Rarity]}/{TechRarity_Dict[rarityData.Rarity].Count})";
		slot.PieceIcon.url = rarityData.PieceItemIconUrl;
		((GObject)slot.PieceCount).text = $"{rarityData.PieceCount}";
		if (rarityData.RT == RarityData.RarityType.Red)
		{
			EventListener onClick = ((GObject)slot.helpBtn).onClick;
			object obj = _003C_003Ec._003C_003E9__41_0;
			if (obj == null)
			{
				EventCallback1 val = delegate(EventContext context)
				{
					//IL_000e: Unknown result type (might be due to invalid IL or missing references)
					//IL_0014: Expected O, but got Unknown
					//IL_0037: Unknown result type (might be due to invalid IL or missing references)
					//IL_003d: Unknown result type (might be due to invalid IL or missing references)
					context.StopPropagation();
					GObject target = (GObject)context.sender;
					FairyGUITip.ShowTip(target, eFairyGUITipDir.Down, delegate(UI_com_UniversalPopupTip popup)
					{
						((GObject)popup.title).text = "RedRarityOutTechTip".ToLanguage();
					});
				};
				_003C_003Ec._003C_003E9__41_0 = val;
				obj = (object)val;
			}
			onClick.Set((EventCallback1)obj);
		}
		else
		{
			((GObject)slot.helpBtn).onClick.Clear();
		}
	}

	private void RenderTechSlotBig(int index, UI_btn_TechSlotBig slot)
	{
		TechData data = (TechData)Data_List[index];
		RenderTechSlotBig(data, slot);
	}

	private void RenderTechSlotBig(TechData data, UI_btn_TechSlotBig slot)
	{
		//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e6: Expected O, but got Unknown
		if (data == null)
		{
			((GObject)slot).visible = false;
			return;
		}
		slot.Rarity.selectedIndex = data.Rarity;
		slot.State.selectedIndex = ((data.Level == 0) ? 1 : 0);
		((GObject)slot.TechName).text = data.Name;
		slot.TechIcon.url = data.TechIconUrl;
		((GObject)slot.Level).text = $"Lv. {data.Level}";
		((GObject)slot.Effect).text = data.CurLevelEffectDesc;
		((GObject)slot).onClick.Set((EventCallback0)delegate
		{
			OnClickTechSlot(data);
		});
	}

	private void RenderRarityTabSlot(int i, UI_btn_RatityTab tab)
	{
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Expected O, but got Unknown
		RarityData rarityData = RarityData_List[i];
		tab.Rarity.selectedIndex = rarityData.Rarity;
		((GObject)tab).onClick.Set((EventCallback0)delegate
		{
			OnClickRarityTab(i);
		});
	}

	private void UpdateTechLotteryEntry()
	{
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Expected O, but got Unknown
		TechLotteryEntry.HasEnterIZ.selectedIndex = ((Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.HasEnterIZ || Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.LastIZId != -1) ? 1 : 0);
		string itemId = "I63121";
		FGUIManager.Instance.SetItemIconAndFrame(TechLotteryEntry.ChipIcon, itemId, null, "", frameVisible: false);
		((GObject)TechLotteryEntry.ChipCount).text = $"{Singleton<GvGOuterTechManager>.Instance.ChipCount}";
		((GObject)TechLotteryEntry.ChipIcon).onClick.Set((EventCallback0)delegate
		{
			FGUIManager.Instance.ItemTip(itemId, ((GObject)this).sortingOrder, noCheckBtn: true);
		});
		((GObject)TechLotteryEntry.ItemName).text = GDMgr.Get<GDEItemData>(itemId).Name;
		TechLotteryEntry.NoticeType.selectedIndex = 0;
		if (Singleton<GvGOuterTechManager>.Instance.HasRedDot)
		{
			if (Singleton<GvGOuterTechManager>.Instance.HasDrawChance)
			{
				TechLotteryEntry.NoticeType.selectedIndex = 1;
			}
			else if (Singleton<GvGOuterTechManager>.Instance.HasPushedGiftBag)
			{
				TechLotteryEntry.NoticeType.selectedIndex = 2;
			}
		}
	}

	private void UpdateSpeedPlanTip()
	{
		if (Singleton<GvGOuterTechManager>.Instance.IsSpeedPlanAvailable)
		{
			if (Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.HasEnterIZ || Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.LastIZId != -1)
			{
				if (Singleton<GvGOuterTechManager>.Instance.SpeedPlan.CouldClaimCount > 0)
				{
					((GObject)TechLotteryEntry.AccTip).visible = true;
					TechLotteryEntry.AccTip.AccStatus.selectedIndex = 1;
					((GObject)TechLotteryEntry.AccTip.Qty).text = $"x{Singleton<GvGOuterTechManager>.Instance.SpeedPlan.CouldClaimCount}";
				}
				else
				{
					((GObject)TechLotteryEntry.AccTip).visible = false;
				}
			}
			else if (Singleton<GvGOuterTechManager>.Instance.SpeedPlan.CouldClaimCount > 0 && !Singleton<GvGOuterTechManager>.Instance.SpeedPlan.Claimed)
			{
				((GObject)TechLotteryEntry.AccTip).visible = true;
				TechLotteryEntry.AccTip.AccStatus.selectedIndex = 2;
				((GObject)TechLotteryEntry.AccTip.Qty).text = $"x{Singleton<GvGOuterTechManager>.Instance.SpeedPlan.CouldClaimCount}";
			}
			else if (Singleton<GvGOuterTechManager>.Instance.SpeedPlan.NextClaimCount > 0 && Singleton<GvGOuterTechManager>.Instance.SpeedPlan.Claimed)
			{
				((GObject)TechLotteryEntry.AccTip).visible = true;
				TechLotteryEntry.AccTip.AccStatus.selectedIndex = 0;
				((GObject)TechLotteryEntry.AccTip.Qty).text = $"x{Singleton<GvGOuterTechManager>.Instance.SpeedPlan.NextClaimCount}";
			}
			else
			{
				((GObject)TechLotteryEntry.AccTip).visible = false;
			}
		}
		else
		{
			((GObject)TechLotteryEntry.AccTip).visible = false;
		}
	}
}
