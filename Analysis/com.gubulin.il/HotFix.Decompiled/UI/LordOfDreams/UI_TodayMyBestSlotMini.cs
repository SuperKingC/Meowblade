using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.LordOfDreams;

public class UI_TodayMyBestSlotMini : GComponent
{
	public Controller NumberController;

	public Controller IsNew;

	public GImage n10;

	public GLoader n1;

	public GImage n3;

	public GTextField n4;

	public GTextField DamageText;

	public UI_Avatar Avatar;

	public GTextField Score;

	public GImage n9;

	public GTextField plus;

	public GGraph ScoreMultiplierTip;

	public GTextField Ratio;

	public GButton arrow;

	public const string URL = "ui://0i520nzmo3e9o8m";

	public static string Name = "UI_TodayMyBestSlotMini";

	public static string GetURL()
	{
		return "ui://0i520nzmo3e9o8m";
	}

	public static UI_TodayMyBestSlotMini CreateInstance()
	{
		return (UI_TodayMyBestSlotMini)(object)UIPackage.CreateObject("LordOfDreams", "TodayMyBestSlotMini");
	}

	public static UI_TodayMyBestSlotMini CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_TodayMyBestSlotMini).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://0i520nzmo3e9o8m", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Expected O, but got Unknown
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Expected O, but got Unknown
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Expected O, but got Unknown
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0197: Expected O, but got Unknown
		//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ad: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		NumberController = ((GComponent)this).GetController("NumberController");
		IsNew = ((GComponent)this).GetController("IsNew");
		n10 = (GImage)((GComponent)this).GetChild("n10");
		n1 = (GLoader)((GComponent)this).GetChild("n1");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n4 = (GTextField)((GComponent)this).GetChild("n4");
		string id = "ui://0i520nzmo3e9o8m".Replace("ui://", "") + "-" + ((GObject)n4).id;
		((GObject)n4).text = LanguagesManager.GetDesc(id);
		DamageText = (GTextField)((GComponent)this).GetChild("DamageText");
		Avatar = (UI_Avatar)(object)((GComponent)this).GetChild("Avatar");
		Score = (GTextField)((GComponent)this).GetChild("Score");
		n9 = (GImage)((GComponent)this).GetChild("n9");
		plus = (GTextField)((GComponent)this).GetChild("plus");
		string id2 = "ui://0i520nzmo3e9o8m".Replace("ui://", "") + "-" + ((GObject)plus).id;
		((GObject)plus).text = LanguagesManager.GetDesc(id2);
		ScoreMultiplierTip = (GGraph)((GComponent)this).GetChild("ScoreMultiplierTip");
		Ratio = (GTextField)((GComponent)this).GetChild("Ratio");
		arrow = (GButton)((GComponent)this).GetChild("arrow");
	}
}
