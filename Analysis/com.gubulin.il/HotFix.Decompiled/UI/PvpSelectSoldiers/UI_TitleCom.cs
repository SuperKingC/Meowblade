using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_TitleCom : GComponent
{
	public GImage n0;

	public GLoader name;

	public GLoader icon;

	public GTextField buildingName;

	public const string URL = "ui://82mo10n5l255dkm";

	public static string Name = "UI_TitleCom";

	public static string GetURL()
	{
		return "ui://82mo10n5l255dkm";
	}

	public static UI_TitleCom CreateInstance()
	{
		return (UI_TitleCom)(object)UIPackage.CreateObject("PvpSelectSoldiers", "TitleCom");
	}

	public static UI_TitleCom CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_TitleCom).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5l255dkm", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n0 = (GImage)((GComponent)this).GetChild("n0");
		name = (GLoader)((GComponent)this).GetChild("name");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		buildingName = (GTextField)((GComponent)this).GetChild("buildingName");
	}
}
