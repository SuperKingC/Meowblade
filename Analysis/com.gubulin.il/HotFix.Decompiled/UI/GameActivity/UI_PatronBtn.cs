using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GameActivity;

public class UI_PatronBtn : GButton
{
	public Controller button;

	public Controller Status;

	public Controller InviterStatus;

	public UI_InviteBtn InviteBtn;

	public UI_InvitationIcon IconBtn;

	public GButton leaseBtn;

	public GButton gainBtn;

	public GGraph back1;

	public GTextField name;

	public GGraph back2;

	public GTextField inviterStatusText;

	public GTextField tip;

	public GImage n15;

	public GTextField level;

	public GGroup n17;

	public const string URL = "ui://29q48tv6hkkt22";

	public static string Name = "UI_PatronBtn";

	public static string GetURL()
	{
		return "ui://29q48tv6hkkt22";
	}

	public static UI_PatronBtn CreateInstance()
	{
		return (UI_PatronBtn)(object)UIPackage.CreateObject("GameActivity", "PatronBtn");
	}

	public static UI_PatronBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_PatronBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://29q48tv6hkkt22", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected O, but got Unknown
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Expected O, but got Unknown
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected O, but got Unknown
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Expected O, but got Unknown
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Expected O, but got Unknown
		//IL_0172: Unknown result type (might be due to invalid IL or missing references)
		//IL_017c: Expected O, but got Unknown
		//IL_01c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cf: Expected O, but got Unknown
		//IL_01db: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e5: Expected O, but got Unknown
		//IL_022e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0238: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Status = ((GComponent)this).GetController("Status");
		InviterStatus = ((GComponent)this).GetController("InviterStatus");
		InviteBtn = (UI_InviteBtn)(object)((GComponent)this).GetChild("InviteBtn");
		IconBtn = (UI_InvitationIcon)(object)((GComponent)this).GetChild("IconBtn");
		leaseBtn = (GButton)((GComponent)this).GetChild("leaseBtn");
		gainBtn = (GButton)((GComponent)this).GetChild("gainBtn");
		back1 = (GGraph)((GComponent)this).GetChild("back1");
		name = (GTextField)((GComponent)this).GetChild("name");
		string id = "ui://29q48tv6hkkt22".Replace("ui://", "") + "-" + ((GObject)name).id;
		((GObject)name).text = LanguagesManager.GetDesc(id);
		back2 = (GGraph)((GComponent)this).GetChild("back2");
		inviterStatusText = (GTextField)((GComponent)this).GetChild("inviterStatusText");
		string id2 = "ui://29q48tv6hkkt22".Replace("ui://", "") + "-" + ((GObject)inviterStatusText).id;
		((GObject)inviterStatusText).text = LanguagesManager.GetDesc(id2);
		tip = (GTextField)((GComponent)this).GetChild("tip");
		string id3 = "ui://29q48tv6hkkt22".Replace("ui://", "") + "-" + ((GObject)tip).id;
		((GObject)tip).text = LanguagesManager.GetDesc(id3);
		n15 = (GImage)((GComponent)this).GetChild("n15");
		level = (GTextField)((GComponent)this).GetChild("level");
		string id4 = "ui://29q48tv6hkkt22".Replace("ui://", "") + "-" + ((GObject)level).id;
		((GObject)level).text = LanguagesManager.GetDesc(id4);
		n17 = (GGroup)((GComponent)this).GetChild("n17");
	}
}
