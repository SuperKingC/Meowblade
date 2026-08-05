using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemBlueprint;

public class UI_btn_Lock : GButton
{
	public Controller button;

	public Controller isLocked;

	public GImage n3;

	public GImage n5;

	public GImage n6;

	public const string URL = "ui://h09dvkcgfevs5ltfu";

	public static string Name = "UI_btn_Lock";

	public static string GetURL()
	{
		return "ui://h09dvkcgfevs5ltfu";
	}

	public static UI_btn_Lock CreateInstance()
	{
		return (UI_btn_Lock)(object)UIPackage.CreateObject("LegendItemBlueprint", "btn_Lock");
	}

	public static UI_btn_Lock CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_Lock).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://h09dvkcgfevs5ltfu", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		isLocked = ((GComponent)this).GetController("isLocked");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		n6 = (GImage)((GComponent)this).GetChild("n6");
	}
}
