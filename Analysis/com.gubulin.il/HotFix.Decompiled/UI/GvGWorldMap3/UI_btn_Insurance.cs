using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_btn_Insurance : GButton
{
	public Controller button;

	public Controller State;

	public GImage n3;

	public GImage n4;

	public GComponent ShipIcon;

	public const string URL = "ui://4eq8fgd2jljfb6sd9";

	public static string Name = "UI_btn_Insurance";

	public static string GetURL()
	{
		return "ui://4eq8fgd2jljfb6sd9";
	}

	public static UI_btn_Insurance CreateInstance()
	{
		return (UI_btn_Insurance)(object)UIPackage.CreateObject("GvGWorldMap3", "btn_Insurance");
	}

	public static UI_btn_Insurance CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_Insurance).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2jljfb6sd9", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		State = ((GComponent)this).GetController("State");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		ShipIcon = (GComponent)((GComponent)this).GetChild("ShipIcon");
	}
}
