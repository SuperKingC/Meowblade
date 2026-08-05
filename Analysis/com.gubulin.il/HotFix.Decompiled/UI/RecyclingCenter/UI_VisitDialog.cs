using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.RecyclingCenter;

public class UI_VisitDialog : GComponent
{
	public Controller Status;

	public GImage back;

	public GTextField title;

	public GList FriendsList;

	public UI_ReturnMaincity ReturnMaincity;

	public GTextField tip2;

	public GTextField tip3;

	public const string URL = "ui://72poq8plkxix11";

	public static string Name = "UI_VisitDialog";

	public static string GetURL()
	{
		return "ui://72poq8plkxix11";
	}

	public static UI_VisitDialog CreateInstance()
	{
		return (UI_VisitDialog)(object)UIPackage.CreateObject("RecyclingCenter", "VisitDialog");
	}

	public static UI_VisitDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_VisitDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://72poq8plkxix11", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Status = ((GComponent)this).GetController("Status");
		back = (GImage)((GComponent)this).GetChild("back");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://72poq8plkxix11".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
		FriendsList = (GList)((GComponent)this).GetChild("FriendsList");
		ReturnMaincity = (UI_ReturnMaincity)(object)((GComponent)this).GetChild("ReturnMaincity");
		tip2 = (GTextField)((GComponent)this).GetChild("tip2");
		string id2 = "ui://72poq8plkxix11".Replace("ui://", "") + "-" + ((GObject)tip2).id;
		((GObject)tip2).text = LanguagesManager.GetDesc(id2);
		tip3 = (GTextField)((GComponent)this).GetChild("tip3");
		string id3 = "ui://72poq8plkxix11".Replace("ui://", "") + "-" + ((GObject)tip3).id;
		((GObject)tip3).text = LanguagesManager.GetDesc(id3);
	}
}
