using FairyGUI;
using FairyGUI.Utils;

namespace UI.IslandComeAgain;

public class UI_btn_Exchange : GButton
{
	public Controller button;

	public GImage n32;

	public GImage n33;

	public const string URL = "ui://k2sprg26laau62";

	public static string Name = "UI_btn_Exchange";

	public static string GetURL()
	{
		return "ui://k2sprg26laau62";
	}

	public static UI_btn_Exchange CreateInstance()
	{
		return (UI_btn_Exchange)(object)UIPackage.CreateObject("IslandComeAgain", "btn_Exchange");
	}

	public static UI_btn_Exchange CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_Exchange).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k2sprg26laau62", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n32 = (GImage)((GComponent)this).GetChild("n32");
		n33 = (GImage)((GComponent)this).GetChild("n33");
	}
}
