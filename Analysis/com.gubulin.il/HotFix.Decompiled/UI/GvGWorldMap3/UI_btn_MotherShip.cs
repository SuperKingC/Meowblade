using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_btn_MotherShip : GButton
{
	public Controller Camp;

	public GImage n25;

	public GLoader FlagShip;

	public GImage n26;

	public const string URL = "ui://4eq8fgd2x0rbco";

	public static string Name = "UI_btn_MotherShip";

	public static string GetURL()
	{
		return "ui://4eq8fgd2x0rbco";
	}

	public static UI_btn_MotherShip CreateInstance()
	{
		return (UI_btn_MotherShip)(object)UIPackage.CreateObject("GvGWorldMap3", "btn_MotherShip");
	}

	public static UI_btn_MotherShip CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_MotherShip).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2x0rbco", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		Camp = ((GComponent)this).GetController("Camp");
		n25 = (GImage)((GComponent)this).GetChild("n25");
		FlagShip = (GLoader)((GComponent)this).GetChild("FlagShip");
		n26 = (GImage)((GComponent)this).GetChild("n26");
	}
}
