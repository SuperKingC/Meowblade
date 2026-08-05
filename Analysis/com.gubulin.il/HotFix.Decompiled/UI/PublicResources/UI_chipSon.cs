using FairyGUI;
using FairyGUI.Utils;

namespace UI.PublicResources;

public class UI_chipSon : GButton
{
	public Controller button;

	public GImage mask;

	public GLoader back;

	public GLoader icon;

	public const string URL = "ui://kt6rg65ovv0uei";

	public static string Name = "UI_chipSon";

	public static string GetURL()
	{
		return "ui://kt6rg65ovv0uei";
	}

	public static UI_chipSon CreateInstance()
	{
		return (UI_chipSon)(object)UIPackage.CreateObject("PublicResources", "chipSon");
	}

	public static UI_chipSon CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_chipSon).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kt6rg65ovv0uei", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		mask = (GImage)((GComponent)this).GetChild("mask");
		back = (GLoader)((GComponent)this).GetChild("back");
		icon = (GLoader)((GComponent)this).GetChild("icon");
	}
}
