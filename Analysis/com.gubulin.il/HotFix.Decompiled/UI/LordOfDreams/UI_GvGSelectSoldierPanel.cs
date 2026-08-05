using System;
using System.Collections.Generic;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using GameDataEditor;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Shift.Legion.GvG.Common;
using Shift.Legion.GvGServer.Models.WorldBossSocket;
using UI.EnemyIntroduction;

namespace UI.LordOfDreams;

public class UI_GvGSelectSoldierPanel : GComponent, IUiController
{
	public GLoader background;

	public GGraph _mask;

	public UI_GvGSelectSoldierBack Back;

	public GGraph n47;

	public GImage flashImage1;

	public GTextField OurCombat;

	public GTextField n12;

	public GGroup PowerMine;

	public UI_StandardFormationSketchMap OurFormationSketchMap;

	public UI_EnemyStandardFormationSketchMap EnemyFormationSketchMap;

	public UI_CurFormation CurFormation;

	public GImage n74;

	public GButton exitBtn;

	public UI_MakeWar MakeWar;

	public Transition Disappear;

	public Transition Appear;

	public const string URL = "ui://0i520nzmtlapo6x";

	public static string Name = "UI_GvGSelectSoldierPanel";

	private List<string> SelectedSoldiers;

	private string FId;

	private Dictionary<string, GvGInspectInfo> InspectInfoDict;

	public Action OnStartBattleCallback;

	private UI_SoldierFormation BossSlot;

	public static string GetURL()
	{
		return "ui://0i520nzmtlapo6x";
	}

	public static UI_GvGSelectSoldierPanel CreateInstance()
	{
		return (UI_GvGSelectSoldierPanel)(object)UIPackage.CreateObject("LordOfDreams", "GvGSelectSoldierPanel");
	}

	public static UI_GvGSelectSoldierPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_GvGSelectSoldierPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://0i520nzmtlapo6x", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected O, but got Unknown
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Expected O, but got Unknown
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Expected O, but got Unknown
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		//IL_014e: Expected O, but got Unknown
		//IL_015a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0164: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		background = (GLoader)((GComponent)this).GetChild("background");
		_mask = (GGraph)((GComponent)this).GetChild("_mask");
		Back = (UI_GvGSelectSoldierBack)(object)((GComponent)this).GetChild("Back");
		n47 = (GGraph)((GComponent)this).GetChild("n47");
		flashImage1 = (GImage)((GComponent)this).GetChild("flashImage1");
		OurCombat = (GTextField)((GComponent)this).GetChild("OurCombat");
		n12 = (GTextField)((GComponent)this).GetChild("n12");
		string id = "ui://0i520nzmtlapo6x".Replace("ui://", "") + "-" + ((GObject)n12).id;
		((GObject)n12).text = LanguagesManager.GetDesc(id);
		PowerMine = (GGroup)((GComponent)this).GetChild("PowerMine");
		OurFormationSketchMap = (UI_StandardFormationSketchMap)(object)((GComponent)this).GetChild("OurFormationSketchMap");
		EnemyFormationSketchMap = (UI_EnemyStandardFormationSketchMap)(object)((GComponent)this).GetChild("EnemyFormationSketchMap");
		CurFormation = (UI_CurFormation)(object)((GComponent)this).GetChild("CurFormation");
		n74 = (GImage)((GComponent)this).GetChild("n74");
		exitBtn = (GButton)((GComponent)this).GetChild("exitBtn");
		MakeWar = (UI_MakeWar)(object)((GComponent)this).GetChild("MakeWar");
		Disappear = ((GComponent)this).GetTransition("Disappear");
		Appear = ((GComponent)this).GetTransition("Appear");
	}

	public void Init(Dictionary<string, object> parameters)
	{
		if (parameters.TryGetValue("Actions", out var value))
		{
			Dictionary<string, Action> dictionary = (Dictionary<string, Action>)value;
			if (dictionary.TryGetValue("OnStartBattleCallback", out var value2))
			{
				OnStartBattleCallback = value2;
			}
		}
		BossSlot = null;
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		InspectInfoDict = new Dictionary<string, GvGInspectInfo>();
		RenderOurFormation();
		RenderBossFormation();
	}

	private void RenderSoldierItem(string soldierId, int level, int potentialLevel, UI_soliderItem btn, bool isBoss = false)
	{
		int itemLevel = (potentialLevel + 2) / 2;
		string iconPath = UiHelper.GetIconPath(soldierId, itemLevel);
		btn.icon.url = "ui://PublicResources/" + iconPath;
		((GObject)btn.lv).text = level.ToString();
		((GComponent)btn).GetChild("BossTag").visible = isBoss;
		string iconFrameBorderSoldier = UiHelper.GetIconFrameBorderSoldier(potentialLevel);
		if (soldierId == "S039_wild")
		{
			iconFrameBorderSoldier = UiHelper.GetIconFrameBorderSoldier(7);
		}
		btn.iconFrame.url = "ui://PublicResources/" + iconFrameBorderSoldier;
		btn.lvFrame.url = UiHelper.GetLevelFrameBorderSoldier(potentialLevel);
		UiHelper.LoadSoldierIconFrameMaterial(((GObject)btn.iconFrame).asLoader, potentialLevel);
	}

	private void RenderOurFormation()
	{
		GvGSelectedSoldiersConfig gvGSelectedSoldiersConfigs = GameLocalDataManager.GetGvGSelectedSoldiersConfigs();
		FId = gvGSelectedSoldiersConfigs.FId;
		SelectedSoldiers = gvGSelectedSoldiersConfigs.SoldierIds;
		CurFormation.Init(FId, delegate(string newFid)
		{
			FId = newFid;
			OurFormationSketchMap.SetOurPos(FId, SelectedSoldiers, null, delegate(int combatPower)
			{
				((GObject)OurCombat).text = combatPower.ToString();
			}, isSelectSoldiers: true);
		});
	}

	private void RenderBossFormation()
	{
		//IL_01cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d7: Expected O, but got Unknown
		decimal bossMaxHp = GvGWorldController.Instance.ProcessInfo.BossInfo.BossMaxHp;
		BroadcastGroupInitInfo bossGroupInitInfo = GvGWorldController.Instance.BossGroupInitInfo;
		List<UnitInfo_Protocol> unitsInfo = bossGroupInitInfo.UnitsInfo;
		GameManagers.Instance.GetGvGInspectInfo(unitsInfo, bossMaxHp, delegate(Dictionary<string, GvGInspectInfo> dict)
		{
			InspectInfoDict = dict;
		});
		foreach (UnitInfo_Protocol unit in unitsInfo)
		{
			int posId = unit.PosId;
			UI_SoldierFormation uI_SoldierFormation = (UI_SoldierFormation)(object)((GComponent)EnemyFormationSketchMap).GetChild($"PosId{posId}");
			string finalSoldierId = GDMgr.Get<GDESoldierData>(unit.SoldierId).ParentSoldierId;
			if (string.IsNullOrEmpty(finalSoldierId))
			{
				finalSoldierId = unit.SoldierId;
			}
			bool isBoss = unit.SoldierId.Contains("WorldBOSS");
			uI_SoldierFormation.Type.selectedIndex = 0;
			((GObject)uI_SoldierFormation.Icon).TweenFade(1f, 0.5f);
			uI_SoldierFormation.Icon.Type.selectedIndex = 1;
			RenderSoldierItem(finalSoldierId, 0, unit.PotentialLevel, uI_SoldierFormation.Icon, isBoss);
			if (unit.SoldierId == "WorldBOSS_007")
			{
				uI_SoldierFormation.Icon.icon.url = "ui://PublicResources/I30029_6";
			}
			((GObject)uI_SoldierFormation).onClick.Set((EventCallback0)delegate
			{
				OnInspect(unit, finalSoldierId, isBoss);
			});
			if (isBoss)
			{
				BossSlot = uI_SoldierFormation;
				UiTagManager.Instance.Register("GvG.BossDetailShow", BossSlot);
			}
		}
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		((GObject)MakeWar).onClick.Set(new EventCallback0(OnClickStartBattle));
		((GObject)exitBtn).onClick.Set(new EventCallback0(End));
		((GObject)_mask).onClick.Set(new EventCallback0(End));
		OurFormationSketchMap.RegisterUiEventListeners();
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)MakeWar).onClick.Clear();
		((GObject)exitBtn).onClick.Clear();
		((GObject)_mask).onClick.Clear();
		OurFormationSketchMap.UnregisterUiEventListeners();
	}

	private void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
	}

	private void OnInspect(UnitInfo_Protocol unit, string finalSoldierId, bool isBoss = false)
	{
		FakeSoldier fakeSoldier = new FakeSoldier(unit.SoldierId, 0, 0, unit.PotentialLevel);
		FakeSoldier fakeSoldier2 = new FakeSoldier(finalSoldierId, 0, 0, unit.PotentialLevel);
		if (InspectInfoDict.TryGetValue(unit.SoldierId, out var value))
		{
			string value2 = "";
			string value3 = "";
			if (unit.IsBossUnit)
			{
				GvGWorldBossInfo gvGWorldBossInfoByWBId = GvGConfigHelper.GetGvGWorldBossInfoByWBId(GvGWorldController.Instance.ProcessInfo.BossInfo.WBId);
				value2 = gvGWorldBossInfoByWBId.featureName;
				value3 = GDMgr.Get<GDELanguagesData>(gvGWorldBossInfoByWBId.featureLangId)?.Template;
			}
			int num = unit.PotentialLevel;
			if (unit.SoldierId == "World_039")
			{
				num = 7;
			}
			List<string> value4 = ((fakeSoldier.AbilityList.Count == 0) ? fakeSoldier2.AbilityList : fakeSoldier.AbilityList);
			string skin = fakeSoldier.Skin;
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_EnemyIntroduction.Name, new Dictionary<string, object>
			{
				{ "SoldierId", finalSoldierId },
				{ "Num", unit.PerTeamMemberCnt },
				{ "FakeSoldierData", fakeSoldier2 },
				{ "CombatPower", value.CombatPower },
				{ "ATK", value.Atk },
				{ "DEF", value.Def },
				{ "HP", value.MaxHp },
				{ "PotentialLevel", num },
				{ "LegendItemBrief", null },
				{ "SpecialityName", value2 },
				{ "SpecialityText", value3 },
				{ "ChangedAbilities", value4 },
				{ "ChangedSkin", skin },
				{ "IsBoss", isBoss }
			});
		}
	}

	private void OnClickStartBattle()
	{
		if (SelectedSoldiers.IndexOf("Unlock") >= 0)
		{
			List<string> arg = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText421") + "5" + LanguagesManager.GetDesc("CsharpCodeZhTcText341") };
			SharedMessenger.Broadcast("SHOW_TIPS", arg, 1, arg3: false);
			return;
		}
		End();
		GvGWorldController.Instance?.StartBattle(FId, SelectedSoldiers, delegate
		{
			OnStartBattleCallback?.Invoke();
		}, delegate
		{
		});
		GameLocalDataManager.SetGvGSelectedSoldiersConfigs(new GvGSelectedSoldiersConfig
		{
			FId = FId,
			SoldierIds = SelectedSoldiers
		});
	}

	public void OnShow()
	{
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
		if (BossSlot != null)
		{
			UiTagManager.Instance.Register("GvG.BossDetailShow", BossSlot);
		}
	}
}
