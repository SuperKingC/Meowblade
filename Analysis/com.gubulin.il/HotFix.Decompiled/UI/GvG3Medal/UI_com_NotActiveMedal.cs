using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvG3Medal;

public class UI_com_NotActiveMedal : GComponent
{
	public GLoader MedalIcon;

	public GTextField n1;

	public const string URL = "ui://g5hi1peosxgw12";

	public static string Name = "UI_com_NotActiveMedal";

	public static string GetURL()
	{
		return "ui://g5hi1peosxgw12";
	}

	public static UI_com_NotActiveMedal CreateInstance()
	{
		return (UI_com_NotActiveMedal)(object)UIPackage.CreateObject("GvG3Medal", "com_NotActiveMedal");
	}

	public static UI_com_NotActiveMedal CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_NotActiveMedal).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://g5hi1peosxgw12", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		MedalIcon = (GLoader)((GComponent)this).GetChild("MedalIcon");
		n1 = (GTextField)((GComponent)this).GetChild("n1");
		string id = "ui://g5hi1peosxgw12".Replace("ui://", "") + "-" + ((GObject)n1).id;
		((GObject)n1).text = LanguagesManager.GetDesc(id);
	}
}
