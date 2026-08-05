using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_EnemyHPbar : GProgressBar
{
	public Controller Type;

	public GImage bar;

	public const string URL = "ui://82mo10n5onsrdbs";

	public static string Name = "UI_EnemyHPbar";

	public static string GetURL()
	{
		return "ui://82mo10n5onsrdbs";
	}

	public static UI_EnemyHPbar CreateInstance()
	{
		return (UI_EnemyHPbar)(object)UIPackage.CreateObject("PvpSelectSoldiers", "EnemyHPbar");
	}

	public static UI_EnemyHPbar CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_EnemyHPbar).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5onsrdbs", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		bar = (GImage)((GComponent)this).GetChild("bar");
	}
}
