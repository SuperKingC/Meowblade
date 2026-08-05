using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvG3Leaderboard;

public class UI_btn_PageTabType : GButton
{
	public Controller button;

	public Controller UITypeController;

	public Controller RankingType;

	public GImage n156;

	public GImage n157;

	public GImage n163;

	public GGroup n168;

	public GTextField n158;

	public GTextField n159;

	public GTextField n160;

	public GTextField n161;

	public GTextField n164;

	public GTextField n165;

	public GTextField n166;

	public GTextField n169;

	public GTextField n170;

	public GTextField n171;

	public const string URL = "ui://ylvfgf90zaf76s";

	public static string Name = "UI_btn_PageTabType";

	public static string GetURL()
	{
		return "ui://ylvfgf90zaf76s";
	}

	public static UI_btn_PageTabType CreateInstance()
	{
		return (UI_btn_PageTabType)(object)UIPackage.CreateObject("GvG3Leaderboard", "btn_PageTabType");
	}

	public static UI_btn_PageTabType CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_PageTabType).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://ylvfgf90zaf76s", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Expected O, but got Unknown
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected O, but got Unknown
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Expected O, but got Unknown
		//IL_0146: Unknown result type (might be due to invalid IL or missing references)
		//IL_0150: Expected O, but got Unknown
		//IL_0199: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a3: Expected O, but got Unknown
		//IL_01ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f6: Expected O, but got Unknown
		//IL_0241: Unknown result type (might be due to invalid IL or missing references)
		//IL_024b: Expected O, but got Unknown
		//IL_0296: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a0: Expected O, but got Unknown
		//IL_02eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f5: Expected O, but got Unknown
		//IL_0340: Unknown result type (might be due to invalid IL or missing references)
		//IL_034a: Expected O, but got Unknown
		//IL_0395: Unknown result type (might be due to invalid IL or missing references)
		//IL_039f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		UITypeController = ((GComponent)this).GetController("UITypeController");
		RankingType = ((GComponent)this).GetController("RankingType");
		n156 = (GImage)((GComponent)this).GetChild("n156");
		n157 = (GImage)((GComponent)this).GetChild("n157");
		n163 = (GImage)((GComponent)this).GetChild("n163");
		n168 = (GGroup)((GComponent)this).GetChild("n168");
		n158 = (GTextField)((GComponent)this).GetChild("n158");
		string id = "ui://ylvfgf90zaf76s".Replace("ui://", "") + "-" + ((GObject)n158).id;
		((GObject)n158).text = LanguagesManager.GetDesc(id);
		n159 = (GTextField)((GComponent)this).GetChild("n159");
		string id2 = "ui://ylvfgf90zaf76s".Replace("ui://", "") + "-" + ((GObject)n159).id;
		((GObject)n159).text = LanguagesManager.GetDesc(id2);
		n160 = (GTextField)((GComponent)this).GetChild("n160");
		string id3 = "ui://ylvfgf90zaf76s".Replace("ui://", "") + "-" + ((GObject)n160).id;
		((GObject)n160).text = LanguagesManager.GetDesc(id3);
		n161 = (GTextField)((GComponent)this).GetChild("n161");
		string id4 = "ui://ylvfgf90zaf76s".Replace("ui://", "") + "-" + ((GObject)n161).id;
		((GObject)n161).text = LanguagesManager.GetDesc(id4);
		n164 = (GTextField)((GComponent)this).GetChild("n164");
		string id5 = "ui://ylvfgf90zaf76s".Replace("ui://", "") + "-" + ((GObject)n164).id;
		((GObject)n164).text = LanguagesManager.GetDesc(id5);
		n165 = (GTextField)((GComponent)this).GetChild("n165");
		string id6 = "ui://ylvfgf90zaf76s".Replace("ui://", "") + "-" + ((GObject)n165).id;
		((GObject)n165).text = LanguagesManager.GetDesc(id6);
		n166 = (GTextField)((GComponent)this).GetChild("n166");
		string id7 = "ui://ylvfgf90zaf76s".Replace("ui://", "") + "-" + ((GObject)n166).id;
		((GObject)n166).text = LanguagesManager.GetDesc(id7);
		n169 = (GTextField)((GComponent)this).GetChild("n169");
		string id8 = "ui://ylvfgf90zaf76s".Replace("ui://", "") + "-" + ((GObject)n169).id;
		((GObject)n169).text = LanguagesManager.GetDesc(id8);
		n170 = (GTextField)((GComponent)this).GetChild("n170");
		string id9 = "ui://ylvfgf90zaf76s".Replace("ui://", "") + "-" + ((GObject)n170).id;
		((GObject)n170).text = LanguagesManager.GetDesc(id9);
		n171 = (GTextField)((GComponent)this).GetChild("n171");
		string id10 = "ui://ylvfgf90zaf76s".Replace("ui://", "") + "-" + ((GObject)n171).id;
		((GObject)n171).text = LanguagesManager.GetDesc(id10);
	}
}
