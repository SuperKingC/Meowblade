using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.UpgradePotential;

public class UI_UpgradeCard : GComponent
{
	public Controller PageSwitch;

	public Controller Type;

	public Controller state;

	public GImage n203;

	public GImage n191;

	public GGroup BG;

	public GLoader n0;

	public GImage n40;

	public GImage n41;

	public GImage n42;

	public GGroup n44;

	public GLoader n1;

	public GLoader level;

	public GImage n204;

	public UI_armItem SoldierIcon;

	public GImage n25;

	public GGroup n26;

	public GImage n24;

	public GImage n3;

	public GImage n4;

	public GImage n22;

	public GGroup n5;

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

	public GGroup n87;

	public GTextField nextFightTitle1;

	public GTextField nextFight1;

	public GImage n163;

	public GGroup nextFightGroup1;

	public GTextField nextLevelTitle1;

	public GTextField nextLevel1;

	public GImage n164;

	public GGroup nextLevelGroup1;

	public GTextField nextAttackTitle1;

	public GTextField nextAttack1;

	public GImage n165;

	public GGroup nextAttackGroup1;

	public GTextField nextDeffenseTitle1;

	public GTextField nextDeffense1;

	public GImage n166;

	public GGroup nextDeffenseGroup1;

	public GTextField nextHealthTitle1;

	public GTextField nextHealth1;

	public GImage n167;

	public GGroup nextHealthGroup1;

	public GGroup nextPropertys1;

	public GTextField nextFightTitle2;

	public GTextField nextFight2;

	public GImage n185;

	public GGroup nextFightGroup2;

	public GTextField nextAttackTitle2;

	public GTextField nextAttack2;

	public GImage n186;

	public GGroup nextAttackGroup2;

	public GTextField nextDeffenseTitle2;

	public GTextField nextDeffense2;

	public GImage n187;

	public GGroup nextDeffenseGroup2;

	public GTextField nextHealthTitle2;

	public GTextField nextHealth2;

	public GImage n188;

	public GGroup nextHealthGroup2;

	public GGroup nextPropertys2;

	public GGroup n161;

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

	public Transition UpgradeEffect;

	public Transition ShowProperty1;

	public Transition ShowProperty2;

	public const string URL = "ui://l5ik1uclpanqt8o";

	public static string Name = "UI_UpgradeCard";

	public static string GetURL()
	{
		return "ui://l5ik1uclpanqt8o";
	}

	public static UI_UpgradeCard CreateInstance()
	{
		return (UI_UpgradeCard)(object)UIPackage.CreateObject("UpgradePotential", "UpgradeCard");
	}

	public static UI_UpgradeCard CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_UpgradeCard).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://l5ik1uclpanqt8o", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected O, but got Unknown
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected O, but got Unknown
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Expected O, but got Unknown
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected O, but got Unknown
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected O, but got Unknown
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Expected O, but got Unknown
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Expected O, but got Unknown
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Expected O, but got Unknown
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Expected O, but got Unknown
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Expected O, but got Unknown
		//IL_0192: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Expected O, but got Unknown
		//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b2: Expected O, but got Unknown
		//IL_01be: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c8: Expected O, but got Unknown
		//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01de: Expected O, but got Unknown
		//IL_01ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f4: Expected O, but got Unknown
		//IL_023d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0247: Expected O, but got Unknown
		//IL_0253: Unknown result type (might be due to invalid IL or missing references)
		//IL_025d: Expected O, but got Unknown
		//IL_0269: Unknown result type (might be due to invalid IL or missing references)
		//IL_0273: Expected O, but got Unknown
		//IL_02bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c6: Expected O, but got Unknown
		//IL_030f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0319: Expected O, but got Unknown
		//IL_0325: Unknown result type (might be due to invalid IL or missing references)
		//IL_032f: Expected O, but got Unknown
		//IL_0378: Unknown result type (might be due to invalid IL or missing references)
		//IL_0382: Expected O, but got Unknown
		//IL_03cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d7: Expected O, but got Unknown
		//IL_03e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ed: Expected O, but got Unknown
		//IL_0438: Unknown result type (might be due to invalid IL or missing references)
		//IL_0442: Expected O, but got Unknown
		//IL_048d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0497: Expected O, but got Unknown
		//IL_04a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ad: Expected O, but got Unknown
		//IL_04f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0502: Expected O, but got Unknown
		//IL_054d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0557: Expected O, but got Unknown
		//IL_0563: Unknown result type (might be due to invalid IL or missing references)
		//IL_056d: Expected O, but got Unknown
		//IL_0579: Unknown result type (might be due to invalid IL or missing references)
		//IL_0583: Expected O, but got Unknown
		//IL_05ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_05d8: Expected O, but got Unknown
		//IL_05e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ee: Expected O, but got Unknown
		//IL_05fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0604: Expected O, but got Unknown
		//IL_064f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0659: Expected O, but got Unknown
		//IL_06a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ae: Expected O, but got Unknown
		//IL_06ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_06c4: Expected O, but got Unknown
		//IL_070f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0719: Expected O, but got Unknown
		//IL_0764: Unknown result type (might be due to invalid IL or missing references)
		//IL_076e: Expected O, but got Unknown
		//IL_077a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0784: Expected O, but got Unknown
		//IL_07cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_07d9: Expected O, but got Unknown
		//IL_0824: Unknown result type (might be due to invalid IL or missing references)
		//IL_082e: Expected O, but got Unknown
		//IL_083a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0844: Expected O, but got Unknown
		//IL_0850: Unknown result type (might be due to invalid IL or missing references)
		//IL_085a: Expected O, but got Unknown
		//IL_0866: Unknown result type (might be due to invalid IL or missing references)
		//IL_0870: Expected O, but got Unknown
		//IL_08bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_08c5: Expected O, but got Unknown
		//IL_08d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_08db: Expected O, but got Unknown
		//IL_08e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_08f1: Expected O, but got Unknown
		//IL_08fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0907: Expected O, but got Unknown
		//IL_0952: Unknown result type (might be due to invalid IL or missing references)
		//IL_095c: Expected O, but got Unknown
		//IL_09a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_09b1: Expected O, but got Unknown
		//IL_09bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_09c7: Expected O, but got Unknown
		//IL_09d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_09dd: Expected O, but got Unknown
		//IL_0a28: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a32: Expected O, but got Unknown
		//IL_0a7d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a87: Expected O, but got Unknown
		//IL_0a93: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a9d: Expected O, but got Unknown
		//IL_0aa9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ab3: Expected O, but got Unknown
		//IL_0afe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b08: Expected O, but got Unknown
		//IL_0b53: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b5d: Expected O, but got Unknown
		//IL_0b69: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b73: Expected O, but got Unknown
		//IL_0b7f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b89: Expected O, but got Unknown
		//IL_0bd4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bde: Expected O, but got Unknown
		//IL_0c29: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c33: Expected O, but got Unknown
		//IL_0c3f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c49: Expected O, but got Unknown
		//IL_0c55: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c5f: Expected O, but got Unknown
		//IL_0c6b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c75: Expected O, but got Unknown
		//IL_0cc0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cca: Expected O, but got Unknown
		//IL_0cd6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ce0: Expected O, but got Unknown
		//IL_0cec: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cf6: Expected O, but got Unknown
		//IL_0d02: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d0c: Expected O, but got Unknown
		//IL_0d57: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d61: Expected O, but got Unknown
		//IL_0dac: Unknown result type (might be due to invalid IL or missing references)
		//IL_0db6: Expected O, but got Unknown
		//IL_0dc2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dcc: Expected O, but got Unknown
		//IL_0dd8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0de2: Expected O, but got Unknown
		//IL_0e2d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e37: Expected O, but got Unknown
		//IL_0e82: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e8c: Expected O, but got Unknown
		//IL_0e98: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ea2: Expected O, but got Unknown
		//IL_0eae: Unknown result type (might be due to invalid IL or missing references)
		//IL_0eb8: Expected O, but got Unknown
		//IL_0f03: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f0d: Expected O, but got Unknown
		//IL_0f58: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f62: Expected O, but got Unknown
		//IL_0f6e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f78: Expected O, but got Unknown
		//IL_0f84: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f8e: Expected O, but got Unknown
		//IL_0f9a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fa4: Expected O, but got Unknown
		//IL_0fb0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fba: Expected O, but got Unknown
		//IL_0fc6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fd0: Expected O, but got Unknown
		//IL_0fdc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fe6: Expected O, but got Unknown
		//IL_0ff2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ffc: Expected O, but got Unknown
		//IL_1008: Unknown result type (might be due to invalid IL or missing references)
		//IL_1012: Expected O, but got Unknown
		//IL_101e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1028: Expected O, but got Unknown
		//IL_1034: Unknown result type (might be due to invalid IL or missing references)
		//IL_103e: Expected O, but got Unknown
		//IL_104a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1054: Expected O, but got Unknown
		//IL_1060: Unknown result type (might be due to invalid IL or missing references)
		//IL_106a: Expected O, but got Unknown
		//IL_1076: Unknown result type (might be due to invalid IL or missing references)
		//IL_1080: Expected O, but got Unknown
		//IL_108c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1096: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		PageSwitch = ((GComponent)this).GetController("PageSwitch");
		Type = ((GComponent)this).GetController("Type");
		state = ((GComponent)this).GetController("state");
		n203 = (GImage)((GComponent)this).GetChild("n203");
		n191 = (GImage)((GComponent)this).GetChild("n191");
		BG = (GGroup)((GComponent)this).GetChild("BG");
		n0 = (GLoader)((GComponent)this).GetChild("n0");
		n40 = (GImage)((GComponent)this).GetChild("n40");
		n41 = (GImage)((GComponent)this).GetChild("n41");
		n42 = (GImage)((GComponent)this).GetChild("n42");
		n44 = (GGroup)((GComponent)this).GetChild("n44");
		n1 = (GLoader)((GComponent)this).GetChild("n1");
		level = (GLoader)((GComponent)this).GetChild("level");
		n204 = (GImage)((GComponent)this).GetChild("n204");
		SoldierIcon = (UI_armItem)(object)((GComponent)this).GetChild("SoldierIcon");
		n25 = (GImage)((GComponent)this).GetChild("n25");
		n26 = (GGroup)((GComponent)this).GetChild("n26");
		n24 = (GImage)((GComponent)this).GetChild("n24");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		n22 = (GImage)((GComponent)this).GetChild("n22");
		n5 = (GGroup)((GComponent)this).GetChild("n5");
		curFightTitle1 = (GTextField)((GComponent)this).GetChild("curFightTitle1");
		string id = "ui://l5ik1uclpanqt8o".Replace("ui://", "") + "-" + ((GObject)curFightTitle1).id;
		((GObject)curFightTitle1).text = LanguagesManager.GetDesc(id);
		curFight1 = (GTextField)((GComponent)this).GetChild("curFight1");
		curFightGroup1 = (GGroup)((GComponent)this).GetChild("curFightGroup1");
		curLevelTitle1 = (GTextField)((GComponent)this).GetChild("curLevelTitle1");
		string id2 = "ui://l5ik1uclpanqt8o".Replace("ui://", "") + "-" + ((GObject)curLevelTitle1).id;
		((GObject)curLevelTitle1).text = LanguagesManager.GetDesc(id2);
		curLevel1 = (GTextField)((GComponent)this).GetChild("curLevel1");
		string id3 = "ui://l5ik1uclpanqt8o".Replace("ui://", "") + "-" + ((GObject)curLevel1).id;
		((GObject)curLevel1).text = LanguagesManager.GetDesc(id3);
		curLevelGroup1 = (GGroup)((GComponent)this).GetChild("curLevelGroup1");
		curAttackTitle1 = (GTextField)((GComponent)this).GetChild("curAttackTitle1");
		string id4 = "ui://l5ik1uclpanqt8o".Replace("ui://", "") + "-" + ((GObject)curAttackTitle1).id;
		((GObject)curAttackTitle1).text = LanguagesManager.GetDesc(id4);
		curAttack1 = (GTextField)((GComponent)this).GetChild("curAttack1");
		string id5 = "ui://l5ik1uclpanqt8o".Replace("ui://", "") + "-" + ((GObject)curAttack1).id;
		((GObject)curAttack1).text = LanguagesManager.GetDesc(id5);
		curAttackGroup1 = (GGroup)((GComponent)this).GetChild("curAttackGroup1");
		curDeffenseTitle1 = (GTextField)((GComponent)this).GetChild("curDeffenseTitle1");
		string id6 = "ui://l5ik1uclpanqt8o".Replace("ui://", "") + "-" + ((GObject)curDeffenseTitle1).id;
		((GObject)curDeffenseTitle1).text = LanguagesManager.GetDesc(id6);
		curDeffense1 = (GTextField)((GComponent)this).GetChild("curDeffense1");
		string id7 = "ui://l5ik1uclpanqt8o".Replace("ui://", "") + "-" + ((GObject)curDeffense1).id;
		((GObject)curDeffense1).text = LanguagesManager.GetDesc(id7);
		curDeffenseGroup1 = (GGroup)((GComponent)this).GetChild("curDeffenseGroup1");
		curHealthTitle1 = (GTextField)((GComponent)this).GetChild("curHealthTitle1");
		string id8 = "ui://l5ik1uclpanqt8o".Replace("ui://", "") + "-" + ((GObject)curHealthTitle1).id;
		((GObject)curHealthTitle1).text = LanguagesManager.GetDesc(id8);
		curHealth1 = (GTextField)((GComponent)this).GetChild("curHealth1");
		string id9 = "ui://l5ik1uclpanqt8o".Replace("ui://", "") + "-" + ((GObject)curHealth1).id;
		((GObject)curHealth1).text = LanguagesManager.GetDesc(id9);
		curHealthGroup1 = (GGroup)((GComponent)this).GetChild("curHealthGroup1");
		curPropertys1 = (GGroup)((GComponent)this).GetChild("curPropertys1");
		curFightTitle2 = (GTextField)((GComponent)this).GetChild("curFightTitle2");
		string id10 = "ui://l5ik1uclpanqt8o".Replace("ui://", "") + "-" + ((GObject)curFightTitle2).id;
		((GObject)curFightTitle2).text = LanguagesManager.GetDesc(id10);
		curFight2 = (GTextField)((GComponent)this).GetChild("curFight2");
		curFightGroup2 = (GGroup)((GComponent)this).GetChild("curFightGroup2");
		curAttackTitle2 = (GTextField)((GComponent)this).GetChild("curAttackTitle2");
		string id11 = "ui://l5ik1uclpanqt8o".Replace("ui://", "") + "-" + ((GObject)curAttackTitle2).id;
		((GObject)curAttackTitle2).text = LanguagesManager.GetDesc(id11);
		curAttack2 = (GTextField)((GComponent)this).GetChild("curAttack2");
		string id12 = "ui://l5ik1uclpanqt8o".Replace("ui://", "") + "-" + ((GObject)curAttack2).id;
		((GObject)curAttack2).text = LanguagesManager.GetDesc(id12);
		curAttackGroup2 = (GGroup)((GComponent)this).GetChild("curAttackGroup2");
		curDeffenseTitle2 = (GTextField)((GComponent)this).GetChild("curDeffenseTitle2");
		string id13 = "ui://l5ik1uclpanqt8o".Replace("ui://", "") + "-" + ((GObject)curDeffenseTitle2).id;
		((GObject)curDeffenseTitle2).text = LanguagesManager.GetDesc(id13);
		curDeffense2 = (GTextField)((GComponent)this).GetChild("curDeffense2");
		string id14 = "ui://l5ik1uclpanqt8o".Replace("ui://", "") + "-" + ((GObject)curDeffense2).id;
		((GObject)curDeffense2).text = LanguagesManager.GetDesc(id14);
		curDeffenseGroup2 = (GGroup)((GComponent)this).GetChild("curDeffenseGroup2");
		curHealthTitle2 = (GTextField)((GComponent)this).GetChild("curHealthTitle2");
		string id15 = "ui://l5ik1uclpanqt8o".Replace("ui://", "") + "-" + ((GObject)curHealthTitle2).id;
		((GObject)curHealthTitle2).text = LanguagesManager.GetDesc(id15);
		curHealth2 = (GTextField)((GComponent)this).GetChild("curHealth2");
		string id16 = "ui://l5ik1uclpanqt8o".Replace("ui://", "") + "-" + ((GObject)curHealth2).id;
		((GObject)curHealth2).text = LanguagesManager.GetDesc(id16);
		curHealthGroup2 = (GGroup)((GComponent)this).GetChild("curHealthGroup2");
		curPropertys2 = (GGroup)((GComponent)this).GetChild("curPropertys2");
		n87 = (GGroup)((GComponent)this).GetChild("n87");
		nextFightTitle1 = (GTextField)((GComponent)this).GetChild("nextFightTitle1");
		string id17 = "ui://l5ik1uclpanqt8o".Replace("ui://", "") + "-" + ((GObject)nextFightTitle1).id;
		((GObject)nextFightTitle1).text = LanguagesManager.GetDesc(id17);
		nextFight1 = (GTextField)((GComponent)this).GetChild("nextFight1");
		n163 = (GImage)((GComponent)this).GetChild("n163");
		nextFightGroup1 = (GGroup)((GComponent)this).GetChild("nextFightGroup1");
		nextLevelTitle1 = (GTextField)((GComponent)this).GetChild("nextLevelTitle1");
		string id18 = "ui://l5ik1uclpanqt8o".Replace("ui://", "") + "-" + ((GObject)nextLevelTitle1).id;
		((GObject)nextLevelTitle1).text = LanguagesManager.GetDesc(id18);
		nextLevel1 = (GTextField)((GComponent)this).GetChild("nextLevel1");
		string id19 = "ui://l5ik1uclpanqt8o".Replace("ui://", "") + "-" + ((GObject)nextLevel1).id;
		((GObject)nextLevel1).text = LanguagesManager.GetDesc(id19);
		n164 = (GImage)((GComponent)this).GetChild("n164");
		nextLevelGroup1 = (GGroup)((GComponent)this).GetChild("nextLevelGroup1");
		nextAttackTitle1 = (GTextField)((GComponent)this).GetChild("nextAttackTitle1");
		string id20 = "ui://l5ik1uclpanqt8o".Replace("ui://", "") + "-" + ((GObject)nextAttackTitle1).id;
		((GObject)nextAttackTitle1).text = LanguagesManager.GetDesc(id20);
		nextAttack1 = (GTextField)((GComponent)this).GetChild("nextAttack1");
		string id21 = "ui://l5ik1uclpanqt8o".Replace("ui://", "") + "-" + ((GObject)nextAttack1).id;
		((GObject)nextAttack1).text = LanguagesManager.GetDesc(id21);
		n165 = (GImage)((GComponent)this).GetChild("n165");
		nextAttackGroup1 = (GGroup)((GComponent)this).GetChild("nextAttackGroup1");
		nextDeffenseTitle1 = (GTextField)((GComponent)this).GetChild("nextDeffenseTitle1");
		string id22 = "ui://l5ik1uclpanqt8o".Replace("ui://", "") + "-" + ((GObject)nextDeffenseTitle1).id;
		((GObject)nextDeffenseTitle1).text = LanguagesManager.GetDesc(id22);
		nextDeffense1 = (GTextField)((GComponent)this).GetChild("nextDeffense1");
		string id23 = "ui://l5ik1uclpanqt8o".Replace("ui://", "") + "-" + ((GObject)nextDeffense1).id;
		((GObject)nextDeffense1).text = LanguagesManager.GetDesc(id23);
		n166 = (GImage)((GComponent)this).GetChild("n166");
		nextDeffenseGroup1 = (GGroup)((GComponent)this).GetChild("nextDeffenseGroup1");
		nextHealthTitle1 = (GTextField)((GComponent)this).GetChild("nextHealthTitle1");
		string id24 = "ui://l5ik1uclpanqt8o".Replace("ui://", "") + "-" + ((GObject)nextHealthTitle1).id;
		((GObject)nextHealthTitle1).text = LanguagesManager.GetDesc(id24);
		nextHealth1 = (GTextField)((GComponent)this).GetChild("nextHealth1");
		string id25 = "ui://l5ik1uclpanqt8o".Replace("ui://", "") + "-" + ((GObject)nextHealth1).id;
		((GObject)nextHealth1).text = LanguagesManager.GetDesc(id25);
		n167 = (GImage)((GComponent)this).GetChild("n167");
		nextHealthGroup1 = (GGroup)((GComponent)this).GetChild("nextHealthGroup1");
		nextPropertys1 = (GGroup)((GComponent)this).GetChild("nextPropertys1");
		nextFightTitle2 = (GTextField)((GComponent)this).GetChild("nextFightTitle2");
		string id26 = "ui://l5ik1uclpanqt8o".Replace("ui://", "") + "-" + ((GObject)nextFightTitle2).id;
		((GObject)nextFightTitle2).text = LanguagesManager.GetDesc(id26);
		nextFight2 = (GTextField)((GComponent)this).GetChild("nextFight2");
		n185 = (GImage)((GComponent)this).GetChild("n185");
		nextFightGroup2 = (GGroup)((GComponent)this).GetChild("nextFightGroup2");
		nextAttackTitle2 = (GTextField)((GComponent)this).GetChild("nextAttackTitle2");
		string id27 = "ui://l5ik1uclpanqt8o".Replace("ui://", "") + "-" + ((GObject)nextAttackTitle2).id;
		((GObject)nextAttackTitle2).text = LanguagesManager.GetDesc(id27);
		nextAttack2 = (GTextField)((GComponent)this).GetChild("nextAttack2");
		string id28 = "ui://l5ik1uclpanqt8o".Replace("ui://", "") + "-" + ((GObject)nextAttack2).id;
		((GObject)nextAttack2).text = LanguagesManager.GetDesc(id28);
		n186 = (GImage)((GComponent)this).GetChild("n186");
		nextAttackGroup2 = (GGroup)((GComponent)this).GetChild("nextAttackGroup2");
		nextDeffenseTitle2 = (GTextField)((GComponent)this).GetChild("nextDeffenseTitle2");
		string id29 = "ui://l5ik1uclpanqt8o".Replace("ui://", "") + "-" + ((GObject)nextDeffenseTitle2).id;
		((GObject)nextDeffenseTitle2).text = LanguagesManager.GetDesc(id29);
		nextDeffense2 = (GTextField)((GComponent)this).GetChild("nextDeffense2");
		string id30 = "ui://l5ik1uclpanqt8o".Replace("ui://", "") + "-" + ((GObject)nextDeffense2).id;
		((GObject)nextDeffense2).text = LanguagesManager.GetDesc(id30);
		n187 = (GImage)((GComponent)this).GetChild("n187");
		nextDeffenseGroup2 = (GGroup)((GComponent)this).GetChild("nextDeffenseGroup2");
		nextHealthTitle2 = (GTextField)((GComponent)this).GetChild("nextHealthTitle2");
		string id31 = "ui://l5ik1uclpanqt8o".Replace("ui://", "") + "-" + ((GObject)nextHealthTitle2).id;
		((GObject)nextHealthTitle2).text = LanguagesManager.GetDesc(id31);
		nextHealth2 = (GTextField)((GComponent)this).GetChild("nextHealth2");
		string id32 = "ui://l5ik1uclpanqt8o".Replace("ui://", "") + "-" + ((GObject)nextHealth2).id;
		((GObject)nextHealth2).text = LanguagesManager.GetDesc(id32);
		n188 = (GImage)((GComponent)this).GetChild("n188");
		nextHealthGroup2 = (GGroup)((GComponent)this).GetChild("nextHealthGroup2");
		nextPropertys2 = (GGroup)((GComponent)this).GetChild("nextPropertys2");
		n161 = (GGroup)((GComponent)this).GetChild("n161");
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
		UpgradeEffect = ((GComponent)this).GetTransition("UpgradeEffect");
		ShowProperty1 = ((GComponent)this).GetTransition("ShowProperty1");
		ShowProperty2 = ((GComponent)this).GetTransition("ShowProperty2");
	}
}
