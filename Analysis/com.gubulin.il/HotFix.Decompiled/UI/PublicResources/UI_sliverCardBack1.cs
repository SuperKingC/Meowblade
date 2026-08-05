using FairyGUI;
using FairyGUI.Utils;

namespace UI.PublicResources;

public class UI_sliverCardBack1 : GButton
{
	public Controller button;

	public GImage n18;

	public GImage n19;

	public const string URL = "ui://kt6rg65ovecst9c";

	public static string Name = "UI_sliverCardBack1";

	public static string GetURL()
	{
		return "ui://kt6rg65ovecst9c";
	}

	public static UI_sliverCardBack1 CreateInstance()
	{
		return (UI_sliverCardBack1)(object)UIPackage.CreateObject("PublicResources", "sliverCardBack1");
	}

	public static UI_sliverCardBack1 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_sliverCardBack1).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kt6rg65ovecst9c", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n18 = (GImage)((GComponent)this).GetChild("n18");
		n19 = (GImage)((GComponent)this).GetChild("n19");
	}
}
