using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvG3Leaderboard;

public class UI_com_info03 : GComponent
{
	public Controller RankType;

	public Controller isSelf;

	public Controller isEmpty;

	public GImage n207;

	public GImage n208;

	public GTextField n209;

	public GTextField n214;

	public GList Contributions;

	public GList winCount;

	public GButton Close;

	public GImage n215;

	public GTextField n216;

	public const string URL = "ui://ylvfgf90jijw77";

	public static string Name = "UI_com_info03";

	public static string GetURL()
	{
		return "ui://ylvfgf90jijw77";
	}

	public static UI_com_info03 CreateInstance()
	{
		return (UI_com_info03)(object)UIPackage.CreateObject("GvG3Leaderboard", "com_info03");
	}

	public static UI_com_info03 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_info03).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://ylvfgf90jijw77", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected O, but got Unknown
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected O, but got Unknown
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Expected O, but got Unknown
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Expected O, but got Unknown
		//IL_0130: Unknown result type (might be due to invalid IL or missing references)
		//IL_013a: Expected O, but got Unknown
		//IL_0146: Unknown result type (might be due to invalid IL or missing references)
		//IL_0150: Expected O, but got Unknown
		//IL_015c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Expected O, but got Unknown
		//IL_0172: Unknown result type (might be due to invalid IL or missing references)
		//IL_017c: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		RankType = ((GComponent)this).GetController("RankType");
		isSelf = ((GComponent)this).GetController("isSelf");
		isEmpty = ((GComponent)this).GetController("isEmpty");
		n207 = (GImage)((GComponent)this).GetChild("n207");
		n208 = (GImage)((GComponent)this).GetChild("n208");
		n209 = (GTextField)((GComponent)this).GetChild("n209");
		string id = "ui://ylvfgf90jijw77".Replace("ui://", "") + "-" + ((GObject)n209).id;
		((GObject)n209).text = LanguagesManager.GetDesc(id);
		n214 = (GTextField)((GComponent)this).GetChild("n214");
		string id2 = "ui://ylvfgf90jijw77".Replace("ui://", "") + "-" + ((GObject)n214).id;
		((GObject)n214).text = LanguagesManager.GetDesc(id2);
		Contributions = (GList)((GComponent)this).GetChild("Contributions");
		winCount = (GList)((GComponent)this).GetChild("winCount");
		Close = (GButton)((GComponent)this).GetChild("Close");
		n215 = (GImage)((GComponent)this).GetChild("n215");
		n216 = (GTextField)((GComponent)this).GetChild("n216");
		string id3 = "ui://ylvfgf90jijw77".Replace("ui://", "") + "-" + ((GObject)n216).id;
		((GObject)n216).text = LanguagesManager.GetDesc(id3);
	}
}
