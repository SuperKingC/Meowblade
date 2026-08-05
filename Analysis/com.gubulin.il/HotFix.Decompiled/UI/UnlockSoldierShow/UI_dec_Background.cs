using FairyGUI;
using FairyGUI.Utils;

namespace UI.UnlockSoldierShow;

public class UI_dec_Background : GComponent
{
	public GImage n82;

	public GImage n85;

	public const string URL = "ui://ia1am3ehi7qut31";

	public static string Name = "UI_dec_Background";

	public static string GetURL()
	{
		return "ui://ia1am3ehi7qut31";
	}

	public static UI_dec_Background CreateInstance()
	{
		return (UI_dec_Background)(object)UIPackage.CreateObject("UnlockSoldierShow", "dec_Background");
	}

	public static UI_dec_Background CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_dec_Background).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://ia1am3ehi7qut31", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n82 = (GImage)((GComponent)this).GetChild("n82");
		n85 = (GImage)((GComponent)this).GetChild("n85");
	}
}
