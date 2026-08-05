using FairyGUI;
using FairyGUI.Utils;

namespace UI.WorldMap;

public class UI_AdjustBtn : GButton
{
	public Controller button;

	public GGraph n4;

	public GImage n5;

	public const string URL = "ui://c9n2h0ksjt7ma5";

	public static string Name = "UI_AdjustBtn";

	public static string GetURL()
	{
		return "ui://c9n2h0ksjt7ma5";
	}

	public static UI_AdjustBtn CreateInstance()
	{
		return (UI_AdjustBtn)(object)UIPackage.CreateObject("WorldMap", "AdjustBtn");
	}

	public static UI_AdjustBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_AdjustBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://c9n2h0ksjt7ma5", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n4 = (GGraph)((GComponent)this).GetChild("n4");
		n5 = (GImage)((GComponent)this).GetChild("n5");
	}
}
