using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGOuterTech;

public class UI_btn_RatityTab : GButton
{
	public Controller Rarity;

	public GLoader n122;

	public const string URL = "ui://th385mtty63lj";

	public static string Name = "UI_btn_RatityTab";

	public static string GetURL()
	{
		return "ui://th385mtty63lj";
	}

	public static UI_btn_RatityTab CreateInstance()
	{
		return (UI_btn_RatityTab)(object)UIPackage.CreateObject("GvGOuterTech", "btn_RatityTab");
	}

	public static UI_btn_RatityTab CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_RatityTab).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://th385mtty63lj", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Rarity = ((GComponent)this).GetController("Rarity");
		n122 = (GLoader)((GComponent)this).GetChild("n122");
	}
}
