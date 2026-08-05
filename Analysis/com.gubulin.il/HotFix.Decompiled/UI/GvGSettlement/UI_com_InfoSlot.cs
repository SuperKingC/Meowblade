using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGSettlement;

public class UI_com_InfoSlot : GComponent
{
	public GImage n159;

	public GImage n162;

	public GTextField InfoName;

	public GTextField InfoData;

	public GImage n163;

	public const string URL = "ui://91jxdrkap3r715";

	public static string Name = "UI_com_InfoSlot";

	public static string GetURL()
	{
		return "ui://91jxdrkap3r715";
	}

	public static UI_com_InfoSlot CreateInstance()
	{
		return (UI_com_InfoSlot)(object)UIPackage.CreateObject("GvGSettlement", "com_InfoSlot");
	}

	public static UI_com_InfoSlot CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_InfoSlot).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://91jxdrkap3r715", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n159 = (GImage)((GComponent)this).GetChild("n159");
		n162 = (GImage)((GComponent)this).GetChild("n162");
		InfoName = (GTextField)((GComponent)this).GetChild("InfoName");
		InfoData = (GTextField)((GComponent)this).GetChild("InfoData");
		n163 = (GImage)((GComponent)this).GetChild("n163");
	}
}
