using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGOnIsland3;

public class UI_btn_Zoom : GButton
{
	public Controller button;

	public Controller Type;

	public GImage n9;

	public GImage n3;

	public GImage n4;

	public const string URL = "ui://ebc4ciwrl44lz";

	public static string Name = "UI_btn_Zoom";

	public static string GetURL()
	{
		return "ui://ebc4ciwrl44lz";
	}

	public static UI_btn_Zoom CreateInstance()
	{
		return (UI_btn_Zoom)(object)UIPackage.CreateObject("GvGOnIsland3", "btn_Zoom");
	}

	public static UI_btn_Zoom CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_Zoom).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://ebc4ciwrl44lz", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		Type = ((GComponent)this).GetController("Type");
		n9 = (GImage)((GComponent)this).GetChild("n9");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n4 = (GImage)((GComponent)this).GetChild("n4");
	}
}
