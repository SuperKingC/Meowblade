using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemBlueprint;

public class UI_btn_Close : GButton
{
	public Controller button;

	public GImage n3;

	public const string URL = "ui://h09dvkcgvual5lteu";

	public static string Name = "UI_btn_Close";

	public static string GetURL()
	{
		return "ui://h09dvkcgvual5lteu";
	}

	public static UI_btn_Close CreateInstance()
	{
		return (UI_btn_Close)(object)UIPackage.CreateObject("LegendItemBlueprint", "btn_Close");
	}

	public static UI_btn_Close CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_Close).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://h09dvkcgvual5lteu", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n3 = (GImage)((GComponent)this).GetChild("n3");
	}
}
