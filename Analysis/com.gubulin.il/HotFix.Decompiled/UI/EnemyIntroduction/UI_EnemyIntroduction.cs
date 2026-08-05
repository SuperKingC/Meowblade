using System;
using System.Collections.Generic;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using GameDataEditor;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Spine.Unity;
using UI.LegendItemInfo;
using UI.Tips;
using UnityEngine;

namespace UI.EnemyIntroduction;

public class UI_EnemyIntroduction : GComponent, IUiController
{
	public GLoader background;

	public GGraph mask;

	public GGraph mask2;

	public GImage backgroundNormal;

	public GImage backgroundAdvanced;

	public GImage propertyBackgroundA;

	public GImage n77;

	public GImage n78;

	public GImage n79;

	public UI_SoldierAnimarion SoldierAnimation;

	public GButton attackPropertyBtn;

	public GButton defensePropertyBtn;

	public GButton n24;

	public GImage mercenaryLogo;

	public GComponent SoldierNamePotentialLevelBack;

	public GRichTextField title;

	public GRichTextField introduction;

	public GTextField attributes;

	public GTextField attackTiele;

	public GTextField defenseTiele;

	public GTextField healthTiele;

	public GTextField attack;

	public GTextField health;

	public GTextField defense;

	public GImage propertyBackgroundC;

	public GImage n81;

	public GTextField specialityName;

	public GRichTextField specialityText;

	public GImage n85;

	public GImage n86;

	public GTextField n87;

	public GGroup skillTitleGroup;

	public GList skillList;

	public GLoader rareness;

	public UI_ExitAdvancedBtn ExitAdvancedBtn;

	public GButton exit;

	public GLoader attackLoader;

	public GLoader defenseLoader;

	public GLoader healthLoader;

	public GButton racePicture;

	public UI_LegendSlot LegendSlot;

	public GImage FormationSoldierAmountBack;

	public GImage n65;

	public GGraph CombatPowerSfxBack;

	public GTextField phalanx;

	public GGraph FormationSoldierAmountSpine;

	public GTextField upperLimit;

	public GTextField combatPower;

	public GTextField fighting;

	public GGraph CombatPowerSpine;

	public GImage CombatPowerIcon;

	public GButton CambatPowerBuff;

	public GGroup Bottomleftcorner;

	public GImage BossIcon;

	public GGroup tip;

	public Transition showSelf;

	public const string URL = "ui://rn232z3emol0is";

	public static string Name = "UI_EnemyIntroduction";

	private string ChangedSpecialityText = "";

	private string ChangedSpecialityName = "";

	private List<string> ChangedAbilities = null;

	private string ChangedSkin = "";

	private List<string> textureList = new List<string>();

	private HashSet<string> spineSet = new HashSet<string>();

	private string SoldierId;

	private GameEntityData EntityData;

	private FakeSoldier fakeSoldier;

	private string fakeSoldierCombatPower;

	private int fakeSoldierAtk;

	private int fakeSoldierDef;

	private long fakeSoldierHp;

	private bool isBoss;

	private bool isZBoss002;

	private List<LegendItemBrief> LegendItems;

	private bool hasFakeLegendItems;

	private int num = 0;

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

	private bool isAssistanceSoldier;

	public static string GetURL()
	{
		return "ui://rn232z3emol0is";
	}

	public static UI_EnemyIntroduction CreateInstance()
	{
		return (UI_EnemyIntroduction)(object)UIPackage.CreateObject("EnemyIntroduction", "EnemyIntroduction");
	}

	public static UI_EnemyIntroduction CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_EnemyIntroduction).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://rn232z3emol0is", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Expected O, but got Unknown
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Expected O, but got Unknown
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Expected O, but got Unknown
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Expected O, but got Unknown
		//IL_011d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0127: Expected O, but got Unknown
		//IL_0133: Unknown result type (might be due to invalid IL or missing references)
		//IL_013d: Expected O, but got Unknown
		//IL_0149: Unknown result type (might be due to invalid IL or missing references)
		//IL_0153: Expected O, but got Unknown
		//IL_015f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0169: Expected O, but got Unknown
		//IL_01b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bc: Expected O, but got Unknown
		//IL_0205: Unknown result type (might be due to invalid IL or missing references)
		//IL_020f: Expected O, but got Unknown
		//IL_0258: Unknown result type (might be due to invalid IL or missing references)
		//IL_0262: Expected O, but got Unknown
		//IL_02ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b5: Expected O, but got Unknown
		//IL_0300: Unknown result type (might be due to invalid IL or missing references)
		//IL_030a: Expected O, but got Unknown
		//IL_0355: Unknown result type (might be due to invalid IL or missing references)
		//IL_035f: Expected O, but got Unknown
		//IL_03aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b4: Expected O, but got Unknown
		//IL_03ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0409: Expected O, but got Unknown
		//IL_0454: Unknown result type (might be due to invalid IL or missing references)
		//IL_045e: Expected O, but got Unknown
		//IL_046a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0474: Expected O, but got Unknown
		//IL_0480: Unknown result type (might be due to invalid IL or missing references)
		//IL_048a: Expected O, but got Unknown
		//IL_04d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_04df: Expected O, but got Unknown
		//IL_04eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f5: Expected O, but got Unknown
		//IL_0501: Unknown result type (might be due to invalid IL or missing references)
		//IL_050b: Expected O, but got Unknown
		//IL_0517: Unknown result type (might be due to invalid IL or missing references)
		//IL_0521: Expected O, but got Unknown
		//IL_056c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0576: Expected O, but got Unknown
		//IL_0582: Unknown result type (might be due to invalid IL or missing references)
		//IL_058c: Expected O, but got Unknown
		//IL_0598: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a2: Expected O, but got Unknown
		//IL_05c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ce: Expected O, but got Unknown
		//IL_05da: Unknown result type (might be due to invalid IL or missing references)
		//IL_05e4: Expected O, but got Unknown
		//IL_05f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_05fa: Expected O, but got Unknown
		//IL_0606: Unknown result type (might be due to invalid IL or missing references)
		//IL_0610: Expected O, but got Unknown
		//IL_061c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0626: Expected O, but got Unknown
		//IL_0648: Unknown result type (might be due to invalid IL or missing references)
		//IL_0652: Expected O, but got Unknown
		//IL_065e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0668: Expected O, but got Unknown
		//IL_0674: Unknown result type (might be due to invalid IL or missing references)
		//IL_067e: Expected O, but got Unknown
		//IL_068a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0694: Expected O, but got Unknown
		//IL_06df: Unknown result type (might be due to invalid IL or missing references)
		//IL_06e9: Expected O, but got Unknown
		//IL_06f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ff: Expected O, but got Unknown
		//IL_070b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0715: Expected O, but got Unknown
		//IL_0760: Unknown result type (might be due to invalid IL or missing references)
		//IL_076a: Expected O, but got Unknown
		//IL_0776: Unknown result type (might be due to invalid IL or missing references)
		//IL_0780: Expected O, but got Unknown
		//IL_078c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0796: Expected O, but got Unknown
		//IL_07a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_07ac: Expected O, but got Unknown
		//IL_07b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_07c2: Expected O, but got Unknown
		//IL_07ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_07d8: Expected O, but got Unknown
		//IL_07e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_07ee: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		background = (GLoader)((GComponent)this).GetChild("background");
		mask = (GGraph)((GComponent)this).GetChild("mask");
		mask2 = (GGraph)((GComponent)this).GetChild("mask2");
		backgroundNormal = (GImage)((GComponent)this).GetChild("backgroundNormal");
		backgroundAdvanced = (GImage)((GComponent)this).GetChild("backgroundAdvanced");
		propertyBackgroundA = (GImage)((GComponent)this).GetChild("propertyBackgroundA");
		n77 = (GImage)((GComponent)this).GetChild("n77");
		n78 = (GImage)((GComponent)this).GetChild("n78");
		n79 = (GImage)((GComponent)this).GetChild("n79");
		SoldierAnimation = (UI_SoldierAnimarion)(object)((GComponent)this).GetChild("SoldierAnimation");
		attackPropertyBtn = (GButton)((GComponent)this).GetChild("attackPropertyBtn");
		defensePropertyBtn = (GButton)((GComponent)this).GetChild("defensePropertyBtn");
		n24 = (GButton)((GComponent)this).GetChild("n24");
		mercenaryLogo = (GImage)((GComponent)this).GetChild("mercenaryLogo");
		SoldierNamePotentialLevelBack = (GComponent)((GComponent)this).GetChild("SoldierNamePotentialLevelBack");
		title = (GRichTextField)((GComponent)this).GetChild("title");
		string id = "ui://rn232z3emol0is".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
		introduction = (GRichTextField)((GComponent)this).GetChild("introduction");
		string id2 = "ui://rn232z3emol0is".Replace("ui://", "") + "-" + ((GObject)introduction).id;
		((GObject)introduction).text = LanguagesManager.GetDesc(id2);
		attributes = (GTextField)((GComponent)this).GetChild("attributes");
		string id3 = "ui://rn232z3emol0is".Replace("ui://", "") + "-" + ((GObject)attributes).id;
		((GObject)attributes).text = LanguagesManager.GetDesc(id3);
		attackTiele = (GTextField)((GComponent)this).GetChild("attackTiele");
		string id4 = "ui://rn232z3emol0is".Replace("ui://", "") + "-" + ((GObject)attackTiele).id;
		((GObject)attackTiele).text = LanguagesManager.GetDesc(id4);
		defenseTiele = (GTextField)((GComponent)this).GetChild("defenseTiele");
		string id5 = "ui://rn232z3emol0is".Replace("ui://", "") + "-" + ((GObject)defenseTiele).id;
		((GObject)defenseTiele).text = LanguagesManager.GetDesc(id5);
		healthTiele = (GTextField)((GComponent)this).GetChild("healthTiele");
		string id6 = "ui://rn232z3emol0is".Replace("ui://", "") + "-" + ((GObject)healthTiele).id;
		((GObject)healthTiele).text = LanguagesManager.GetDesc(id6);
		attack = (GTextField)((GComponent)this).GetChild("attack");
		string id7 = "ui://rn232z3emol0is".Replace("ui://", "") + "-" + ((GObject)attack).id;
		((GObject)attack).text = LanguagesManager.GetDesc(id7);
		health = (GTextField)((GComponent)this).GetChild("health");
		string id8 = "ui://rn232z3emol0is".Replace("ui://", "") + "-" + ((GObject)health).id;
		((GObject)health).text = LanguagesManager.GetDesc(id8);
		defense = (GTextField)((GComponent)this).GetChild("defense");
		string id9 = "ui://rn232z3emol0is".Replace("ui://", "") + "-" + ((GObject)defense).id;
		((GObject)defense).text = LanguagesManager.GetDesc(id9);
		propertyBackgroundC = (GImage)((GComponent)this).GetChild("propertyBackgroundC");
		n81 = (GImage)((GComponent)this).GetChild("n81");
		specialityName = (GTextField)((GComponent)this).GetChild("specialityName");
		string id10 = "ui://rn232z3emol0is".Replace("ui://", "") + "-" + ((GObject)specialityName).id;
		((GObject)specialityName).text = LanguagesManager.GetDesc(id10);
		specialityText = (GRichTextField)((GComponent)this).GetChild("specialityText");
		n85 = (GImage)((GComponent)this).GetChild("n85");
		n86 = (GImage)((GComponent)this).GetChild("n86");
		n87 = (GTextField)((GComponent)this).GetChild("n87");
		string id11 = "ui://rn232z3emol0is".Replace("ui://", "") + "-" + ((GObject)n87).id;
		((GObject)n87).text = LanguagesManager.GetDesc(id11);
		skillTitleGroup = (GGroup)((GComponent)this).GetChild("skillTitleGroup");
		skillList = (GList)((GComponent)this).GetChild("skillList");
		rareness = (GLoader)((GComponent)this).GetChild("rareness");
		ExitAdvancedBtn = (UI_ExitAdvancedBtn)(object)((GComponent)this).GetChild("ExitAdvancedBtn");
		exit = (GButton)((GComponent)this).GetChild("exit");
		attackLoader = (GLoader)((GComponent)this).GetChild("attackLoader");
		defenseLoader = (GLoader)((GComponent)this).GetChild("defenseLoader");
		healthLoader = (GLoader)((GComponent)this).GetChild("healthLoader");
		racePicture = (GButton)((GComponent)this).GetChild("racePicture");
		LegendSlot = (UI_LegendSlot)(object)((GComponent)this).GetChild("LegendSlot");
		FormationSoldierAmountBack = (GImage)((GComponent)this).GetChild("FormationSoldierAmountBack");
		n65 = (GImage)((GComponent)this).GetChild("n65");
		CombatPowerSfxBack = (GGraph)((GComponent)this).GetChild("CombatPowerSfxBack");
		phalanx = (GTextField)((GComponent)this).GetChild("phalanx");
		string id12 = "ui://rn232z3emol0is".Replace("ui://", "") + "-" + ((GObject)phalanx).id;
		((GObject)phalanx).text = LanguagesManager.GetDesc(id12);
		FormationSoldierAmountSpine = (GGraph)((GComponent)this).GetChild("FormationSoldierAmountSpine");
		upperLimit = (GTextField)((GComponent)this).GetChild("upperLimit");
		combatPower = (GTextField)((GComponent)this).GetChild("combatPower");
		string id13 = "ui://rn232z3emol0is".Replace("ui://", "") + "-" + ((GObject)combatPower).id;
		((GObject)combatPower).text = LanguagesManager.GetDesc(id13);
		fighting = (GTextField)((GComponent)this).GetChild("fighting");
		CombatPowerSpine = (GGraph)((GComponent)this).GetChild("CombatPowerSpine");
		CombatPowerIcon = (GImage)((GComponent)this).GetChild("CombatPowerIcon");
		CambatPowerBuff = (GButton)((GComponent)this).GetChild("CambatPowerBuff");
		Bottomleftcorner = (GGroup)((GComponent)this).GetChild("Bottomleftcorner");
		BossIcon = (GImage)((GComponent)this).GetChild("BossIcon");
		tip = (GGroup)((GComponent)this).GetChild("tip");
		showSelf = ((GComponent)this).GetTransition("showSelf");
	}

	public void Init(Dictionary<string, object> parameters)
	{
		//IL_0bfc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c06: Expected O, but got Unknown
		//IL_0c19: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c23: Expected O, but got Unknown
		//IL_03d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e0: Expected O, but got Unknown
		//IL_03f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fd: Expected O, but got Unknown
		//IL_0daf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0de9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d04: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d4c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d5e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d68: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d6f: Expected O, but got Unknown
		//IL_05d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fb6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fc0: Expected O, but got Unknown
		//IL_108b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0618: Unknown result type (might be due to invalid IL or missing references)
		//IL_0505: Unknown result type (might be due to invalid IL or missing references)
		//IL_050a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0570: Unknown result type (might be due to invalid IL or missing references)
		//IL_0582: Unknown result type (might be due to invalid IL or missing references)
		//IL_058c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0593: Expected O, but got Unknown
		//IL_07af: Unknown result type (might be due to invalid IL or missing references)
		//IL_07da: Unknown result type (might be due to invalid IL or missing references)
		//IL_07e4: Expected O, but got Unknown
		//IL_0a40: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a4a: Expected O, but got Unknown
		//IL_0b15: Unknown result type (might be due to invalid IL or missing references)
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		if (parameters.TryGetValue("SpecialityText", out var value))
		{
			ChangedSpecialityText = value.ToString();
		}
		if (parameters.TryGetValue("SpecialityName", out var value2))
		{
			ChangedSpecialityName = value2.ToString();
		}
		if (parameters.TryGetValue("ChangedAbilities", out var value3))
		{
			ChangedAbilities = (List<string>)value3;
		}
		if (parameters.TryGetValue("ChangedSkin", out var value4))
		{
			ChangedSkin = value4.ToString();
		}
		if (parameters.TryGetValue("IsBoss", out var value5))
		{
			isBoss = (bool)value5;
		}
		isZBoss002 = parameters.TryGetValue("IsZBoss002", out var value6) && (bool)value6;
		if (parameters.TryGetValue("SoldierId", out var value7))
		{
			SoldierId = (string)value7;
			if (parameters.TryGetValue("EntityData", out var value8))
			{
				EntityData = (GameEntityData)value8;
			}
			else
			{
				if (!parameters.TryGetValue("FakeSoldierData", out var value9))
				{
					Debug.LogWarning((object)"参数EntityDatab不存在");
					End();
					return;
				}
				fakeSoldier = (FakeSoldier)value9;
				fakeSoldierCombatPower = parameters["CombatPower"].ToString();
				fakeSoldierAtk = (int)parameters["ATK"];
				fakeSoldierDef = (int)parameters["DEF"];
				object obj = parameters["HP"];
				if (obj is int num)
				{
					fakeSoldierHp = num;
				}
				else if (obj is string s)
				{
					fakeSoldierHp = long.Parse(s);
				}
				else if (obj is long num2)
				{
					fakeSoldierHp = num2;
				}
				else if (obj is float num3)
				{
					fakeSoldierHp = Mathf.RoundToInt(num3);
				}
				LegendItems = (List<LegendItemBrief>)parameters["LegendItemBrief"];
			}
			if (parameters.TryGetValue("Num", out var value10))
			{
				this.num = (int)value10;
				if (parameters.TryGetValue("IsAssistanceSoldier", out var value11))
				{
					isAssistanceSoldier = (bool)value11;
				}
				if (parameters.TryGetValue("FakeLegendItem", out var value12))
				{
					hasFakeLegendItems = true;
					LegendItems = (List<LegendItemBrief>)value12;
				}
				if (EntityData != null)
				{
					if (EntityData.Tags.Contains("IS_BOSS"))
					{
						((GObject)backgroundNormal).visible = false;
						((GObject)backgroundAdvanced).visible = true;
						((GObject)BossIcon).visible = true;
						((GObject)ExitAdvancedBtn).visible = true;
						((GObject)exit).visible = false;
					}
					else
					{
						((GObject)backgroundNormal).visible = true;
						((GObject)backgroundAdvanced).visible = false;
						((GObject)BossIcon).visible = false;
						((GObject)ExitAdvancedBtn).visible = false;
						((GObject)exit).visible = true;
					}
					Soldier soldier = GameManagers.Instance.SoldierManager.Get(SoldierId);
					((GObject)attackPropertyBtn).onClick.Set((EventCallback0)delegate
					{
						OpenAttackAndDefense((GObject)(object)attackPropertyBtn, type: true, (int)EntityData.DamageType);
					});
					((GObject)defensePropertyBtn).onClick.Set((EventCallback0)delegate
					{
						OpenAttackAndDefense((GObject)(object)defensePropertyBtn, type: false, (int)EntityData.ArmorType);
					});
					bool flag = ((EntityData.ModelName == "fort_1" || EntityData.ModelName == "fort_2") ? true : false);
					Object obj2 = Object.Instantiate(Resources.Load("SpineTest", typeof(GameObject)));
					GameObject val = (GameObject)(object)((obj2 is GameObject) ? obj2 : null);
					if ((Object)(object)val != (Object)null)
					{
						SkeletonAnimation animation = val.GetComponent<SkeletonAnimation>();
						string skinName = (flag ? "default" : EntityData.Skin);
						string model = (flag ? EntityData.ModelName : (EntityData.ModelName + "_" + skinName));
						SpawnManager.Instance.LoadSoldierSpine(val, model, isMask: true).Then((Action<SkeletonDataAsset>)delegate(SkeletonDataAsset asset)
						{
							if ((Object)(object)asset != (Object)null && (Object)(object)animation != (Object)null && !((GObject)this).isDisposed)
							{
								((SkeletonRenderer)animation).skeletonDataAsset = asset;
								((SkeletonRenderer)animation).initialSkinName = skinName;
								((SkeletonRenderer)animation).Initialize(true);
								animation.AnimationState.AddAnimation(0, "idle", true, 0f);
							}
						});
						Vector3 soldierScale = GetSoldierScale(EntityData.ModelName);
						if (flag)
						{
							((Vector3)(ref soldierScale))._002Ector(0.18f, 0.18f, 0.18f);
						}
						soldierScale.x *= 100f;
						soldierScale.y *= 100f;
						soldierScale.z *= 100f;
						val.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
						val.transform.localScale = soldierScale;
						GoWrapper val2 = new GoWrapper(val);
						val2.supportStencil = true;
						SoldierAnimation.icon.SetNativeObject((DisplayObject)(object)val2);
					}
					FGUIManager.Instance.AddTextSpecialEffects(SoldierAnimation.baseSpine, "MagicCircleBase", new Vector3(100f, 100f, 100f));
					if (!flag)
					{
						FGUIManager.Instance.AddTextSpecialEffects(SoldierAnimation.maskSpine, "MagicCircleMask", new Vector3(100f, 100f, 100f));
					}
					((GObject)title).text = soldier.Name;
					SoldierNamePotentialLevelBack.GetController("Level").selectedIndex = (parameters.ContainsKey("PotentialLevel") ? int.Parse(parameters["PotentialLevel"].ToString()) : soldier.PotentialLevel);
					((GObject)introduction).text = "";
					string text = $"{this.num}";
					((GObject)upperLimit).text = text;
					object value13;
					RealTimeCombatPowerModel realTimeCombatPowerModel = (parameters.TryGetValue("RealTimeCombatPowerModel", out value13) ? ((RealTimeCombatPowerModel)value13) : null);
					object value14;
					int num4 = (parameters.TryGetValue("CombatPowerIncrement", out value14) ? ((int)value14) : 0);
					object value15;
					float num5 = (parameters.TryGetValue("AttackIncrement", out value15) ? ((float)value15) : 0f);
					object value16;
					float num6 = (parameters.TryGetValue("DefenseIncrement", out value16) ? ((float)value16) : 0f);
					object value17;
					float num7 = (parameters.TryGetValue("HealthIncrement", out value17) ? ((float)value17) : 0f);
					((GObject)CambatPowerBuff).visible = realTimeCombatPowerModel?.Total ?? false;
					if (((GObject)CambatPowerBuff).visible)
					{
						((GObject)CambatPowerBuff).data = new Dictionary<string, object>
						{
							{
								"Title",
								realTimeCombatPowerModel.GetRealTimeCombatPowerText()
							},
							{
								"Pos",
								(object)new Vector2(551f, 750f)
							}
						};
						((GObject)CambatPowerBuff).onClick.Set(new EventCallback1(FGUIManager.Instance.OpenExclamationMarkPanel));
					}
					if (isZBoss002)
					{
						((GObject)fighting).text = "????????";
					}
					else if (!((GObject)CambatPowerBuff).visible)
					{
						((GObject)fighting).text = (EntityData.CombatPower * this.num).ToString();
					}
					else
					{
						((GObject)fighting).text = $"{EntityData.CombatPower * this.num}+[color=#aef224]{num4 * this.num}[/color]";
					}
					((GObject)attack).text = ((num5 > 0f) ? $"{Convert.ToInt32(EntityData.AttackDamage)}+[color=#1f8c15]{Convert.ToInt32(num5)}[/color]" : $"{Convert.ToInt32(EntityData.AttackDamage)}");
					((GObject)defense).text = ((num6 > 0f) ? $"{Convert.ToInt32(EntityData.Armor)}+[color=#1f8c15]{Convert.ToInt32(num6)}[/color]" : $"{Convert.ToInt32(EntityData.Armor)}");
					((GObject)health).text = ((num7 > 0f) ? (Convert.ToInt64(EntityData.Health).ShortNumberFormat() + "+[color=#1f8c15]" + Convert.ToInt64(num7).ShortNumberFormat() + "[/color]") : (Convert.ToInt64(EntityData.Health).ShortNumberFormat() ?? ""));
					attackLoader.url = $"ui://PublicResources/icon_atk_{(int)EntityData.DamageType}";
					defenseLoader.url = $"ui://PublicResources/icon_def_{(int)EntityData.ArmorType}";
					healthLoader.url = "ui://PublicResources/icon_hp";
					((GComponent)racePicture).GetController("Type").selectedIndex = FGUIManager.Instance.GetRaceIcon(soldier.Faction);
					((GObject)racePicture).onClick.Set((EventCallback0)delegate
					{
						FGUIManager.Instance.ShowRaceInfo(soldier.Faction, 1, ((GObject)this).sortingOrder);
					});
					((GObject)attackTiele).text = attackTypeNames[(uint)(EntityData.DamageType - 1)] + "：";
					((GObject)defenseTiele).text = armorTypeNames[(uint)(EntityData.ArmorType - 1)] + "：";
					((GObject)healthTiele).text = LanguagesManager.GetDesc("CsharpCodeZhTcText204") + "：";
					SkillListRenderer();
					((GObject)CombatPowerSfxBack).displayObject.Dispose();
					FGUIManager.Instance.AddTextSpecialEffects(CombatPowerSfxBack, "combat_power", new Vector3(((GObject)CombatPowerSfxBack).width / 4f, ((GObject)CombatPowerSfxBack).height * 6f, ((GObject)CombatPowerSfxBack).height));
					showTip();
					if (hasFakeLegendItems)
					{
						RenderLegendSlot();
					}
				}
				else if (fakeSoldier != null)
				{
					((GObject)backgroundNormal).visible = !isBoss;
					((GObject)backgroundAdvanced).visible = isBoss;
					((GObject)BossIcon).visible = isBoss;
					((GObject)ExitAdvancedBtn).visible = isBoss;
					((GObject)exit).visible = !isBoss;
					Soldier soldier2 = GameManagers.Instance.SoldierManager.Get(SoldierId);
					((GObject)attackPropertyBtn).onClick.Set((EventCallback0)delegate
					{
						OpenAttackAndDefense((GObject)(object)attackPropertyBtn, type: true, fakeSoldier.DamageType);
					});
					((GObject)defensePropertyBtn).onClick.Set((EventCallback0)delegate
					{
						OpenAttackAndDefense((GObject)(object)defensePropertyBtn, type: false, fakeSoldier.ArmorType);
					});
					Object obj3 = Object.Instantiate(Resources.Load("SpineTest", typeof(GameObject)));
					GameObject val3 = (GameObject)(object)((obj3 is GameObject) ? obj3 : null);
					int num8 = (fakeSoldier.PotentialLevel + 2) / 2;
					string skin = ((!string.IsNullOrEmpty(ChangedSkin)) ? ChangedSkin : $"skin{num8}");
					if ((Object)(object)val3 != (Object)null)
					{
						SkeletonAnimation animation2 = val3.GetComponent<SkeletonAnimation>();
						SpawnManager.Instance.LoadSoldierSpine(val3, fakeSoldier.Id + "_" + skin, isMask: true).Then((Action<SkeletonDataAsset>)delegate(SkeletonDataAsset asset)
						{
							if ((Object)(object)asset != (Object)null && (Object)(object)animation2 != (Object)null && !((GObject)this).isDisposed)
							{
								((SkeletonRenderer)animation2).skeletonDataAsset = asset;
								((SkeletonRenderer)animation2).Initialize(true);
								SpineHelper.SetSkin((ISkeletonAnimation)(object)animation2, skin);
								animation2.AnimationState.AddAnimation(0, "idle", true, 0f);
							}
						});
						Vector3 soldierScale2 = GetSoldierScale(fakeSoldier.Id);
						soldierScale2.x *= 100f;
						soldierScale2.y *= 100f;
						soldierScale2.z *= 100f;
						val3.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
						val3.transform.localScale = soldierScale2;
						GoWrapper val4 = new GoWrapper(val3);
						val4.supportStencil = true;
						SoldierAnimation.icon.SetNativeObject((DisplayObject)(object)val4);
					}
					FGUIManager.Instance.AddTextSpecialEffects(SoldierAnimation.baseSpine, "MagicCircleBase", new Vector3(100f, 100f, 100f));
					FGUIManager.Instance.AddTextSpecialEffects(SoldierAnimation.maskSpine, "MagicCircleMask", new Vector3(100f, 100f, 100f));
					((GObject)title).text = soldier2.Name;
					SoldierNamePotentialLevelBack.GetController("Level").selectedIndex = (parameters.ContainsKey("PotentialLevel") ? int.Parse(parameters["PotentialLevel"].ToString()) : soldier2.PotentialLevel);
					((GObject)introduction).text = "";
					string text2 = $"{this.num}";
					((GObject)upperLimit).text = text2;
					((GObject)fighting).text = fakeSoldierCombatPower ?? "";
					((GObject)attack).text = $"{Convert.ToInt32(fakeSoldierAtk)}";
					((GObject)defense).text = $"{Convert.ToInt32(fakeSoldierDef)}";
					((GObject)health).text = fakeSoldierHp.ShortNumberFormat() ?? "";
					attackLoader.url = $"ui://PublicResources/icon_atk_{fakeSoldier.DamageType}";
					defenseLoader.url = $"ui://PublicResources/icon_def_{fakeSoldier.ArmorType}";
					healthLoader.url = "ui://PublicResources/icon_hp";
					((GComponent)racePicture).GetController("Type").selectedIndex = FGUIManager.Instance.GetRaceIcon(soldier2.Faction);
					((GObject)racePicture).onClick.Set((EventCallback0)delegate
					{
						FGUIManager.Instance.ShowRaceInfo(soldier2.Faction, 1, ((GObject)this).sortingOrder);
					});
					((GObject)attackTiele).text = attackTypeNames[fakeSoldier.DamageType - 1] + "：";
					((GObject)defenseTiele).text = armorTypeNames[fakeSoldier.ArmorType - 1] + "：";
					((GObject)healthTiele).text = LanguagesManager.GetDesc("CsharpCodeZhTcText204") + "：";
					SkillListRendererForFakeSoldier();
					((GObject)CombatPowerSfxBack).displayObject.Dispose();
					FGUIManager.Instance.AddTextSpecialEffects(CombatPowerSfxBack, "combat_power", new Vector3(((GObject)CombatPowerSfxBack).width / 4f, ((GObject)CombatPowerSfxBack).height * 6f, ((GObject)CombatPowerSfxBack).height));
					RenderLegendSlot();
					showTip();
				}
				((GObject)mercenaryLogo).visible = isAssistanceSoldier;
			}
			else
			{
				End();
			}
		}
		else
		{
			End();
		}
	}

	private void PlaySoldierVoice()
	{
		if (EntityData != null)
		{
			UiAudioManager.Instance.PlaySoldierVoice(EntityData.ModelName, UiAudioManager.SoldierVoiceType.Onomatopoeia);
		}
		else if (fakeSoldier != null)
		{
			UiAudioManager.Instance.PlaySoldierVoice(fakeSoldier.Id, UiAudioManager.SoldierVoiceType.Onomatopoeia);
		}
	}

	private void showTip()
	{
		GTweener val = ((GObject)tip).TweenMoveY(128f, 0.3f);
		val.SetEase((EaseType)26);
		val = ((GObject)tip).TweenFade(1f, 0.3f);
		val.SetEase((EaseType)5);
		((GObject)ExitAdvancedBtn).alpha = 1f;
	}

	public void OnShow()
	{
		UiTagManager instance = UiTagManager.Instance;
		instance.Register("EnemyIntroduction.Exit", ExitAdvancedBtn);
		PlaySoldierVoice();
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
		((GObject)exit).onClick.Add(new EventCallback0(End));
		((GObject)ExitAdvancedBtn).onClick.Add(new EventCallback0(End));
		((GObject)specialityText).onClickLink.Set(new EventCallback1(OnClickEffectLink));
		((GObject)SoldierAnimation).onClick.Add(new EventCallback0(PlaySoldierVoice));
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected O, but got Unknown
		((GObject)exit).onClick.Remove(new EventCallback0(End));
		((GObject)ExitAdvancedBtn).onClick.Remove(new EventCallback0(End));
		((GObject)specialityText).onClickLink.Clear();
		((GObject)SoldierAnimation).onClick.Remove(new EventCallback0(PlaySoldierVoice));
	}

	public void BeforeDestroy()
	{
		UiTagManager instance = UiTagManager.Instance;
		instance.Unregister("EnemyIntroduction.Exit", ExitAdvancedBtn);
		instance.Unregister("EnemyIntroduction.BossSkill");
	}

	public void Destroy()
	{
	}

	private Vector3 GetSoldierScale(string sid)
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		if (isZBoss002)
		{
			return new Vector3(0.25f, 0.25f, 0.25f);
		}
		int soldierFxSize = GameManagers.Instance.SoldierManager.GetSoldierFxSize(sid);
		Vector3 result = default(Vector3);
		((Vector3)(ref result))._002Ector(0.5f, 0.5f, 0.5f);
		switch (soldierFxSize)
		{
		case 0:
		case 1:
			((Vector3)(ref result))._002Ector(0.5f, 0.5f, 0.5f);
			break;
		case 2:
			((Vector3)(ref result))._002Ector(0.45f, 0.45f, 0.45f);
			break;
		case 3:
			((Vector3)(ref result))._002Ector(0.4f, 0.4f, 0.4f);
			break;
		}
		return result;
	}

	private void RenderLegendSlot()
	{
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Expected O, but got Unknown
		if (LegendItems != null && LegendItems.Count > 0)
		{
			LegendSlot.LegendItemSlots.itemRenderer = new ListItemRenderer(LegendSlotItemRender);
			LegendSlot.LegendItemSlots.numItems = LegendItems.Count;
			LegendSlot.LegendItemSlots.ResizeToFit(LegendItems.Count);
			LegendSlot.SlotNum.selectedIndex = ((LegendSlot.LegendItemSlots.numItems > 1) ? 1 : 0);
			((GObject)LegendSlot.Tip).visible = false;
			((GObject)LegendSlot).visible = true;
		}
	}

	private void LegendSlotItemRender(int index, GObject obj)
	{
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Expected O, but got Unknown
		LegendItemBrief legendItemBrief = LegendItems[index];
		UI_LegendItemSlot uI_LegendItemSlot = obj as UI_LegendItemSlot;
		uI_LegendItemSlot.Type.selectedIndex = 0;
		UiHelper.RenderLegendItem(uI_LegendItemSlot.Icon, legendItemBrief, UiHelper.TextColorType.Dark, textureList, 2);
		((GObject)uI_LegendItemSlot).data = legendItemBrief;
		((GObject)uI_LegendItemSlot).onClick.Set(new EventCallback1(OpenLegendItemInfoDialog));
	}

	private void OpenLegendItemInfoDialog(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		LegendItemBrief itemBrief = (LegendItemBrief)((GObject)context.sender).data;
		UI_LegendItemInfoDialog.DialogInfo = new LegendItemInfoDialogInfo(null, "", -1, 3, null, itemBrief);
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_LegendItemInfoDialog.Name, null);
	}

	private void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
		for (int i = 0; i < textureList.Count; i++)
		{
			AssetsManager.Instance.UnloadAsset<Texture2D>(textureList[i]);
		}
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

	private void SkillListRenderer()
	{
		List<string> list = new List<string>();
		string key = null;
		for (int i = 0; i < EntityData.AbilityIdList.Count; i++)
		{
			if (i == EntityData.AbilityIdList.Count - 1)
			{
				key = EntityData.AbilityIdList[i];
			}
			else if (GDMgr.TryGetWithErrorHandling<GDEAbilityData>(EntityData.AbilityIdList[i]).Visible)
			{
				list.Add(EntityData.AbilityIdList[i]);
			}
		}
		GDEAbilityData gDEAbilityData = GDMgr.TryGetWithErrorHandling<GDEAbilityData>(key);
		((GObject)specialityName).text = (string.IsNullOrEmpty(ChangedSpecialityName) ? $"{gDEAbilityData.Name} LV{gDEAbilityData.Level}" : ChangedSpecialityName);
		((GObject)specialityText).text = (string.IsNullOrEmpty(ChangedSpecialityText) ? Singleton<AbilityDataManager>.Instance.GetDescription(gDEAbilityData.Key) : ChangedSpecialityText);
		skillList.numItems = list.Count;
		for (int j = 0; j < list.Count; j++)
		{
			bool isUnLocked = true;
			RenderSkillListItem(list[j], ((GComponent)skillList).GetChildAt(j).asButton, isUnLocked, -1);
			if (j == 0)
			{
				UiTagManager instance = UiTagManager.Instance;
				instance.Register("EnemyIntroduction.BossSkill", ((GComponent)skillList).GetChildAt(j).asButton);
			}
		}
		skillList.numItems = list.Count;
	}

	private void SkillListRendererForFakeSoldier()
	{
		List<string> list = new List<string>();
		Dictionary<string, int> dictionary = fakeSoldier.AbilitiesUnlockState();
		List<string> list2 = ((ChangedAbilities != null) ? ChangedAbilities : ((EntityData == null) ? fakeSoldier.UnlockedAbilityList : EntityData.AbilityIdList));
		for (int i = 0; i < list2.Count; i++)
		{
			if (i != list2.Count - 1 && GDMgr.TryGetWithErrorHandling<GDEAbilityData>(list2[i]).Visible)
			{
				list.Add(list2[i]);
			}
		}
		string currentLevelFeatureAbilityId = fakeSoldier.GetCurrentLevelFeatureAbilityId();
		int featureAbilityLevel = fakeSoldier.GetFeatureAbilityLevel();
		GDEAbilityData gDEAbilityData = GDMgr.TryGetWithErrorHandling<GDEAbilityData>(currentLevelFeatureAbilityId);
		((GObject)specialityName).text = (string.IsNullOrEmpty(ChangedSpecialityName) ? $"{gDEAbilityData.Name} LV{featureAbilityLevel}" : ChangedSpecialityName);
		((GObject)specialityText).text = (string.IsNullOrEmpty(ChangedSpecialityText) ? Singleton<AbilityDataManager>.Instance.GetDescription(gDEAbilityData.Key) : ChangedSpecialityText);
		int num = Mathf.Min(list.Count, 3);
		skillList.numItems = num;
		for (int j = 0; j < num; j++)
		{
			bool isUnLocked = ChangedAbilities != null || dictionary[list[j]] <= fakeSoldier.PotentialLevel;
			RenderSkillListItem(list[j], ((GComponent)skillList).GetChildAt(j).asButton, isUnLocked, -1);
		}
		skillList.numItems = num;
	}

	private void RenderSkillListItem(string skillId, GButton button, bool isUnLocked, int limit)
	{
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Expected O, but got Unknown
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Expected O, but got Unknown
		GDEAbilityData abilityData = GDMgr.TryGetWithErrorHandling<GDEAbilityData>(skillId);
		((GComponent)((GComponent)((GObject)button).asButton).GetChild("IconBtn").asButton).GetChild("IconLoader").asLoader.LoadAbilityIcon(abilityData.Icon);
		if (isUnLocked)
		{
			((GComponent)((GObject)button).asButton).GetChild("IconBtn").grayed = false;
			((GObject)button).touchable = true;
			((GObject)button).onClick.Set((EventCallback0)delegate
			{
				SkillDetailPopup(abilityData, limit, isUnLocked);
			});
		}
		else
		{
			((GComponent)((GObject)button).asButton).GetChild("IconBtn").grayed = true;
			((GObject)button).onClick.Set((EventCallback0)delegate
			{
				SkillDetailPopup(abilityData, limit, isUnLocked);
			});
			((GObject)button).touchable = true;
		}
		int num = 5 - 5 * ((GComponent)skillList).GetChildIndex((GObject)(object)button);
		((GComponent)((GObject)button).asButton).GetChild("n16").rotation = num;
	}

	public void SkillDetailPopup(GDEAbilityData abilityData, int limit, bool isUnlock)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		Vector2 val = ((GObject)skillList).LocalToGlobal(Vector2.zero);
		val = ((GObject)this).GlobalToLocal(val) + new Vector2(200f, 20f);
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		dictionary.Add("Pos", val);
		dictionary.Add("Data", abilityData);
		dictionary.Add("Limit", limit);
		dictionary.Add("State", isUnlock);
		dictionary.Add("GList", skillList);
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_SkillDetailPopup.Name, dictionary);
	}

	private void OnClickEffectLink(EventContext e)
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_SkillEffectPanel.Name, new Dictionary<string, object> { 
		{
			"EffectKey",
			e.data.ToString()
		} });
	}
}
