using FairyGUI;
using FairyGUI.Utils;

namespace UI.Battle;

public class UI_EnemyHPbar : GProgressBar
{
	public GImage bar;

	public GImage name;

	public const string URL = "ui://twlbabicsw0z1v";

	public static string Name = "UI_EnemyHPbar";

	public static string GetURL()
	{
		return "ui://twlbabicsw0z1v";
	}

	public static UI_EnemyHPbar CreateInstance()
	{
		return (UI_EnemyHPbar)(object)UIPackage.CreateObject("Battle", "EnemyHPbar");
	}

	public static UI_EnemyHPbar CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_EnemyHPbar).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://twlbabicsw0z1v", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		name = (GImage)((GComponent)this).GetChild("name");
	}
}
