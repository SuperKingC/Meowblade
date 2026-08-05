using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemsDraw;

public class UI_LegendItemStore : GButton
{
	public Controller button;

	public GImage n9;

	public GImage n10;

	public const string URL = "ui://xogvri2hfjjs14";

	public static string Name = "UI_LegendItemStore";

	public static string GetURL()
	{
		return "ui://xogvri2hfjjs14";
	}

	public static UI_LegendItemStore CreateInstance()
	{
		return (UI_LegendItemStore)(object)UIPackage.CreateObject("LegendItemsDraw", "LegendItemStore");
	}

	public static UI_LegendItemStore CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_LegendItemStore).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://xogvri2hfjjs14", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n9 = (GImage)((GComponent)this).GetChild("n9");
		n10 = (GImage)((GComponent)this).GetChild("n10");
	}
}
