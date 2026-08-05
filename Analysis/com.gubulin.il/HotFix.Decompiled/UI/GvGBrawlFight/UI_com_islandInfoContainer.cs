using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBrawlFight;

public class UI_com_islandInfoContainer : GComponent
{
	public Controller showCenterText;

	public UI_com_BrawlFightFinalCloudTip textInfo;

	public const string URL = "ui://hozu168rllu55t";

	public static string Name = "UI_com_islandInfoContainer";

	public static string GetURL()
	{
		return "ui://hozu168rllu55t";
	}

	public static UI_com_islandInfoContainer CreateInstance()
	{
		return (UI_com_islandInfoContainer)(object)UIPackage.CreateObject("GvGBrawlFight", "com_islandInfoContainer");
	}

	public static UI_com_islandInfoContainer CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_islandInfoContainer).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hozu168rllu55t", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		((GComponent)this).ConstructFromXML(xml);
		showCenterText = ((GComponent)this).GetController("showCenterText");
		textInfo = (UI_com_BrawlFightFinalCloudTip)(object)((GComponent)this).GetChild("textInfo");
	}
}
