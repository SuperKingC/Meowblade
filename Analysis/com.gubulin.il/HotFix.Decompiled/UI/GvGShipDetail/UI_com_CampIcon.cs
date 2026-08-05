using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGShipDetail;

public class UI_com_CampIcon : GComponent
{
	public Controller CampId;

	public GLoader n82;

	public const string URL = "ui://u6x0b1gnatee22";

	public static string Name = "UI_com_CampIcon";

	public static string GetURL()
	{
		return "ui://u6x0b1gnatee22";
	}

	public static UI_com_CampIcon CreateInstance()
	{
		return (UI_com_CampIcon)(object)UIPackage.CreateObject("GvGShipDetail", "com_CampIcon");
	}

	public static UI_com_CampIcon CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_CampIcon).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://u6x0b1gnatee22", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		CampId = ((GComponent)this).GetController("CampId");
		n82 = (GLoader)((GComponent)this).GetChild("n82");
	}
}
