using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemBlueprint;

public class UI_btn_reset : GButton
{
	public Controller button;

	public GGraph n0;

	public GImage backBtn1;

	public GImage n4;

	public const string URL = "ui://h09dvkcgp29h5ltfi";

	public static string Name = "UI_btn_reset";

	public static string GetURL()
	{
		return "ui://h09dvkcgp29h5ltfi";
	}

	public static UI_btn_reset CreateInstance()
	{
		return (UI_btn_reset)(object)UIPackage.CreateObject("LegendItemBlueprint", "btn_reset");
	}

	public static UI_btn_reset CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_reset).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://h09dvkcgp29h5ltfi", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		button = ((GComponent)this).GetController("button");
		n0 = (GGraph)((GComponent)this).GetChild("n0");
		backBtn1 = (GImage)((GComponent)this).GetChild("backBtn1");
		n4 = (GImage)((GComponent)this).GetChild("n4");
	}
}
