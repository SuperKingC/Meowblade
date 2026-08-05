using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_EnemyFid : GButton
{
	public Controller button;

	public GGraph n0;

	public GTextField FormationName;

	public const string URL = "ui://82mo10n5gwv06b";

	public static string Name = "UI_EnemyFid";

	public static string GetURL()
	{
		return "ui://82mo10n5gwv06b";
	}

	public static UI_EnemyFid CreateInstance()
	{
		return (UI_EnemyFid)(object)UIPackage.CreateObject("PvpSelectSoldiers", "EnemyFid");
	}

	public static UI_EnemyFid CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_EnemyFid).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5gwv06b", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n0 = (GGraph)((GComponent)this).GetChild("n0");
		FormationName = (GTextField)((GComponent)this).GetChild("FormationName");
		string id = "ui://82mo10n5gwv06b".Replace("ui://", "") + "-" + ((GObject)FormationName).id;
		((GObject)FormationName).text = LanguagesManager.GetDesc(id);
	}
}
