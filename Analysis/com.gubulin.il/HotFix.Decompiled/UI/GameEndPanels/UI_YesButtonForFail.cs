using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GameEndPanels;

public class UI_YesButtonForFail : GButton
{
	public Controller button;

	public GImage bg;

	public GTextField title;

	public GLoader n5;

	public const string URL = "ui://hda5vzklimvh33";

	public static string Name = "UI_YesButtonForFail";

	public static string GetURL()
	{
		return "ui://hda5vzklimvh33";
	}

	public static UI_YesButtonForFail CreateInstance()
	{
		return (UI_YesButtonForFail)(object)UIPackage.CreateObject("GameEndPanels", "YesButtonForFail");
	}

	public static UI_YesButtonForFail CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_YesButtonForFail).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hda5vzklimvh33", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		bg = (GImage)((GComponent)this).GetChild("bg");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://hda5vzklimvh33".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
		n5 = (GLoader)((GComponent)this).GetChild("n5");
	}
}
