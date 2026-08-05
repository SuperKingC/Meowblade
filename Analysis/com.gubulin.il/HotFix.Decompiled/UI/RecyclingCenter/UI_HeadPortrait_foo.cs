using FairyGUI;
using FairyGUI.Utils;

namespace UI.RecyclingCenter;

public class UI_HeadPortrait_foo : GComponent
{
	public GGraph mask;

	public GLoader icon;

	public const string URL = "ui://72poq8plt5u81u";

	public static string Name = "UI_HeadPortrait_foo";

	public static string GetURL()
	{
		return "ui://72poq8plt5u81u";
	}

	public static UI_HeadPortrait_foo CreateInstance()
	{
		return (UI_HeadPortrait_foo)(object)UIPackage.CreateObject("RecyclingCenter", "HeadPortrait_foo");
	}

	public static UI_HeadPortrait_foo CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_HeadPortrait_foo).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://72poq8plt5u81u", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		mask = (GGraph)((GComponent)this).GetChild("mask");
		icon = (GLoader)((GComponent)this).GetChild("icon");
	}
}
