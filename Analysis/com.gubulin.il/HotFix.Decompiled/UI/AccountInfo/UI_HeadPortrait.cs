using FairyGUI;
using FairyGUI.Utils;

namespace UI.AccountInfo;

public class UI_HeadPortrait : GComponent
{
	public Controller Type;

	public GGraph mask;

	public GLoader icon;

	public const string URL = "ui://b9yxt7u0gw2m1w";

	public static string Name = "UI_HeadPortrait";

	public static string GetURL()
	{
		return "ui://b9yxt7u0gw2m1w";
	}

	public static UI_HeadPortrait CreateInstance()
	{
		return (UI_HeadPortrait)(object)UIPackage.CreateObject("AccountInfo", "HeadPortrait");
	}

	public static UI_HeadPortrait CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_HeadPortrait).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b9yxt7u0gw2m1w", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		mask = (GGraph)((GComponent)this).GetChild("mask");
		icon = (GLoader)((GComponent)this).GetChild("icon");
	}
}
