using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using GameDataEditor;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Model;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Shift.Legion.GvG.Common.Models.GvGMode3;
using UI.Tips;
using UnityEngine;

namespace UI.GvGWorldMap3;

public class UI_main_IslandDefenders : GComponent, IUiController
{
	public class UnitInfo
	{
		public string UnitKey;

		public List<UnitInfo_Protocol> UnitInfos;

		public bool HasBoss => UnitInfos.Any((UnitInfo_Protocol u) => u.IsBossUnit);
	}

	public GGraph back;

	public UI_com_IslandDefenders Dialog;

	public const string URL = "ui://4eq8fgd2mdde2j";

	public static string Name = "UI_main_IslandDefenders";

	private readonly List<int> _phalanxMaxNum = new List<int>();

	private readonly List<int> _currentPhalanxNum = new List<int>();

	private readonly WaitForSeconds _perSecond = new WaitForSeconds(1f);

	private Coroutine _updateCountDownCoroutine;

	private int _renderingUnitsIndex;

	private int _countDownTimestamp;

	private readonly List<UnitInfo> _unitInfos = new List<UnitInfo>();

	private int _islandId;

	private int _npcRebornTimestamp;

	private int _npcRecoveryTimestamp;

	private List<string> _buff;

	private int _obedienceValue;

	private string _countdownText;

	private int CurrentTimestamp => (int)GameController.Instance.GetServerTime();

	private bool NoRecovery => _unitInfos.Any((UnitInfo u) => u.HasBoss) || (IslandState.IslandEvents != null && IslandState.IslandEvents.Count > 0);

	private IslandStateModel IslandState => Singleton<WorldStateManager>.Instance.TryGetIsland(_islandId);

	public static string GetURL()
	{
		return "ui://4eq8fgd2mdde2j";
	}

	public static UI_main_IslandDefenders CreateInstance()
	{
		return (UI_main_IslandDefenders)(object)UIPackage.CreateObject("GvGWorldMap3", "main_IslandDefenders");
	}

	public static UI_main_IslandDefenders CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_IslandDefenders).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2mdde2j", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		back = (GGraph)((GComponent)this).GetChild("back");
		Dialog = (UI_com_IslandDefenders)(object)((GComponent)this).GetChild("Dialog");
	}

	public void BeforeDestroy()
	{
		if (_updateCountDownCoroutine != null)
		{
			FGUIManager.Instance.CloseIEnumerator(_updateCountDownCoroutine);
		}
	}

	public void Destroy()
	{
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		object value;
		List<UnitInfo> collection = (parameters.TryGetValue("UnitInfos", out value) ? (value as List<UnitInfo>) : new List<UnitInfo>());
		_unitInfos.AddRange(collection);
		_islandId = (parameters.TryGetValue("IslandId", out var value2) ? ((int)value2) : 0);
		_npcRebornTimestamp = (parameters.TryGetValue("RebornTimestamp", out var value3) ? ((int)value3) : 0);
		_npcRecoveryTimestamp = (parameters.TryGetValue("RecoveryTimestamp", out var value4) ? ((int)value4) : 0);
		_obedienceValue = (parameters.TryGetValue("ObedienceValue", out var value5) ? ((int)value5) : 0);
		RenderDialog();
	}

	public void OnShow()
	{
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		((GObject)back).onClick.Add(new EventCallback0(ClosePanel));
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		((GObject)back).onClick.Remove(new EventCallback0(ClosePanel));
	}

	public void ClosePanel()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
	}

	private void RenderDialog()
	{
		((GObject)Dialog.Title).text = string.Format("GvGDefendersName".ToLanguage(), new object[1] { WorldMapConfigHelper.Configs.TryGetIsland(_islandId).Name });
		((GObject)Dialog.ObedienceValue).text = $"{_obedienceValue}%";
		if (IslandState.CampId == 0)
		{
			Dialog.Obedience.selectedIndex = 2;
		}
		else
		{
			Dialog.Obedience.selectedIndex = ((_obedienceValue == 0) ? 1 : 0);
		}
		ShowCountDown();
		List<IslandBuff> buffs = IslandState.DetailInfo.Buff.Where((IslandBuff _b) => _b.AffectedCampId.Contains(Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.ObCampId)).ToList();
		RenderAbilities(buffs);
		RenderDefenders();
	}

	private void RenderAbilities(List<IslandBuff> buffs)
	{
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Expected O, but got Unknown
		if (buffs == null || buffs.Count <= 0)
		{
			Dialog.Buff.selectedIndex = 0;
			return;
		}
		Dialog.Buff.selectedIndex = 1;
		Dialog.Abilities.itemRenderer = (ListItemRenderer)delegate(int index, GObject item)
		{
			//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ce: Expected O, but got Unknown
			if (item is UI_com_BossAbility uI_com_BossAbility)
			{
				ItemAbility itemAbility = (ItemAbility)(((GObject)uI_com_BossAbility).data = buffs[index].Ability.ItemAbility);
				((GObject)uI_com_BossAbility.Title).text = Singleton<AbilityDataManager>.Instance.GetSpecialTagName(itemAbility.AbilityData.Key);
				((GObject)uI_com_BossAbility.LvNum).text = $"LV{itemAbility.AbilityLevel}";
				GLoader asLoader = uI_com_BossAbility.icon.GetChild("Icon").asLoader;
				string url = (itemAbility.Icon = itemAbility.AbilityData.Icon.ToPublicResourcesRgbIcon());
				asLoader.url = url;
				((GObject)uI_com_BossAbility).onClick.Set(new EventCallback1(OnAbilityItemClick));
			}
		};
		Dialog.Abilities.numItems = buffs.Count;
	}

	private void OnAbilityItemClick(EventContext context)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Expected O, but got Unknown
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		context.StopPropagation();
		GObject val = (GObject)context.sender;
		if (val.data is ItemAbility itemAbility)
		{
			Vector2 val2 = default(Vector2);
			((Vector2)(ref val2))._002Ector(960f, 680f);
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

	private void RenderDefenders()
	{
		//IL_025b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0265: Expected O, but got Unknown
		long num = 0L;
		_phalanxMaxNum.Clear();
		_currentPhalanxNum.Clear();
		for (int num2 = _unitInfos.Count - 1; num2 >= 0; num2--)
		{
			if (_unitInfos[num2] == null)
			{
				_unitInfos.RemoveAt(num2);
			}
			for (int num3 = _unitInfos[num2].UnitInfos.Count - 1; num3 >= 0; num3--)
			{
				if (_unitInfos[num2].UnitInfos[num3] == null)
				{
					_unitInfos[num2].UnitInfos.RemoveAt(num3);
				}
			}
		}
		foreach (UnitInfo unitInfo in _unitInfos)
		{
			unitInfo.UnitInfos.Sort(UnitInfo_ProtocolSort);
		}
		for (int i = 0; i < _unitInfos.Count; i++)
		{
			int num4 = 0;
			for (int j = 0; j < _unitInfos[i].UnitInfos.Count; j++)
			{
				UnitInfo_Protocol unitInfo_Protocol = _unitInfos[i].UnitInfos[j];
				if (unitInfo_Protocol != null)
				{
					if (j == 0)
					{
						_phalanxMaxNum.Add(unitInfo_Protocol.InitTotal / unitInfo_Protocol.PerTeamMemberCnt);
					}
					num += unitInfo_Protocol.TeamsCombatPower;
					num4 = ((num4 <= 0) ? (unitInfo_Protocol.Total / unitInfo_Protocol.PerTeamMemberCnt) : Mathf.Min(unitInfo_Protocol.Total / unitInfo_Protocol.PerTeamMemberCnt, num4));
				}
			}
			_currentPhalanxNum.Add(num4);
		}
		((GObject)Dialog.AverageCombatPower).text = string.Format("GvGDefendersCombatPower".ToLanguage(), new object[1] { num / _unitInfos.Count });
		Dialog.Soldiers.itemRenderer = new ListItemRenderer(RenderFormation);
		Dialog.Soldiers.numItems = _unitInfos.Count;
	}

	private void RenderFormation(int index, GObject obj)
	{
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		if (!(obj is UI_com_DefenderInfo uI_com_DefenderInfo))
		{
			return;
		}
		UnitInfo unitInfo = _unitInfos[index];
		_renderingUnitsIndex = index;
		((GObject)uI_com_DefenderInfo.Soldiers).data = index;
		uI_com_DefenderInfo.Soldiers.itemProvider = new ListItemProvider(GetFormationItemResource);
		uI_com_DefenderInfo.Soldiers.itemRenderer = new ListItemRenderer(RenderSoldier);
		uI_com_DefenderInfo.Soldiers.numItems = unitInfo.UnitInfos.Count;
		bool flag = IslandState.DetailInfo.IsReNpc(unitInfo.UnitKey);
		uI_com_DefenderInfo.Type.selectedIndex = (flag ? 1 : (unitInfo.HasBoss ? 2 : 0));
		int num = 0;
		for (int i = 0; i < unitInfo.UnitInfos.Count; i++)
		{
			if (unitInfo.UnitInfos[i] != null)
			{
				num += unitInfo.UnitInfos[i].Total;
			}
		}
		((GObject)uI_com_DefenderInfo.CurrentSoldierNum).text = num.ToString();
		((GObject)uI_com_DefenderInfo.FormationNum).text = $"{_currentPhalanxNum[index]}/{_phalanxMaxNum[index]}";
	}

	private void RenderSoldier(int index, GObject obj)
	{
		if (obj is UI_com_TroopsItem btn)
		{
			RenderBossSoldier(btn, index);
		}
		else if (obj is UI_com_TroopsItem1 btn2)
		{
			RenderNpcSoldier(btn2, index);
		}
	}

	private void RenderBossSoldier(UI_com_TroopsItem btn, int index)
	{
		UnitInfo_Protocol unitInfo_Protocol = _unitInfos[(int)((GObject)((GObject)btn).parent).data].UnitInfos[index];
		if (unitInfo_Protocol == null)
		{
			btn.Type.selectedIndex = 0;
			return;
		}
		btn.Type.selectedIndex = 1;
		btn.IconLoader.IconLoader.url = unitInfo_Protocol.Icon;
		int level = unitInfo_Protocol.PotentialLevel;
		GDESoldierData gDESoldierData = GDMgr.Get<GDESoldierData>(unitInfo_Protocol.SoldierId);
		if (gDESoldierData.Tags != null && gDESoldierData.Tags.Contains("WORLD_BOSS"))
		{
			level = 9;
		}
		FGUIManager.Instance.SetAlightSoulStoneForSoldierIcon(btn.SoulStoneLevel, level, new List<int>());
		btn.FrameLoader.url = "ui://PublicResources/" + UiHelper.GetIconFrameBorderSoldier(level);
		UiHelper.LoadSoldierIconFrameMaterial(btn.FrameLoader, level);
		btn.NumEnough.selectedIndex = (unitInfo_Protocol.SoldierNumNotEnough ? 1 : 0);
		((GObject)btn.Amount_t).text = unitInfo_Protocol.Total.ToString();
	}

	private void RenderNpcSoldier(UI_com_TroopsItem1 btn, int index)
	{
		UnitInfo_Protocol unitInfo_Protocol = _unitInfos[(int)((GObject)((GObject)btn).parent).data].UnitInfos[index];
		if (unitInfo_Protocol == null)
		{
			btn.Type.selectedIndex = 0;
			return;
		}
		btn.Type.selectedIndex = 1;
		UI_com_TroopItemContent frameLoader = btn.FrameLoader;
		frameLoader.IconLoader.IconLoader.url = unitInfo_Protocol.Icon;
		FGUIManager.Instance.SetAlightSoulStoneForSoldierIcon(frameLoader.SoulStoneLevel, unitInfo_Protocol.PotentialLevel, new List<int>());
		frameLoader.FrameLoader.url = "ui://PublicResources/" + UiHelper.GetIconFrameBorderSoldier(unitInfo_Protocol.PotentialLevel);
		UiHelper.LoadSoldierIconFrameMaterial(frameLoader.FrameLoader, unitInfo_Protocol.PotentialLevel);
		frameLoader.NumEnough.selectedIndex = (unitInfo_Protocol.SoldierNumNotEnough ? 1 : 0);
		((GObject)frameLoader.Amount_t).text = unitInfo_Protocol.Total.ToString();
	}

	private string GetFormationItemResource(int index)
	{
		return (index == 0) ? "ui://GvGWorldMap3/com_TroopsItem" : "ui://GvGWorldMap3/com_TroopsItem1";
	}

	private int UnitInfo_ProtocolSort(UnitInfo_Protocol a, UnitInfo_Protocol b)
	{
		List<string> tags = GameManagers.Instance.SoldierManager.Get(a.SoldierId).Tags;
		List<string> tags2 = GameManagers.Instance.SoldierManager.Get(b.SoldierId).Tags;
		bool flag = tags.Contains("WORLD_BOSS") || tags.Contains(" IS_BOSS");
		bool flag2 = tags2.Contains("WORLD_BOSS") || tags2.Contains(" IS_BOSS");
		if (flag)
		{
			if (!flag2)
			{
				return -1;
			}
		}
		else if (flag2)
		{
			return 1;
		}
		return 0;
	}

	private IEnumerator UpdateCountDown(Action displayDefault, Action<string> displayCountDown)
	{
		while (_countDownTimestamp - CurrentTimestamp > 0)
		{
			displayCountDown(UiHelper.ParseTime(_countDownTimestamp - CurrentTimestamp));
			yield return _perSecond;
		}
		displayDefault();
	}

	private void ShowCountDown()
	{
		if (_updateCountDownCoroutine != null)
		{
			FGUIManager.Instance.CloseIEnumerator(_updateCountDownCoroutine);
		}
		((GObject)Dialog.ResurrectionCountdown).text = string.Empty;
		_countDownTimestamp = 0;
		if (NoRecovery)
		{
			DisplayNoRecoveryTip();
		}
		else if (_npcRebornTimestamp > CurrentTimestamp)
		{
			DisplayRebornTip();
		}
		else if (_npcRecoveryTimestamp > CurrentTimestamp)
		{
			DisplayRecoveryTip();
		}
	}

	private void DisplayNoRecoveryTip()
	{
		_countDownTimestamp = _npcRebornTimestamp;
		_countdownText = "GvGDefendersNoRecovery".ToLanguage();
		_updateCountDownCoroutine = FGUIManager.Instance.OpenIEnumerator(UpdateCountDown(delegate
		{
			((GObject)Dialog.ResurrectionCountdown).text = HotFix.Sources.Base.Scripts.Helper.StringExtensions.Format(_countdownText, string.Empty);
		}, delegate(string desc)
		{
			((GObject)Dialog.ResurrectionCountdown).text = HotFix.Sources.Base.Scripts.Helper.StringExtensions.Format(_countdownText, " " + desc);
		}));
	}

	private void DisplayRebornTip()
	{
		_countDownTimestamp = _npcRebornTimestamp;
		_countdownText = "GvGDefendersReborn".ToLanguage();
		_updateCountDownCoroutine = FGUIManager.Instance.OpenIEnumerator(UpdateCountDown(delegate
		{
			((GObject)Dialog.ResurrectionCountdown).text = string.Empty;
		}, delegate(string desc)
		{
			((GObject)Dialog.ResurrectionCountdown).text = _countdownText + desc;
		}));
	}

	private void DisplayRecoveryTip()
	{
		_countDownTimestamp = _npcRecoveryTimestamp;
		_countdownText = "GvGDefendersRecovery".ToLanguage();
		_updateCountDownCoroutine = FGUIManager.Instance.OpenIEnumerator(UpdateCountDown(delegate
		{
			((GObject)Dialog.ResurrectionCountdown).text = string.Empty;
		}, delegate(string desc)
		{
			((GObject)Dialog.ResurrectionCountdown).text = _countdownText + desc;
		}));
	}
}
