using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemDungeon;

public class UI_DrawBtn : GButton
{
	public Controller button;

	public GImage Back;

	public GImage n7;

	public const string URL = "ui://2eraz3j9y9rzn";

	public static string Name = "UI_DrawBtn";

	public static string GetURL()
	{
		return "ui://2eraz3j9y9rzn";
	}

	public static UI_DrawBtn CreateInstance()
	{
		return (UI_DrawBtn)(object)UIPackage.CreateObject("LegendItemDungeon", "DrawBtn");
	}

	public static UI_DrawBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_DrawBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://2eraz3j9y9rzn", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		Back = (GImage)((GComponent)this).GetChild("Back");
		n7 = (GImage)((GComponent)this).GetChild("n7");
	}
}
