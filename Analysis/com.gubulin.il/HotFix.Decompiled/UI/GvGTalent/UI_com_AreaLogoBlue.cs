using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGTalent;

public class UI_com_AreaLogoBlue : GComponent
{
	public Controller Lv;

	public GImage n29;

	public GImage n34;

	public GLoader n36;

	public const string URL = "ui://4r1llhd8tchc36";

	public static string Name = "UI_com_AreaLogoBlue";

	public static string GetURL()
	{
		return "ui://4r1llhd8tchc36";
	}

	public static UI_com_AreaLogoBlue CreateInstance()
	{
		return (UI_com_AreaLogoBlue)(object)UIPackage.CreateObject("GvGTalent", "com_AreaLogoBlue");
	}

	public static UI_com_AreaLogoBlue CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_AreaLogoBlue).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4r1llhd8tchc36", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n29 = (GImage)((GComponent)this).GetChild("n29");
		n34 = (GImage)((GComponent)this).GetChild("n34");
		n36 = (GLoader)((GComponent)this).GetChild("n36");
	}
}
