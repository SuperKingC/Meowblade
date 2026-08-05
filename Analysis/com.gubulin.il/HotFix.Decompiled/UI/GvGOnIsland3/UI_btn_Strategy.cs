using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGOnIsland3;

public class UI_btn_Strategy : GButton
{
	public Controller button;

	public Controller CampId;

	public GLoader Icon;

	public GImage n7;

	public GImage n8;

	public const string URL = "ui://ebc4ciwrl44l12";

	public static string Name = "UI_btn_Strategy";

	public static string GetURL()
	{
		return "ui://ebc4ciwrl44l12";
	}

	public static UI_btn_Strategy CreateInstance()
	{
		return (UI_btn_Strategy)(object)UIPackage.CreateObject("GvGOnIsland3", "btn_Strategy");
	}

	public static UI_btn_Strategy CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_Strategy).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://ebc4ciwrl44l12", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		CampId = ((GComponent)this).GetController("CampId");
		Icon = (GLoader)((GComponent)this).GetChild("Icon");
		n7 = (GImage)((GComponent)this).GetChild("n7");
		n8 = (GImage)((GComponent)this).GetChild("n8");
	}
}
