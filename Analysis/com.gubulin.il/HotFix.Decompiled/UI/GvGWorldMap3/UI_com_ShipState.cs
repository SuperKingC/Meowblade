using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_com_ShipState : GComponent
{
	public Controller State;

	public GImage n1;

	public GImage n2;

	public GImage n3;

	public GImage n4;

	public const string URL = "ui://4eq8fgd2v3u536";

	public static string Name = "UI_com_ShipState";

	public static string GetURL()
	{
		return "ui://4eq8fgd2v3u536";
	}

	public static UI_com_ShipState CreateInstance()
	{
		return (UI_com_ShipState)(object)UIPackage.CreateObject("GvGWorldMap3", "com_ShipState");
	}

	public static UI_com_ShipState CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_ShipState).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2v3u536", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		State = ((GComponent)this).GetController("State");
		n1 = (GImage)((GComponent)this).GetChild("n1");
		n2 = (GImage)((GComponent)this).GetChild("n2");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n4 = (GImage)((GComponent)this).GetChild("n4");
	}
}
