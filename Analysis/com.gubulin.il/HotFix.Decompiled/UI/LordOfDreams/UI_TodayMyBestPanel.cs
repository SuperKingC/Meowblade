using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.LordOfDreams;

public class UI_TodayMyBestPanel : GComponent
{
	public GImage panelBack;

	public GImage n125;

	public GList List;

	public GTextField n127;

	public GTextField n128;

	public GTextField TodayTotalScore;

	public GTextField TotalScore;

	public GImage n130;

	public GImage n131;

	public const string URL = "ui://0i520nzmtlapo6t";

	public static string Name = "UI_TodayMyBestPanel";

	public static string GetURL()
	{
		return "ui://0i520nzmtlapo6t";
	}

	public static UI_TodayMyBestPanel CreateInstance()
	{
		return (UI_TodayMyBestPanel)(object)UIPackage.CreateObject("LordOfDreams", "TodayMyBestPanel");
	}

	public static UI_TodayMyBestPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_TodayMyBestPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://0i520nzmtlapo6t", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Expected O, but got Unknown
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Expected O, but got Unknown
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		panelBack = (GImage)((GComponent)this).GetChild("panelBack");
		n125 = (GImage)((GComponent)this).GetChild("n125");
		List = (GList)((GComponent)this).GetChild("List");
		n127 = (GTextField)((GComponent)this).GetChild("n127");
		string id = "ui://0i520nzmtlapo6t".Replace("ui://", "") + "-" + ((GObject)n127).id;
		((GObject)n127).text = LanguagesManager.GetDesc(id);
		n128 = (GTextField)((GComponent)this).GetChild("n128");
		string id2 = "ui://0i520nzmtlapo6t".Replace("ui://", "") + "-" + ((GObject)n128).id;
		((GObject)n128).text = LanguagesManager.GetDesc(id2);
		TodayTotalScore = (GTextField)((GComponent)this).GetChild("TodayTotalScore");
		TotalScore = (GTextField)((GComponent)this).GetChild("TotalScore");
		n130 = (GImage)((GComponent)this).GetChild("n130");
		n131 = (GImage)((GComponent)this).GetChild("n131");
	}
}
