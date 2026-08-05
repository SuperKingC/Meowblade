using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGMode3Collecting;

public class UI_com_ShipCollectingInformation : GComponent
{
	public Controller 信息类型;

	public GImage n0;

	public GTextField Num;

	public GLoader n2;

	public const string URL = "ui://n2y4xuvarxuqd";

	public static string Name = "UI_com_ShipCollectingInformation";

	public static string GetURL()
	{
		return "ui://n2y4xuvarxuqd";
	}

	public static UI_com_ShipCollectingInformation CreateInstance()
	{
		return (UI_com_ShipCollectingInformation)(object)UIPackage.CreateObject("GvGMode3Collecting", "com_ShipCollectingInformation");
	}

	public static UI_com_ShipCollectingInformation CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_ShipCollectingInformation).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://n2y4xuvarxuqd", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		信息类型 = ((GComponent)this).GetController("信息类型");
		n0 = (GImage)((GComponent)this).GetChild("n0");
		Num = (GTextField)((GComponent)this).GetChild("Num");
		n2 = (GLoader)((GComponent)this).GetChild("n2");
	}
}
