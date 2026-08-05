using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Collection;

public class UI_materialItem_foo : GButton
{
	public Controller button;

	public GLoader frame;

	public GLoader icon;

	public GTextField title;

	public GTextField num;

	public GImage selectedNote;

	public GTextField notFound;

	public GTextField notFoundNote;

	public GImage max;

	public GImage recruitmentMark;

	public const string URL = "ui://ehe4tm5zns7751";

	public static string Name = "UI_materialItem_foo";

	public static string GetURL()
	{
		return "ui://ehe4tm5zns7751";
	}

	public static UI_materialItem_foo CreateInstance()
	{
		return (UI_materialItem_foo)(object)UIPackage.CreateObject("Collection", "materialItem_foo");
	}

	public static UI_materialItem_foo CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_materialItem_foo).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://ehe4tm5zns7751", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Expected O, but got Unknown
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		frame = (GLoader)((GComponent)this).GetChild("frame");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://ehe4tm5zns7751".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
		num = (GTextField)((GComponent)this).GetChild("num");
		selectedNote = (GImage)((GComponent)this).GetChild("selectedNote");
		notFound = (GTextField)((GComponent)this).GetChild("notFound");
		string id2 = "ui://ehe4tm5zns7751".Replace("ui://", "") + "-" + ((GObject)notFound).id;
		((GObject)notFound).text = LanguagesManager.GetDesc(id2);
		notFoundNote = (GTextField)((GComponent)this).GetChild("notFoundNote");
		max = (GImage)((GComponent)this).GetChild("max");
		recruitmentMark = (GImage)((GComponent)this).GetChild("recruitmentMark");
	}
}
