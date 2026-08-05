using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Tips;

public class UI_materialItem : GButton
{
	public Controller button;

	public Controller Status;

	public GLoader frame;

	public GLoader icon;

	public GTextField title;

	public GTextField num;

	public GImage maxIcon;

	public const string URL = "ui://47lbpgx9op6km";

	public static string Name = "UI_materialItem";

	public static string GetURL()
	{
		return "ui://47lbpgx9op6km";
	}

	public static UI_materialItem CreateInstance()
	{
		return (UI_materialItem)(object)UIPackage.CreateObject("Tips", "materialItem");
	}

	public static UI_materialItem CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_materialItem).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://47lbpgx9op6km", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Status = ((GComponent)this).GetController("Status");
		frame = (GLoader)((GComponent)this).GetChild("frame");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://47lbpgx9op6km".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
		num = (GTextField)((GComponent)this).GetChild("num");
		string id2 = "ui://47lbpgx9op6km".Replace("ui://", "") + "-" + ((GObject)num).id;
		((GObject)num).text = LanguagesManager.GetDesc(id2);
		maxIcon = (GImage)((GComponent)this).GetChild("maxIcon");
	}
}
