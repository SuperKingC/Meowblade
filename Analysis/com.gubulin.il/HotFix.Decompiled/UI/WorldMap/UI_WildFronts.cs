using FairyGUI;
using FairyGUI.Utils;

namespace UI.WorldMap;

public class UI_WildFronts : GButton
{
	public GImage mask;

	public GGraph highlight;

	public GImage icon;

	public UI_stronghold stronghold1;

	public UI_stronghold stronghold2;

	public UI_stronghold stronghold3;

	public UI_stronghold stronghold4;

	public UI_WildFronts_1Btn stronghold5;

	public UI_stronghold stronghold6;

	public UI_stronghold stronghold7;

	public UI_stronghold stronghold8;

	public UI_stronghold stronghold9;

	public UI_WildFronts_2Btn stronghold10;

	public UI_stronghold stronghold11;

	public UI_stronghold stronghold12;

	public UI_stronghold stronghold13;

	public UI_stronghold stronghold14;

	public UI_WildFronts_3Btn stronghold15;

	public UI_stronghold stronghold16;

	public UI_stronghold stronghold17;

	public UI_stronghold stronghold18;

	public UI_stronghold stronghold19;

	public UI_WildFronts_4Btn stronghold20;

	public GGroup strongholdsGroup;

	public GGraph slot0;

	public GGraph slot1;

	public GGraph slot2;

	public GGraph slot4;

	public GGraph fog;

	public GGraph blackHolePos;

	public UI_uiLocator uiLocator;

	public GGraph cameraFocusPos;

	public const string URL = "ui://c9n2h0ksm7wz9z";

	public static string Name = "UI_WildFronts";

	public static string GetURL()
	{
		return "ui://c9n2h0ksm7wz9z";
	}

	public static UI_WildFronts CreateInstance()
	{
		return (UI_WildFronts)(object)UIPackage.CreateObject("WorldMap", "WildFronts");
	}

	public static UI_WildFronts CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_WildFronts).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://c9n2h0ksm7wz9z", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_020f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0219: Expected O, but got Unknown
		//IL_0225: Unknown result type (might be due to invalid IL or missing references)
		//IL_022f: Expected O, but got Unknown
		//IL_023b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0245: Expected O, but got Unknown
		//IL_0251: Unknown result type (might be due to invalid IL or missing references)
		//IL_025b: Expected O, but got Unknown
		//IL_0267: Unknown result type (might be due to invalid IL or missing references)
		//IL_0271: Expected O, but got Unknown
		//IL_027d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0287: Expected O, but got Unknown
		//IL_0293: Unknown result type (might be due to invalid IL or missing references)
		//IL_029d: Expected O, but got Unknown
		//IL_02bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c9: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		mask = (GImage)((GComponent)this).GetChild("mask");
		highlight = (GGraph)((GComponent)this).GetChild("highlight");
		icon = (GImage)((GComponent)this).GetChild("icon");
		stronghold1 = (UI_stronghold)(object)((GComponent)this).GetChild("stronghold1");
		stronghold2 = (UI_stronghold)(object)((GComponent)this).GetChild("stronghold2");
		stronghold3 = (UI_stronghold)(object)((GComponent)this).GetChild("stronghold3");
		stronghold4 = (UI_stronghold)(object)((GComponent)this).GetChild("stronghold4");
		stronghold5 = (UI_WildFronts_1Btn)(object)((GComponent)this).GetChild("stronghold5");
		stronghold6 = (UI_stronghold)(object)((GComponent)this).GetChild("stronghold6");
		stronghold7 = (UI_stronghold)(object)((GComponent)this).GetChild("stronghold7");
		stronghold8 = (UI_stronghold)(object)((GComponent)this).GetChild("stronghold8");
		stronghold9 = (UI_stronghold)(object)((GComponent)this).GetChild("stronghold9");
		stronghold10 = (UI_WildFronts_2Btn)(object)((GComponent)this).GetChild("stronghold10");
		stronghold11 = (UI_stronghold)(object)((GComponent)this).GetChild("stronghold11");
		stronghold12 = (UI_stronghold)(object)((GComponent)this).GetChild("stronghold12");
		stronghold13 = (UI_stronghold)(object)((GComponent)this).GetChild("stronghold13");
		stronghold14 = (UI_stronghold)(object)((GComponent)this).GetChild("stronghold14");
		stronghold15 = (UI_WildFronts_3Btn)(object)((GComponent)this).GetChild("stronghold15");
		stronghold16 = (UI_stronghold)(object)((GComponent)this).GetChild("stronghold16");
		stronghold17 = (UI_stronghold)(object)((GComponent)this).GetChild("stronghold17");
		stronghold18 = (UI_stronghold)(object)((GComponent)this).GetChild("stronghold18");
		stronghold19 = (UI_stronghold)(object)((GComponent)this).GetChild("stronghold19");
		stronghold20 = (UI_WildFronts_4Btn)(object)((GComponent)this).GetChild("stronghold20");
		strongholdsGroup = (GGroup)((GComponent)this).GetChild("strongholdsGroup");
		slot0 = (GGraph)((GComponent)this).GetChild("slot0");
		slot1 = (GGraph)((GComponent)this).GetChild("slot1");
		slot2 = (GGraph)((GComponent)this).GetChild("slot2");
		slot4 = (GGraph)((GComponent)this).GetChild("slot4");
		fog = (GGraph)((GComponent)this).GetChild("fog");
		blackHolePos = (GGraph)((GComponent)this).GetChild("blackHolePos");
		uiLocator = (UI_uiLocator)(object)((GComponent)this).GetChild("uiLocator");
		cameraFocusPos = (GGraph)((GComponent)this).GetChild("cameraFocusPos");
	}
}
