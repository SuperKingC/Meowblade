using System;
using System.Collections.Generic;
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
using UI.Tips;
using UnityEngine;

namespace UI.UnlockSoldierInfo;

public class UI_UnlockSoldierInfoPanel : GComponent, IUiController
{
	public GGraph mask;

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

	public GList UnlockStoneNum;

	public GButton racePicture;

	public GTextField n172;

	public GGroup tip;

	public Transition showSelf;

	public const string URL = "ui://jctgkd2urxdc0";

	public static string Name = "UI_UnlockSoldierInfoPanel";

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

	private GoWrapper gw1;

	private string soldierId;

	public static string GetURL()
	{
		return "ui://jctgkd2urxdc0";
	}

	public static UI_UnlockSoldierInfoPanel CreateInstance()
	{
		return (UI_UnlockSoldierInfoPanel)(object)UIPackage.CreateObject("UnlockSoldierInfo", "UnlockSoldierInfoPanel");
	}

	public static UI_UnlockSoldierInfoPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_UnlockSoldierInfoPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://jctgkd2urxdc0", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Expected O, but got Unknown
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Expected O, but got Unknown
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Expected O, but got Unknown
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Expected O, but got Unknown
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		//IL_014e: Expected O, but got Unknown
		//IL_0197: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a1: Expected O, but got Unknown
		//IL_01ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f4: Expected O, but got Unknown
		//IL_023d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0247: Expected O, but got Unknown
		//IL_0292: Unknown result type (might be due to invalid IL or missing references)
		//IL_029c: Expected O, but got Unknown
		//IL_02e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f1: Expected O, but got Unknown
		//IL_02fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0307: Expected O, but got Unknown
		//IL_0313: Unknown result type (might be due to invalid IL or missing references)
		//IL_031d: Expected O, but got Unknown
		//IL_0329: Unknown result type (might be due to invalid IL or missing references)
		//IL_0333: Expected O, but got Unknown
		//IL_033f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0349: Expected O, but got Unknown
		//IL_0394: Unknown result type (might be due to invalid IL or missing references)
		//IL_039e: Expected O, but got Unknown
		//IL_03aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b4: Expected O, but got Unknown
		//IL_03c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ca: Expected O, but got Unknown
		//IL_0415: Unknown result type (might be due to invalid IL or missing references)
		//IL_041f: Expected O, but got Unknown
		//IL_042b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0435: Expected O, but got Unknown
		//IL_0441: Unknown result type (might be due to invalid IL or missing references)
		//IL_044b: Expected O, but got Unknown
		//IL_0457: Unknown result type (might be due to invalid IL or missing references)
		//IL_0461: Expected O, but got Unknown
		//IL_04ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b6: Expected O, but got Unknown
		//IL_04c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_04cc: Expected O, but got Unknown
		//IL_04d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e2: Expected O, but got Unknown
		//IL_04ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f8: Expected O, but got Unknown
		//IL_0504: Unknown result type (might be due to invalid IL or missing references)
		//IL_050e: Expected O, but got Unknown
		//IL_051a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0524: Expected O, but got Unknown
		//IL_056f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0579: Expected O, but got Unknown
		//IL_0585: Unknown result type (might be due to invalid IL or missing references)
		//IL_058f: Expected O, but got Unknown
		//IL_059b: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a5: Expected O, but got Unknown
		//IL_05f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_05fa: Expected O, but got Unknown
		//IL_0606: Unknown result type (might be due to invalid IL or missing references)
		//IL_0610: Expected O, but got Unknown
		//IL_061c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0626: Expected O, but got Unknown
		//IL_0632: Unknown result type (might be due to invalid IL or missing references)
		//IL_063c: Expected O, but got Unknown
		//IL_0648: Unknown result type (might be due to invalid IL or missing references)
		//IL_0652: Expected O, but got Unknown
		//IL_065e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0668: Expected O, but got Unknown
		//IL_0674: Unknown result type (might be due to invalid IL or missing references)
		//IL_067e: Expected O, but got Unknown
		//IL_068a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0694: Expected O, but got Unknown
		//IL_06a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_06aa: Expected O, but got Unknown
		//IL_06f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ff: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		mask = (GGraph)((GComponent)this).GetChild("mask");
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
		string id = "ui://jctgkd2urxdc0".Replace("ui://", "") + "-" + ((GObject)attackTiele).id;
		((GObject)attackTiele).text = LanguagesManager.GetDesc(id);
		defenseTiele = (GTextField)((GComponent)this).GetChild("defenseTiele");
		string id2 = "ui://jctgkd2urxdc0".Replace("ui://", "") + "-" + ((GObject)defenseTiele).id;
		((GObject)defenseTiele).text = LanguagesManager.GetDesc(id2);
		healthTiele = (GTextField)((GComponent)this).GetChild("healthTiele");
		string id3 = "ui://jctgkd2urxdc0".Replace("ui://", "") + "-" + ((GObject)healthTiele).id;
		((GObject)healthTiele).text = LanguagesManager.GetDesc(id3);
		attack = (GTextField)((GComponent)this).GetChild("attack");
		string id4 = "ui://jctgkd2urxdc0".Replace("ui://", "") + "-" + ((GObject)attack).id;
		((GObject)attack).text = LanguagesManager.GetDesc(id4);
		health = (GTextField)((GComponent)this).GetChild("health");
		string id5 = "ui://jctgkd2urxdc0".Replace("ui://", "") + "-" + ((GObject)health).id;
		((GObject)health).text = LanguagesManager.GetDesc(id5);
		defense = (GTextField)((GComponent)this).GetChild("defense");
		string id6 = "ui://jctgkd2urxdc0".Replace("ui://", "") + "-" + ((GObject)defense).id;
		((GObject)defense).text = LanguagesManager.GetDesc(id6);
		attackLoader = (GLoader)((GComponent)this).GetChild("attackLoader");
		defenseLoader = (GLoader)((GComponent)this).GetChild("defenseLoader");
		healthLoader = (GLoader)((GComponent)this).GetChild("healthLoader");
		SoldierNamePotentialLevelBack = (GComponent)((GComponent)this).GetChild("SoldierNamePotentialLevelBack");
		title = (GRichTextField)((GComponent)this).GetChild("title");
		string id7 = "ui://jctgkd2urxdc0".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id7);
		propertyBackgroundC = (GImage)((GComponent)this).GetChild("propertyBackgroundC");
		n140 = (GImage)((GComponent)this).GetChild("n140");
		specialityName = (GTextField)((GComponent)this).GetChild("specialityName");
		string id8 = "ui://jctgkd2urxdc0".Replace("ui://", "") + "-" + ((GObject)specialityName).id;
		((GObject)specialityName).text = LanguagesManager.GetDesc(id8);
		specialityText = (GRichTextField)((GComponent)this).GetChild("specialityText");
		n144 = (GImage)((GComponent)this).GetChild("n144");
		n145 = (GImage)((GComponent)this).GetChild("n145");
		n146 = (GTextField)((GComponent)this).GetChild("n146");
		string id9 = "ui://jctgkd2urxdc0".Replace("ui://", "") + "-" + ((GObject)n146).id;
		((GObject)n146).text = LanguagesManager.GetDesc(id9);
		skillTitleGroup = (GGroup)((GComponent)this).GetChild("skillTitleGroup");
		skillList = (GList)((GComponent)this).GetChild("skillList");
		FormationSoldierAmountBack = (GImage)((GComponent)this).GetChild("FormationSoldierAmountBack");
		n152 = (GImage)((GComponent)this).GetChild("n152");
		CombatPowerSfxBack = (GGraph)((GComponent)this).GetChild("CombatPowerSfxBack");
		phalanx = (GTextField)((GComponent)this).GetChild("phalanx");
		string id10 = "ui://jctgkd2urxdc0".Replace("ui://", "") + "-" + ((GObject)phalanx).id;
		((GObject)phalanx).text = LanguagesManager.GetDesc(id10);
		FormationSoldierAmountSpine = (GGraph)((GComponent)this).GetChild("FormationSoldierAmountSpine");
		upperLimit = (GTextField)((GComponent)this).GetChild("upperLimit");
		combatPower = (GTextField)((GComponent)this).GetChild("combatPower");
		string id11 = "ui://jctgkd2urxdc0".Replace("ui://", "") + "-" + ((GObject)combatPower).id;
		((GObject)combatPower).text = LanguagesManager.GetDesc(id11);
		fighting = (GTextField)((GComponent)this).GetChild("fighting");
		CombatPowerSpine = (GGraph)((GComponent)this).GetChild("CombatPowerSpine");
		CombatPowerIcon = (GImage)((GComponent)this).GetChild("CombatPowerIcon");
		Bottomleftcorner = (GGroup)((GComponent)this).GetChild("Bottomleftcorner");
		rareness = (GLoader)((GComponent)this).GetChild("rareness");
		exit = (GButton)((GComponent)this).GetChild("exit");
		UnlockStoneNum = (GList)((GComponent)this).GetChild("UnlockStoneNum");
		racePicture = (GButton)((GComponent)this).GetChild("racePicture");
		n172 = (GTextField)((GComponent)this).GetChild("n172");
		string id12 = "ui://jctgkd2urxdc0".Replace("ui://", "") + "-" + ((GObject)n172).id;
		((GObject)n172).text = LanguagesManager.GetDesc(id12);
		tip = (GGroup)((GComponent)this).GetChild("tip");
		showSelf = ((GComponent)this).GetTransition("showSelf");
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		if (parameters.TryGetValue("UnlockSoldierId", out var value))
		{
			soldierId = value.ToString();
			Soldier soldier = GameManagers.Instance.SoldierManager.Get(soldierId);
			if (soldier != null)
			{
				RenderIntroductionPanel(soldier);
				PlaySoldierVoice();
			}
		}
	}

	public void OnShow()
	{
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		((GObject)exit).onClick.Add(new EventCallback0(End));
		((GObject)specialityText).onClickLink.Set(new EventCallback1(OnClickEffectLink));
		((GObject)SoldierAnimation).onClick.Add(new EventCallback0(PlaySoldierVoice));
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		((GObject)exit).onClick.Remove(new EventCallback0(End));
		((GObject)specialityText).onClickLink.Clear();
		((GObject)SoldierAnimation).onClick.Remove(new EventCallback0(PlaySoldierVoice));
	}

	public void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
	}

	private void PlaySoldierVoice()
	{
		UiAudioManager.Instance.PlaySoldierVoice(soldierId, UiAudioManager.SoldierVoiceType.Voice);
	}

	private void RenderIntroductionPanel(Soldier soldier)
	{
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected O, but got Unknown
		//IL_0173: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_0106: Unknown result type (might be due to invalid IL or missing references)
		//IL_0117: Unknown result type (might be due to invalid IL or missing references)
		//IL_0121: Unknown result type (might be due to invalid IL or missing references)
		//IL_012b: Expected O, but got Unknown
		//IL_03fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0469: Unknown result type (might be due to invalid IL or missing references)
		//IL_0473: Expected O, but got Unknown
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
			SpawnManager.Instance.LoadSoldierSpine(val, $"{soldier.Id}_skin{4}", isMask: true).Then((Action<SkeletonDataAsset>)delegate(SkeletonDataAsset asset)
			{
				if ((Object)(object)asset != (Object)null && (Object)(object)animation != (Object)null && !((GObject)this).isDisposed)
				{
					((SkeletonRenderer)animation).skeletonDataAsset = asset;
					((SkeletonRenderer)animation).Initialize(true);
					SpineHelper.SetSkin((ISkeletonAnimation)(object)animation, $"skin{4}");
					animation.AnimationState.AddAnimation(0, "idle", true, 0f);
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
		RenderLockSoldierStoneList(soldier.Id, UnlockStoneNum);
		((GComponent)racePicture).GetController("Type").selectedIndex = FGUIManager.Instance.GetRaceIcon(soldier.Faction);
		((GObject)racePicture).onClick.Set((EventCallback0)delegate
		{
			FGUIManager.Instance.ShowRaceInfo(soldier.Faction, 2, ((GObject)this).sortingOrder);
		});
		showSelf.Play();
	}

	private void RenderLockSoldierStoneList(string sid, GList stoneGList)
	{
		//IL_01e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ec: Unknown result type (might be due to invalid IL or missing references)
		List<int> list = new List<int>();
		List<int> list2 = new List<int> { 1, 2, 3, 4, 5 };
		for (int i = 0; i < stoneGList.numItems; i++)
		{
			list.Add(0);
		}
		for (int j = 0; j < list2.Count; j++)
		{
			string itemId = $"I2{list2[j]}{sid.Substring(1)}";
			switch (Item.Level(GameManagers.Instance, itemId))
			{
			case 1:
				list[0] += GameManagers.Instance.StockController.GetStock(itemId);
				break;
			case 2:
				list[1] += GameManagers.Instance.StockController.GetStock(itemId);
				break;
			case 3:
				list[2] += GameManagers.Instance.StockController.GetStock(itemId);
				break;
			case 4:
				list[3] += GameManagers.Instance.StockController.GetStock(itemId);
				break;
			case 5:
				list[4] += GameManagers.Instance.StockController.GetStock(itemId);
				break;
			}
		}
		for (int k = 0; k < stoneGList.numItems; k++)
		{
			GComponent asCom = ((GComponent)stoneGList).GetChildAt(k).asCom;
			asCom.GetChild("num").text = list[k].ShortNumberFormat();
			asCom.GetChild("num").asTextField.strokeColor = Color32.op_Implicit(new Color32((byte)0, (byte)0, (byte)0, (byte)229));
		}
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
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
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
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Expected O, but got Unknown
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
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

	public static void OnClickEffectLink(EventContext e)
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_SkillEffectPanel.Name, new Dictionary<string, object> { 
		{
			"EffectKey",
			e.data.ToString()
		} });
	}
}
