using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGTalent;

public class UI_com_AreaLogoGreen : GComponent
{
	public Controller Lv;

	public GImage n27;

	public GImage n31;

	public GLoader n32;

	public const string URL = "ui://4r1llhd8tchc35";

	public static string Name = "UI_com_AreaLogoGreen";

	public static string GetURL()
	{
		return "ui://4r1llhd8tchc35";
	}

	public static UI_com_AreaLogoGreen CreateInstance()
	{
		return (UI_com_AreaLogoGreen)(object)UIPackage.CreateObject("GvGTalent", "com_AreaLogoGreen");
	}

	public static UI_com_AreaLogoGreen CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_AreaLogoGreen).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4r1llhd8tchc35", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n27 = (GImage)((GComponent)this).GetChild("n27");
		n31 = (GImage)((GComponent)this).GetChild("n31");
		n32 = (GLoader)((GComponent)this).GetChild("n32");
	}
}
