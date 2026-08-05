using FairyGUI;
using FairyGUI.Utils;

namespace UI.GameActivity;

public class UI_CertificationGiftPack : GComponent
{
	public UI_MissionGiftIconBtn Icon;

	public GTextField num;

	public const string URL = "ui://29q48tv6jgi12z";

	public static string Name = "UI_CertificationGiftPack";

	public static string GetURL()
	{
		return "ui://29q48tv6jgi12z";
	}

	public static UI_CertificationGiftPack CreateInstance()
	{
		return (UI_CertificationGiftPack)(object)UIPackage.CreateObject("GameActivity", "CertificationGiftPack");
	}

	public static UI_CertificationGiftPack CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_CertificationGiftPack).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://29q48tv6jgi12z", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Icon = (UI_MissionGiftIconBtn)(object)((GComponent)this).GetChild("Icon");
		num = (GTextField)((GComponent)this).GetChild("num");
	}
}
