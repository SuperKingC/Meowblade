using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_btn_ReplenishSoldier : GButton
{
	public Controller button;

	public Controller IsAvailable;

	public GImage n3;

	public GImage n8;

	public GImage n9;

	public const string URL = "ui://4eq8fgd2ql4qgn";

	public static string Name = "UI_btn_ReplenishSoldier";

	public static string GetURL()
	{
		return "ui://4eq8fgd2ql4qgn";
	}

	public static UI_btn_ReplenishSoldier CreateInstance()
	{
		return (UI_btn_ReplenishSoldier)(object)UIPackage.CreateObject("GvGWorldMap3", "btn_ReplenishSoldier");
	}

	public static UI_btn_ReplenishSoldier CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_ReplenishSoldier).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2ql4qgn", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		IsAvailable = ((GComponent)this).GetController("IsAvailable");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n8 = (GImage)((GComponent)this).GetChild("n8");
		n9 = (GImage)((GComponent)this).GetChild("n9");
	}
}
