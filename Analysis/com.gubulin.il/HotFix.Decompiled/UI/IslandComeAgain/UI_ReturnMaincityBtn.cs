using FairyGUI;
using FairyGUI.Utils;

namespace UI.IslandComeAgain;

public class UI_ReturnMaincityBtn : GButton
{
	public Controller button;

	public GImage n14;

	public GImage n15;

	public const string URL = "ui://k2sprg26rytn12";

	public static string Name = "UI_ReturnMaincityBtn";

	public static string GetURL()
	{
		return "ui://k2sprg26rytn12";
	}

	public static UI_ReturnMaincityBtn CreateInstance()
	{
		return (UI_ReturnMaincityBtn)(object)UIPackage.CreateObject("IslandComeAgain", "ReturnMaincityBtn");
	}

	public static UI_ReturnMaincityBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ReturnMaincityBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k2sprg26rytn12", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n14 = (GImage)((GComponent)this).GetChild("n14");
		n15 = (GImage)((GComponent)this).GetChild("n15");
	}
}
