using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGTalent;

public class UI_com_AreaLogoYellow : GComponent
{
	public Controller Lv;

	public GImage n28;

	public GImage n33;

	public GLoader n34;

	public const string URL = "ui://4r1llhd8tchc33";

	public static string Name = "UI_com_AreaLogoYellow";

	public static string GetURL()
	{
		return "ui://4r1llhd8tchc33";
	}

	public static UI_com_AreaLogoYellow CreateInstance()
	{
		return (UI_com_AreaLogoYellow)(object)UIPackage.CreateObject("GvGTalent", "com_AreaLogoYellow");
	}

	public static UI_com_AreaLogoYellow CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_AreaLogoYellow).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4r1llhd8tchc33", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		Lv = ((GComponent)this).GetController("Lv");
		n28 = (GImage)((GComponent)this).GetChild("n28");
		n33 = (GImage)((GComponent)this).GetChild("n33");
		n34 = (GLoader)((GComponent)this).GetChild("n34");
	}
}
