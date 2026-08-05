using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Legion;

public class UI_IntroductionPanelA : GComponent
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

	public UI_activate activate;

	public GRichTextField chipsTitle;

	public GRichTextField currentChipNum;

	public GRichTextField upLimit;

	public GGroup activeGroup;

	public GList UnlockStoneNum;

	public GButton racePicture;

	public GTextField n172;

	public GGroup tip;

	public Transition showSelf;

	public const string URL = "ui://lrhs6zw7sni52i";

	public static string Name = "UI_IntroductionPanelA";

	public static string GetURL()
	{
		return "ui://lrhs6zw7sni52i";
	}

	public static UI_IntroductionPanelA CreateInstance()
	{
		return (UI_IntroductionPanelA)(object)UIPackage.CreateObject("Legion", "IntroductionPanelA");
	}

	public static UI_IntroductionPanelA CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_IntroductionPanelA).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://lrhs6zw7sni52i", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		string id = "ui://lrhs6zw7sni52i".Replace("ui://", "") + "-" + ((GObject)attackTiele).id;
		((GObject)attackTiele).text = LanguagesManager.GetDesc(id);
		defenseTiele = (GTextField)((GComponent)this).GetChild("defenseTiele");
		string id2 = "ui://lrhs6zw7sni52i".Replace("ui://", "") + "-" + ((GObject)defenseTiele).id;
		((GObject)defenseTiele).text = LanguagesManager.GetDesc(id2);
		healthTiele = (GTextField)((GComponent)this).GetChild("healthTiele");
		string id3 = "ui://lrhs6zw7sni52i".Replace("ui://", "") + "-" + ((GObject)healthTiele).id;
		((GObject)healthTiele).text = LanguagesManager.GetDesc(id3);
		attack = (GTextField)((GComponent)this).GetChild("attack");
		string id4 = "ui://lrhs6zw7sni52i".Replace("ui://", "") + "-" + ((GObject)attack).id;
		((GObject)attack).text = LanguagesManager.GetDesc(id4);
		health = (GTextField)((GComponent)this).GetChild("health");
		string id5 = "ui://lrhs6zw7sni52i".Replace("ui://", "") + "-" + ((GObject)health).id;
		((GObject)health).text = LanguagesManager.GetDesc(id5);
		defense = (GTextField)((GComponent)this).GetChild("defense");
		string id6 = "ui://lrhs6zw7sni52i".Replace("ui://", "") + "-" + ((GObject)defense).id;
		((GObject)defense).text = LanguagesManager.GetDesc(id6);
		attackLoader = (GLoader)((GComponent)this).GetChild("attackLoader");
		defenseLoader = (GLoader)((GComponent)this).GetChild("defenseLoader");
		healthLoader = (GLoader)((GComponent)this).GetChild("healthLoader");
		SoldierNamePotentialLevelBack = (GComponent)((GComponent)this).GetChild("SoldierNamePotentialLevelBack");
		title = (GRichTextField)((GComponent)this).GetChild("title");
		string id7 = "ui://lrhs6zw7sni52i".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id7);
		introduction = (GRichTextField)((GComponent)this).GetChild("introduction");
		string id8 = "ui://lrhs6zw7sni52i".Replace("ui://", "") + "-" + ((GObject)introduction).id;
		((GObject)introduction).text = LanguagesManager.GetDesc(id8);
		propertyBackgroundC = (GImage)((GComponent)this).GetChild("propertyBackgroundC");
		n140 = (GImage)((GComponent)this).GetChild("n140");
		specialityName = (GTextField)((GComponent)this).GetChild("specialityName");
		string id9 = "ui://lrhs6zw7sni52i".Replace("ui://", "") + "-" + ((GObject)specialityName).id;
		((GObject)specialityName).text = LanguagesManager.GetDesc(id9);
		specialityText = (GRichTextField)((GComponent)this).GetChild("specialityText");
		n144 = (GImage)((GComponent)this).GetChild("n144");
		n145 = (GImage)((GComponent)this).GetChild("n145");
		n146 = (GTextField)((GComponent)this).GetChild("n146");
		string id10 = "ui://lrhs6zw7sni52i".Replace("ui://", "") + "-" + ((GObject)n146).id;
		((GObject)n146).text = LanguagesManager.GetDesc(id10);
		skillTitleGroup = (GGroup)((GComponent)this).GetChild("skillTitleGroup");
		skillList = (GList)((GComponent)this).GetChild("skillList");
		FormationSoldierAmountBack = (GImage)((GComponent)this).GetChild("FormationSoldierAmountBack");
		n152 = (GImage)((GComponent)this).GetChild("n152");
		CombatPowerSfxBack = (GGraph)((GComponent)this).GetChild("CombatPowerSfxBack");
		phalanx = (GTextField)((GComponent)this).GetChild("phalanx");
		string id11 = "ui://lrhs6zw7sni52i".Replace("ui://", "") + "-" + ((GObject)phalanx).id;
		((GObject)phalanx).text = LanguagesManager.GetDesc(id11);
		FormationSoldierAmountSpine = (GGraph)((GComponent)this).GetChild("FormationSoldierAmountSpine");
		upperLimit = (GTextField)((GComponent)this).GetChild("upperLimit");
		combatPower = (GTextField)((GComponent)this).GetChild("combatPower");
		string id12 = "ui://lrhs6zw7sni52i".Replace("ui://", "") + "-" + ((GObject)combatPower).id;
		((GObject)combatPower).text = LanguagesManager.GetDesc(id12);
		fighting = (GTextField)((GComponent)this).GetChild("fighting");
		CombatPowerSpine = (GGraph)((GComponent)this).GetChild("CombatPowerSpine");
		CombatPowerIcon = (GImage)((GComponent)this).GetChild("CombatPowerIcon");
		Bottomleftcorner = (GGroup)((GComponent)this).GetChild("Bottomleftcorner");
		rareness = (GLoader)((GComponent)this).GetChild("rareness");
		exit = (GButton)((GComponent)this).GetChild("exit");
		activate = (UI_activate)(object)((GComponent)this).GetChild("activate");
		chipsTitle = (GRichTextField)((GComponent)this).GetChild("chipsTitle");
		string id13 = "ui://lrhs6zw7sni52i".Replace("ui://", "") + "-" + ((GObject)chipsTitle).id;
		((GObject)chipsTitle).text = LanguagesManager.GetDesc(id13);
		currentChipNum = (GRichTextField)((GComponent)this).GetChild("currentChipNum");
		string id14 = "ui://lrhs6zw7sni52i".Replace("ui://", "") + "-" + ((GObject)currentChipNum).id;
		((GObject)currentChipNum).text = LanguagesManager.GetDesc(id14);
		upLimit = (GRichTextField)((GComponent)this).GetChild("upLimit");
		string id15 = "ui://lrhs6zw7sni52i".Replace("ui://", "") + "-" + ((GObject)upLimit).id;
		((GObject)upLimit).text = LanguagesManager.GetDesc(id15);
		activeGroup = (GGroup)((GComponent)this).GetChild("activeGroup");
		UnlockStoneNum = (GList)((GComponent)this).GetChild("UnlockStoneNum");
		racePicture = (GButton)((GComponent)this).GetChild("racePicture");
		n172 = (GTextField)((GComponent)this).GetChild("n172");
		string id16 = "ui://lrhs6zw7sni52i".Replace("ui://", "") + "-" + ((GObject)n172).id;
		((GObject)n172).text = LanguagesManager.GetDesc(id16);
		tip = (GGroup)((GComponent)this).GetChild("tip");
		showSelf = ((GComponent)this).GetTransition("showSelf");
	}
}
