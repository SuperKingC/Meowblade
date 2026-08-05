using FairyGUI;
using FairyGUI.Utils;

namespace UI.Tips;

public class UI_earningsPanels : GComponent
{
	public GList soldierList;

	public GGraph separatedLine;

	public GList materialList;

	public const string URL = "ui://47lbpgx9op6kw";

	public static string Name = "UI_earningsPanels";

	public static string GetURL()
	{
		return "ui://47lbpgx9op6kw";
	}

	public static UI_earningsPanels CreateInstance()
	{
		return (UI_earningsPanels)(object)UIPackage.CreateObject("Tips", "earningsPanels");
	}

	public static UI_earningsPanels CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_earningsPanels).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://47lbpgx9op6kw", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		soldierList = (GList)((GComponent)this).GetChild("soldierList");
		separatedLine = (GGraph)((GComponent)this).GetChild("separatedLine");
		materialList = (GList)((GComponent)this).GetChild("materialList");
	}
}
