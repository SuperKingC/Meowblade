using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGOnIsland3;

public class UI_btn_Retreat : GButton
{
	public Controller button;

	public GImage n11;

	public GImage n12;

	public const string URL = "ui://ebc4ciwrokm8q5a";

	public static string Name = "UI_btn_Retreat";

	public static string GetURL()
	{
		return "ui://ebc4ciwrokm8q5a";
	}

	public static UI_btn_Retreat CreateInstance()
	{
		return (UI_btn_Retreat)(object)UIPackage.CreateObject("GvGOnIsland3", "btn_Retreat");
	}

	public static UI_btn_Retreat CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_Retreat).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://ebc4ciwrokm8q5a", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n11 = (GImage)((GComponent)this).GetChild("n11");
		n12 = (GImage)((GComponent)this).GetChild("n12");
	}
}
