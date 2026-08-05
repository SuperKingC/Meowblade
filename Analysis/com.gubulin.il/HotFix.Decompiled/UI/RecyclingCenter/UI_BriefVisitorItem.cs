using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.RecyclingCenter;

public class UI_BriefVisitorItem : GButton
{
	public Controller button;

	public GImage n3;

	public GTextField level;

	public GTextField name;

	public GTextField num;

	public GList n7;

	public const string URL = "ui://72poq8plkxixm";

	public static string Name = "UI_BriefVisitorItem";

	public static string GetURL()
	{
		return "ui://72poq8plkxixm";
	}

	public static UI_BriefVisitorItem CreateInstance()
	{
		return (UI_BriefVisitorItem)(object)UIPackage.CreateObject("RecyclingCenter", "BriefVisitorItem");
	}

	public static UI_BriefVisitorItem CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_BriefVisitorItem).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://72poq8plkxixm", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		level = (GTextField)((GComponent)this).GetChild("level");
		name = (GTextField)((GComponent)this).GetChild("name");
		string id = "ui://72poq8plkxixm".Replace("ui://", "") + "-" + ((GObject)name).id;
		((GObject)name).text = LanguagesManager.GetDesc(id);
		num = (GTextField)((GComponent)this).GetChild("num");
		string id2 = "ui://72poq8plkxixm".Replace("ui://", "") + "-" + ((GObject)num).id;
		((GObject)num).text = LanguagesManager.GetDesc(id2);
		n7 = (GList)((GComponent)this).GetChild("n7");
	}
}
