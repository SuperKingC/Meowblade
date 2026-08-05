using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvG3Leaderboard;

public class UI_com_infoSlot3 : GComponent
{
	public Controller hideAddition;

	public Controller isNormalScore;

	public GImage n210;

	public GImage n211;

	public GRichTextField Title;

	public GRichTextField OtherSource;

	public GLoader LevelIcon;

	public GTextField mainScore;

	public GLoader additionScoreBg;

	public GTextField additionScore;

	public GImage n217;

	public GGroup n218;

	public const string URL = "ui://ylvfgf90jijw78";

	public static string Name = "UI_com_infoSlot3";

	public static string GetURL()
	{
		return "ui://ylvfgf90jijw78";
	}

	public static UI_com_infoSlot3 CreateInstance()
	{
		return (UI_com_infoSlot3)(object)UIPackage.CreateObject("GvG3Leaderboard", "com_infoSlot3");
	}

	public static UI_com_infoSlot3 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_infoSlot3).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://ylvfgf90jijw78", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected O, but got Unknown
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Expected O, but got Unknown
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Expected O, but got Unknown
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		hideAddition = ((GComponent)this).GetController("hideAddition");
		isNormalScore = ((GComponent)this).GetController("isNormalScore");
		n210 = (GImage)((GComponent)this).GetChild("n210");
		n211 = (GImage)((GComponent)this).GetChild("n211");
		Title = (GRichTextField)((GComponent)this).GetChild("Title");
		OtherSource = (GRichTextField)((GComponent)this).GetChild("OtherSource");
		string id = "ui://ylvfgf90jijw78".Replace("ui://", "") + "-" + ((GObject)OtherSource).id;
		((GObject)OtherSource).text = LanguagesManager.GetDesc(id);
		LevelIcon = (GLoader)((GComponent)this).GetChild("LevelIcon");
		mainScore = (GTextField)((GComponent)this).GetChild("mainScore");
		additionScoreBg = (GLoader)((GComponent)this).GetChild("additionScoreBg");
		additionScore = (GTextField)((GComponent)this).GetChild("additionScore");
		n217 = (GImage)((GComponent)this).GetChild("n217");
		n218 = (GGroup)((GComponent)this).GetChild("n218");
	}
}
