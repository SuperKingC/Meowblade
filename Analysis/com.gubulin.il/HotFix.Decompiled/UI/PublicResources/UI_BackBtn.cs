using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.PublicResources;

public class UI_BackBtn : GButton
{
	public Controller button;

	public Controller Status;

	public GImage icon;

	public GImage arrow;

	public GTextField title;

	public const string URL = "ui://kt6rg65on63w2v";

	public static string Name = "UI_BackBtn";

	public static string GetURL()
	{
		return "ui://kt6rg65on63w2v";
	}

	public static UI_BackBtn CreateInstance()
	{
		return (UI_BackBtn)(object)UIPackage.CreateObject("PublicResources", "BackBtn");
	}

	public static UI_BackBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_BackBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kt6rg65on63w2v", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Status = ((GComponent)this).GetController("Status");
		icon = (GImage)((GComponent)this).GetChild("icon");
		arrow = (GImage)((GComponent)this).GetChild("arrow");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://kt6rg65on63w2v".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
	}
}
