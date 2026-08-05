using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemDungeon;

public class UI_ItemDisplayLarge : GButton
{
	public Controller button;

	public GLoader Icon;

	public GTextField Num;

	public const string URL = "ui://2eraz3j9j2ox17";

	public static string Name = "UI_ItemDisplayLarge";

	public static string GetURL()
	{
		return "ui://2eraz3j9j2ox17";
	}

	public static UI_ItemDisplayLarge CreateInstance()
	{
		return (UI_ItemDisplayLarge)(object)UIPackage.CreateObject("LegendItemDungeon", "ItemDisplayLarge");
	}

	public static UI_ItemDisplayLarge CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ItemDisplayLarge).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://2eraz3j9j2ox17", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		Icon = (GLoader)((GComponent)this).GetChild("Icon");
		Num = (GTextField)((GComponent)this).GetChild("Num");
	}
}
