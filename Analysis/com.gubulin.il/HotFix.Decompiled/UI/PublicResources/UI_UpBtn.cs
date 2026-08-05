using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.PublicResources;

public class UI_UpBtn : GButton
{
	public Controller button;

	public GImage back;

	public GTextField title;

	public GTextField level;

	public GImage redPoint;

	public const string URL = "ui://kt6rg65ol3scx";

	public static string Name = "UI_UpBtn";

	public static string GetURL()
	{
		return "ui://kt6rg65ol3scx";
	}

	public static UI_UpBtn CreateInstance()
	{
		return (UI_UpBtn)(object)UIPackage.CreateObject("PublicResources", "UpBtn");
	}

	public static UI_UpBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_UpBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kt6rg65ol3scx", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		button = ((GComponent)this).GetController("button");
		back = (GImage)((GComponent)this).GetChild("back");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://kt6rg65ol3scx".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
		level = (GTextField)((GComponent)this).GetChild("level");
		redPoint = (GImage)((GComponent)this).GetChild("redPoint");
	}
}
