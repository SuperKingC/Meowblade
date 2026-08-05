using System.Collections.Generic;
using System.Linq;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Controller;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Model;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Shift.Legion.GvG.Common.Models.GvGMode3;
using UI.GvGOnIsland3;
using UI.GvGWorldMap3;
using UI.Tips;
using UnityEngine;

namespace UI.GvGIslandBuff;

public class UI_main_IslandBuffPanel : GComponent, IUiController
{
	private enum eMode
	{
		WorlMap,
		OnIsland
	}

	public GGraph back;

	public UI_com_IslandBuffDialog Dialog;

	public Transition t0;

	public const string URL = "ui://zh7jgfijnewqfg";

	public static string Name = "UI_main_IslandBuffPanel";

	private eMode Mode;

	private List<IslandBuff> Buffs;

	private Dictionary<int, List<UIIslandBuff>> CampInBuff_dict;

	private List<UIIslandBuffDetail> IslandOutBuff_list;

	private int MyCampId;

	private int CurIslandId;

	public static string GetURL()
	{
		return "ui://zh7jgfijnewqfg";
	}

	public static UI_main_IslandBuffPanel CreateInstance()
	{
		return (UI_main_IslandBuffPanel)(object)UIPackage.CreateObject("GvGIslandBuff", "main_IslandBuffPanel");
	}

	public static UI_main_IslandBuffPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_IslandBuffPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://zh7jgfijnewqfg", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		back = (GGraph)((GComponent)this).GetChild("back");
		Dialog = (UI_com_IslandBuffDialog)(object)((GComponent)this).GetChild("Dialog");
		t0 = ((GComponent)this).GetTransition("t0");
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		((GObject)back).onClick.Add(new EventCallback0(End));
		((GObject)Dialog.n5).onClick.Add(new EventCallback0(ChangeOtherCamp));
		((GObject)Dialog.n2).onClick.Add(new EventCallback0(ChangeMyrCamp));
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		((GObject)back).onClick.Remove(new EventCallback0(End));
		((GObject)Dialog.n5).onClick.Remove(new EventCallback0(ChangeOtherCamp));
		((GObject)Dialog.n2).onClick.Remove(new EventCallback0(ChangeMyrCamp));
	}

	private void ChangeMyrCamp()
	{
		Dialog.camp.SetSelectedIndex(0);
	}

	private void ChangeOtherCamp()
	{
		Dialog.camp.SetSelectedIndex(1);
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		if (!parameters.TryGetValue("CurIslandId", out var value))
		{
			ILRuntimeDebug.LogError("[UI_main_IslandBuffPanel]: 缺少 CurIslandId 参数");
			End();
			return;
		}
		if (!parameters.TryGetValue("ParentUIName", out var value2))
		{
			ILRuntimeDebug.LogError("[UI_main_IslandBuffPanel]: 缺少 CurIslandId 参数");
			End();
			return;
		}
		string text = value2.ToString();
		if (text == UI_main_GvGWorldMap3.Name)
		{
			Mode = eMode.WorlMap;
		}
		else if (text == UI_main_GvGOnIsland3.Name)
		{
			Mode = eMode.OnIsland;
		}
		CurIslandId = (int)value;
		IslandStateModel islandStateModel = Singleton<WorldStateManager>.Instance.TryGetIsland(CurIslandId);
		List<IslandBuff> buff = islandStateModel.DetailInfo.Buff;
		MyCampId = Singleton<WorldStateManager>.Instance.Data.MyCampId;
		Dictionary<int, FlagShipStateModel>.KeyCollection keys = Singleton<WorldStateManager>.Instance.Data.FlagShips.Keys;
		Dictionary<int, Dictionary<string, UIIslandBuff>> dictionary = new Dictionary<int, Dictionary<string, UIIslandBuff>>();
		foreach (int item in keys)
		{
			dictionary.Add(item, new Dictionary<string, UIIslandBuff>());
		}
		foreach (IslandBuff item2 in buff)
		{
			foreach (int item3 in item2.AffectedCampId)
			{
				if (!dictionary[item3].ContainsKey(item2.Ability.AbilityId))
				{
					dictionary[item3].Add(item2.Ability.AbilityId, new UIIslandBuff(item2, item3));
				}
				else
				{
					dictionary[item3][item2.Ability.AbilityId].Merge(item2);
				}
			}
		}
		CampInBuff_dict = new Dictionary<int, List<UIIslandBuff>>();
		foreach (KeyValuePair<int, Dictionary<string, UIIslandBuff>> item4 in dictionary)
		{
			CampInBuff_dict.Add(item4.Key, item4.Value.Values.ToList());
		}
		Dictionary<int, UIIslandBuffDetail> dictionary2 = new Dictionary<int, UIIslandBuffDetail>();
		foreach (IslandBuff item5 in buff)
		{
			if (item5.AffectedCampIdConfig.Contains(MyCampId))
			{
				int fromIslandId = item5.FromIslandId;
				if (!dictionary2.TryGetValue(fromIslandId, out var value3))
				{
					eIslandType type = WorldMapConfigHelper.Configs.TryGetIsland(fromIslandId).Props.Type;
					value3 = new UIIslandBuffDetail();
					value3.IslandId = fromIslandId;
					value3.IsMyIsland = fromIslandId == CurIslandId;
					value3.OccupyStatus = 0;
					value3.IslandUIType = ((type != eIslandType.Star) ? 1 : 0);
					value3.UIIslandBuffs = new List<UIIslandBuff>();
					value3.IsActiveToMyCamp = item5.AffectedCampId.Contains(MyCampId);
					value3.CheckOccupyStatus(MyCampId);
					dictionary2.Add(fromIslandId, value3);
				}
				value3.UIIslandBuffs.Add(new UIIslandBuff(item5, MyCampId));
			}
		}
		IslandOutBuff_list = dictionary2.Values.ToList();
	}

	public void OnShow()
	{
		RenderMyVampBuff();
		RenderOtherCampBuff();
		RenderMyDetail();
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
	}

	public void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
	}

	private void RenderMyVampBuff()
	{
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		List<UIIslandBuff> data = CampInBuff_dict[MyCampId];
		Dialog.myCampBuff.HasBuff.selectedIndex = ((data.Count != 0) ? 1 : 0);
		Dialog.myCampBuff.BuffList.itemRenderer = (ListItemRenderer)delegate(int index, GObject obj)
		{
			RenderAbility(data[index], obj as UI_com_IslandBuff, showName: true);
		};
		Dialog.myCampBuff.BuffList.numItems = data.Count;
	}

	private void RenderOtherCampBuff()
	{
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Expected O, but got Unknown
		Dialog.otherCampBuffList.RemoveChildrenToPool();
		foreach (KeyValuePair<int, List<UIIslandBuff>> item in CampInBuff_dict)
		{
			int key = item.Key;
			if (key != MyCampId)
			{
				List<UIIslandBuff> data = CampInBuff_dict[key];
				UI_com_IslandBuffListContainer uI_com_IslandBuffListContainer = Dialog.otherCampBuffList.AddItemFromPool() as UI_com_IslandBuffListContainer;
				uI_com_IslandBuffListContainer.HaveBuff.selectedIndex = ((data.Count != 0) ? 1 : 0);
				uI_com_IslandBuffListContainer.Camp.SetSelectedIndex(key);
				uI_com_IslandBuffListContainer.BuffList.itemRenderer = (ListItemRenderer)delegate(int index, GObject obj)
				{
					RenderAbility(data[index], obj as UI_com_IslandBuff, showName: false);
				};
				uI_com_IslandBuffListContainer.BuffList.numItems = data.Count;
			}
		}
	}

	private void RenderMyDetail()
	{
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Expected O, but got Unknown
		//IL_011e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0128: Expected O, but got Unknown
		Dialog.myCampBuff.myDetailList.RemoveChildrenToPool();
		foreach (UIIslandBuffDetail data in IslandOutBuff_list)
		{
			UI_com_BuffListSmall uI_com_BuffListSmall = Dialog.myCampBuff.myDetailList.AddItemFromPool() as UI_com_BuffListSmall;
			uI_com_BuffListSmall.MyIsland.selectedIndex = (data.IsMyIsland ? 1 : 0);
			((GObject)uI_com_BuffListSmall.btn_IslandName.IslandName).text = data.IslandConfigData.Name;
			((GObject)uI_com_BuffListSmall.btn_IslandName).onClick.Set((EventCallback0)delegate
			{
				OnClickIsland(data.IslandId, data.IsMyIsland);
			});
			uI_com_BuffListSmall.Camp.selectedIndex = data.IslandStateModel.CampId;
			uI_com_BuffListSmall.OccupyStatus.selectedIndex = data.OccupyStatus;
			uI_com_BuffListSmall.Type.selectedIndex = data.IslandUIType;
			uI_com_BuffListSmall.HasBuff.selectedIndex = 1;
			uI_com_BuffListSmall.BuffList.itemRenderer = (ListItemRenderer)delegate(int index, GObject obj)
			{
				RenderAbility(data.UIIslandBuffs[index], obj as UI_com_IslandBuff, showName: false);
			};
			uI_com_BuffListSmall.BuffList.numItems = data.UIIslandBuffs.Count;
		}
	}

	private void OnClickIsland(int islandId, bool isCurIsland)
	{
		if (Mode == eMode.WorlMap)
		{
			End();
			GvGWorldMapController.Instance.FocusIslandById(islandId);
		}
		else if (Mode == eMode.OnIsland)
		{
			if (isCurIsland)
			{
				"GvGIslandBuffTip_CurIsland".ToShowLanguageTip();
			}
			else
			{
				"GvGIslandBuffTip_Other".ToShowLanguageTip();
			}
		}
	}

	private void RenderAbility(UIIslandBuff uiIslandBuff, UI_com_IslandBuff com, bool showName)
	{
		//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ff: Expected O, but got Unknown
		com.icon.GetChild("Icon").asLoader.url = "ui://PublicResourcesRGB/" + uiIslandBuff.AbilityData.Icon;
		com.IsDebuff.selectedIndex = (uiIslandBuff.IsDebuff ? 1 : 0);
		((GObject)com.LvNum).text = uiIslandBuff.TotalLevel.ToString();
		((GObject)com.AbName).text = Singleton<AbilityDataManager>.Instance.GetSpecialTagName(uiIslandBuff.AbilityData.Key);
		com.WithBuffName.selectedIndex = (showName ? 1 : 0);
		ItemAbility itemAbility = new ItemAbility
		{
			AbilityId = uiIslandBuff.AbilityData.Key,
			Icon = uiIslandBuff.AbilityData.Icon.ToPublicResourcesRgbIcon()
		};
		itemAbility.SetLevel(uiIslandBuff.TotalLevel);
		((GObject)com.icon).data = itemAbility;
		((GObject)com.icon).onClick.Set(new EventCallback1(OnAbilityItemClick));
	}

	private void OnAbilityItemClick(EventContext context)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Expected O, but got Unknown
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		context.StopPropagation();
		GObject val = (GObject)context.sender;
		if (val.data is ItemAbility itemAbility)
		{
			Vector2 val2 = val.LocalToRoot(Vector2.zero, GRoot.inst);
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_SkillDetailPopup.Name, new Dictionary<string, object>
			{
				{ "Pos", val2 },
				{ "Data", itemAbility.AbilityData },
				{ "Limit", 0 },
				{ "State", true },
				{ "GList", null },
				{ "SkillIconUrl", itemAbility.Icon },
				{ "Level", itemAbility.AbilityLevel }
			});
		}
	}
}
