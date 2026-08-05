using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GameActivity;

public class UI_VisitorItem : GComponent
{
	public UI_InvitationIcon Icon;

	public GImage n2;

	public GTextField level;

	public GTextField name;

	public GTextField time;

	public GTextField CurEarnings;

	public const string URL = "ui://29q48tv6h95m2d";

	public static string Name = "UI_VisitorItem";

	public static string GetURL()
	{
		return "ui://29q48tv6h95m2d";
	}

	public static UI_VisitorItem CreateInstance()
	{
		return (UI_VisitorItem)(object)UIPackage.CreateObject("GameActivity", "VisitorItem");
	}

	public static UI_VisitorItem CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_VisitorItem).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://29q48tv6h95m2d", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Icon = (UI_InvitationIcon)(object)((GComponent)this).GetChild("Icon");
		n2 = (GImage)((GComponent)this).GetChild("n2");
		level = (GTextField)((GComponent)this).GetChild("level");
		string id = "ui://29q48tv6h95m2d".Replace("ui://", "") + "-" + ((GObject)level).id;
		((GObject)level).text = LanguagesManager.GetDesc(id);
		name = (GTextField)((GComponent)this).GetChild("name");
		string id2 = "ui://29q48tv6h95m2d".Replace("ui://", "") + "-" + ((GObject)name).id;
		((GObject)name).text = LanguagesManager.GetDesc(id2);
		time = (GTextField)((GComponent)this).GetChild("time");
		string id3 = "ui://29q48tv6h95m2d".Replace("ui://", "") + "-" + ((GObject)time).id;
		((GObject)time).text = LanguagesManager.GetDesc(id3);
		CurEarnings = (GTextField)((GComponent)this).GetChild("CurEarnings");
		string id4 = "ui://29q48tv6h95m2d".Replace("ui://", "") + "-" + ((GObject)CurEarnings).id;
		((GObject)CurEarnings).text = LanguagesManager.GetDesc(id4);
	}
}
