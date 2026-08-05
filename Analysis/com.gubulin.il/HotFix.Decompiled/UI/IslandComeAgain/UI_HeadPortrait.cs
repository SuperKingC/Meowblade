using FairyGUI;
using FairyGUI.Utils;

namespace UI.IslandComeAgain;

public class UI_HeadPortrait : GComponent
{
	public GGraph Mask;

	public GLoader icon;

	public const string URL = "ui://k2sprg26oc3d91";

	public static string Name = "UI_HeadPortrait";

	public static string GetURL()
	{
		return "ui://k2sprg26oc3d91";
	}

	public static UI_HeadPortrait CreateInstance()
	{
		return (UI_HeadPortrait)(object)UIPackage.CreateObject("IslandComeAgain", "HeadPortrait");
	}

	public static UI_HeadPortrait CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_HeadPortrait).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k2sprg26oc3d91", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
