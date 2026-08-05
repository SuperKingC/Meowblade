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
using UnityEngine;

namespace UI.UpgradePotential;

public class UI_UpgradeSuccessPanel : GComponent, IUiController
{
	public Controller PageSwitch;

	public GGraph mask;

	public GLoader background;

	public GGraph VictorySfx;

	public GComponent victoryLight;

	public GImage n111;

	public GTextField title;

	public GGroup titleGroup;

	public GLoader AnimBgLoader;

	public GGraph baseSpine;

	public GGraph Spine;

	public GGraph maskSpine;

	public GGraph cover;

	public GGroup soldierImage;

	public UI_confirmBtn confirmBtn;

	public GImage arrow;

	public UI_propertyBackBtn n108;

	public UI_armItem nextSoldierIcon;

	public GGroup nextPropertyBack;

	public UI_propertyBackBtn n109;

	public UI_armItem curSoldierIcon;

	public GGroup curPropertyBack;

	public GTextField curFightTitle1;

	public GTextField curFight1;

	public GGroup curFightGroup1;

	public GTextField curLevelTitle1;

	public GTextField curLevel1;

	public GGroup curLevelGroup1;

	public GTextField curAttackTitle1;

	public GTextField curAttack1;

	public GGroup curAttackGroup1;

	public GTextField curDeffenseTitle1;

	public GTextField curDeffense1;

	public GGroup curDeffenseGroup1;

	public GTextField curHealthTitle1;

	public GTextField curHealth1;

	public GGroup curHealthGroup1;

	public GGroup curPropertys1;

	public GTextField nextFightTitle1;

	public GTextField nextFight1;

	public GImage n125;

	public GGroup nextFightGroup1;

	public GTextField nextLevelTitle1;

	public GTextField nextLevel1;

	public GImage n128;

	public GGroup nextLevelGroup1;

	public GTextField nextAttackTitle1;

	public GTextField nextAttack1;

	public GImage n127;

	public GGroup nextAttackGroup1;

	public GTextField nextDeffense1;

	public GTextField nextDeffenseTitle1;

	public GImage n126;

	public GGroup nextDeffenseGroup1;

	public GTextField nextHealthTitle1;

	public GTextField nextHealth1;

	public GImage n129;

	public GGroup nextHealthGroup1;

	public GGroup nextPropertys1;

	public GTextField curFightTitle2;

	public GTextField curFight2;

	public GGroup curFightGroup2;

	public GTextField curAttackTitle2;

	public GTextField curAttack2;

	public GGroup curAttackGroup2;

	public GTextField curDeffenseTitle2;

	public GTextField curDeffense2;

	public GGroup curDeffenseGroup2;

	public GTextField curHealthTitle2;

	public GTextField curHealth2;

	public GGroup curHealthGroup2;

	public GGroup curPropertys2;

	public GTextField nextFightTitle2;

	public GTextField nextFight2;

	public GImage n121;

	public GGroup nextFightGroup2;

	public GTextField nextAttackTitle2;

	public GTextField nextAttack2;

	public GImage n122;

	public GGroup nextAttackGroup2;

	public GTextField nextDeffenseTitle2;

	public GTextField nextDeffense2;

	public GImage n123;

	public GGroup nextDeffenseGroup2;

	public GTextField nextHealthTitle2;

	public GTextField nextHealth2;

	public GImage n124;

	public GGroup nextHealthGroup2;

	public GGroup nextPropertys2;

	public GImage skillBack;

	public GGraph showSkillBack;

	public GTextField unLockTitle;

	public UI_SkillIntorduction SkillIntorduction;

	public GLoader FloorLoader;

	public GLoader skillIcon;

	public GLoader FrameLoader;

	public GGroup showSkill;

	public GImage star0;

	public GImage star1;

	public GImage star2;

	public GImage star3;

	public GImage star4;

	public GGraph StarSfxBack0;

	public GGraph StarSfxBack1;

	public GGraph StarSfxBack2;

	public GGraph StarSfxBack3;

	public GGraph StarSfxBack4;

	public GGroup starAnimationGroup;

	public GGraph toEndMask;

	public Transition showSoldierImageChange;

	public Transition showNextProperty1;

	public Transition showNextProperty2;

	public Transition starIncrease;

	public Transition showNextProperty3;

	public const string URL = "ui://l5ik1uclic7jt7w";

	public static string Name = "UI_UpgradeSuccessPanel";

	private string uiTitleAnimName = "ui_title_lightray_rotate";

	private List<string> textureList = new List<string>();

	private string soldierId;

	private FakeSoldier fakeSoldier;

	private FakeSoldier soldier;

	private bool existSpine;

	private Dictionary<string, int> bonus = new Dictionary<string, int>();

	private readonly List<string> _skillList = new List<string>();

	private bool isLevelUp;

	private GComponent SoliderSoulStone;

	private float changePageDelay;

	private bool MythAvailable => Define.SoldierMythUnderDevelopment();

	public void SetControllerPageText()
	{
		string id = string.Format("{0}-{1}-{2}", "ui://l5ik1uclic7jt7w".Replace("ui://", ""), ((GObject)title).id, PageSwitch.selectedIndex);
		((GObject)title).text = LanguagesManager.GetDesc(id);
		string id2 = string.Format("{0}-{1}-{2}", "ui://l5ik1uclic7jt7w".Replace("ui://", ""), ((GObject)curAttackTitle2).id, PageSwitch.selectedIndex);
		((GObject)curAttackTitle2).text = LanguagesManager.GetDesc(id2);
		string id3 = string.Format("{0}-{1}-{2}", "ui://l5ik1uclic7jt7w".Replace("ui://", ""), ((GObject)curDeffenseTitle2).id, PageSwitch.selectedIndex);
		((GObject)curDeffenseTitle2).text = LanguagesManager.GetDesc(id3);
		string id4 = string.Format("{0}-{1}-{2}", "ui://l5ik1uclic7jt7w".Replace("ui://", ""), ((GObject)curHealthTitle2).id, PageSwitch.selectedIndex);
		((GObject)curHealthTitle2).text = LanguagesManager.GetDesc(id4);
		string id5 = string.Format("{0}-{1}-{2}", "ui://l5ik1uclic7jt7w".Replace("ui://", ""), ((GObject)nextAttackTitle2).id, PageSwitch.selectedIndex);
		((GObject)nextAttackTitle2).text = LanguagesManager.GetDesc(id5);
		string id6 = string.Format("{0}-{1}-{2}", "ui://l5ik1uclic7jt7w".Replace("ui://", ""), ((GObject)nextDeffenseTitle2).id, PageSwitch.selectedIndex);
		((GObject)nextDeffenseTitle2).text = LanguagesManager.GetDesc(id6);
		string id7 = string.Format("{0}-{1}-{2}", "ui://l5ik1uclic7jt7w".Replace("ui://", ""), ((GObject)nextHealthTitle2).id, PageSwitch.selectedIndex);
		((GObject)nextHealthTitle2).text = LanguagesManager.GetDesc(id7);
	}

	public static string GetURL()
	{
		return "ui://l5ik1uclic7jt7w";
	}

	public static UI_UpgradeSuccessPanel CreateInstance()
	{
		return (UI_UpgradeSuccessPanel)(object)UIPackage.CreateObject("UpgradePotential", "UpgradeSuccessPanel");
	}

	public static UI_UpgradeSuccessPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_UpgradeSuccessPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://l5ik1uclic7jt7w", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Expected O, but got Unknown
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Expected O, but got Unknown
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Expected O, but got Unknown
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_015f: Expected O, but got Unknown
		//IL_016b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0175: Expected O, but got Unknown
		//IL_0197: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a1: Expected O, but got Unknown
		//IL_01d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e3: Expected O, but got Unknown
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
		//IL_0303: Unknown result type (might be due to invalid IL or missing references)
		//IL_030d: Expected O, but got Unknown
		//IL_0356: Unknown result type (might be due to invalid IL or missing references)
		//IL_0360: Expected O, but got Unknown
		//IL_036c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0376: Expected O, but got Unknown
		//IL_03c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03cb: Expected O, but got Unknown
		//IL_0416: Unknown result type (might be due to invalid IL or missing references)
		//IL_0420: Expected O, but got Unknown
		//IL_042c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0436: Expected O, but got Unknown
		//IL_0481: Unknown result type (might be due to invalid IL or missing references)
		//IL_048b: Expected O, but got Unknown
		//IL_04d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e0: Expected O, but got Unknown
		//IL_04ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f6: Expected O, but got Unknown
		//IL_0541: Unknown result type (might be due to invalid IL or missing references)
		//IL_054b: Expected O, but got Unknown
		//IL_0596: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a0: Expected O, but got Unknown
		//IL_05ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_05b6: Expected O, but got Unknown
		//IL_05c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_05cc: Expected O, but got Unknown
		//IL_0617: Unknown result type (might be due to invalid IL or missing references)
		//IL_0621: Expected O, but got Unknown
		//IL_062d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0637: Expected O, but got Unknown
		//IL_0643: Unknown result type (might be due to invalid IL or missing references)
		//IL_064d: Expected O, but got Unknown
		//IL_0659: Unknown result type (might be due to invalid IL or missing references)
		//IL_0663: Expected O, but got Unknown
		//IL_06ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_06b8: Expected O, but got Unknown
		//IL_0703: Unknown result type (might be due to invalid IL or missing references)
		//IL_070d: Expected O, but got Unknown
		//IL_0719: Unknown result type (might be due to invalid IL or missing references)
		//IL_0723: Expected O, but got Unknown
		//IL_072f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0739: Expected O, but got Unknown
		//IL_0784: Unknown result type (might be due to invalid IL or missing references)
		//IL_078e: Expected O, but got Unknown
		//IL_07d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_07e3: Expected O, but got Unknown
		//IL_07ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_07f9: Expected O, but got Unknown
		//IL_0805: Unknown result type (might be due to invalid IL or missing references)
		//IL_080f: Expected O, but got Unknown
		//IL_085a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0864: Expected O, but got Unknown
		//IL_08af: Unknown result type (might be due to invalid IL or missing references)
		//IL_08b9: Expected O, but got Unknown
		//IL_08c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_08cf: Expected O, but got Unknown
		//IL_08db: Unknown result type (might be due to invalid IL or missing references)
		//IL_08e5: Expected O, but got Unknown
		//IL_0930: Unknown result type (might be due to invalid IL or missing references)
		//IL_093a: Expected O, but got Unknown
		//IL_0985: Unknown result type (might be due to invalid IL or missing references)
		//IL_098f: Expected O, but got Unknown
		//IL_099b: Unknown result type (might be due to invalid IL or missing references)
		//IL_09a5: Expected O, but got Unknown
		//IL_09b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_09bb: Expected O, but got Unknown
		//IL_09c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_09d1: Expected O, but got Unknown
		//IL_0a1c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a26: Expected O, but got Unknown
		//IL_0a32: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a3c: Expected O, but got Unknown
		//IL_0a48: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a52: Expected O, but got Unknown
		//IL_0a9d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aa7: Expected O, but got Unknown
		//IL_0af2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0afc: Expected O, but got Unknown
		//IL_0b08: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b12: Expected O, but got Unknown
		//IL_0b5d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b67: Expected O, but got Unknown
		//IL_0bb2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bbc: Expected O, but got Unknown
		//IL_0bc8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bd2: Expected O, but got Unknown
		//IL_0c1d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c27: Expected O, but got Unknown
		//IL_0c72: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c7c: Expected O, but got Unknown
		//IL_0c88: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c92: Expected O, but got Unknown
		//IL_0c9e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ca8: Expected O, but got Unknown
		//IL_0cf3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cfd: Expected O, but got Unknown
		//IL_0d09: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d13: Expected O, but got Unknown
		//IL_0d1f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d29: Expected O, but got Unknown
		//IL_0d35: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d3f: Expected O, but got Unknown
		//IL_0d8a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d94: Expected O, but got Unknown
		//IL_0ddf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0de9: Expected O, but got Unknown
		//IL_0df5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dff: Expected O, but got Unknown
		//IL_0e0b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e15: Expected O, but got Unknown
		//IL_0e60: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e6a: Expected O, but got Unknown
		//IL_0eb5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ebf: Expected O, but got Unknown
		//IL_0ecb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ed5: Expected O, but got Unknown
		//IL_0ee1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0eeb: Expected O, but got Unknown
		//IL_0f36: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f40: Expected O, but got Unknown
		//IL_0f8b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f95: Expected O, but got Unknown
		//IL_0fa1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fab: Expected O, but got Unknown
		//IL_0fb7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fc1: Expected O, but got Unknown
		//IL_0fcd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fd7: Expected O, but got Unknown
		//IL_0fe3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fed: Expected O, but got Unknown
		//IL_0ff9: Unknown result type (might be due to invalid IL or missing references)
		//IL_1003: Expected O, but got Unknown
		//IL_1064: Unknown result type (might be due to invalid IL or missing references)
		//IL_106e: Expected O, but got Unknown
		//IL_107a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1084: Expected O, but got Unknown
		//IL_1090: Unknown result type (might be due to invalid IL or missing references)
		//IL_109a: Expected O, but got Unknown
		//IL_10a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_10b0: Expected O, but got Unknown
		//IL_10bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_10c6: Expected O, but got Unknown
		//IL_10d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_10dc: Expected O, but got Unknown
		//IL_10e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_10f2: Expected O, but got Unknown
		//IL_10fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_1108: Expected O, but got Unknown
		//IL_1114: Unknown result type (might be due to invalid IL or missing references)
		//IL_111e: Expected O, but got Unknown
		//IL_112a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1134: Expected O, but got Unknown
		//IL_1140: Unknown result type (might be due to invalid IL or missing references)
		//IL_114a: Expected O, but got Unknown
		//IL_1156: Unknown result type (might be due to invalid IL or missing references)
		//IL_1160: Expected O, but got Unknown
		//IL_116c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1176: Expected O, but got Unknown
		//IL_1182: Unknown result type (might be due to invalid IL or missing references)
		//IL_118c: Expected O, but got Unknown
		//IL_1198: Unknown result type (might be due to invalid IL or missing references)
		//IL_11a2: Expected O, but got Unknown
		//IL_11ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_11b8: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		PageSwitch = ((GComponent)this).GetController("PageSwitch");
		mask = (GGraph)((GComponent)this).GetChild("mask");
		background = (GLoader)((GComponent)this).GetChild("background");
		VictorySfx = (GGraph)((GComponent)this).GetChild("VictorySfx");
		victoryLight = (GComponent)((GComponent)this).GetChild("victoryLight");
		n111 = (GImage)((GComponent)this).GetChild("n111");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://l5ik1uclic7jt7w".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
		titleGroup = (GGroup)((GComponent)this).GetChild("titleGroup");
		AnimBgLoader = (GLoader)((GComponent)this).GetChild("AnimBgLoader");
		baseSpine = (GGraph)((GComponent)this).GetChild("baseSpine");
		Spine = (GGraph)((GComponent)this).GetChild("Spine");
		maskSpine = (GGraph)((GComponent)this).GetChild("maskSpine");
		cover = (GGraph)((GComponent)this).GetChild("cover");
		soldierImage = (GGroup)((GComponent)this).GetChild("soldierImage");
		confirmBtn = (UI_confirmBtn)(object)((GComponent)this).GetChild("confirmBtn");
		arrow = (GImage)((GComponent)this).GetChild("arrow");
		n108 = (UI_propertyBackBtn)(object)((GComponent)this).GetChild("n108");
		nextSoldierIcon = (UI_armItem)(object)((GComponent)this).GetChild("nextSoldierIcon");
		nextPropertyBack = (GGroup)((GComponent)this).GetChild("nextPropertyBack");
		n109 = (UI_propertyBackBtn)(object)((GComponent)this).GetChild("n109");
		curSoldierIcon = (UI_armItem)(object)((GComponent)this).GetChild("curSoldierIcon");
		curPropertyBack = (GGroup)((GComponent)this).GetChild("curPropertyBack");
		curFightTitle1 = (GTextField)((GComponent)this).GetChild("curFightTitle1");
		string id2 = "ui://l5ik1uclic7jt7w".Replace("ui://", "") + "-" + ((GObject)curFightTitle1).id;
		((GObject)curFightTitle1).text = LanguagesManager.GetDesc(id2);
		curFight1 = (GTextField)((GComponent)this).GetChild("curFight1");
		curFightGroup1 = (GGroup)((GComponent)this).GetChild("curFightGroup1");
		curLevelTitle1 = (GTextField)((GComponent)this).GetChild("curLevelTitle1");
		string id3 = "ui://l5ik1uclic7jt7w".Replace("ui://", "") + "-" + ((GObject)curLevelTitle1).id;
		((GObject)curLevelTitle1).text = LanguagesManager.GetDesc(id3);
		curLevel1 = (GTextField)((GComponent)this).GetChild("curLevel1");
		string id4 = "ui://l5ik1uclic7jt7w".Replace("ui://", "") + "-" + ((GObject)curLevel1).id;
		((GObject)curLevel1).text = LanguagesManager.GetDesc(id4);
		curLevelGroup1 = (GGroup)((GComponent)this).GetChild("curLevelGroup1");
		curAttackTitle1 = (GTextField)((GComponent)this).GetChild("curAttackTitle1");
		string id5 = "ui://l5ik1uclic7jt7w".Replace("ui://", "") + "-" + ((GObject)curAttackTitle1).id;
		((GObject)curAttackTitle1).text = LanguagesManager.GetDesc(id5);
		curAttack1 = (GTextField)((GComponent)this).GetChild("curAttack1");
		string id6 = "ui://l5ik1uclic7jt7w".Replace("ui://", "") + "-" + ((GObject)curAttack1).id;
		((GObject)curAttack1).text = LanguagesManager.GetDesc(id6);
		curAttackGroup1 = (GGroup)((GComponent)this).GetChild("curAttackGroup1");
		curDeffenseTitle1 = (GTextField)((GComponent)this).GetChild("curDeffenseTitle1");
		string id7 = "ui://l5ik1uclic7jt7w".Replace("ui://", "") + "-" + ((GObject)curDeffenseTitle1).id;
		((GObject)curDeffenseTitle1).text = LanguagesManager.GetDesc(id7);
		curDeffense1 = (GTextField)((GComponent)this).GetChild("curDeffense1");
		string id8 = "ui://l5ik1uclic7jt7w".Replace("ui://", "") + "-" + ((GObject)curDeffense1).id;
		((GObject)curDeffense1).text = LanguagesManager.GetDesc(id8);
		curDeffenseGroup1 = (GGroup)((GComponent)this).GetChild("curDeffenseGroup1");
		curHealthTitle1 = (GTextField)((GComponent)this).GetChild("curHealthTitle1");
		string id9 = "ui://l5ik1uclic7jt7w".Replace("ui://", "") + "-" + ((GObject)curHealthTitle1).id;
		((GObject)curHealthTitle1).text = LanguagesManager.GetDesc(id9);
		curHealth1 = (GTextField)((GComponent)this).GetChild("curHealth1");
		string id10 = "ui://l5ik1uclic7jt7w".Replace("ui://", "") + "-" + ((GObject)curHealth1).id;
		((GObject)curHealth1).text = LanguagesManager.GetDesc(id10);
		curHealthGroup1 = (GGroup)((GComponent)this).GetChild("curHealthGroup1");
		curPropertys1 = (GGroup)((GComponent)this).GetChild("curPropertys1");
		nextFightTitle1 = (GTextField)((GComponent)this).GetChild("nextFightTitle1");
		string id11 = "ui://l5ik1uclic7jt7w".Replace("ui://", "") + "-" + ((GObject)nextFightTitle1).id;
		((GObject)nextFightTitle1).text = LanguagesManager.GetDesc(id11);
		nextFight1 = (GTextField)((GComponent)this).GetChild("nextFight1");
		n125 = (GImage)((GComponent)this).GetChild("n125");
		nextFightGroup1 = (GGroup)((GComponent)this).GetChild("nextFightGroup1");
		nextLevelTitle1 = (GTextField)((GComponent)this).GetChild("nextLevelTitle1");
		string id12 = "ui://l5ik1uclic7jt7w".Replace("ui://", "") + "-" + ((GObject)nextLevelTitle1).id;
		((GObject)nextLevelTitle1).text = LanguagesManager.GetDesc(id12);
		nextLevel1 = (GTextField)((GComponent)this).GetChild("nextLevel1");
		string id13 = "ui://l5ik1uclic7jt7w".Replace("ui://", "") + "-" + ((GObject)nextLevel1).id;
		((GObject)nextLevel1).text = LanguagesManager.GetDesc(id13);
		n128 = (GImage)((GComponent)this).GetChild("n128");
		nextLevelGroup1 = (GGroup)((GComponent)this).GetChild("nextLevelGroup1");
		nextAttackTitle1 = (GTextField)((GComponent)this).GetChild("nextAttackTitle1");
		string id14 = "ui://l5ik1uclic7jt7w".Replace("ui://", "") + "-" + ((GObject)nextAttackTitle1).id;
		((GObject)nextAttackTitle1).text = LanguagesManager.GetDesc(id14);
		nextAttack1 = (GTextField)((GComponent)this).GetChild("nextAttack1");
		string id15 = "ui://l5ik1uclic7jt7w".Replace("ui://", "") + "-" + ((GObject)nextAttack1).id;
		((GObject)nextAttack1).text = LanguagesManager.GetDesc(id15);
		n127 = (GImage)((GComponent)this).GetChild("n127");
		nextAttackGroup1 = (GGroup)((GComponent)this).GetChild("nextAttackGroup1");
		nextDeffense1 = (GTextField)((GComponent)this).GetChild("nextDeffense1");
		string id16 = "ui://l5ik1uclic7jt7w".Replace("ui://", "") + "-" + ((GObject)nextDeffense1).id;
		((GObject)nextDeffense1).text = LanguagesManager.GetDesc(id16);
		nextDeffenseTitle1 = (GTextField)((GComponent)this).GetChild("nextDeffenseTitle1");
		string id17 = "ui://l5ik1uclic7jt7w".Replace("ui://", "") + "-" + ((GObject)nextDeffenseTitle1).id;
		((GObject)nextDeffenseTitle1).text = LanguagesManager.GetDesc(id17);
		n126 = (GImage)((GComponent)this).GetChild("n126");
		nextDeffenseGroup1 = (GGroup)((GComponent)this).GetChild("nextDeffenseGroup1");
		nextHealthTitle1 = (GTextField)((GComponent)this).GetChild("nextHealthTitle1");
		string id18 = "ui://l5ik1uclic7jt7w".Replace("ui://", "") + "-" + ((GObject)nextHealthTitle1).id;
		((GObject)nextHealthTitle1).text = LanguagesManager.GetDesc(id18);
		nextHealth1 = (GTextField)((GComponent)this).GetChild("nextHealth1");
		string id19 = "ui://l5ik1uclic7jt7w".Replace("ui://", "") + "-" + ((GObject)nextHealth1).id;
		((GObject)nextHealth1).text = LanguagesManager.GetDesc(id19);
		n129 = (GImage)((GComponent)this).GetChild("n129");
		nextHealthGroup1 = (GGroup)((GComponent)this).GetChild("nextHealthGroup1");
		nextPropertys1 = (GGroup)((GComponent)this).GetChild("nextPropertys1");
		curFightTitle2 = (GTextField)((GComponent)this).GetChild("curFightTitle2");
		string id20 = "ui://l5ik1uclic7jt7w".Replace("ui://", "") + "-" + ((GObject)curFightTitle2).id;
		((GObject)curFightTitle2).text = LanguagesManager.GetDesc(id20);
		curFight2 = (GTextField)((GComponent)this).GetChild("curFight2");
		curFightGroup2 = (GGroup)((GComponent)this).GetChild("curFightGroup2");
		curAttackTitle2 = (GTextField)((GComponent)this).GetChild("curAttackTitle2");
		string id21 = "ui://l5ik1uclic7jt7w".Replace("ui://", "") + "-" + ((GObject)curAttackTitle2).id;
		((GObject)curAttackTitle2).text = LanguagesManager.GetDesc(id21);
		curAttack2 = (GTextField)((GComponent)this).GetChild("curAttack2");
		string id22 = "ui://l5ik1uclic7jt7w".Replace("ui://", "") + "-" + ((GObject)curAttack2).id;
		((GObject)curAttack2).text = LanguagesManager.GetDesc(id22);
		curAttackGroup2 = (GGroup)((GComponent)this).GetChild("curAttackGroup2");
		curDeffenseTitle2 = (GTextField)((GComponent)this).GetChild("curDeffenseTitle2");
		string id23 = "ui://l5ik1uclic7jt7w".Replace("ui://", "") + "-" + ((GObject)curDeffenseTitle2).id;
		((GObject)curDeffenseTitle2).text = LanguagesManager.GetDesc(id23);
		curDeffense2 = (GTextField)((GComponent)this).GetChild("curDeffense2");
		string id24 = "ui://l5ik1uclic7jt7w".Replace("ui://", "") + "-" + ((GObject)curDeffense2).id;
		((GObject)curDeffense2).text = LanguagesManager.GetDesc(id24);
		curDeffenseGroup2 = (GGroup)((GComponent)this).GetChild("curDeffenseGroup2");
		curHealthTitle2 = (GTextField)((GComponent)this).GetChild("curHealthTitle2");
		string id25 = "ui://l5ik1uclic7jt7w".Replace("ui://", "") + "-" + ((GObject)curHealthTitle2).id;
		((GObject)curHealthTitle2).text = LanguagesManager.GetDesc(id25);
		curHealth2 = (GTextField)((GComponent)this).GetChild("curHealth2");
		string id26 = "ui://l5ik1uclic7jt7w".Replace("ui://", "") + "-" + ((GObject)curHealth2).id;
		((GObject)curHealth2).text = LanguagesManager.GetDesc(id26);
		curHealthGroup2 = (GGroup)((GComponent)this).GetChild("curHealthGroup2");
		curPropertys2 = (GGroup)((GComponent)this).GetChild("curPropertys2");
		nextFightTitle2 = (GTextField)((GComponent)this).GetChild("nextFightTitle2");
		string id27 = "ui://l5ik1uclic7jt7w".Replace("ui://", "") + "-" + ((GObject)nextFightTitle2).id;
		((GObject)nextFightTitle2).text = LanguagesManager.GetDesc(id27);
		nextFight2 = (GTextField)((GComponent)this).GetChild("nextFight2");
		n121 = (GImage)((GComponent)this).GetChild("n121");
		nextFightGroup2 = (GGroup)((GComponent)this).GetChild("nextFightGroup2");
		nextAttackTitle2 = (GTextField)((GComponent)this).GetChild("nextAttackTitle2");
		string id28 = "ui://l5ik1uclic7jt7w".Replace("ui://", "") + "-" + ((GObject)nextAttackTitle2).id;
		((GObject)nextAttackTitle2).text = LanguagesManager.GetDesc(id28);
		nextAttack2 = (GTextField)((GComponent)this).GetChild("nextAttack2");
		string id29 = "ui://l5ik1uclic7jt7w".Replace("ui://", "") + "-" + ((GObject)nextAttack2).id;
		((GObject)nextAttack2).text = LanguagesManager.GetDesc(id29);
		n122 = (GImage)((GComponent)this).GetChild("n122");
		nextAttackGroup2 = (GGroup)((GComponent)this).GetChild("nextAttackGroup2");
		nextDeffenseTitle2 = (GTextField)((GComponent)this).GetChild("nextDeffenseTitle2");
		string id30 = "ui://l5ik1uclic7jt7w".Replace("ui://", "") + "-" + ((GObject)nextDeffenseTitle2).id;
		((GObject)nextDeffenseTitle2).text = LanguagesManager.GetDesc(id30);
		nextDeffense2 = (GTextField)((GComponent)this).GetChild("nextDeffense2");
		string id31 = "ui://l5ik1uclic7jt7w".Replace("ui://", "") + "-" + ((GObject)nextDeffense2).id;
		((GObject)nextDeffense2).text = LanguagesManager.GetDesc(id31);
		n123 = (GImage)((GComponent)this).GetChild("n123");
		nextDeffenseGroup2 = (GGroup)((GComponent)this).GetChild("nextDeffenseGroup2");
		nextHealthTitle2 = (GTextField)((GComponent)this).GetChild("nextHealthTitle2");
		string id32 = "ui://l5ik1uclic7jt7w".Replace("ui://", "") + "-" + ((GObject)nextHealthTitle2).id;
		((GObject)nextHealthTitle2).text = LanguagesManager.GetDesc(id32);
		nextHealth2 = (GTextField)((GComponent)this).GetChild("nextHealth2");
		string id33 = "ui://l5ik1uclic7jt7w".Replace("ui://", "") + "-" + ((GObject)nextHealth2).id;
		((GObject)nextHealth2).text = LanguagesManager.GetDesc(id33);
		n124 = (GImage)((GComponent)this).GetChild("n124");
		nextHealthGroup2 = (GGroup)((GComponent)this).GetChild("nextHealthGroup2");
		nextPropertys2 = (GGroup)((GComponent)this).GetChild("nextPropertys2");
		skillBack = (GImage)((GComponent)this).GetChild("skillBack");
		showSkillBack = (GGraph)((GComponent)this).GetChild("showSkillBack");
		unLockTitle = (GTextField)((GComponent)this).GetChild("unLockTitle");
		string id34 = "ui://l5ik1uclic7jt7w".Replace("ui://", "") + "-" + ((GObject)unLockTitle).id;
		((GObject)unLockTitle).text = LanguagesManager.GetDesc(id34);
		SkillIntorduction = (UI_SkillIntorduction)(object)((GComponent)this).GetChild("SkillIntorduction");
		FloorLoader = (GLoader)((GComponent)this).GetChild("FloorLoader");
		skillIcon = (GLoader)((GComponent)this).GetChild("skillIcon");
		FrameLoader = (GLoader)((GComponent)this).GetChild("FrameLoader");
		showSkill = (GGroup)((GComponent)this).GetChild("showSkill");
		star0 = (GImage)((GComponent)this).GetChild("star0");
		star1 = (GImage)((GComponent)this).GetChild("star1");
		star2 = (GImage)((GComponent)this).GetChild("star2");
		star3 = (GImage)((GComponent)this).GetChild("star3");
		star4 = (GImage)((GComponent)this).GetChild("star4");
		StarSfxBack0 = (GGraph)((GComponent)this).GetChild("StarSfxBack0");
		StarSfxBack1 = (GGraph)((GComponent)this).GetChild("StarSfxBack1");
		StarSfxBack2 = (GGraph)((GComponent)this).GetChild("StarSfxBack2");
		StarSfxBack3 = (GGraph)((GComponent)this).GetChild("StarSfxBack3");
		StarSfxBack4 = (GGraph)((GComponent)this).GetChild("StarSfxBack4");
		starAnimationGroup = (GGroup)((GComponent)this).GetChild("starAnimationGroup");
		toEndMask = (GGraph)((GComponent)this).GetChild("toEndMask");
		showSoldierImageChange = ((GComponent)this).GetTransition("showSoldierImageChange");
		showNextProperty1 = ((GComponent)this).GetTransition("showNextProperty1");
		showNextProperty2 = ((GComponent)this).GetTransition("showNextProperty2");
		starIncrease = ((GComponent)this).GetTransition("starIncrease");
		showNextProperty3 = ((GComponent)this).GetTransition("showNextProperty3");
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
		SpawnManager.Instance.UnloadAnimation(uiTitleAnimName);
		UiTagManager instance = UiTagManager.Instance;
		instance.Unregister("SoldierPotentialUpgradeSuccess.ConfirmBtn", confirmBtn);
		instance.Unregister("UpgradeSuccessPanel.FrameLoader", showSkillBack);
		FGUIManager.Instance.UpdateParent(soldierId);
		FGUIManager.Instance.UpgradeSuccessPanel = null;
		if (FGUIManager.Instance.DebrisCompoundPanel != null)
		{
			((GObject)FGUIManager.Instance.DebrisCompoundPanel).visible = true;
		}
		if (FGUIManager.Instance.SoldierCultivatePanel != null)
		{
			((GObject)FGUIManager.Instance.SoldierCultivatePanel.backMask).alpha = 0f;
		}
		UiAudioManager.Instance.StopBackgroundSound("SoldierUp");
		UiAudioManager.Instance.SetMainCityBgmVolume(UiAudioManager.Instance.MiddleBgmVolume);
	}

	public void Init(Dictionary<string, object> parameters)
	{
		//IL_0146: Unknown result type (might be due to invalid IL or missing references)
		//IL_0150: Expected O, but got Unknown
		if (parameters.TryGetValue("Bonus", out var value))
		{
			bonus = (Dictionary<string, int>)value;
		}
		soldier = (FakeSoldier)parameters["Soldier"];
		fakeSoldier = (FakeSoldier)parameters["FakeSoldier"];
		soldierId = soldier.Id;
		((GObject)this).sortingOrder = 106;
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		((GObject)toEndMask).touchable = true;
		((GObject)confirmBtn).touchable = false;
		if (soldier.PotentialLevel == 9)
		{
			isLevelUp = true;
		}
		else if (soldier.PotentialLevel % 2 != 0)
		{
			isLevelUp = false;
		}
		else
		{
			isLevelUp = true;
		}
		SetLeftDetial();
		SetRightDetial();
		if (isLevelUp)
		{
			PageSwitch.selectedIndex = 0;
			LoadSoldierSpine();
			changePageDelay = 4f;
			SetControllerPageText();
		}
		UiHelper.LoadSpine_AB(VictorySfx, uiTitleAnimName, 100f, delegate(SkeletonAnimation animation)
		{
			//IL_004a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0054: Expected O, but got Unknown
			((SkeletonRenderer)animation).Skeleton.A = ((PageSwitch.selectedIndex != 0) ? 1 : 0);
			PageSwitch.onChanged.Add((EventCallback0)delegate
			{
				((SkeletonRenderer)animation).Skeleton.A = ((PageSwitch.selectedIndex != 0) ? 1 : 0);
			});
			SpineHelper.SetSkin((ISkeletonAnimation)(object)animation, "skin1");
			animation.AnimationState.SetAnimation(0, "ui_title_lightray_rotate_yellow", true);
		});
		((GComponent)(object)this).SetTimeout(changePageDelay).OnComplete((GTweenCallback)delegate
		{
			//IL_0022: Unknown result type (might be due to invalid IL or missing references)
			//IL_002c: Expected O, but got Unknown
			PageSwitch.selectedIndex = 3;
			SetControllerPageText();
			showNextProperty3.Play((PlayCompleteCallback)delegate
			{
				((GObject)confirmBtn).touchable = true;
				((GObject)toEndMask).touchable = false;
			});
		});
	}

	public void OnShow()
	{
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Expected O, but got Unknown
		FGUIManager.Instance.UpgradeSuccessPanel = this;
		UiTagManager instance = UiTagManager.Instance;
		instance.Register("SoldierPotentialUpgradeSuccess.ConfirmBtn", confirmBtn);
		instance.Register("UpgradeSuccessPanel.FrameLoader", showSkillBack);
		UiAudioManager.Instance.SetMainCityBgmVolume(0f);
		UiAudioManager.Instance.PlayBackgroundSound("SoldierUp");
		ScriptApi.CreateTimer(1f, delegate
		{
			FGUIManager.Instance.OnSoldierChanged(soldierId, fakeSoldier.PotentialLevel, soldier.PotentialLevel);
		});
		((GComponent)(object)this).SetTimeout(changePageDelay + 1f).OnComplete((GTweenCallback)delegate
		{
			//IL_003d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0083: Unknown result type (might be due to invalid IL or missing references)
			//IL_008d: Expected O, but got Unknown
			//IL_0166: Unknown result type (might be due to invalid IL or missing references)
			//IL_0170: Expected O, but got Unknown
			//IL_0192: Unknown result type (might be due to invalid IL or missing references)
			//IL_019c: Expected O, but got Unknown
			if (isLevelUp)
			{
				FGUIManager.Instance.AddTextSpecialEffects(((GComponent)nextSoldierIcon).GetChild("PotentialIconSfxBack").asGraph, "activating_white_sp", new Vector3(120f, 120f, 120f), "Default", 0.5f, delegate(GameObject activatingWhiteSp)
				{
					activatingWhiteSp.AddComponent<HotFix_DestroySelf>().destroyTime = 0.6f;
					UiAudioManager.Instance.LoadSoundsForSfx(activatingWhiteSp, "LevelUp");
				});
				((GComponent)(object)this).SetTimeout(0.15f).OnComplete((GTweenCallback)delegate
				{
					//IL_0171: Unknown result type (might be due to invalid IL or missing references)
					//IL_0176: Unknown result type (might be due to invalid IL or missing references)
					int itemLevel = (soldier.PotentialLevel + 2) / 2;
					if (soldier.PotentialLevel == 9)
					{
						itemLevel = 6;
					}
					((GComponent)((GObject)nextSoldierIcon).asButton).GetChild("icon").asLoader.url = "ui://PublicResources/" + UiHelper.GetIconPath(soldier.Id, itemLevel);
					string iconFrameBorderSoldier = UiHelper.GetIconFrameBorderSoldier(soldier.PotentialLevel);
					((GComponent)nextSoldierIcon).GetChild("iconFrame").asLoader.url = "ui://PublicResources/" + iconFrameBorderSoldier;
					UiHelper.LoadSoldierIconFrameMaterial(((GComponent)nextSoldierIcon).GetChild("iconFrame").asLoader, soldier.PotentialLevel);
					if (SoliderSoulStone != null)
					{
						((GObject)SoliderSoulStone).visible = true;
					}
					string text = "title";
					if (soldier.PotentialLevel >= 8)
					{
						text = "title_Max";
						((GComponent)nextSoldierIcon).GetController("Level").selectedIndex = 1;
					}
					else
					{
						((GComponent)nextSoldierIcon).GetController("Level").selectedIndex = 0;
					}
					((GComponent)((GObject)nextSoldierIcon).asButton).GetChild(text).text = soldier.Name;
					((GComponent)nextSoldierIcon).GetChild(text).asTextField.color = Color32.op_Implicit(UiHelper.GetColorByLevel(soldier.PotentialLevel));
					((GComponent)nextSoldierIcon).GetChild("level").asCom.GetController("Level").selectedIndex = soldier.PotentialLevel;
					if (soldier.PotentialLevel == 8)
					{
						((GComponent)nextSoldierIcon).GetChild("level").asCom.GetChild("n24").visible = MythAvailable;
						((GComponent)nextSoldierIcon).GetChild("level").asCom.GetChild("n11").visible = !MythAvailable;
					}
				});
				FGUIManager.Instance.ClearCache_SoliderSoulStone();
				FGUIManager.Instance.SetAlightSoulStoneForSoldierIcon(((GComponent)nextSoldierIcon).GetChild("SoulStoneLevel").asCom, soldier.PotentialLevel, soldier.PotentialProgress);
			}
			else if (SoliderSoulStone != null && SoliderSoulStone.GetTransition("activate") != null)
			{
				SoliderSoulStone.GetTransition("activate").Play();
				((GObject)SoliderSoulStone).visible = true;
				for (int num = 0; num < 3; num++)
				{
					int index = num;
					SoliderSoulStone.GetTransition("activate").SetHook($"act{index}", (TransitionHook)delegate
					{
						//IL_0044: Unknown result type (might be due to invalid IL or missing references)
						FGUIManager.Instance.AddTextSpecialEffects(SoliderSoulStone.GetChild($"sfxBack{index}").asGraph, "activating_white", new Vector3(60f, 60f, 60f), "Default", 0.5f, delegate(GameObject activatingWhite)
						{
							activatingWhite.AddComponent<HotFix_DestroySelf>().destroyTime = 1f;
							UiAudioManager.Instance.LoadSoundsForSfx(activatingWhite, "BlastForPack");
						});
					});
				}
				((GComponent)(object)this).SetTimeout(2f).OnComplete((GTweenCallback)delegate
				{
					FGUIManager.Instance.SetAlightSoulStoneForSoldierIcon(((GComponent)nextSoldierIcon).GetChild("SoulStoneLevel").asCom, soldier.PotentialLevel, soldier.PotentialProgress);
				});
			}
		});
		if (FGUIManager.Instance.DebrisCompoundPanel != null)
		{
			((GObject)FGUIManager.Instance.DebrisCompoundPanel).visible = false;
		}
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		((GObject)toEndMask).onClick.Add(new EventCallback0(DirectlyToPotentialEnd));
		((GObject)confirmBtn).onClick.Add(new EventCallback0(End));
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		((GObject)toEndMask).onClick.Remove(new EventCallback0(DirectlyToPotentialEnd));
		((GObject)confirmBtn).onClick.Remove(new EventCallback0(End));
	}

	private void DirectlyToPotentialEnd()
	{
		if (PageSwitch.selectedIndex != 0)
		{
			if (showNextProperty3.playing)
			{
				showNextProperty3.Stop();
			}
			((GObject)nextSoldierIcon).alpha = 1f;
			((GObject)nextFightGroup2).alpha = 1f;
			((GObject)nextAttackGroup2).alpha = 1f;
			((GObject)nextDeffenseGroup2).alpha = 1f;
			((GObject)nextHealthGroup2).alpha = 1f;
			((GObject)confirmBtn).alpha = 1f;
			((GObject)showSkill).alpha = 1f;
			((GObject)toEndMask).touchable = false;
			((GObject)confirmBtn).touchable = true;
		}
	}

	private void SetLeftDetial()
	{
		//IL_01b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bd: Unknown result type (might be due to invalid IL or missing references)
		((GObject)curFight2).text = fakeSoldier.CombatPower.ToString();
		((GObject)curAttack2).text = UiHelper.RemoveSurplusZeroBehindDecimalPoint(Convert.ToInt32(fakeSoldier.Attack).ToString());
		((GObject)curDeffense2).text = UiHelper.RemoveSurplusZeroBehindDecimalPoint(Convert.ToInt32(fakeSoldier.Defense).ToString());
		((GObject)curHealth2).text = UiHelper.RemoveSurplusZeroBehindDecimalPoint(Convert.ToInt32(fakeSoldier.Health).ToString());
		UI_armItem uI_armItem = curSoldierIcon;
		((GComponent)uI_armItem).GetChild("level").asCom.GetController("Level").selectedIndex = fakeSoldier.PotentialLevel;
		if (fakeSoldier.PotentialLevel == 8)
		{
			((GComponent)uI_armItem).GetChild("level").asCom.GetChild("n24").visible = MythAvailable;
			((GComponent)uI_armItem).GetChild("level").asCom.GetChild("n11").visible = !MythAvailable;
		}
		string text = "title";
		if (fakeSoldier.PotentialLevel >= 8)
		{
			text = "title_Max";
			((GComponent)uI_armItem).GetController("Level").selectedIndex = 1;
		}
		else
		{
			((GComponent)uI_armItem).GetController("Level").selectedIndex = 0;
		}
		((GComponent)((GObject)uI_armItem).asButton).GetChild(text).text = fakeSoldier.Name;
		((GComponent)uI_armItem).GetChild(text).asTextField.color = Color32.op_Implicit(UiHelper.GetColorByLevel(fakeSoldier.PotentialLevel));
		int itemLevel = (fakeSoldier.PotentialLevel + 2) / 2;
		((GComponent)((GObject)uI_armItem).asButton).GetChild("icon").asLoader.url = "ui://PublicResources/" + UiHelper.GetIconPath(fakeSoldier.Id, itemLevel);
		string iconFrameBorderSoldier = UiHelper.GetIconFrameBorderSoldier(fakeSoldier.PotentialLevel);
		((GComponent)uI_armItem).GetChild("iconFrame").asLoader.url = "ui://PublicResources/" + iconFrameBorderSoldier;
		UiHelper.LoadSoldierIconFrameMaterial(((GComponent)uI_armItem).GetChild("iconFrame").asLoader, fakeSoldier.PotentialLevel);
		List<int> progress = fakeSoldier.PotentialProgress;
		if (!isLevelUp)
		{
			progress = new List<int>();
		}
		FGUIManager.Instance.SetAlightSoulStoneForSoldierIcon(((GComponent)uI_armItem).GetChild("SoulStoneLevel").asCom, fakeSoldier.PotentialLevel, progress);
	}

	private void SetRightDetial()
	{
		//IL_03ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f4: Unknown result type (might be due to invalid IL or missing references)
		((GObject)showSkill).alpha = 0f;
		Dictionary<string, int> dictionary = soldier.AbilitiesUnlockState();
		_skillList.Clear();
		for (int i = 0; i < soldier.AbilityList.Count; i++)
		{
			if (GDMgr.TryGetWithErrorHandling<GDEAbilityData>(soldier.AbilityList[i]).Visible)
			{
				_skillList.Add(soldier.AbilityList[i]);
			}
		}
		((GObject)showSkill).visible = false;
		for (int j = 0; j < _skillList.Count; j++)
		{
			if (dictionary[_skillList[j]] == soldier.PotentialLevel)
			{
				((GObject)showSkill).visible = true;
				GDEAbilityData gDEAbilityData = GDMgr.TryGetWithErrorHandling<GDEAbilityData>(_skillList[j]);
				skillIcon.LoadAbilityIcon(gDEAbilityData.Icon);
				((GObject)SkillIntorduction.skillIntorduction).text = Singleton<AbilityDataManager>.Instance.GetDescription(gDEAbilityData.Key);
				break;
			}
		}
		((GObject)nextFightGroup2).alpha = 0f;
		((GObject)nextAttackGroup2).alpha = 0f;
		((GObject)nextDeffenseGroup2).alpha = 0f;
		((GObject)nextHealthGroup2).alpha = 0f;
		((GObject)nextFight2).text = soldier.CombatPower.ToString();
		((GObject)nextAttack2).text = UiHelper.RemoveSurplusZeroBehindDecimalPoint(Convert.ToInt32(soldier.Attack).ToString());
		((GObject)nextDeffense2).text = UiHelper.RemoveSurplusZeroBehindDecimalPoint(Convert.ToInt32(soldier.Defense).ToString());
		((GObject)nextHealth2).text = UiHelper.RemoveSurplusZeroBehindDecimalPoint(Convert.ToInt32(soldier.Health).ToString());
		UI_armItem uI_armItem = nextSoldierIcon;
		List<int> progress = soldier.PotentialProgress;
		int potentialLevel = soldier.PotentialLevel;
		if (isLevelUp)
		{
			potentialLevel = fakeSoldier.PotentialLevel;
			progress = new List<int> { 1, 2, 4 };
		}
		int num = (potentialLevel + 2) / 2;
		((GComponent)((GObject)uI_armItem).asButton).GetChild("icon").asLoader.url = "ui://PublicResources/" + UiHelper.GetIconPath(soldier.Id, num);
		string iconFrameBorderSoldier = UiHelper.GetIconFrameBorderSoldier(potentialLevel);
		((GComponent)uI_armItem).GetChild("iconFrame").asLoader.url = "ui://PublicResources/" + iconFrameBorderSoldier;
		UiHelper.LoadSoldierIconFrameMaterial(((GComponent)uI_armItem).GetChild("iconFrame").asLoader, potentialLevel);
		string text = "title";
		if (num >= 5)
		{
			text = "title_Max";
			((GComponent)uI_armItem).GetController("Level").selectedIndex = 1;
		}
		else
		{
			((GComponent)uI_armItem).GetController("Level").selectedIndex = 0;
		}
		((GComponent)((GObject)uI_armItem).asButton).GetChild(text).text = soldier.Name;
		((GComponent)uI_armItem).GetChild("level").asCom.GetController("Level").selectedIndex = potentialLevel;
		if (potentialLevel == 8)
		{
			((GComponent)uI_armItem).GetChild("level").asCom.GetChild("n24").visible = MythAvailable;
			((GComponent)uI_armItem).GetChild("level").asCom.GetChild("n11").visible = !MythAvailable;
		}
		((GComponent)uI_armItem).GetChild(text).asTextField.color = Color32.op_Implicit(UiHelper.GetColorByLevel(potentialLevel));
		SoliderSoulStone = FGUIManager.Instance.SetAlightSoulStoneForSoldierIcon(((GComponent)uI_armItem).GetChild("SoulStoneLevel").asCom, potentialLevel, progress, !isLevelUp);
		((GObject)SoliderSoulStone).visible = false;
	}

	private void LoadSoldierSpine()
	{
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f9: Expected O, but got Unknown
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_014c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Unknown result type (might be due to invalid IL or missing references)
		GameObject canvasObject1 = default(GameObject);
		ref GameObject reference = ref canvasObject1;
		Object obj = Object.Instantiate(Resources.Load("Items/Spine", typeof(GameObject)));
		reference = (GameObject)(object)((obj is GameObject) ? obj : null);
		canvasObject1.GetComponent<Canvas>().sortingLayerName = "Default";
		int nextPotentialLevel = soldier.CurrentSpineSkinId;
		SpawnManager.Instance.LoadSoldierSpine(canvasObject1, $"{soldierId}_skin{nextPotentialLevel - 1}").Then((Action<SkeletonDataAsset>)delegate(SkeletonDataAsset asset)
		{
			//IL_00be: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c8: Expected O, but got Unknown
			if (!((GObject)this).isDisposed)
			{
				existSpine = true;
				SkeletonGraphic skeletonGraphic = ((Component)canvasObject1.transform.GetChild(0)).gameObject.GetComponent<SkeletonGraphic>();
				skeletonGraphic.skeletonDataAsset = asset;
				skeletonGraphic.initialSkinName = $"skin{nextPotentialLevel - 1}";
				skeletonGraphic.Initialize(true);
				((Component)canvasObject1.transform.GetChild(0)).gameObject.SetActive(true);
				GTweenCallback val2 = default(GTweenCallback);
				((GComponent)(object)this).SetTimeout(1f).OnComplete((GTweenCallback)delegate
				{
					//IL_002a: Unknown result type (might be due to invalid IL or missing references)
					//IL_0085: Unknown result type (might be due to invalid IL or missing references)
					//IL_008a: Unknown result type (might be due to invalid IL or missing references)
					//IL_008c: Expected O, but got Unknown
					//IL_0091: Expected O, but got Unknown
					FGUIManager.Instance.AddTextSpecialEffects(cover, "LightningBlast", new Vector3(720f, 720f, 720f), "Default", 0.5f, delegate(GameObject lightningBlast)
					{
						UiAudioManager.Instance.LoadSoundsForSfx(lightningBlast, "Refresh");
					});
					GTweener obj2 = ((GComponent)(object)this).SetTimeout(0.75f);
					GTweenCallback obj3 = val2;
					if (obj3 == null)
					{
						GTweenCallback val3 = delegate
						{
							SpawnManager.Instance.LoadSoldierSpine(canvasObject1, $"{soldierId}_skin{nextPotentialLevel}").Then((Action<SkeletonDataAsset>)delegate(SkeletonDataAsset assetNext)
							{
								skeletonGraphic.skeletonDataAsset = assetNext;
								skeletonGraphic.initialSkinName = $"skin{nextPotentialLevel}";
								skeletonGraphic.Initialize(true);
								skeletonGraphic.AnimationState.AddAnimation(0, "idle", false, 0.5f);
								skeletonGraphic.AnimationState.AddAnimation(0, "attack", false, 0f);
								skeletonGraphic.AnimationState.AddAnimation(0, "idle", true, 0f);
							});
						};
						GTweenCallback val4 = val3;
						val2 = val3;
						obj3 = val4;
					}
					obj2.OnComplete(obj3);
				});
			}
		});
		canvasObject1.transform.localPosition = -new Vector3(0f, 0f, 0f);
		canvasObject1.transform.localEulerAngles = -new Vector3(0f, 0f, 0f);
		GoWrapper val = new GoWrapper(canvasObject1);
		((DisplayObject)val).SetXY(0f, 0f);
		((DisplayObject)val).pivot = new Vector2(0.5f, 0.5f);
		Spine.SetNativeObject((DisplayObject)(object)val);
		FGUIManager.Instance.AddTextSpecialEffects(baseSpine, "MagicCircleBase", new Vector3(100f, 100f, 100f));
		FGUIManager.Instance.AddTextSpecialEffects(maskSpine, "MagicCircleMask", new Vector3(100f, 100f, 100f));
	}

	public void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
	}

	private void RenderStarList(int num, GList list)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Expected O, but got Unknown
		list.itemRenderer = new ListItemRenderer(RenderStarItem);
		list.numItems = num;
	}

	private void RenderStarItem(int index, GObject obj)
	{
		GComponent asCom = obj.asCom;
		asCom.GetChild("icon").asLoader.url = "ui://PublicResources/icon_star_Light";
	}
}
