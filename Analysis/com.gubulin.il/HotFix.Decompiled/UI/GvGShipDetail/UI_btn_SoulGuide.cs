using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGShipDetail;

public class UI_btn_SoulGuide : GButton
{
	public GImage n0;

	public const string URL = "ui://u6x0b1gnc9xa6m";

	public static string Name = "UI_btn_SoulGuide";

	public static string GetURL()
	{
		return "ui://u6x0b1gnc9xa6m";
	}

	public static UI_btn_SoulGuide CreateInstance()
	{
		return (UI_btn_SoulGuide)(object)UIPackage.CreateObject("GvGShipDetail", "btn_SoulGuide");
	}

	public static UI_btn_SoulGuide CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_SoulGuide).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://u6x0b1gnc9xa6m", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n0 = (GImage)((GComponent)this).GetChild("n0");
	}
}
