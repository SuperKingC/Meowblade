using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGShipDetail;

public class UI_com_BuffsTip : GComponent
{
	public GImage BuffsBg;

	public GImage BuffsIcon;

	public const string URL = "ui://u6x0b1gne5z07p";

	public static string Name = "UI_com_BuffsTip";

	public static string GetURL()
	{
		return "ui://u6x0b1gne5z07p";
	}

	public static UI_com_BuffsTip CreateInstance()
	{
		return (UI_com_BuffsTip)(object)UIPackage.CreateObject("GvGShipDetail", "com_BuffsTip");
	}

	public static UI_com_BuffsTip CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_BuffsTip).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://u6x0b1gne5z07p", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		BuffsBg = (GImage)((GComponent)this).GetChild("BuffsBg");
		BuffsIcon = (GImage)((GComponent)this).GetChild("BuffsIcon");
	}
}
