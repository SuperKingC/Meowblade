using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.PublicResources;

public class UI_goodItem : GButton
{
	public Controller button;

	public GLoader frame;

	public GLoader back;

	public GLoader icon;

	public GTextField title;

	public GTextField name;

	public const string URL = "ui://kt6rg65ol3sc16";

	public static string Name = "UI_goodItem";

	public static string GetURL()
	{
		return "ui://kt6rg65ol3sc16";
	}

	public static UI_goodItem CreateInstance()
	{
		return (UI_goodItem)(object)UIPackage.CreateObject("PublicResources", "goodItem");
	}

	public static UI_goodItem CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_goodItem).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kt6rg65ol3sc16", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		frame = (GLoader)((GComponent)this).GetChild("frame");
		back = (GLoader)((GComponent)this).GetChild("back");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://kt6rg65ol3sc16".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
		name = (GTextField)((GComponent)this).GetChild("name");
		string id2 = "ui://kt6rg65ol3sc16".Replace("ui://", "") + "-" + ((GObject)name).id;
		((GObject)name).text = LanguagesManager.GetDesc(id2);
	}
}
