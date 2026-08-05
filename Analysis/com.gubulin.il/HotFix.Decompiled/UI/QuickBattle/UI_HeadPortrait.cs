using FairyGUI;
using FairyGUI.Utils;

namespace UI.QuickBattle;

public class UI_HeadPortrait : GButton
{
	public Controller button;

	public GImage n3;

	public GImage back;

	public GLoader icon;

	public const string URL = "ui://kqd1t06of25815";

	public static string Name = "UI_HeadPortrait";

	public static string GetURL()
	{
		return "ui://kqd1t06of25815";
	}

	public static UI_HeadPortrait CreateInstance()
	{
		return (UI_HeadPortrait)(object)UIPackage.CreateObject("QuickBattle", "HeadPortrait");
	}

	public static UI_HeadPortrait CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_HeadPortrait).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kqd1t06of25815", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n3 = (GImage)((GComponent)this).GetChild("n3");
		back = (GImage)((GComponent)this).GetChild("back");
		icon = (GLoader)((GComponent)this).GetChild("icon");
	}
}
