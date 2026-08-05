using FairyGUI;
using FairyGUI.Utils;

namespace UI.WarOrder;

public class UI_QuickGetBtn : GButton
{
	public Controller button;

	public GImage n6;

	public GImage n7;

	public const string URL = "ui://ax280w58okbc23";

	public static string Name = "UI_QuickGetBtn";

	public static string GetURL()
	{
		return "ui://ax280w58okbc23";
	}

	public static UI_QuickGetBtn CreateInstance()
	{
		return (UI_QuickGetBtn)(object)UIPackage.CreateObject("WarOrder", "QuickGetBtn");
	}

	public static UI_QuickGetBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_QuickGetBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://ax280w58okbc23", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n6 = (GImage)((GComponent)this).GetChild("n6");
		n7 = (GImage)((GComponent)this).GetChild("n7");
	}
}
