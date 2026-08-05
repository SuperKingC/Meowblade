using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GameActivity;

public class UI_InvitedWorkersDialog : GComponent
{
	public Controller Status;

	public GImage back;

	public GTextField title;

	public GList FriendsList;

	public GTextField tip2;

	public const string URL = "ui://29q48tv6h95m2c";

	public static string Name = "UI_InvitedWorkersDialog";

	public static string GetURL()
	{
		return "ui://29q48tv6h95m2c";
	}

	public static UI_InvitedWorkersDialog CreateInstance()
	{
		return (UI_InvitedWorkersDialog)(object)UIPackage.CreateObject("GameActivity", "InvitedWorkersDialog");
	}

	public static UI_InvitedWorkersDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_InvitedWorkersDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://29q48tv6h95m2c", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Status = ((GComponent)this).GetController("Status");
		back = (GImage)((GComponent)this).GetChild("back");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://29q48tv6h95m2c".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
		FriendsList = (GList)((GComponent)this).GetChild("FriendsList");
		tip2 = (GTextField)((GComponent)this).GetChild("tip2");
		string id2 = "ui://29q48tv6h95m2c".Replace("ui://", "") + "-" + ((GObject)tip2).id;
		((GObject)tip2).text = LanguagesManager.GetDesc(id2);
	}
}
