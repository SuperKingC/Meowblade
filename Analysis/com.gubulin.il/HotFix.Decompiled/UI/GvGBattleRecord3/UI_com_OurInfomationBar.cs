using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBattleRecord3;

public class UI_com_OurInfomationBar : GComponent
{
	public UI_com_LeftProfileDisplay ProfileDisplay;

	public const string URL = "ui://b3fc6085stwvk";

	public static string Name = "UI_com_OurInfomationBar";

	public static string GetURL()
	{
		return "ui://b3fc6085stwvk";
	}

	public static UI_com_OurInfomationBar CreateInstance()
	{
		return (UI_com_OurInfomationBar)(object)UIPackage.CreateObject("GvGBattleRecord3", "com_OurInfomationBar");
	}

	public static UI_com_OurInfomationBar CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_OurInfomationBar).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b3fc6085stwvk", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		((GComponent)this).ConstructFromXML(xml);
		ProfileDisplay = (UI_com_LeftProfileDisplay)(object)((GComponent)this).GetChild("ProfileDisplay");
	}
}
