using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_EnemyHP : GProgressBar
{
	public GImage bar;

	public GImage n3;

	public const string URL = "ui://82mo10n5c3gbdcs";

	public static string Name = "UI_EnemyHP";

	public static string GetURL()
	{
		return "ui://82mo10n5c3gbdcs";
	}

	public static UI_EnemyHP CreateInstance()
	{
		return (UI_EnemyHP)(object)UIPackage.CreateObject("PvpSelectSoldiers", "EnemyHP");
	}

	public static UI_EnemyHP CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_EnemyHP).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5c3gbdcs", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		bar = (GImage)((GComponent)this).GetChild("bar");
		n3 = (GImage)((GComponent)this).GetChild("n3");
	}
}
