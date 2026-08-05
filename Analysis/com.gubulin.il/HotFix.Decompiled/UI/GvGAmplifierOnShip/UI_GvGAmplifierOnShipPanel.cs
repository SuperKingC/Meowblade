using System;
using System.Collections.Generic;
using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Services;
using UI.PublicResources;
using UI.Tips;
using UnityEngine;

namespace UI.GvGAmplifierOnShip;

public class UI_GvGAmplifierOnShipPanel : GComponent, IUiController
{
	public Controller IsShowFilterDialog;

	public Controller IsShowDropDown;

	public Controller IsShowSummary;

	public Controller CanSave;

	public Controller IsListEmpty;

	public Controller c1;

	public Controller IsAmpListContentEmpty;

	public GLoader background;

	public GButton BackBtn;

	public UI_com_Title Title;

	public GButton HelpBtn;

	public GImage n101;

	public GImage n142;

	public GImage n169;

	public GImage n115;

	public GImage n166;

	public GImage n168;

	public GLoader n167;

	public GTextField n165;

	public GList TypeMenu;

	public GList LoadedList;

	public UI_com_AmpListContent AmpListContent;

	public UI_btn_FilterBtn FilterBtn;

	public UI_btn_SelectedShip SelectedShip;

	public UI_btn_OneClickUnload OneClickUnload;

	public UI_btn_OneClickLoad OneClickEquip;

	public UI_btn_ConfirmSaveBtn ConfirmSaveBtn;

	public UI_btn_LoadedInfo LoadedInfo;

	public GGraph FilterDialogBack;

	public UI_com_AmplifierFilterDialog FilterDialog;

	public GGraph ShipDropDownMenuBack;

	public UI_com_ShipDropDownMenu ShipDropDownMenu;

	public GGraph SummaryDialogMask;

	public UI_com_SummaryDialog SummaryDialog;

	public const string URL = "ui://pwlamcyxgp160";

	public static string Name = "UI_GvGAmplifierOnShipPanel";

	private GvGAmplifierOnShipModel Data;

	private int CurSelectedShipIndex;

	private eAmplifierType CurSelectedType;

	private List<AmplifierModel> StorageAmpsConfig_List;

	private Dictionary<eAmplifierType, List<AmplifierModel>> ShipAmpsType_Dict;

	private List<AmplifierModel> ShipAmpsFilteredByType;

	private List<AmplifierModel> StorageAmpsFilteredByType;

	private List<AmplifierModel> RecommendAmps;

	private List<AmplifierModel> OthersAmps;

	private Dictionary<int, int> StorageChanges;

	private Dictionary<eAmplifierType, int> NewLoadedCount_Dict;

	private Action OnClose;

	private bool IsEdited
	{
		get
		{
			if (StorageChanges == null)
			{
				return false;
			}
			foreach (KeyValuePair<int, int> storageChange in StorageChanges)
			{
				if (storageChange.Value != 0)
				{
					return true;
				}
			}
			return false;
		}
	}

	public static string GetURL()
	{
		return "ui://pwlamcyxgp160";
	}

	public static UI_GvGAmplifierOnShipPanel CreateInstance()
	{
		return (UI_GvGAmplifierOnShipPanel)(object)UIPackage.CreateObject("GvGAmplifierOnShip", "GvGAmplifierOnShipPanel");
	}

	public static UI_GvGAmplifierOnShipPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_GvGAmplifierOnShipPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://pwlamcyxgp160", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Expected O, but got Unknown
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Expected O, but got Unknown
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Expected O, but got Unknown
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Expected O, but got Unknown
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Expected O, but got Unknown
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Expected O, but got Unknown
		//IL_0126: Unknown result type (might be due to invalid IL or missing references)
		//IL_0130: Expected O, but got Unknown
		//IL_013c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0146: Expected O, but got Unknown
		//IL_0152: Unknown result type (might be due to invalid IL or missing references)
		//IL_015c: Expected O, but got Unknown
		//IL_0168: Unknown result type (might be due to invalid IL or missing references)
		//IL_0172: Expected O, but got Unknown
		//IL_017e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0188: Expected O, but got Unknown
		//IL_01d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01db: Expected O, but got Unknown
		//IL_01e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f1: Expected O, but got Unknown
		//IL_0297: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a1: Expected O, but got Unknown
		//IL_02c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cd: Expected O, but got Unknown
		//IL_02ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f9: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		IsShowFilterDialog = ((GComponent)this).GetController("IsShowFilterDialog");
		IsShowDropDown = ((GComponent)this).GetController("IsShowDropDown");
		IsShowSummary = ((GComponent)this).GetController("IsShowSummary");
		CanSave = ((GComponent)this).GetController("CanSave");
		IsListEmpty = ((GComponent)this).GetController("IsListEmpty");
		c1 = ((GComponent)this).GetController("c1");
		IsAmpListContentEmpty = ((GComponent)this).GetController("IsAmpListContentEmpty");
		background = (GLoader)((GComponent)this).GetChild("background");
		BackBtn = (GButton)((GComponent)this).GetChild("BackBtn");
		Title = (UI_com_Title)(object)((GComponent)this).GetChild("Title");
		HelpBtn = (GButton)((GComponent)this).GetChild("HelpBtn");
		n101 = (GImage)((GComponent)this).GetChild("n101");
		n142 = (GImage)((GComponent)this).GetChild("n142");
		n169 = (GImage)((GComponent)this).GetChild("n169");
		n115 = (GImage)((GComponent)this).GetChild("n115");
		n166 = (GImage)((GComponent)this).GetChild("n166");
		n168 = (GImage)((GComponent)this).GetChild("n168");
		n167 = (GLoader)((GComponent)this).GetChild("n167");
		n165 = (GTextField)((GComponent)this).GetChild("n165");
		string id = "ui://pwlamcyxgp160".Replace("ui://", "") + "-" + ((GObject)n165).id;
		((GObject)n165).text = LanguagesManager.GetDesc(id);
		TypeMenu = (GList)((GComponent)this).GetChild("TypeMenu");
		LoadedList = (GList)((GComponent)this).GetChild("LoadedList");
		AmpListContent = (UI_com_AmpListContent)(object)((GComponent)this).GetChild("AmpListContent");
		FilterBtn = (UI_btn_FilterBtn)(object)((GComponent)this).GetChild("FilterBtn");
		SelectedShip = (UI_btn_SelectedShip)(object)((GComponent)this).GetChild("SelectedShip");
		OneClickUnload = (UI_btn_OneClickUnload)(object)((GComponent)this).GetChild("OneClickUnload");
		OneClickEquip = (UI_btn_OneClickLoad)(object)((GComponent)this).GetChild("OneClickEquip");
		ConfirmSaveBtn = (UI_btn_ConfirmSaveBtn)(object)((GComponent)this).GetChild("ConfirmSaveBtn");
		LoadedInfo = (UI_btn_LoadedInfo)(object)((GComponent)this).GetChild("LoadedInfo");
		FilterDialogBack = (GGraph)((GComponent)this).GetChild("FilterDialogBack");
		FilterDialog = (UI_com_AmplifierFilterDialog)(object)((GComponent)this).GetChild("FilterDialog");
		ShipDropDownMenuBack = (GGraph)((GComponent)this).GetChild("ShipDropDownMenuBack");
		ShipDropDownMenu = (UI_com_ShipDropDownMenu)(object)((GComponent)this).GetChild("ShipDropDownMenu");
		SummaryDialogMask = (GGraph)((GComponent)this).GetChild("SummaryDialogMask");
		SummaryDialog = (UI_com_SummaryDialog)(object)((GComponent)this).GetChild("SummaryDialog");
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		FilterDialog.Init();
		string initialShipId = null;
		if (parameters.TryGetValue("ShipId", out var value))
		{
			initialShipId = (string)value;
		}
		if (parameters.TryGetValue("OnClose", out var value2))
		{
			OnClose = ((UICallbackParam<Action>)value2).Callback;
		}
		StorageChanges = new Dictionary<int, int>();
		NewLoadedCount_Dict = new Dictionary<eAmplifierType, int>();
		for (int i = 0; i < TypeMenu.numItems; i++)
		{
			UI_TypeTab uI_TypeTab = (UI_TypeTab)(object)((GComponent)TypeMenu).GetChildAt(i);
			eAmplifierType selectedIndex = (eAmplifierType)uI_TypeTab.Type.selectedIndex;
			NewLoadedCount_Dict.Add(selectedIndex, 0);
		}
		Data = new GvGAmplifierOnShipModel();
		Data.GetData(delegate
		{
			RenderShipDropDownMenu();
			int num = ((initialShipId != null) ? FindShipIndex(initialShipId) : 0);
			ShipDropDownMenu.ShipList.selectedIndex = num;
			TypeMenu.selectedIndex = 0;
			CurSelectedType = (eAmplifierType)((UI_TypeTab)(object)((GComponent)TypeMenu).GetChildAt(TypeMenu.selectedIndex)).Type.selectedIndex;
			SelectShip(num);
		});
		((GObject)LoadedInfo.ExtraAmplifierCountLimitBtn).visible = false;
		Singleton<GvGAmplifierManager>.Instance.SyncAmplifierTalentData(delegate
		{
			//IL_0073: Unknown result type (might be due to invalid IL or missing references)
			Data.AmplifierCountLimit = Singleton<GvGAmplifierManager>.Instance.TalentData.AmplifierCountLimit;
			int extraAmplifierCountLimit = Singleton<GvGAmplifierManager>.Instance.TalentData.ExtraAmplifierCountLimit;
			((GObject)LoadedInfo.ExtraAmplifierCountLimitBtn).visible = extraAmplifierCountLimit > 0;
			LoadedInfo.ExtraAmplifierCountLimitBtn.SetPopupTips(Singleton<GvGAmplifierManager>.Instance.TalentData.ExtraAmplifierCountLimit_Tip, new Vector2(0f, -216f));
		});
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
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Expected O, but got Unknown
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Expected O, but got Unknown
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Expected O, but got Unknown
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Expected O, but got Unknown
		//IL_0100: Unknown result type (might be due to invalid IL or missing references)
		//IL_010a: Expected O, but got Unknown
		//IL_011d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0127: Expected O, but got Unknown
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		((GObject)BackBtn).onClick.Add(new EventCallback0(OnClickBackBtn));
		((GObject)OneClickUnload).onClick.Add(new EventCallback0(OnAutoUnloadSelectedType));
		((GObject)OneClickEquip).onClick.Add(new EventCallback0(OnAutoLoadSelectedType));
		((GObject)SelectedShip).onClick.Add(new EventCallback0(OnShowDropDownMenu));
		((GObject)ShipDropDownMenuBack).onClick.Add(new EventCallback0(OnCloseDropDownMenu));
		ShipDropDownMenu.ShipList.onClickItem.Add(new EventCallback0(OnClickShipMenuItem));
		TypeMenu.onClickItem.Add(new EventCallback0(OnClickTypeMenuItem));
		((GObject)ConfirmSaveBtn).onClick.Add(new EventCallback0(OnClickConfirmSaveBtn));
		((GObject)LoadedInfo).onClick.Add(new EventCallback1(OnClickLoadedInfo));
		((GObject)FilterBtn).onClick.Add(new EventCallback0(OnShowDetailFilter));
		((GObject)FilterDialogBack).onClick.Add(new EventCallback0(OnCloseDetailFilter));
		FilterDialog.RegisterUiEventListeners();
		UI_com_AmplifierFilterDialog filterDialog = FilterDialog;
		filterDialog.OnFilterChange = (Action)Delegate.Combine(filterDialog.OnFilterChange, new Action(OnChangeDetailFilter));
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)BackBtn).onClick.Clear();
		((GObject)OneClickUnload).onClick.Clear();
		((GObject)OneClickEquip).onClick.Clear();
		((GObject)SelectedShip).onClick.Clear();
		((GObject)ShipDropDownMenuBack).onClick.Clear();
		ShipDropDownMenu.ShipList.onClickItem.Clear();
		TypeMenu.onClickItem.Clear();
		((GObject)ConfirmSaveBtn).onClick.Clear();
		((GObject)LoadedInfo).onClick.Clear();
		((GObject)FilterBtn).onClick.Clear();
		((GObject)FilterDialogBack).onClick.Clear();
		FilterDialog.UnregisterUiEventListeners();
		UI_com_AmplifierFilterDialog filterDialog = FilterDialog;
		filterDialog.OnFilterChange = (Action)Delegate.Remove(filterDialog.OnFilterChange, new Action(OnChangeDetailFilter));
	}

	private void OnClickLoadedInfo(EventContext context)
	{
		Dictionary<int, int> dictionary = new Dictionary<int, int>();
		foreach (KeyValuePair<int, int> storageChange in StorageChanges)
		{
			if (storageChange.Value != 0)
			{
				dictionary.Add(storageChange.Key, -storageChange.Value);
			}
		}
		GvGAmplifierOnShipModel.UIShipAmpsInfoModel uIShipAmpsInfoModel = Data.ShipAmpsInfo_List[CurSelectedShipIndex];
		Dictionary<int, int> loadedAmps = Singleton<GvGAmplifierManager>.Instance.PreviewShipAmpChanges(uIShipAmpsInfoModel.ShipId, dictionary);
		ShowSingleSummaryDialog(loadedAmps);
	}

	private void OnClickConfirmSaveBtn()
	{
		if (IsEdited)
		{
			Save(delegate
			{
				SelectShip(CurSelectedShipIndex);
			});
		}
	}

	private void OnClickShipMenuItem()
	{
		int newSelectedIndex = ShipDropDownMenu.ShipList.selectedIndex;
		if (CurSelectedShipIndex == newSelectedIndex)
		{
			return;
		}
		if (IsEdited)
		{
			ShowConfirmChangePopup(delegate
			{
				Save(delegate
				{
					SelectShip(newSelectedIndex);
				});
			}, delegate
			{
				SelectShip(newSelectedIndex);
			});
		}
		else
		{
			SelectShip(newSelectedIndex);
		}
	}

	private void OnClickTypeMenuItem()
	{
		eAmplifierType selectedIndex = (eAmplifierType)((UI_TypeTab)(object)((GComponent)TypeMenu).GetChildAt(TypeMenu.selectedIndex)).Type.selectedIndex;
		if (CurSelectedType != selectedIndex)
		{
			SelectType(selectedIndex);
		}
	}

	private void OnChangeDetailFilter()
	{
		if (ShipAmpsType_Dict != null)
		{
			SelectDetail();
		}
	}

	private void OnClickBackBtn()
	{
		if (IsEdited)
		{
			ShowConfirmChangePopup(delegate
			{
				Save(delegate
				{
					End();
				});
			}, delegate
			{
				End();
			});
		}
		else
		{
			End();
		}
	}

	private void OnShowDropDownMenu()
	{
		IsShowDropDown.selectedIndex = 1;
	}

	private void OnCloseDropDownMenu()
	{
		IsShowDropDown.selectedIndex = 0;
	}

	private void OnShowDetailFilter()
	{
		IsShowFilterDialog.selectedIndex = 1;
	}

	private void OnCloseDetailFilter()
	{
		IsShowFilterDialog.selectedIndex = 0;
	}

	private void OnLoadAmplifier(AmplifierModel data)
	{
		if (GetTotalLoadedCount() == Data.AmplifierCountLimit)
		{
			ShowMaxAmpLoadedTip();
			return;
		}
		LoadSingleAmplifier(data);
		UpdateAmplifierChanges();
	}

	private void OnUnloadAmplifier(AmplifierModel data, int index)
	{
		UnloadSingleAmplifier(index);
		UpdateAmplifierChanges();
	}

	private void OnAutoLoadSelectedType()
	{
		int i = GetTotalLoadedCount();
		foreach (AmplifierModel recommendAmp in RecommendAmps)
		{
			for (; i < Data.AmplifierCountLimit; i++)
			{
				if (!LoadSingleAmplifier(recommendAmp))
				{
					break;
				}
			}
		}
		UpdateAmplifierChanges();
	}

	private void OnAutoUnloadSelectedType()
	{
		for (int num = ShipAmpsFilteredByType.Count - 1; num >= 0; num--)
		{
			UnloadSingleAmplifier(num);
		}
		UpdateAmplifierChanges();
	}

	private void ShowSingleSummaryDialog(Dictionary<int, int> loadedAmps)
	{
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Expected O, but got Unknown
		IsShowSummary.selectedIndex = 1;
		SummaryDialog.Type.selectedIndex = 0;
		ShipAmpSummaryModel summaryData = ShipAmpSummaryModel.CreateFromLoadedAmps(loadedAmps);
		RenderShipAmpSummary(SummaryDialog.Summary1, summaryData);
		((GObject)SummaryDialogMask).onClick.Set((EventCallback0)delegate
		{
			((GObject)SummaryDialogMask).onClick.Clear();
			IsShowSummary.selectedIndex = 0;
		});
	}

	private void ShowCompareSummaryDialog(Dictionary<int, int> loadedAmps1, Dictionary<int, int> loadedAmps2, Action onConfirmInfo)
	{
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Expected O, but got Unknown
		IsShowSummary.selectedIndex = 1;
		SummaryDialog.Type.selectedIndex = 1;
		ShipAmpSummaryModel shipAmpSummaryModel = ShipAmpSummaryModel.CreateFromLoadedAmps(loadedAmps1);
		ShipAmpSummaryModel shipAmpSummaryModel2 = ShipAmpSummaryModel.CreateFromLoadedAmps(loadedAmps2);
		shipAmpSummaryModel2.DiffWith(shipAmpSummaryModel);
		RenderShipAmpSummary(SummaryDialog.Summary1, shipAmpSummaryModel);
		RenderShipAmpSummary(SummaryDialog.Summary2, shipAmpSummaryModel2);
		((GObject)SummaryDialog.ConfirmBtn).onClick.Set((EventCallback0)delegate
		{
			((GObject)SummaryDialog.ConfirmBtn).onClick.Clear();
			IsShowSummary.selectedIndex = 0;
			onConfirmInfo?.Invoke();
		});
	}

	private void RenderShipAmpSummary(UI_com_ShipAmpSummary comp, ShipAmpSummaryModel summaryData)
	{
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Expected O, but got Unknown
		RenderSelectedShipInfo(comp.SelectedShip);
		((GObject)comp.AmpScore).text = $"{summaryData.TotalScore}";
		((GObject)comp.AmpCount).text = $"{summaryData.TotalAmpCount}";
		((GObject)comp.AmpCountLimit).text = $"/{Data.AmplifierCountLimit}";
		comp.TotalPropList.SetVirtual();
		comp.TotalPropList.itemRenderer = (ListItemRenderer)delegate(int i, GObject o)
		{
			TotalPropsItemRenderer(i, (UI_PropItemLong)(object)o, summaryData.TotalPropList);
		};
		comp.TotalPropList.numItems = summaryData.TotalPropList.Count;
	}

	private void TotalPropsItemRenderer(int index, UI_PropItemLong item, List<ShipAmpSummaryModel.TotalPropModel2> propList)
	{
		//IL_0111: Unknown result type (might be due to invalid IL or missing references)
		//IL_011b: Expected O, but got Unknown
		ShipAmpSummaryModel.TotalPropModel2 totalPropModel = propList[index];
		((GObject)item.EffectRange).text = totalPropModel.EffectRange;
		item.State.selectedIndex = (int)totalPropModel.State;
		if (totalPropModel.PropName.Contains("{"))
		{
			((GObject)item.PropName).text = string.Format(totalPropModel.PropName, totalPropModel.DescValue);
			((GObject)item.PropEffect).text = "";
		}
		else
		{
			((GObject)item.PropName).text = totalPropModel.PropName;
			((GObject)item.PropEffect).text = totalPropModel.DescValue ?? "";
		}
		item.HasTip.selectedIndex = ((totalPropModel.DescType == ePropType.DRSum) ? 1 : 0);
		if (totalPropModel.DescType == ePropType.DRSum)
		{
			((GObject)item).onClick.Set((EventCallback0)delegate
			{
				OnClickDRSumProps(item);
			});
		}
	}

	private void OnClickDRSumProps(UI_PropItemLong item)
	{
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		FairyGUITip.ShowTip((GObject)(object)item, eFairyGUITipDir.Up, delegate(UI_com_UniversalPopupTip popup)
		{
			((GObject)popup.title).text = "GVGAmplifierDRSumPropTips".ToLanguage();
		});
	}

	private void UpdateTypeMenu()
	{
		for (int i = 0; i < TypeMenu.numItems; i++)
		{
			UI_TypeTab uI_TypeTab = (UI_TypeTab)(object)((GComponent)TypeMenu).GetChildAt(i);
			eAmplifierType selectedIndex = (eAmplifierType)uI_TypeTab.Type.selectedIndex;
			int count = ShipAmpsType_Dict[selectedIndex].Count;
			((GObject)uI_TypeTab.Count).text = count.ToString();
		}
	}

	private void RenderShipDropDownMenu()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		ShipDropDownMenu.ShipList.itemRenderer = (ListItemRenderer)delegate(int i, GObject o)
		{
			RenderShipSlot(i, (UI_ShipSlot)(object)o);
		};
		ShipDropDownMenu.ShipList.numItems = Data.ShipAmpsInfo_List.Count;
		ShipDropDownMenu.ShipList.ResizeToFit(Data.ShipAmpsInfo_List.Count);
	}

	private void RenderShipSlot(int i, UI_ShipSlot shipSlot)
	{
		GvGAmplifierOnShipModel.UIShipAmpsInfoModel uIShipAmpsInfoModel = Data.ShipAmpsInfo_List[i];
		((GObject)shipSlot.ShipIndex).text = uIShipAmpsInfoModel.Index.ToString();
		((GObject)shipSlot.ShipName).text = uIShipAmpsInfoModel.ShipName;
		RenderHelper_RaceTypeIcon.RenderShipRaceType((GComponent)(object)shipSlot.RaceType, uIShipAmpsInfoModel.Race);
	}

	private void UpdateLoadedInfo()
	{
		int num = 0;
		foreach (List<AmplifierModel> value in ShipAmpsType_Dict.Values)
		{
			foreach (AmplifierModel item in value)
			{
				num += item.Score;
			}
		}
		((GObject)LoadedInfo.LoadedCount).text = $"{GetTotalLoadedCount()}/{Data.AmplifierCountLimit}";
		((GObject)LoadedInfo.LoadedScore).text = $"{num}";
	}

	private void UpdateLoadedList()
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Expected O, but got Unknown
		LoadedList.SetVirtual();
		LoadedList.itemRenderer = (ListItemRenderer)delegate(int i, GObject o)
		{
			RenderLoadedItem(i, (UI_AmplifierStotBar)(object)o);
		};
		LoadedList.numItems = ShipAmpsFilteredByType.Count;
		IsListEmpty.selectedIndex = ((LoadedList.numItems == 0) ? 1 : 0);
	}

	private void RenderLoadedItem(int i, UI_AmplifierStotBar slotBar)
	{
		//IL_017a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0184: Expected O, but got Unknown
		AmplifierModel data = ShipAmpsFilteredByType[i];
		int num = NewLoadedCount_Dict[CurSelectedType];
		slotBar.IsNewAdded.selectedIndex = ((i < num) ? 1 : 0);
		RenderHelper_AmplifierIcon.RenderAmplifier(slotBar.AmplifierIcon, data);
		((GObject)slotBar.AmpName).text = data.Name;
		slotBar.Quality.selectedIndex = data.Quality;
		((GObject)slotBar.Property).text = "";
		foreach (KeyValuePair<string, float> item in data.Desc)
		{
			GTextField property = slotBar.Property;
			((GObject)property).text = ((GObject)property).text + string.Format(item.Key, item.Value) + "\n";
		}
		bool flag = string.IsNullOrEmpty(data.AffectedSoldier);
		slotBar.IsShowRace.selectedIndex = (flag ? 1 : 0);
		if (flag)
		{
			RenderHelper_RaceTypeIcon.RenderAmplifierAffectedRace(slotBar.RaceType, data);
		}
		else
		{
			RenderHelper_SimpleSolierIcon.RenderAmplifierAffectedSoldier(slotBar.AffectedSoldier, data);
		}
		((GObject)slotBar.UnloadBtn).onClick.Set((EventCallback0)delegate
		{
			OnUnloadAmplifier(data, i);
		});
	}

	private void UpdateStorageList()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Expected O, but got Unknown
		AmpListContent.RecommendList.itemRenderer = (ListItemRenderer)delegate(int i, GObject o)
		{
			RenderAmplifierSlot(i, (UI_AmplifierSlot)(object)o, RecommendAmps);
		};
		AmpListContent.RecommendList.numItems = RecommendAmps.Count;
		AmpListContent.RecommendList.ResizeToFit(RecommendAmps.Count);
		AmpListContent.OthersList.itemRenderer = (ListItemRenderer)delegate(int i, GObject o)
		{
			RenderAmplifierSlot(i, (UI_AmplifierSlot)(object)o, OthersAmps);
		};
		AmpListContent.OthersList.numItems = OthersAmps.Count;
		AmpListContent.OthersList.ResizeToFit(OthersAmps.Count);
		bool flag = RecommendAmps.Count == 0 && OthersAmps.Count == 0;
		IsAmpListContentEmpty.SetSelectedIndex(flag ? 1 : 0);
		CanSave.selectedIndex = (IsEdited ? 1 : 0);
	}

	private void RenderAmplifierSlot(int i, UI_AmplifierSlot slot, List<AmplifierModel> dataList)
	{
		//IL_0154: Unknown result type (might be due to invalid IL or missing references)
		//IL_015e: Expected O, but got Unknown
		AmplifierModel amp = dataList[i];
		RenderHelper_AmplifierIcon.RenderAmplifier(slot.AmplifierIcon, amp);
		RenderHelper_AmpAffectedRange.RenderAmplifierAffectedRange(slot.AffectedRange, amp);
		if (StorageChanges.TryGetValue(amp.Idx, out var value) && value != 0)
		{
			string text = ((value > 0) ? $"[color=#1f8c15](+{value})[/color]" : $"[color=#bf1d1d]({value})[/color]");
			if (GetStorageAmpCount(amp.Idx) > 0)
			{
				((GObject)slot.Count).text = $"{Data.StorageAmpsCount_Dict[amp.Idx]}{text}";
			}
			else
			{
				((GObject)slot.Count).text = text ?? "";
			}
			slot.IsNewSelected.selectedIndex = 1;
		}
		else
		{
			((GObject)slot.Count).text = Data.StorageAmpsCount_Dict[amp.Idx].ToString();
			slot.IsNewSelected.selectedIndex = 0;
		}
		((GObject)slot).onClick.Set((EventCallback0)delegate
		{
			OnLoadAmplifier(amp);
		});
	}

	private void UpdateAmplifierChanges()
	{
		UpdateLoadedList();
		UpdateTypeMenu();
		UpdateLoadedInfo();
		SelectDetail();
	}

	private void RenderSelectedShipInfo(UI_btn_SelectedShip comp)
	{
		if (CurSelectedShipIndex < 0 || Data.ShipAmpsInfo_List.Count <= CurSelectedShipIndex)
		{
			ILRuntimeDebug.LogError($"[UI_GvGAmplifierOnShipPanel]In UpdateSelectedShipInfo, SelectedShipIndex:{CurSelectedShipIndex}, ShipAmpsInfo_List is null:{Data.ShipAmpsInfo_List == null}");
			return;
		}
		GvGAmplifierOnShipModel.UIShipAmpsInfoModel uIShipAmpsInfoModel = Data.ShipAmpsInfo_List[CurSelectedShipIndex];
		((GObject)comp.ShipIndex).text = uIShipAmpsInfoModel.Index.ToString();
		((GObject)comp.ShipName).text = uIShipAmpsInfoModel.ShipName;
		RenderHelper_RaceTypeIcon.RenderShipRaceType((GComponent)(object)comp.RaceType, uIShipAmpsInfoModel.Race);
	}

	private void ShowMaxAmpLoadedTip()
	{
		List<string> arg = new List<string> { "GVG_MAX_AMP_LOADED_TIPS".ToLanguage() };
		SharedMessenger.Broadcast("SHOW_TIPS", arg, ((GObject)this).sortingOrder, arg3: false);
	}

	private void SelectShip(int shipIndex)
	{
		CurSelectedShipIndex = shipIndex;
		RenderSelectedShipInfo(SelectedShip);
		Data.GetShipData(Data.ShipAmpsInfo_List[CurSelectedShipIndex].ShipId, delegate(string shipId)
		{
			if (!(Data.ShipAmpsInfo_List[CurSelectedShipIndex].ShipId != shipId))
			{
				DoChangeShip();
				UpdateTypeMenu();
				UpdateLoadedInfo();
				SelectType(CurSelectedType);
				OnCloseDropDownMenu();
			}
		});
	}

	private void SelectType(eAmplifierType type)
	{
		CurSelectedType = type;
		if (ShipAmpsType_Dict != null)
		{
			DoTypeFilter();
			UpdateLoadedList();
			FilterDialog.IsShowPropFilter = CurSelectedType == eAmplifierType.Perks;
			SelectDetail();
		}
	}

	private void SelectDetail()
	{
		DoDetailFilter();
		UpdateStorageList();
	}

	private void DoChangeShip()
	{
		GvGAmplifierOnShipModel.UIShipAmpsInfoModel uIShipAmpsInfoModel = Data.ShipAmpsInfo_List[CurSelectedShipIndex];
		StorageAmpsConfig_List = new List<AmplifierModel>(Data.StorageAmpsConfig_List);
		ShipAmpsType_Dict = new Dictionary<eAmplifierType, List<AmplifierModel>>();
		for (int i = 0; i < TypeMenu.numItems; i++)
		{
			UI_TypeTab uI_TypeTab = (UI_TypeTab)(object)((GComponent)TypeMenu).GetChildAt(i);
			eAmplifierType selectedIndex = (eAmplifierType)uI_TypeTab.Type.selectedIndex;
			List<AmplifierModel> list = AmpConfigHelper.FilterAmplifiersByType(uIShipAmpsInfoModel.AmplifiersConfig_List, selectedIndex);
			List<AmplifierModel> list2 = new List<AmplifierModel>();
			foreach (AmplifierModel item in list)
			{
				int num = uIShipAmpsInfoModel.AmplifiersCount_Dict[item.Idx];
				for (int j = 0; j < num; j++)
				{
					list2.Add(item);
				}
			}
			ShipAmpsType_Dict.Add(selectedIndex, list2);
		}
		ClearChanges();
	}

	private void DoTypeFilter()
	{
		ShipAmpsFilteredByType = ShipAmpsType_Dict[CurSelectedType];
		StorageAmpsFilteredByType = AmpConfigHelper.FilterAmplifiersByType(StorageAmpsConfig_List, CurSelectedType);
	}

	private void DoDetailFilter()
	{
		List<AmplifierModel> list = AmpConfigHelper.FilterAmplifiers(StorageAmpsFilteredByType, FilterDialog.SelectedQuality, FilterDialog.SelectedRace, FilterDialog.SelectedSoldierId, FilterDialog.SelectedModifier);
		RecommendAmps = AmpConfigHelper.FilterAmplifiersBySoldierIds(list, Data.ShipAmpsInfo_List[CurSelectedShipIndex].Soldiers, out var others);
		RecommendAmps.Sort((AmplifierModel a, AmplifierModel b) => a.Score.CompareTo(b.Score));
		OthersAmps = others;
	}

	private bool UnloadSingleAmplifier(int index)
	{
		if (index < 0 || ShipAmpsFilteredByType.Count < index)
		{
			return false;
		}
		AmplifierModel amplifierModel = ShipAmpsFilteredByType[index];
		if (StorageChanges.ContainsKey(amplifierModel.Idx))
		{
			StorageChanges[amplifierModel.Idx]++;
		}
		else
		{
			StorageChanges.Add(amplifierModel.Idx, 1);
			if (GetStorageAmpCount(amplifierModel.Idx) == 0)
			{
				StorageAmpsConfig_List.Add(amplifierModel);
				StorageAmpsFilteredByType.Add(amplifierModel);
			}
		}
		if (index < NewLoadedCount_Dict[CurSelectedType])
		{
			NewLoadedCount_Dict[CurSelectedType]--;
		}
		ShipAmpsFilteredByType.RemoveAt(index);
		return true;
	}

	private bool LoadSingleAmplifier(AmplifierModel data)
	{
		if (StorageChanges.ContainsKey(data.Idx))
		{
			StorageChanges[data.Idx]--;
		}
		else
		{
			StorageChanges.Add(data.Idx, -1);
		}
		int storageAmpCount = GetStorageAmpCount(data.Idx);
		if (storageAmpCount == 0 && StorageChanges[data.Idx] < 0)
		{
			StorageChanges.Remove(data.Idx);
			StorageAmpsConfig_List.Remove(data);
			StorageAmpsFilteredByType.Remove(data);
			return false;
		}
		if (storageAmpCount + StorageChanges[data.Idx] < 0)
		{
			StorageChanges[data.Idx] = -storageAmpCount;
			return false;
		}
		if (StorageChanges[data.Idx] == 0 && storageAmpCount == 0)
		{
			StorageChanges.Remove(data.Idx);
			StorageAmpsConfig_List.Remove(data);
			StorageAmpsFilteredByType.Remove(data);
		}
		if (StorageChanges.ContainsKey(data.Idx) && StorageChanges[data.Idx] < 0)
		{
			NewLoadedCount_Dict[CurSelectedType]++;
			ShipAmpsFilteredByType.Insert(0, data);
		}
		else
		{
			ShipAmpsFilteredByType.Insert(NewLoadedCount_Dict[CurSelectedType], data);
		}
		return true;
	}

	private int GetStorageAmpCount(int idx)
	{
		if (!Data.StorageAmpsCount_Dict.TryGetValue(idx, out var value))
		{
			return 0;
		}
		return value;
	}

	private int GetTotalLoadedCount()
	{
		int num = 0;
		foreach (List<AmplifierModel> value in ShipAmpsType_Dict.Values)
		{
			num += value.Count;
		}
		return num;
	}

	private void Save(Action onFinished = null)
	{
		GvGAmplifierOnShipModel.UIShipAmpsInfoModel shipAmpInfo = Data.ShipAmpsInfo_List[CurSelectedShipIndex];
		string shipId = shipAmpInfo.ShipId;
		Dictionary<int, int> dictionary = new Dictionary<int, int>();
		foreach (KeyValuePair<int, int> storageChange in StorageChanges)
		{
			if (storageChange.Value != 0)
			{
				dictionary.Add(storageChange.Key, -storageChange.Value);
			}
		}
		Dictionary<int, int> oldLoadedAmp = new Dictionary<int, int>(shipAmpInfo.AmplifiersCount_Dict);
		Data.ChangeShipAmplifiers(shipId, dictionary, delegate
		{
			Dictionary<int, int> loadedAmps = new Dictionary<int, int>(shipAmpInfo.AmplifiersCount_Dict);
			ShowCompareSummaryDialog(oldLoadedAmp, loadedAmps, delegate
			{
				onFinished?.Invoke();
			});
		});
	}

	private void ClearChanges()
	{
		StorageChanges.Clear();
		List<eAmplifierType> list = new List<eAmplifierType>(NewLoadedCount_Dict.Keys);
		foreach (eAmplifierType item in list)
		{
			NewLoadedCount_Dict[item] = 0;
		}
	}

	public void ShowConfirmChangePopup(Action onConfirm, Action onCancel)
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_UniversalConfirmPopup.Name, new Dictionary<string, object>
		{
			{
				"TipTextAlign",
				(object)(AlignType)1
			},
			{
				"Content",
				"GvGAmplifierOnShip_ConfirmSavePopup".ToLanguage()
			},
			{
				"Buttons",
				new Dictionary<string, Action>
				{
					{ "Confirm", onConfirm },
					{ "Cancel", onCancel }
				}
			},
			{ "PageIndex", 0 },
			{ "FontSize", 44 },
			{
				"Order",
				((GObject)this).sortingOrder + 1
			}
		});
	}

	public int FindShipIndex(string shipId)
	{
		return Data.ShipAmpsInfo_List.FindIndex((GvGAmplifierOnShipModel.UIShipAmpsInfoModel ship) => ship.ShipId == shipId);
	}

	public void OnShow()
	{
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
		OnClose?.Invoke();
	}

	public void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
	}
}
