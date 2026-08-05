using FairyGUI;
using FairyGUI.Utils;

namespace UI.WorldMap;

public class UI_arrow2 : GButton
{
	public Controller button;

	public GGraph n4;

	public GImage n3;

	public const string URL = "ui://c9n2h0ksr46h33";

	public static string Name = "UI_arrow2";

	public static string GetURL()
	{
		return "ui://c9n2h0ksr46h33";
	}

	public static UI_arrow2 CreateInstance()
	{
		return (UI_arrow2)(object)UIPackage.CreateObject("WorldMap", "arrow2");
	}

	public static UI_arrow2 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_arrow2).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://c9n2h0ksr46h33", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n3 = (GImage)((GComponent)this).GetChild("n3");
	}
}
