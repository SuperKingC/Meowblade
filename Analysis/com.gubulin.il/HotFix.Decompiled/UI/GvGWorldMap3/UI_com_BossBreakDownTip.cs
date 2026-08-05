using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_com_BossBreakDownTip : GComponent
{
	public GImage back;

	public GTextField n1;

	public GTextField n2;

	public GTextField n3;

	public const string URL = "ui://4eq8fgd2e71eqb6ser";

	public static string Name = "UI_com_BossBreakDownTip";

	public static string GetURL()
	{
		return "ui://4eq8fgd2e71eqb6ser";
	}

	public static UI_com_BossBreakDownTip CreateInstance()
	{
		return (UI_com_BossBreakDownTip)(object)UIPackage.CreateObject("GvGWorldMap3", "com_BossBreakDownTip");
	}

	public static UI_com_BossBreakDownTip CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_BossBreakDownTip).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2e71eqb6ser", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		back = (GImage)((GComponent)this).GetChild("back");
		n1 = (GTextField)((GComponent)this).GetChild("n1");
		string id = "ui://4eq8fgd2e71eqb6ser".Replace("ui://", "") + "-" + ((GObject)n1).id;
		((GObject)n1).text = LanguagesManager.GetDesc(id);
		n2 = (GTextField)((GComponent)this).GetChild("n2");
		string id2 = "ui://4eq8fgd2e71eqb6ser".Replace("ui://", "") + "-" + ((GObject)n2).id;
		((GObject)n2).text = LanguagesManager.GetDesc(id2);
		n3 = (GTextField)((GComponent)this).GetChild("n3");
		string id3 = "ui://4eq8fgd2e71eqb6ser".Replace("ui://", "") + "-" + ((GObject)n3).id;
		((GObject)n3).text = LanguagesManager.GetDesc(id3);
	}
}
