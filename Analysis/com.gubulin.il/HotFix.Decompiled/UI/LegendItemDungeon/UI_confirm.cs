using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemDungeon;

public class UI_confirm : GButton
{
	public Controller button;

	public GImage n7;

	public GImage n8;

	public const string URL = "ui://2eraz3j9ldt62k";

	public static string Name = "UI_confirm";

	public static string GetURL()
	{
		return "ui://2eraz3j9ldt62k";
	}

	public static UI_confirm CreateInstance()
	{
		return (UI_confirm)(object)UIPackage.CreateObject("LegendItemDungeon", "confirm");
	}

	public static UI_confirm CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_confirm).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://2eraz3j9ldt62k", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n7 = (GImage)((GComponent)this).GetChild("n7");
		n8 = (GImage)((GComponent)this).GetChild("n8");
	}
}
