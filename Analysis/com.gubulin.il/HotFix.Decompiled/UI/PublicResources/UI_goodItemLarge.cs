using FairyGUI;
using FairyGUI.Utils;

namespace UI.PublicResources;

public class UI_goodItemLarge : GButton
{
	public Controller button;

	public Controller isLocked;

	public GLoader frame;

	public GLoader back;

	public GLoader icon;

	public GTextField title;

	public GTextField name;

	public GImage max;

	public const string URL = "ui://kt6rg65onwjtlg";

	public static string Name = "UI_goodItemLarge";

	public static string GetURL()
	{
		return "ui://kt6rg65onwjtlg";
	}

	public static UI_goodItemLarge CreateInstance()
	{
		return (UI_goodItemLarge)(object)UIPackage.CreateObject("PublicResources", "goodItemLarge");
	}

	public static UI_goodItemLarge CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_goodItemLarge).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kt6rg65onwjtlg", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		isLocked = ((GComponent)this).GetController("isLocked");
		frame = (GLoader)((GComponent)this).GetChild("frame");
		back = (GLoader)((GComponent)this).GetChild("back");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		title = (GTextField)((GComponent)this).GetChild("title");
		name = (GTextField)((GComponent)this).GetChild("name");
		max = (GImage)((GComponent)this).GetChild("max");
	}
}
