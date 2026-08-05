using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBattleRecord3;

public class UI_btn_IslandCampaign : GButton
{
	public Controller button;

	public GImage n3;

	public const string URL = "ui://b3fc6085owu53";

	public static string Name = "UI_btn_IslandCampaign";

	public static string GetURL()
	{
		return "ui://b3fc6085owu53";
	}

	public static UI_btn_IslandCampaign CreateInstance()
	{
		return (UI_btn_IslandCampaign)(object)UIPackage.CreateObject("GvGBattleRecord3", "btn_IslandCampaign");
	}

	public static UI_btn_IslandCampaign CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_IslandCampaign).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b3fc6085owu53", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
