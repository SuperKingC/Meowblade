using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGSettlement;

public class UI_com_HeadPortrait : GComponent
{
	public GGraph Mask;

	public GLoader icon;

	public const string URL = "ui://91jxdrkam9tac";

	public static string Name = "UI_com_HeadPortrait";

	public static string GetURL()
	{
		return "ui://91jxdrkam9tac";
	}

	public static UI_com_HeadPortrait CreateInstance()
	{
		return (UI_com_HeadPortrait)(object)UIPackage.CreateObject("GvGSettlement", "com_HeadPortrait");
	}

	public static UI_com_HeadPortrait CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_HeadPortrait).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://91jxdrkam9tac", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		icon = (GLoader)((GComponent)this).GetChild("icon");
	}
}
