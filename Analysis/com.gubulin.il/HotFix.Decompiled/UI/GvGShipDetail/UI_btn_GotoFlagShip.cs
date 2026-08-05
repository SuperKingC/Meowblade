using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGShipDetail;

public class UI_btn_GotoFlagShip : GButton
{
	public GTextField n115;

	public GImage n116;

	public const string URL = "ui://u6x0b1gnng386y";

	public static string Name = "UI_btn_GotoFlagShip";

	public static string GetURL()
	{
		return "ui://u6x0b1gnng386y";
	}

	public static UI_btn_GotoFlagShip CreateInstance()
	{
		return (UI_btn_GotoFlagShip)(object)UIPackage.CreateObject("GvGShipDetail", "btn_GotoFlagShip");
	}

	public static UI_btn_GotoFlagShip CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_GotoFlagShip).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://u6x0b1gnng386y", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n115 = (GTextField)((GComponent)this).GetChild("n115");
		string id = "ui://u6x0b1gnng386y".Replace("ui://", "") + "-" + ((GObject)n115).id;
		((GObject)n115).text = LanguagesManager.GetDesc(id);
		n116 = (GImage)((GComponent)this).GetChild("n116");
	}
}
