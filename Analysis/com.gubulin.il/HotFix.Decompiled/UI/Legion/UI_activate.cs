using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Legion;

public class UI_activate : GButton
{
	public Controller button;

	public GImage background;

	public GRichTextField title;

	public GLoader icon;

	public const string URL = "ui://lrhs6zw7obvz12";

	public static string Name = "UI_activate";

	public static string GetURL()
	{
		return "ui://lrhs6zw7obvz12";
	}

	public static UI_activate CreateInstance()
	{
		return (UI_activate)(object)UIPackage.CreateObject("Legion", "activate");
	}

	public static UI_activate CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_activate).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://lrhs6zw7obvz12", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		background = (GImage)((GComponent)this).GetChild("background");
		title = (GRichTextField)((GComponent)this).GetChild("title");
		string id = "ui://lrhs6zw7obvz12".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
		icon = (GLoader)((GComponent)this).GetChild("icon");
	}
}
