using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using GameDataEditor;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Spine.Unity;
using UI.Legion;
using UI.UnlockSoldierInfo;
using UnityEngine;

namespace UI.Tips;

public class UI_main_IntroductionPanelA : GComponent, IUiController
{
	public GGraph mask;

	public GGraph mask2;

	public GImage background;

	public GImage propertyBackgroundA;

	public GImage n132;

	public GImage n133;

	public GImage n134;

	public UI_SoldierAnimarion SoldierAnimation;

	public GButton attackPropertyBtn;

	public GButton defensePropertyBtn;

	public GButton n95;

	public GTextField attackTiele;

	public GTextField defenseTiele;

	public GTextField healthTiele;

	public GTextField attack;

	public GTextField health;

	public GTextField defense;

	public GLoader attackLoader;

	public GLoader defenseLoader;

	public GLoader healthLoader;

	public GComponent SoldierNamePotentialLevelBack;

	public GRichTextField title;

	public GRichTextField introduction;

	public GImage propertyBackgroundC;

	public GImage n140;

	public GTextField specialityName;

	public GRichTextField specialityText;

	public GImage n144;

	public GImage n145;

	public GTextField n146;

	public GGroup skillTitleGroup;

	public GList skillList;

	public GImage FormationSoldierAmountBack;

	public GImage n152;

	public GGraph CombatPowerSfxBack;

	public GTextField phalanx;

	public GGraph FormationSoldierAmountSpine;

	public GTextField upperLimit;

	public GTextField combatPower;

	public GTextField fighting;

	public GGraph CombatPowerSpine;

	public GImage CombatPowerIcon;

	public GGroup Bottomleftcorner;

	public GLoader rareness;

	public GButton exit;

	public UI_activate2 activate;

	public GRichTextField chipsTitle;

	public GRichTextField currentChipNum;

	public GRichTextField upLimit;

	public GGroup activeGroup;

	public GList UnlockStoneNum;

	public GButton racePicture;

	public GTextField n172;

	public GGroup tip;

	public Transition showSelf;

	public const string URL = "ui://47lbpgx9ef7ej5ltgj";

	public static string Name = "UI_main_IntroductionPanelA";

	public const string SoliderInfo = "SoliderInfo";

	private GoWrapper gw1;

	private readonly string[] attackTypeNames = new string[4]
	{
		LanguagesManager.GetDesc("CsharpCodeZhTcText196"),
		LanguagesManager.GetDesc("CsharpCodeZhTcText197"),
		LanguagesManager.GetDesc("CsharpCodeZhTcText198"),
		LanguagesManager.GetDesc("CsharpCodeZhTcText199")
	};

	private readonly string[] armorTypeNames = new string[4]
	{
		LanguagesManager.GetDesc("CsharpCodeZhTcText200"),
		LanguagesManager.GetDesc("CsharpCodeZhTcText201"),
		LanguagesManager.GetDesc("CsharpCodeZhTcText202"),
		LanguagesManager.GetDesc("CsharpCodeZhTcText203")
	};

	public static string GetURL()
	{
		return "ui://47lbpgx9ef7ej5ltgj";
	}

	public static UI_main_IntroductionPanelA CreateInstance()
	{
		return (UI_main_IntroductionPanelA)(object)UIPackage.CreateObject("Tips", "main_IntroductionPanelA");
	}

	public static UI_main_IntroductionPanelA CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_IntroductionPanelA).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://47lbpgx9ef7ej5ltgj", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected O, but got Unknown
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Expected O, but got Unknown
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Expected O, but got Unknown
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Expected O, but got Unknown
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Expected O, but got Unknown
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Expected O, but got Unknown
		//IL_015a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0164: Expected O, but got Unknown
		//IL_01ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b7: Expected O, but got Unknown
		//IL_0200: Unknown result type (might be due to invalid IL or missing references)
		//IL_020a: Expected O, but got Unknown
		//IL_0253: Unknown result type (might be due to invalid IL or missing references)
		//IL_025d: Expected O, but got Unknown
		//IL_02a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b2: Expected O, but got Unknown
		//IL_02fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0307: Expected O, but got Unknown
		//IL_0313: Unknown result type (might be due to invalid IL or missing references)
		//IL_031d: Expected O, but got Unknown
		//IL_0329: Unknown result type (might be due to invalid IL or missing references)
		//IL_0333: Expected O, but got Unknown
		//IL_033f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0349: Expected O, but got Unknown
		//IL_0355: Unknown result type (might be due to invalid IL or missing references)
		//IL_035f: Expected O, but got Unknown
		//IL_03aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b4: Expected O, but got Unknown
		//IL_03ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0409: Expected O, but got Unknown
		//IL_0415: Unknown result type (might be due to invalid IL or missing references)
		//IL_041f: Expected O, but got Unknown
		//IL_042b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0435: Expected O, but got Unknown
		//IL_0480: Unknown result type (might be due to invalid IL or missing references)
		//IL_048a: Expected O, but got Unknown
		//IL_0496: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a0: Expected O, but got Unknown
		//IL_04ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b6: Expected O, but got Unknown
		//IL_04c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_04cc: Expected O, but got Unknown
		//IL_0517: Unknown result type (might be due to invalid IL or missing references)
		//IL_0521: Expected O, but got Unknown
		//IL_052d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0537: Expected O, but got Unknown
		//IL_0543: Unknown result type (might be due to invalid IL or missing references)
		//IL_054d: Expected O, but got Unknown
		//IL_0559: Unknown result type (might be due to invalid IL or missing references)
		//IL_0563: Expected O, but got Unknown
		//IL_056f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0579: Expected O, but got Unknown
		//IL_0585: Unknown result type (might be due to invalid IL or missing references)
		//IL_058f: Expected O, but got Unknown
		//IL_05da: Unknown result type (might be due to invalid IL or missing references)
		//IL_05e4: Expected O, but got Unknown
		//IL_05f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_05fa: Expected O, but got Unknown
		//IL_0606: Unknown result type (might be due to invalid IL or missing references)
		//IL_0610: Expected O, but got Unknown
		//IL_065b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0665: Expected O, but got Unknown
		//IL_0671: Unknown result type (might be due to invalid IL or missing references)
		//IL_067b: Expected O, but got Unknown
		//IL_0687: Unknown result type (might be due to invalid IL or missing references)
		//IL_0691: Expected O, but got Unknown
		//IL_069d: Unknown result type (might be due to invalid IL or missing references)
		//IL_06a7: Expected O, but got Unknown
		//IL_06b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_06bd: Expected O, but got Unknown
		//IL_06c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_06d3: Expected O, but got Unknown
		//IL_06f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ff: Expected O, but got Unknown
		//IL_074a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0754: Expected O, but got Unknown
		//IL_079f: Unknown result type (might be due to invalid IL or missing references)
		//IL_07a9: Expected O, but got Unknown
		//IL_07f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_07fe: Expected O, but got Unknown
		//IL_080a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0814: Expected O, but got Unknown
		//IL_0820: Unknown result type (might be due to invalid IL or missing references)
		//IL_082a: Expected O, but got Unknown
		//IL_0836: Unknown result type (might be due to invalid IL or missing references)
		//IL_0840: Expected O, but got Unknown
		//IL_088b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0895: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		mask = (GGraph)((GComponent)this).GetChild("mask");
		mask2 = (GGraph)((GComponent)this).GetChild("mask2");
		background = (GImage)((GComponent)this).GetChild("background");
		propertyBackgroundA = (GImage)((GComponent)this).GetChild("propertyBackgroundA");
		n132 = (GImage)((GComponent)this).GetChild("n132");
		n133 = (GImage)((GComponent)this).GetChild("n133");
		n134 = (GImage)((GComponent)this).GetChild("n134");
		SoldierAnimation = (UI_SoldierAnimarion)(object)((GComponent)this).GetChild("SoldierAnimation");
		attackPropertyBtn = (GButton)((GComponent)this).GetChild("attackPropertyBtn");
		defensePropertyBtn = (GButton)((GComponent)this).GetChild("defensePropertyBtn");
		n95 = (GButton)((GComponent)this).GetChild("n95");
		attackTiele = (GTextField)((GComponent)this).GetChild("attackTiele");
		string id = "ui://47lbpgx9ef7ej5ltgj".Replace("ui://", "") + "-" + ((GObject)attackTiele).id;
		((GObject)attackTiele).text = LanguagesManager.GetDesc(id);
		defenseTiele = (GTextField)((GComponent)this).GetChild("defenseTiele");
		string id2 = "ui://47lbpgx9ef7ej5ltgj".Replace("ui://", "") + "-" + ((GObject)defenseTiele).id;
		((GObject)defenseTiele).text = LanguagesManager.GetDesc(id2);
		healthTiele = (GTextField)((GComponent)this).GetChild("healthTiele");
		string id3 = "ui://47lbpgx9ef7ej5ltgj".Replace("ui://", "") + "-" + ((GObject)healthTiele).id;
		((GObject)healthTiele).text = LanguagesManager.GetDesc(id3);
		attack = (GTextField)((GComponent)this).GetChild("attack");
		string id4 = "ui://47lbpgx9ef7ej5ltgj".Replace("ui://", "") + "-" + ((GObject)attack).id;
		((GObject)attack).text = LanguagesManager.GetDesc(id4);
		health = (GTextField)((GComponent)this).GetChild("health");
		string id5 = "ui://47lbpgx9ef7ej5ltgj".Replace("ui://", "") + "-" + ((GObject)health).id;
		((GObject)health).text = LanguagesManager.GetDesc(id5);
		defense = (GTextField)((GComponent)this).GetChild("defense");
		string id6 = "ui://47lbpgx9ef7ej5ltgj".Replace("ui://", "") + "-" + ((GObject)defense).id;
		((GObject)defense).text = LanguagesManager.GetDesc(id6);
		attackLoader = (GLoader)((GComponent)this).GetChild("attackLoader");
		defenseLoader = (GLoader)((GComponent)this).GetChild("defenseLoader");
		healthLoader = (GLoader)((GComponent)this).GetChild("healthLoader");
		SoldierNamePotentialLevelBack = (GComponent)((GComponent)this).GetChild("SoldierNamePotentialLevelBack");
		title = (GRichTextField)((GComponent)this).GetChild("title");
		string id7 = "ui://47lbpgx9ef7ej5ltgj".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id7);
		introduction = (GRichTextField)((GComponent)this).GetChild("introduction");
		string id8 = "ui://47lbpgx9ef7ej5ltgj".Replace("ui://", "") + "-" + ((GObject)introduction).id;
		((GObject)introduction).text = LanguagesManager.GetDesc(id8);
		propertyBackgroundC = (GImage)((GComponent)this).GetChild("propertyBackgroundC");
		n140 = (GImage)((GComponent)this).GetChild("n140");
		specialityName = (GTextField)((GComponent)this).GetChild("specialityName");
		string id9 = "ui://47lbpgx9ef7ej5ltgj".Replace("ui://", "") + "-" + ((GObject)specialityName).id;
		((GObject)specialityName).text = LanguagesManager.GetDesc(id9);
		specialityText = (GRichTextField)((GComponent)this).GetChild("specialityText");
		n144 = (GImage)((GComponent)this).GetChild("n144");
		n145 = (GImage)((GComponent)this).GetChild("n145");
		n146 = (GTextField)((GComponent)this).GetChild("n146");
		string id10 = "ui://47lbpgx9ef7ej5ltgj".Replace("ui://", "") + "-" + ((GObject)n146).id;
		((GObject)n146).text = LanguagesManager.GetDesc(id10);
		skillTitleGroup = (GGroup)((GComponent)this).GetChild("skillTitleGroup");
		skillList = (GList)((GComponent)this).GetChild("skillList");
		FormationSoldierAmountBack = (GImage)((GComponent)this).GetChild("FormationSoldierAmountBack");
		n152 = (GImage)((GComponent)this).GetChild("n152");
		CombatPowerSfxBack = (GGraph)((GComponent)this).GetChild("CombatPowerSfxBack");
		phalanx = (GTextField)((GComponent)this).GetChild("phalanx");
		string id11 = "ui://47lbpgx9ef7ej5ltgj".Replace("ui://", "") + "-" + ((GObject)phalanx).id;
		((GObject)phalanx).text = LanguagesManager.GetDesc(id11);
		FormationSoldierAmountSpine = (GGraph)((GComponent)this).GetChild("FormationSoldierAmountSpine");
		upperLimit = (GTextField)((GComponent)this).GetChild("upperLimit");
		combatPower = (GTextField)((GComponent)this).GetChild("combatPower");
		string id12 = "ui://47lbpgx9ef7ej5ltgj".Replace("ui://", "") + "-" + ((GObject)combatPower).id;
		((GObject)combatPower).text = LanguagesManager.GetDesc(id12);
		fighting = (GTextField)((GComponent)this).GetChild("fighting");
		CombatPowerSpine = (GGraph)((GComponent)this).GetChild("CombatPowerSpine");
		CombatPowerIcon = (GImage)((GComponent)this).GetChild("CombatPowerIcon");
		Bottomleftcorner = (GGroup)((GComponent)this).GetChild("Bottomleftcorner");
		rareness = (GLoader)((GComponent)this).GetChild("rareness");
		exit = (GButton)((GComponent)this).GetChild("exit");
		activate = (UI_activate2)(object)((GComponent)this).GetChild("activate");
		chipsTitle = (GRichTextField)((GComponent)this).GetChild("chipsTitle");
		string id13 = "ui://47lbpgx9ef7ej5ltgj".Replace("ui://", "") + "-" + ((GObject)chipsTitle).id;
		((GObject)chipsTitle).text = LanguagesManager.GetDesc(id13);
		currentChipNum = (GRichTextField)((GComponent)this).GetChild("currentChipNum");
		string id14 = "ui://47lbpgx9ef7ej5ltgj".Replace("ui://", "") + "-" + ((GObject)currentChipNum).id;
		((GObject)currentChipNum).text = LanguagesManager.GetDesc(id14);
		upLimit = (GRichTextField)((GComponent)this).GetChild("upLimit");
		string id15 = "ui://47lbpgx9ef7ej5ltgj".Replace("ui://", "") + "-" + ((GObject)upLimit).id;
		((GObject)upLimit).text = LanguagesManager.GetDesc(id15);
		activeGroup = (GGroup)((GComponent)this).GetChild("activeGroup");
		UnlockStoneNum = (GList)((GComponent)this).GetChild("UnlockStoneNum");
		racePicture = (GButton)((GComponent)this).GetChild("racePicture");
		n172 = (GTextField)((GComponent)this).GetChild("n172");
		string id16 = "ui://47lbpgx9ef7ej5ltgj".Replace("ui://", "") + "-" + ((GObject)n172).id;
		((GObject)n172).text = LanguagesManager.GetDesc(id16);
		tip = (GGroup)((GComponent)this).GetChild("tip");
		showSelf = ((GComponent)this).GetTransition("showSelf");
	}

	private void RenderIntroductionPanel(Soldier soldier)
	{
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e6: Expected O, but got Unknown
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0108: Expected O, but got Unknown
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		//IL_012a: Expected O, but got Unknown
		//IL_027b: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_0204: Unknown result type (might be due to invalid IL or missing references)
		//IL_0215: Unknown result type (might be due to invalid IL or missing references)
		//IL_021f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0229: Expected O, but got Unknown
		//IL_058b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0604: Unknown result type (might be due to invalid IL or missing references)
		//IL_060e: Expected O, but got Unknown
		UiAudioManager.Instance.PlaySoldierVoice(soldier.Id, UiAudioManager.SoldierVoiceType.Onomatopoeia);
		((GObject)this).visible = true;
		((GObject)introduction).visible = false;
		((GTextField)activate.title).strokeColor = Color32.op_Implicit(new Color32((byte)60, (byte)72, (byte)13, (byte)229));
		((GObject)chipsTitle).visible = false;
		((GObject)currentChipNum).visible = false;
		((GObject)upLimit).visible = false;
		((GObject)activate).visible = false;
		((GObject)SoldierAnimation).onClick.Set((EventCallback0)delegate
		{
			UiAudioManager.Instance.PlaySoldierVoice(soldier.Id, UiAudioManager.SoldierVoiceType.Onomatopoeia);
		});
		((GObject)attackPropertyBtn).onClick.Set((EventCallback0)delegate
		{
			OpenAttackAndDefense((GObject)(object)attackPropertyBtn, type: true, soldier.DamageType);
		});
		((GObject)defensePropertyBtn).onClick.Set((EventCallback0)delegate
		{
			OpenAttackAndDefense((GObject)(object)defensePropertyBtn, type: false, soldier.ArmorType);
		});
		Object obj = Object.Instantiate(Resources.Load("SpineTest", typeof(GameObject)));
		GameObject val = (GameObject)(object)((obj is GameObject) ? obj : null);
		if ((Object)(object)val != (Object)null)
		{
			SkeletonAnimation animation = val.GetComponent<SkeletonAnimation>();
			int potentialLevel = (soldier.PotentialLevel + 2) / 2;
			SpawnManager.Instance.LoadSoldierSpine(val, $"{soldier.Id}_skin{potentialLevel}", isMask: true).Then((Action<SkeletonDataAsset>)delegate(SkeletonDataAsset asset)
			{
				if ((Object)(object)asset != (Object)null && (Object)(object)animation != (Object)null && !((GObject)this).isDisposed)
				{
					((SkeletonRenderer)animation).skeletonDataAsset = asset;
					((SkeletonRenderer)animation).initialSkinName = $"skin{potentialLevel}";
					((SkeletonRenderer)animation).Initialize(true);
					string text = "idle";
					if (soldier.Id == "S043" || soldier.Id == "S044")
					{
						text = "idle_ui";
					}
					animation.AnimationState.AddAnimation(0, text, true, 0f);
					animation.timeScale = 0.2f;
				}
			});
			Vector3 localScale = default(Vector3);
			((Vector3)(ref localScale))._002Ector(50f, 50f, 50f);
			val.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
			val.transform.localScale = localScale;
			gw1 = new GoWrapper(val);
			gw1.supportStencil = true;
		}
		SoldierAnimation.icon.SetNativeObject((DisplayObject)(object)gw1);
		FGUIManager.Instance.AddTextSpecialEffects(SoldierAnimation.baseSpine, "MagicCircleBase", new Vector3(100f, 100f, 100f));
		FGUIManager.Instance.AddTextSpecialEffects(SoldierAnimation.maskSpine, "MagicCircleMask", new Vector3(100f, 100f, 100f));
		((GObject)title).text = soldier.Name;
		((GObject)introduction).text = Regex.Match(soldier.Desc, "(?<=Desc:)([^:\\.])*(?=\\#)*").Value;
		int levelAdded = ((soldier.Level <= 0) ? 1 : 0);
		int soldierFormationNumber = Singleton<SoldierFormationManager>.Instance.GetSoldierFormationNumber(soldier.Id, soldier.Level, levelAdded);
		((GObject)upperLimit).text = soldierFormationNumber.ToString() ?? "";
		((GObject)fighting).text = (soldier.CombatPower * soldierFormationNumber).ToString();
		((GObject)attack).text = $"{Convert.ToInt32(soldier.Attack)}";
		((GObject)defense).text = $"{Convert.ToInt32(soldier.Defense)}";
		((GObject)health).text = $"{Convert.ToInt32(soldier.Health)}";
		attackLoader.url = $"ui://PublicResources/icon_atk_{soldier.DamageType}";
		defenseLoader.url = $"ui://PublicResources/icon_def_{soldier.ArmorType}";
		healthLoader.url = "ui://PublicResources/icon_hp";
		((GObject)attackTiele).text = attackTypeNames[soldier.DamageType - 1] + "：";
		((GObject)defenseTiele).text = armorTypeNames[soldier.ArmorType - 1] + "：";
		((GObject)healthTiele).text = LanguagesManager.GetDesc("CsharpCodeZhTcText204") + "：";
		SkillListRenderer(soldier);
		((GObject)CombatPowerSfxBack).displayObject.Dispose();
		FGUIManager.Instance.AddTextSpecialEffects(CombatPowerSfxBack, "combat_power", new Vector3(((GObject)CombatPowerSfxBack).width / 4f, ((GObject)CombatPowerSfxBack).height * 6f, ((GObject)CombatPowerSfxBack).height));
		UI_LegionPanel.RenderLockSoldierStoneList(soldier.Id, UnlockStoneNum);
		((GComponent)racePicture).GetController("Type").selectedIndex = FGUIManager.Instance.GetRaceIcon(soldier.Faction);
		((GObject)racePicture).onClick.Set((EventCallback0)delegate
		{
			FGUIManager.Instance.ShowRaceInfo(soldier.Faction, 2, ((GObject)this).sortingOrder);
		});
		showSelf.Play();
	}

	private void OpenAttackAndDefense(GObject button, bool type, int index)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		Vector2 val = button.LocalToGlobal(Vector2.zero);
		val = ((GObject)this).GlobalToLocal(val);
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		dictionary.Add("Pos", val);
		dictionary.Add("Type", type);
		dictionary.Add("Index", index);
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_SpearAndShield.Name, dictionary);
	}

	private void SkillListRenderer(Soldier soldier)
	{
		skillList.RemoveChildrenToPool();
		List<string> list = new List<string>();
		string currentLevelFeatureAbilityId = soldier.GetCurrentLevelFeatureAbilityId();
		for (int i = 0; i < soldier.AbilityList.Count; i++)
		{
			if (!(soldier.AbilityList[i] == soldier.FeatureAbility) && GDMgr.TryGetWithErrorHandling<GDEAbilityData>(soldier.AbilityList[i]).Visible)
			{
				list.Add(soldier.AbilityList[i]);
			}
		}
		GDEAbilityData gDEAbilityData = GDMgr.TryGetWithErrorHandling<GDEAbilityData>(currentLevelFeatureAbilityId);
		((GObject)specialityName).text = $"{gDEAbilityData.Name} LV{1}";
		((GObject)specialityText).text = Singleton<AbilityDataManager>.Instance.GetDescription(gDEAbilityData.Key);
		bool isShow = !GameManagers.Instance.UserArchiveManager.GetUnlockedSoldiers().Contains(soldier.Id);
		Dictionary<string, int> dictionary = soldier.AbilitiesUnlockState();
		for (int j = 0; j < list.Count; j++)
		{
			bool isUnLocked = ((dictionary[list[j]] <= soldier.PotentialLevel) ? true : false);
			skillList.AddItemFromPool();
			RenderSkillListItem(list[j], ((GComponent)skillList).GetChildAt(j), isUnLocked, dictionary[list[j]], isShow, j);
		}
		if (skillList.numItems == 0)
		{
			((GObject)skillTitleGroup).visible = false;
		}
		else
		{
			((GObject)skillTitleGroup).visible = true;
		}
	}

	private void RenderSkillListItem(string skillId, GObject button, bool isUnLocked, int limit, bool isShow, int index)
	{
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Expected O, but got Unknown
		GDEAbilityData gDEAbilityData = GDMgr.TryGetWithErrorHandling<GDEAbilityData>(skillId);
		((GComponent)((GComponent)button.asButton).GetChild("IconBtn").asButton).GetChild("IconLoader").asLoader.LoadAbilityIcon(gDEAbilityData.Icon);
		if (isUnLocked)
		{
			((GComponent)button.asButton).GetChild("IconBtn").grayed = false;
			button.touchable = true;
			Tuple<GDEAbilityData, int, bool, bool> data = new Tuple<GDEAbilityData, int, bool, bool>(gDEAbilityData, limit, isUnLocked, isShow);
			button.data = data;
		}
		else
		{
			((GComponent)button.asButton).GetChild("IconBtn").grayed = true;
			Tuple<GDEAbilityData, int, bool, bool> data2 = new Tuple<GDEAbilityData, int, bool, bool>(gDEAbilityData, limit, isUnLocked, isShow);
			button.data = data2;
			button.touchable = true;
		}
		button.onClick.Add(new EventCallback1(SkillDetailPopup));
		if (isShow)
		{
			((GComponent)button.asButton).GetChild("IconBtn").grayed = false;
		}
		int num = 5 - 5 * ((GComponent)skillList).GetChildIndex(button);
		((GComponent)button.asButton).GetChild("n16").rotation = num;
	}

	public void SkillDetailPopup(EventContext context)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected O, but got Unknown
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		GButton val = (GButton)context.sender;
		Tuple<GDEAbilityData, int, bool, bool> tuple = (Tuple<GDEAbilityData, int, bool, bool>)((GObject)val).data;
		Vector2 val2 = ((GObject)skillList).LocalToGlobal(Vector2.zero);
		val2 = ((GObject)this).GlobalToLocal(val2);
		((Vector2)(ref val2))._002Ector(val2.x + 200f, val2.y + 20f);
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		dictionary.Add("Pos", val2);
		dictionary.Add("Data", tuple.Item1);
		dictionary.Add("Limit", tuple.Item2);
		dictionary.Add("State", tuple.Item3);
		dictionary.Add("GList", skillList);
		dictionary.Add("IsShow", tuple.Item4);
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_SkillDetailPopup.Name, dictionary);
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		((GObject)exit).onClick.Set(new EventCallback0(Close));
		((GObject)mask).onClick.Set(new EventCallback0(Close));
		((GObject)specialityText).onClickLink.Set(new EventCallback1(UI_UnlockSoldierInfoPanel.OnClickEffectLink));
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)exit).onClick.Clear();
		((GObject)mask).onClick.Clear();
		((GObject)specialityText).onClickLink.Clear();
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this, scaleAdaption: true);
		Soldier soldier = (Soldier)parameters["SoliderInfo"];
		RenderIntroductionPanel(soldier);
	}

	public void OnShow()
	{
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
	}

	private static void Close()
	{
		UnityUiService.Instance.ClosePanel(Name);
	}
}
