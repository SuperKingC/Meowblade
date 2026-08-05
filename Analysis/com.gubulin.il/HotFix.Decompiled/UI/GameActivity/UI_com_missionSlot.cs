using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GameActivity;

public class UI_com_missionSlot : GComponent
{
	public Controller status;

	public Controller isLocked;

	public GImage n1;

	public GLoader rewardIcon;

	public GTextField rewardNum;

	public GTextField title;

	public GTextField num;

	public GTextField n7;

	public GTextField n8;

	public GMovieClip n4;

	public UI_btn_01 gotoBtn;

	public GImage n9;

	public GImage n13;

	public GImage n10;

	public GImage n12;

	public const string URL = "ui://29q48tv6cp085f9i";

	public static string Name = "UI_com_missionSlot";

	public static string GetURL()
	{
		return "ui://29q48tv6cp085f9i";
	}

	public static UI_com_missionSlot CreateInstance()
	{
		return (UI_com_missionSlot)(object)UIPackage.CreateObject("GameActivity", "com_missionSlot");
	}

	public static UI_com_missionSlot CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_missionSlot).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://29q48tv6cp085f9i", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Expected O, but got Unknown
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0155: Expected O, but got Unknown
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Expected O, but got Unknown
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0197: Expected O, but got Unknown
		//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ad: Expected O, but got Unknown
		//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c3: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		status = ((GComponent)this).GetController("status");
		isLocked = ((GComponent)this).GetController("isLocked");
		n1 = (GImage)((GComponent)this).GetChild("n1");
		rewardIcon = (GLoader)((GComponent)this).GetChild("rewardIcon");
		rewardNum = (GTextField)((GComponent)this).GetChild("rewardNum");
		title = (GTextField)((GComponent)this).GetChild("title");
		num = (GTextField)((GComponent)this).GetChild("num");
		n7 = (GTextField)((GComponent)this).GetChild("n7");
		string id = "ui://29q48tv6cp085f9i".Replace("ui://", "") + "-" + ((GObject)n7).id;
		((GObject)n7).text = LanguagesManager.GetDesc(id);
		n8 = (GTextField)((GComponent)this).GetChild("n8");
		string id2 = "ui://29q48tv6cp085f9i".Replace("ui://", "") + "-" + ((GObject)n8).id;
		((GObject)n8).text = LanguagesManager.GetDesc(id2);
		n4 = (GMovieClip)((GComponent)this).GetChild("n4");
		gotoBtn = (UI_btn_01)(object)((GComponent)this).GetChild("gotoBtn");
		n9 = (GImage)((GComponent)this).GetChild("n9");
		n13 = (GImage)((GComponent)this).GetChild("n13");
		n10 = (GImage)((GComponent)this).GetChild("n10");
		n12 = (GImage)((GComponent)this).GetChild("n12");
	}
}
