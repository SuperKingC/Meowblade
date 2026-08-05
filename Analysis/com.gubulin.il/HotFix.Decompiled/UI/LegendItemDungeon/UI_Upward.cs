using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemDungeon;

public class UI_Upward : GButton
{
	public Controller button;

	public GImage n4;

	public GImage n5;

	public const string URL = "ui://2eraz3j9y9rzl";

	public static string Name = "UI_Upward";

	public static string GetURL()
	{
		return "ui://2eraz3j9y9rzl";
	}

	public static UI_Upward CreateInstance()
	{
		return (UI_Upward)(object)UIPackage.CreateObject("LegendItemDungeon", "Upward");
	}

	public static UI_Upward CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_Upward).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://2eraz3j9y9rzl", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n4 = (GImage)((GComponent)this).GetChild("n4");
		n5 = (GImage)((GComponent)this).GetChild("n5");
	}
}
