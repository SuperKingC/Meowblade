using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.PrinceOfTheDevils;

public class UI_targetBtn : GComponent
{
	public Controller button;

	public Controller isClaimed;

	public GImage back;

	public GImage n10;

	public UI_receiveBtn receiveBtn;

	public GTextField title;

	public GTextField num;

	public GGraph fxBack;

	public GLoader rewardIcon;

	public GTextField rewardNum;

	public GImage n17;

	public GImage n18;

	public Transition disappear;

	public const string URL = "ui://zko5n3velkzgg";

	public static string Name = "UI_targetBtn";

	public static string GetURL()
	{
		return "ui://zko5n3velkzgg";
	}

	public static UI_targetBtn CreateInstance()
	{
		return (UI_targetBtn)(object)UIPackage.CreateObject("PrinceOfTheDevils", "targetBtn");
	}

	public static UI_targetBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_targetBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://zko5n3velkzgg", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected O, but got Unknown
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Expected O, but got Unknown
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Expected O, but got Unknown
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0155: Expected O, but got Unknown
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Expected O, but got Unknown
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		isClaimed = ((GComponent)this).GetController("isClaimed");
		back = (GImage)((GComponent)this).GetChild("back");
		n10 = (GImage)((GComponent)this).GetChild("n10");
		receiveBtn = (UI_receiveBtn)(object)((GComponent)this).GetChild("receiveBtn");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://zko5n3velkzgg".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
		num = (GTextField)((GComponent)this).GetChild("num");
		string id2 = "ui://zko5n3velkzgg".Replace("ui://", "") + "-" + ((GObject)num).id;
		((GObject)num).text = LanguagesManager.GetDesc(id2);
		fxBack = (GGraph)((GComponent)this).GetChild("fxBack");
		rewardIcon = (GLoader)((GComponent)this).GetChild("rewardIcon");
		rewardNum = (GTextField)((GComponent)this).GetChild("rewardNum");
		n17 = (GImage)((GComponent)this).GetChild("n17");
		n18 = (GImage)((GComponent)this).GetChild("n18");
		disappear = ((GComponent)this).GetTransition("disappear");
	}
}
