using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.LordOfDreams;

public class UI_PageItem : GButton
{
	public Controller button;

	public GImage n4;

	public GTextField title;

	public const string URL = "ui://0i520nzmtajuo8u";

	public static string Name = "UI_PageItem";

	public static string GetURL()
	{
		return "ui://0i520nzmtajuo8u";
	}

	public static UI_PageItem CreateInstance()
	{
		return (UI_PageItem)(object)UIPackage.CreateObject("LordOfDreams", "PageItem");
	}

	public static UI_PageItem CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_PageItem).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://0i520nzmtajuo8u", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://0i520nzmtajuo8u".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
	}
}
