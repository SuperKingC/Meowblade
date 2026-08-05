using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBrawlFight;

public class UI_btn_01 : GButton
{
	public Controller button;

	public Controller Status;

	public GImage n14;

	public GTextField title;

	public GImage note;

	public const string URL = "ui://hozu168rvnet3t";

	public static string Name = "UI_btn_01";

	public static string GetURL()
	{
		return "ui://hozu168rvnet3t";
	}

	public static UI_btn_01 CreateInstance()
	{
		return (UI_btn_01)(object)UIPackage.CreateObject("GvGBrawlFight", "btn_01");
	}

	public static UI_btn_01 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_01).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hozu168rvnet3t", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Status = ((GComponent)this).GetController("Status");
		n14 = (GImage)((GComponent)this).GetChild("n14");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://hozu168rvnet3t".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
		note = (GImage)((GComponent)this).GetChild("note");
	}
}
