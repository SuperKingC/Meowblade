using FairyGUI;
using FairyGUI.Utils;

namespace UI.WorldMap;

public class UI_CountdownBtn : GButton
{
	public Controller button;

	public GImage back;

	public GTextField timeTip;

	public const string URL = "ui://c9n2h0ksr46h30";

	public static string Name = "UI_CountdownBtn";

	public static string GetURL()
	{
		return "ui://c9n2h0ksr46h30";
	}

	public static UI_CountdownBtn CreateInstance()
	{
		return (UI_CountdownBtn)(object)UIPackage.CreateObject("WorldMap", "CountdownBtn");
	}

	public static UI_CountdownBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_CountdownBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://c9n2h0ksr46h30", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		back = (GImage)((GComponent)this).GetChild("back");
		timeTip = (GTextField)((GComponent)this).GetChild("timeTip");
	}
}
