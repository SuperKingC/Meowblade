using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_VictoryRibbon : GComponent
{
	public UI_VictoryBackGround Light;

	public GGroup VictoryRibbon;

	public GImage n121;

	public const string URL = "ui://82mo10n5c3gbdcu";

	public static string Name = "UI_VictoryRibbon";

	public static string GetURL()
	{
		return "ui://82mo10n5c3gbdcu";
	}

	public static UI_VictoryRibbon CreateInstance()
	{
		return (UI_VictoryRibbon)(object)UIPackage.CreateObject("PvpSelectSoldiers", "VictoryRibbon");
	}

	public static UI_VictoryRibbon CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_VictoryRibbon).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5c3gbdcu", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Light = (UI_VictoryBackGround)(object)((GComponent)this).GetChild("Light");
		VictoryRibbon = (GGroup)((GComponent)this).GetChild("VictoryRibbon");
		n121 = (GImage)((GComponent)this).GetChild("n121");
	}
}
