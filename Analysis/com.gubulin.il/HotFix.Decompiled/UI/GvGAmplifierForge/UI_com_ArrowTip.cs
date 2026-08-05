using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGAmplifierForge;

public class UI_com_ArrowTip : GComponent
{
	public GImage n4;

	public Transition t0;

	public const string URL = "ui://fpjheycbr4tf2k";

	public static string Name = "UI_com_ArrowTip";

	public static string GetURL()
	{
		return "ui://fpjheycbr4tf2k";
	}

	public static UI_com_ArrowTip CreateInstance()
	{
		return (UI_com_ArrowTip)(object)UIPackage.CreateObject("GvGAmplifierForge", "com_ArrowTip");
	}

	public static UI_com_ArrowTip CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_ArrowTip).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://fpjheycbr4tf2k", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n4 = (GImage)((GComponent)this).GetChild("n4");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
