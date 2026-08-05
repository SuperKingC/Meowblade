using FairyGUI;
using FairyGUI.Utils;

namespace UI.Contract;

public class UI_ResultCom : GComponent
{
	public GList NewSoldierList;

	public GGraph separatedLine1;

	public GList LevelUpList;

	public GGraph separatedLine2;

	public GList DebrisList;

	public const string URL = "ui://avplaivdv93kt3o";

	public static string Name = "UI_ResultCom";

	public static string GetURL()
	{
		return "ui://avplaivdv93kt3o";
	}

	public static UI_ResultCom CreateInstance()
	{
		return (UI_ResultCom)(object)UIPackage.CreateObject("Contract", "ResultCom");
	}

	public static UI_ResultCom CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ResultCom).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://avplaivdv93kt3o", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		NewSoldierList = (GList)((GComponent)this).GetChild("NewSoldierList");
		separatedLine1 = (GGraph)((GComponent)this).GetChild("separatedLine1");
		LevelUpList = (GList)((GComponent)this).GetChild("LevelUpList");
		separatedLine2 = (GGraph)((GComponent)this).GetChild("separatedLine2");
		DebrisList = (GList)((GComponent)this).GetChild("DebrisList");
	}
}
