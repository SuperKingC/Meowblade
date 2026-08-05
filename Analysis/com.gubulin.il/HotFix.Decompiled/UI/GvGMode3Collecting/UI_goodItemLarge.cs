using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGMode3Collecting;

public class UI_goodItemLarge : GButton
{
	public Controller button;

	public Controller StockType;

	public GLoader icon;

	public GImage max;

	public const string URL = "ui://n2y4xuvarxuqh";

	public static string Name = "UI_goodItemLarge";

	public static string GetURL()
	{
		return "ui://n2y4xuvarxuqh";
	}

	public static UI_goodItemLarge CreateInstance()
	{
		return (UI_goodItemLarge)(object)UIPackage.CreateObject("GvGMode3Collecting", "goodItemLarge");
	}

	public static UI_goodItemLarge CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_goodItemLarge).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://n2y4xuvarxuqh", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		StockType = ((GComponent)this).GetController("StockType");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		max = (GImage)((GComponent)this).GetChild("max");
	}
}
