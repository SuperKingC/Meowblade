using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.SpecialActivity;

public class UI_rewardBtn155 : GButton
{
	public Controller button;

	public Controller receiveController;

	public GImage iconBack;

	public GGraph squareSfxBack;

	public GGraph activatedSfxBack;

	public GLoader icon;

	public GTextField num;

	public GButton ReceivedBtn;

	public const string URL = "ui://kozswd8hndjaj";

	public static string Name = "UI_rewardBtn155";

	public static string GetURL()
	{
		return "ui://kozswd8hndjaj";
	}

	public static UI_rewardBtn155 CreateInstance()
	{
		return (UI_rewardBtn155)(object)UIPackage.CreateObject("SpecialActivity", "rewardBtn155");
	}

	public static UI_rewardBtn155 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_rewardBtn155).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kozswd8hndjaj", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		receiveController = ((GComponent)this).GetController("receiveController");
		iconBack = (GImage)((GComponent)this).GetChild("iconBack");
		squareSfxBack = (GGraph)((GComponent)this).GetChild("squareSfxBack");
		activatedSfxBack = (GGraph)((GComponent)this).GetChild("activatedSfxBack");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		num = (GTextField)((GComponent)this).GetChild("num");
		string id = "ui://kozswd8hndjaj".Replace("ui://", "") + "-" + ((GObject)num).id;
		((GObject)num).text = LanguagesManager.GetDesc(id);
		ReceivedBtn = (GButton)((GComponent)this).GetChild("ReceivedBtn");
	}
}
