using System;
using System.Collections.Generic;
using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;
using GameMaths;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Interface;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Model;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Services;
using UI.GvGAmplifierOnShip;
using UI.PublicResources;

namespace UI.GvGShipDetail;

public class UI_AmplifierPage : GComponent, IGvGShipDetailPage
{
	public Controller IsTotalPropListEmpty;

	public GImage n70;

	public GImage n86;

	public UI_TwoGearsRotation n94;

	public UI_TwoGearsRotation n96;

	public GImage n93;

	public GImage n88;

	public GImage n90;

	public GImage n91;

	public GImage n89;

	public GImage n87;

	public UI_com_LoadedAmplifier LoadedType1;

	public UI_com_LoadedAmplifier LoadedType2;

	public UI_com_LoadedAmplifier LoadedType3;

	public GImage n97;

	public GList TotalPropList;

	public GImage n105;

	public GTextField TotalCount;

	public GTextField n77;

	public UI_btn_EquipAmplifiersBtn EquipAmplifiersBtn;

	public GTextField n92;

	public GTextField n98;

	public GImage n100;

	public GTextField n99;

	public GButton ExtraAmplifierCountLimitBtn;

	public GImage n102;

	public GTextField n103;

	public GTextField ampScore;

	public const string URL = "ui://u6x0b1gnzpu41o";

	public static string Name = "UI_AmplifierPage";

	private GvGShipDetailModel Data;

	private UI_GvGShipDetailPanel ParentPanel;

	private bool IsInitRendered;

	private Dictionary<eAmplifierType, UI_com_LoadedAmplifier> LoadedAmpComps;

	private Dictionary<eAmplifierType, List<int>> LoadedAmpData;

	private List<TotalPropModel> TotalPropData;

	public int PageIndex { get; set; }

	public bool PageActivated { get; set; }

	public static string GetURL()
	{
		return "ui://u6x0b1gnzpu41o";
	}

	public static UI_AmplifierPage CreateInstance()
	{
		return (UI_AmplifierPage)(object)UIPackage.CreateObject("GvGShipDetail", "AmplifierPage");
	}

	public static UI_AmplifierPage CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_AmplifierPage).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://u6x0b1gnzpu41o", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
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
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		//IL_014e: Expected O, but got Unknown
		//IL_015a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0164: Expected O, but got Unknown
		//IL_0170: Unknown result type (might be due to invalid IL or missing references)
		//IL_017a: Expected O, but got Unknown
		//IL_0186: Unknown result type (might be due to invalid IL or missing references)
		//IL_0190: Expected O, but got Unknown
		//IL_019c: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a6: Expected O, but got Unknown
		//IL_0205: Unknown result type (might be due to invalid IL or missing references)
		//IL_020f: Expected O, but got Unknown
		//IL_0258: Unknown result type (might be due to invalid IL or missing references)
		//IL_0262: Expected O, but got Unknown
		//IL_02ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b5: Expected O, but got Unknown
		//IL_02c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cb: Expected O, but got Unknown
		//IL_0314: Unknown result type (might be due to invalid IL or missing references)
		//IL_031e: Expected O, but got Unknown
		//IL_032a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0334: Expected O, but got Unknown
		//IL_0340: Unknown result type (might be due to invalid IL or missing references)
		//IL_034a: Expected O, but got Unknown
		//IL_0395: Unknown result type (might be due to invalid IL or missing references)
		//IL_039f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		IsTotalPropListEmpty = ((GComponent)this).GetController("IsTotalPropListEmpty");
		n70 = (GImage)((GComponent)this).GetChild("n70");
		n86 = (GImage)((GComponent)this).GetChild("n86");
		n94 = (UI_TwoGearsRotation)(object)((GComponent)this).GetChild("n94");
		n96 = (UI_TwoGearsRotation)(object)((GComponent)this).GetChild("n96");
		n93 = (GImage)((GComponent)this).GetChild("n93");
		n88 = (GImage)((GComponent)this).GetChild("n88");
		n90 = (GImage)((GComponent)this).GetChild("n90");
		n91 = (GImage)((GComponent)this).GetChild("n91");
		n89 = (GImage)((GComponent)this).GetChild("n89");
		n87 = (GImage)((GComponent)this).GetChild("n87");
		LoadedType1 = (UI_com_LoadedAmplifier)(object)((GComponent)this).GetChild("LoadedType1");
		LoadedType2 = (UI_com_LoadedAmplifier)(object)((GComponent)this).GetChild("LoadedType2");
		LoadedType3 = (UI_com_LoadedAmplifier)(object)((GComponent)this).GetChild("LoadedType3");
		n97 = (GImage)((GComponent)this).GetChild("n97");
		TotalPropList = (GList)((GComponent)this).GetChild("TotalPropList");
		n105 = (GImage)((GComponent)this).GetChild("n105");
		TotalCount = (GTextField)((GComponent)this).GetChild("TotalCount");
		n77 = (GTextField)((GComponent)this).GetChild("n77");
		string id = "ui://u6x0b1gnzpu41o".Replace("ui://", "") + "-" + ((GObject)n77).id;
		((GObject)n77).text = LanguagesManager.GetDesc(id);
		EquipAmplifiersBtn = (UI_btn_EquipAmplifiersBtn)(object)((GComponent)this).GetChild("EquipAmplifiersBtn");
		n92 = (GTextField)((GComponent)this).GetChild("n92");
		string id2 = "ui://u6x0b1gnzpu41o".Replace("ui://", "") + "-" + ((GObject)n92).id;
		((GObject)n92).text = LanguagesManager.GetDesc(id2);
		n98 = (GTextField)((GComponent)this).GetChild("n98");
		string id3 = "ui://u6x0b1gnzpu41o".Replace("ui://", "") + "-" + ((GObject)n98).id;
		((GObject)n98).text = LanguagesManager.GetDesc(id3);
		n100 = (GImage)((GComponent)this).GetChild("n100");
		n99 = (GTextField)((GComponent)this).GetChild("n99");
		string id4 = "ui://u6x0b1gnzpu41o".Replace("ui://", "") + "-" + ((GObject)n99).id;
		((GObject)n99).text = LanguagesManager.GetDesc(id4);
		ExtraAmplifierCountLimitBtn = (GButton)((GComponent)this).GetChild("ExtraAmplifierCountLimitBtn");
		n102 = (GImage)((GComponent)this).GetChild("n102");
		n103 = (GTextField)((GComponent)this).GetChild("n103");
		string id5 = "ui://u6x0b1gnzpu41o".Replace("ui://", "") + "-" + ((GObject)n103).id;
		((GObject)n103).text = LanguagesManager.GetDesc(id5);
		ampScore = (GTextField)((GComponent)this).GetChild("ampScore");
		string id6 = "ui://u6x0b1gnzpu41o".Replace("ui://", "") + "-" + ((GObject)ampScore).id;
		((GObject)ampScore).text = LanguagesManager.GetDesc(id6);
	}

	public void Init(GvGShipDetailModel data, UI_GvGShipDetailPanel parentPanel)
	{
		Data = data;
		ParentPanel = parentPanel;
		IsInitRendered = false;
		LoadedAmpComps = new Dictionary<eAmplifierType, UI_com_LoadedAmplifier>
		{
			{
				eAmplifierType.Attack,
				LoadedType1
			},
			{
				eAmplifierType.Health,
				LoadedType2
			},
			{
				eAmplifierType.Perks,
				LoadedType3
			}
		};
		LoadedAmpData = new Dictionary<eAmplifierType, List<int>>();
		foreach (KeyValuePair<eAmplifierType, UI_com_LoadedAmplifier> loadedAmpComp in LoadedAmpComps)
		{
			LoadedAmpData.Add(loadedAmpComp.Key, new List<int>());
		}
		TotalPropData = new List<TotalPropModel>();
		((GObject)ExtraAmplifierCountLimitBtn).visible = false;
		Singleton<GvGAmplifierManager>.Instance.SyncAmplifierTalentData(delegate
		{
			//IL_0050: Unknown result type (might be due to invalid IL or missing references)
			//IL_0056: Unknown result type (might be due to invalid IL or missing references)
			Data.AmplifierCountLimit = Singleton<GvGAmplifierManager>.Instance.TalentData.AmplifierCountLimit;
			((GObject)ExtraAmplifierCountLimitBtn).visible = Singleton<GvGAmplifierManager>.Instance.TalentData.ExtraAmplifierCountLimit > 0;
			ExtraAmplifierCountLimitBtn.SetPopupTips(Singleton<GvGAmplifierManager>.Instance.TalentData.ExtraAmplifierCountLimit_Tip);
		});
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		((GObject)EquipAmplifiersBtn).onClick.Add(new EventCallback0(OnOpenAmplifierOnShipPanel));
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)EquipAmplifiersBtn).onClick.Clear();
	}

	public void OnActivate()
	{
		PageActivated = true;
		if (!IsInitRendered)
		{
			IsInitRendered = true;
			InitVirtualLists();
			Data.GetShipData(delegate
			{
				Update();
			});
		}
	}

	public void OnInactivate()
	{
		PageActivated = false;
	}

	public void OnDestroy()
	{
	}

	private void OnOpenAmplifierOnShipPanel()
	{
		if (EquipAmplifiersBtn.Enable.selectedIndex == 1)
		{
			ShowUnableToLoadAmplifierTips();
			return;
		}
		Singleton<WorldStateManager>.Instance.GetIslandsState(new List<int> { Data.StayIslandId }, delegate
		{
			int campId = Singleton<WorldStateManager>.Instance.TryGetIsland(Data.StayIslandId).CampId;
			if (campId != Singleton<WorldStateManager>.Instance.Data.MyCampId)
			{
				EquipAmplifiersBtn.Enable.SetSelectedIndex(1);
				ShowUnableToLoadAmplifierTips();
			}
			else
			{
				OpenGvGAmplifier();
			}
		});
		void OpenGvGAmplifier()
		{
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_GvGAmplifierOnShipPanel.Name, new Dictionary<string, object>
			{
				{ "ShipId", Data.ShipId },
				{
					"OnClose",
					new UICallbackParam<Action>(delegate
					{
						Data.GetShipData(delegate
						{
							Update();
						});
					})
				}
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

	private void OnClickEvasionRate(UI_PropItemLong item)
	{
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		FairyGUITip.ShowTip((GObject)(object)item, eFairyGUITipDir.Up, delegate(UI_com_UniversalPopupTip popup)
		{
			((GObject)popup.title).text = "GVGAmplifierEvasionRatePropTips".ToLanguage();
		});
	}

	private void ShowUnableToLoadAmplifierTips()
	{
		List<string> arg = new List<string> { "GvGAmpReplaceTip".ToLanguage() };
		SharedMessenger.Broadcast("SHOW_TIPS", arg, 1, arg3: false);
	}

	private void UpdateTotalPropList()
	{
		Dictionary<int, int> amplifiers = Data.Amplifiers;
		Dictionary<string, TotalPropModel> dictionary = new Dictionary<string, TotalPropModel>();
		foreach (KeyValuePair<int, int> item in amplifiers)
		{
			int key = item.Key;
			int value = item.Value;
			AmplifierModel amplifierModel = AmpConfigHelper.Configs.TryGetNormalAmplifier(key);
			foreach (KeyValuePair<string, float> item2 in amplifierModel.Desc)
			{
				string effectRangeDesc = amplifierModel.EffectRangeDesc;
				string key2 = item2.Key;
				ePropType ePropType = amplifierModel.DescType[item2.Key];
				string propKey = amplifierModel.Desc2PropsKey[item2.Key];
				string key3 = effectRangeDesc + "_" + key2;
				if (!dictionary.TryGetValue(key3, out var value2))
				{
					value2 = new TotalPropModel
					{
						Idx = key,
						EffectRange = effectRangeDesc,
						PropName = key2,
						DescType = ePropType,
						PropKey = propKey
					};
					dictionary.Add(key3, value2);
					switch (ePropType)
					{
					case ePropType.Add:
						value2.Value = item2.Value * (float)value;
						break;
					case ePropType.DRSum:
						value2.Value = Mathf.Pow(1f - item2.Value / 100f, (float)value);
						break;
					}
				}
				else
				{
					switch (ePropType)
					{
					case ePropType.Add:
						value2.Value += item2.Value * (float)value;
						break;
					case ePropType.DRSum:
						value2.Value *= Mathf.Pow(1f - item2.Value / 100f, (float)value);
						break;
					}
				}
			}
		}
		TotalPropData.Clear();
		foreach (KeyValuePair<string, TotalPropModel> item3 in dictionary)
		{
			TotalPropData.Add(item3.Value);
		}
		TotalPropList.numItems = TotalPropData.Count;
		IsTotalPropListEmpty.SetSelectedIndex((TotalPropData.Count == 0) ? 1 : 0);
	}

	private void TotalPropsItemRenderer(int index, UI_PropItemLong item)
	{
		//IL_0106: Unknown result type (might be due to invalid IL or missing references)
		//IL_0110: Expected O, but got Unknown
		//IL_014f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0159: Expected O, but got Unknown
		TotalPropModel totalPropModel = TotalPropData[index];
		((GObject)item.EffectRange).text = totalPropModel.EffectRange;
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
		item.HasTip.SetSelectedIndex(0);
		if (totalPropModel.DescType == ePropType.DRSum)
		{
			item.HasTip.SetSelectedIndex(1);
			((GObject)item).onClick.Set((EventCallback0)delegate
			{
				OnClickDRSumProps(item);
			});
		}
		else if (totalPropModel.PropKey.Contains("EA07"))
		{
			item.HasTip.SetSelectedIndex(1);
			((GObject)item).onClick.Set((EventCallback0)delegate
			{
				OnClickEvasionRate(item);
			});
		}
	}

	private void UpdateAmplifierLists()
	{
		Dictionary<int, int> amplifiers = Data.Amplifiers;
		foreach (KeyValuePair<eAmplifierType, List<int>> loadedAmpDatum in LoadedAmpData)
		{
			loadedAmpDatum.Value.Clear();
		}
		foreach (KeyValuePair<int, int> item in amplifiers)
		{
			int key = item.Key;
			int value = item.Value;
			AmplifierModel amplifierModel = AmpConfigHelper.Configs.TryGetNormalAmplifier(key);
			for (int i = 0; i < value; i++)
			{
				LoadedAmpData[amplifierModel.Type].Add(key);
			}
		}
		foreach (KeyValuePair<eAmplifierType, UI_com_LoadedAmplifier> loadedAmpComp in LoadedAmpComps)
		{
			eAmplifierType key2 = loadedAmpComp.Key;
			LoadedAmpComps[key2].List.numItems = LoadedAmpData[key2].Count;
			LoadedAmpComps[key2].IsEmpty.SetSelectedIndex((LoadedAmpData[key2].Count == 0) ? 1 : 0);
			((GObject)LoadedAmpComps[key2].Total).text = $"{LoadedAmpData[key2].Count}";
		}
	}

	private void AmplifierItemRenderer(eAmplifierType type, int index, UI_AmplifierItem item)
	{
		int idx = LoadedAmpData[type][index];
		AmplifierModel amplifierModel = AmpConfigHelper.Configs.TryGetNormalAmplifier(idx);
		RenderHelper_AmplifierIcon.RenderAmplifier(item.AmplifierIcon, amplifierModel);
		bool flag = string.IsNullOrEmpty(amplifierModel.AffectedSoldier);
		item.IsShowRace.selectedIndex = (flag ? 1 : 0);
		if (flag)
		{
			RenderHelper_RaceTypeIcon.RenderAmplifierAffectedRace(item.RaceType, amplifierModel);
		}
		else
		{
			RenderHelper_SimpleSolierIcon.RenderAmplifierAffectedSoldier(item.AffectedSoldier, amplifierModel);
		}
		((GObject)item.EffectRange).text = amplifierModel.EffectRangeDesc;
		item.PropList.RemoveChildrenToPool();
		foreach (KeyValuePair<string, float> item3 in amplifierModel.Desc)
		{
			UI_PropItemShort item2 = (UI_PropItemShort)(object)item.PropList.AddItemFromPool();
			AmplifierPropRenderer(item3, item2);
		}
		item.PropList.ResizeToFit(amplifierModel.Desc.Count);
	}

	private void AmplifierPropRenderer(KeyValuePair<string, float> prop, UI_PropItemShort item)
	{
		if (prop.Key.Contains("{"))
		{
			((GObject)item.PropName).text = string.Format(prop.Key, prop.Value);
			((GObject)item.PropEffect).text = "";
		}
		else
		{
			((GObject)item.PropName).text = prop.Key;
			((GObject)item.PropEffect).text = $"{prop.Value}";
		}
	}

	private void Update()
	{
		UpdateAmplifierLists();
		UpdateTotalPropList();
		EquipAmplifiersBtn.Enable.SetSelectedIndex((!UpdateEquipAmplifiersEnabled()) ? 1 : 0);
		int num = 0;
		int num2 = 0;
		foreach (KeyValuePair<eAmplifierType, List<int>> loadedAmpDatum in LoadedAmpData)
		{
			num += loadedAmpDatum.Value.Count;
			foreach (int item in loadedAmpDatum.Value)
			{
				AmplifierModel amplifierModel = AmpConfigHelper.Configs.TryGetNormalAmplifier(item);
				num2 += amplifierModel.Score;
			}
		}
		((GObject)TotalCount).text = $"{num}/{Data.AmplifierCountLimit}";
		((GObject)ampScore).text = num2.ToString();
	}

	private void InitVirtualLists()
	{
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Expected O, but got Unknown
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Expected O, but got Unknown
		foreach (KeyValuePair<eAmplifierType, UI_com_LoadedAmplifier> loadedAmpComp in LoadedAmpComps)
		{
			eAmplifierType type = loadedAmpComp.Key;
			UI_com_LoadedAmplifier value = loadedAmpComp.Value;
			value.List.SetVirtual();
			value.List.itemRenderer = (ListItemRenderer)delegate(int index, GObject obj)
			{
				AmplifierItemRenderer(type, index, (UI_AmplifierItem)(object)obj);
			};
		}
		TotalPropList.SetVirtual();
		TotalPropList.itemRenderer = (ListItemRenderer)delegate(int index, GObject obj)
		{
			TotalPropsItemRenderer(index, (UI_PropItemLong)(object)obj);
		};
	}

	private bool UpdateEquipAmplifiersEnabled()
	{
		if (Data.ShipState.State != eShipState.Stay)
		{
			return false;
		}
		if (Data.StayIslandId == Singleton<WorldStateManager>.Instance.Data.OurFlagShipStayIslandId)
		{
			return true;
		}
		eIslandType type = WorldMapConfigHelper.Configs.TryGetIsland(Data.StayIslandId).Props.Type;
		return type == eIslandType.Moon || type == eIslandType.MainMoon;
	}

	public void OnShipStateChange()
	{
	}

	public bool ConfigModified()
	{
		return false;
	}

	public void ConfirmOperationOnChangePage(Action changePage, Action revert)
	{
	}

	public void ConfirmOperationOnClose(Action endAction)
	{
	}
}
