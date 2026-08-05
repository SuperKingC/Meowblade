using FairyGUI;
using FairyGUI.Utils;

namespace UI.WorldMap;

public class UI_RedRockPlateau : GButton
{
	public GImage mask;

	public GGraph highlight;

	public GImage icon;

	public UI_stronghold stronghold1;

	public UI_stronghold stronghold2;

	public UI_stronghold stronghold3;

	public UI_stronghold stronghold4;

	public UI_RedRockPlateau_1Btn stronghold5;

	public UI_stronghold stronghold6;

	public UI_stronghold stronghold7;

	public UI_stronghold stronghold8;

	public UI_stronghold stronghold9;

	public UI_RedRockPlateau_2Btn stronghold10;

	public UI_stronghold stronghold11;

	public UI_stronghold stronghold12;

	public UI_stronghold stronghold13;

	public UI_stronghold stronghold14;

	public UI_RedRockPlateau_3Btn stronghold15;

	public UI_stronghold stronghold16;

	public UI_stronghold stronghold17;

	public UI_stronghold stronghold18;

	public UI_stronghold stronghold19;

	public UI_RedRockPlateau_4Btn stronghold20;

	public UI_stronghold stronghold21;

	public UI_stronghold stronghold22;

	public UI_stronghold stronghold23;

	public UI_stronghold stronghold24;

	public UI_RedRockPlateau_5Btn stronghold25;

	public UI_stronghold stronghold26;

	public UI_stronghold stronghold27;

	public UI_stronghold stronghold28;

	public UI_stronghold stronghold29;

	public UI_RedRockPlateau_6Btn stronghold30;

	public GGroup strongholdsGroup;

	public GGraph fog;

	public GGraph blackHolePos;

	public UI_uiLocator uiLocator;

	public GGraph cameraFocusPos;

	public const string URL = "ui://c9n2h0ksm7wz9r";

	public static string Name = "UI_RedRockPlateau";

	public static string GetURL()
	{
		return "ui://c9n2h0ksm7wz9r";
	}

	public static UI_RedRockPlateau CreateInstance()
	{
		return (UI_RedRockPlateau)(object)UIPackage.CreateObject("WorldMap", "RedRockPlateau");
	}

	public static UI_RedRockPlateau CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_RedRockPlateau).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://c9n2h0ksm7wz9r", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_02eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f5: Expected O, but got Unknown
		//IL_0301: Unknown result type (might be due to invalid IL or missing references)
		//IL_030b: Expected O, but got Unknown
		//IL_0317: Unknown result type (might be due to invalid IL or missing references)
		//IL_0321: Expected O, but got Unknown
		//IL_0343: Unknown result type (might be due to invalid IL or missing references)
		//IL_034d: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		mask = (GImage)((GComponent)this).GetChild("mask");
		highlight = (GGraph)((GComponent)this).GetChild("highlight");
		icon = (GImage)((GComponent)this).GetChild("icon");
		stronghold1 = (UI_stronghold)(object)((GComponent)this).GetChild("stronghold1");
		stronghold2 = (UI_stronghold)(object)((GComponent)this).GetChild("stronghold2");
		stronghold3 = (UI_stronghold)(object)((GComponent)this).GetChild("stronghold3");
		stronghold4 = (UI_stronghold)(object)((GComponent)this).GetChild("stronghold4");
		stronghold5 = (UI_RedRockPlateau_1Btn)(object)((GComponent)this).GetChild("stronghold5");
		stronghold6 = (UI_stronghold)(object)((GComponent)this).GetChild("stronghold6");
		stronghold7 = (UI_stronghold)(object)((GComponent)this).GetChild("stronghold7");
		stronghold8 = (UI_stronghold)(object)((GComponent)this).GetChild("stronghold8");
		stronghold9 = (UI_stronghold)(object)((GComponent)this).GetChild("stronghold9");
		stronghold10 = (UI_RedRockPlateau_2Btn)(object)((GComponent)this).GetChild("stronghold10");
		stronghold11 = (UI_stronghold)(object)((GComponent)this).GetChild("stronghold11");
		stronghold12 = (UI_stronghold)(object)((GComponent)this).GetChild("stronghold12");
		stronghold13 = (UI_stronghold)(object)((GComponent)this).GetChild("stronghold13");
		stronghold14 = (UI_stronghold)(object)((GComponent)this).GetChild("stronghold14");
		stronghold15 = (UI_RedRockPlateau_3Btn)(object)((GComponent)this).GetChild("stronghold15");
		stronghold16 = (UI_stronghold)(object)((GComponent)this).GetChild("stronghold16");
		stronghold17 = (UI_stronghold)(object)((GComponent)this).GetChild("stronghold17");
		stronghold18 = (UI_stronghold)(object)((GComponent)this).GetChild("stronghold18");
		stronghold19 = (UI_stronghold)(object)((GComponent)this).GetChild("stronghold19");
		stronghold20 = (UI_RedRockPlateau_4Btn)(object)((GComponent)this).GetChild("stronghold20");
		stronghold21 = (UI_stronghold)(object)((GComponent)this).GetChild("stronghold21");
		stronghold22 = (UI_stronghold)(object)((GComponent)this).GetChild("stronghold22");
		stronghold23 = (UI_stronghold)(object)((GComponent)this).GetChild("stronghold23");
		stronghold24 = (UI_stronghold)(object)((GComponent)this).GetChild("stronghold24");
		stronghold25 = (UI_RedRockPlateau_5Btn)(object)((GComponent)this).GetChild("stronghold25");
		stronghold26 = (UI_stronghold)(object)((GComponent)this).GetChild("stronghold26");
		stronghold27 = (UI_stronghold)(object)((GComponent)this).GetChild("stronghold27");
		stronghold28 = (UI_stronghold)(object)((GComponent)this).GetChild("stronghold28");
		stronghold29 = (UI_stronghold)(object)((GComponent)this).GetChild("stronghold29");
		stronghold30 = (UI_RedRockPlateau_6Btn)(object)((GComponent)this).GetChild("stronghold30");
		strongholdsGroup = (GGroup)((GComponent)this).GetChild("strongholdsGroup");
		fog = (GGraph)((GComponent)this).GetChild("fog");
		blackHolePos = (GGraph)((GComponent)this).GetChild("blackHolePos");
		uiLocator = (UI_uiLocator)(object)((GComponent)this).GetChild("uiLocator");
		cameraFocusPos = (GGraph)((GComponent)this).GetChild("cameraFocusPos");
	}
}
