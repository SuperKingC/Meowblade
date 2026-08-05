using FairyGUI;
using FairyGUI.Utils;

namespace UI.PublicResources;

public class UI_Btn_BattleSkip : GButton
{
	public Controller button;

	public GImage n10;

	public const string URL = "ui://kt6rg65oygntv4vg";

	public static string Name = "UI_Btn_BattleSkip";

	public static string GetURL()
	{
		return "ui://kt6rg65oygntv4vg";
	}

	public static UI_Btn_BattleSkip CreateInstance()
	{
		return (UI_Btn_BattleSkip)(object)UIPackage.CreateObject("PublicResources", "Btn_BattleSkip");
	}

	public static UI_Btn_BattleSkip CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_Btn_BattleSkip).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kt6rg65oygntv4vg", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n10 = (GImage)((GComponent)this).GetChild("n10");
	}
}
