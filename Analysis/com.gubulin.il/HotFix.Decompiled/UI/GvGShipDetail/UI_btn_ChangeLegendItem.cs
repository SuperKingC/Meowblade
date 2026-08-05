using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGShipDetail;

public class UI_btn_ChangeLegendItem : GButton
{
	public Controller button;

	public GImage n3;

	public GLoader n4;

	public const string URL = "ui://u6x0b1gnoip463";

	public static string Name = "UI_btn_ChangeLegendItem";

	public static string GetURL()
	{
		return "ui://u6x0b1gnoip463";
	}

	public static UI_btn_ChangeLegendItem CreateInstance()
	{
		return (UI_btn_ChangeLegendItem)(object)UIPackage.CreateObject("GvGShipDetail", "btn_ChangeLegendItem");
	}

	public static UI_btn_ChangeLegendItem CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_ChangeLegendItem).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://u6x0b1gnoip463", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n4 = (GLoader)((GComponent)this).GetChild("n4");
	}
}
